using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShopesms
{
    public partial class Form2 : Form
    {
        public static string MatirialName;
        public static decimal PriceIn, PriceOut, Profits;
        public static long MatirialBarcod;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text ==""|| txtPriceIn.Text == "" || txtPriceOut.Text == "" ||  cbMatirialName.Text == "")
            {
                MessageBox.Show("الرجاء تعبئة البيانات", "تنبيه");
                return;
            }
            else
            {
                MatirialBarcod = Convert.ToInt64(txtBarcode.Text);
                MatirialName = cbMatirialName.Text.Trim();
                PriceIn = Convert.ToDecimal(txtPriceIn.Text);
                PriceOut= Convert.ToDecimal(txtPriceOut.Text);
                //Profits = PriceOut- PriceIn;
                //txtProfits.Text = Profits.ToString();
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Matirails.Where(x => x.MatirialBarcode == MatirialBarcod && x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count==1)
                    {
                        foreach (var i in cn)
                        {
                            i.exDate = dt1.Value;
                            i.MatirialName = MatirialName;
                            i.Pricein = PriceIn;
                            i.PriceOut = PriceOut;                 
                            i.Shopid = Form5.ShopID;
                            i.UserName = Form5.UserName;
                            i.User_ID = Form5.UserID;
                            db.SaveChanges();
                            txtProfits.Text = i.Profit.ToString();
                        }
                    }
                    else
                    {
                        Matirails m = new Matirails();
                        m.MatirialBarcode = MatirialBarcod;
                        m.exDate = dt1.Value;
                        m.MatirialName = MatirialName;
                        m.Pricein = PriceIn;
                        m.PriceOut = PriceOut;
                        m.Shopid = Form5.ShopID;
                        m.UserName = Form5.UserName;
                        m.User_ID = Form5.UserID;
                        db.Matirails.Add(m);
                        db.SaveChanges();
                        txtProfits.Text = m.Profit.ToString();
                    }
               
                    MessageBox.Show("تم الحفظ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            GetMatirials();
        }
        private void GetMatirials()
        {
            try
            {          
                dbEntities db = new dbEntities();
                var cn = db.Matirails.ToList();
                cbMatirialName.ValueMember = "MatirialName";
                cbMatirialName.DataSource = cn.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "تنبيه");

            }
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                try
                {

                    if (txtBarcode.Text==""|| txtBarcode.Text == null)
                    {
                        return;
                    }
                    else
                    {
                        GetMatirialName();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);                   
                }
            }
        }
        private void GetMatirialName()
        {
            MatirialBarcod = Convert.ToInt64(txtBarcode.Text);
            dbEntities db = new dbEntities();
            var cn = db.Matirails.Where(x => x.MatirialBarcode == MatirialBarcod && x.Shopid == Form5.ShopID).ToList();
            if (cn.Count == 1)
            {
                foreach (var i in cn)
                {
                    cbMatirialName.Text = i.MatirialName;
                    txtPriceIn.Text = i.Pricein.ToString();
                    txtPriceOut.Text = i.PriceOut.ToString();
                    txtProfits.Text = i.Profit.ToString();
                    dt1.Value = i.exDate;
                   
                }
                txtPriceIn.Text = string.Format("{0:N}", Convert.ToDecimal(txtPriceIn.Text));
                txtPriceOut.Text = string.Format("{0:N}", Convert.ToDecimal(txtPriceOut.Text));
                txtProfits.Text = string.Format("{0:N}", Convert.ToDecimal(txtProfits.Text));
            }
            else
            {
                btnNew.PerformClick();
                txtBarcode.Text = MatirialBarcod.ToString();
                cbMatirialName.Focus();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد؟","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                try
                {
                    if (txtBarcode.Text == "" || txtBarcode.Text == null)
                    {
                        MessageBox.Show("قم بكتابة رقم الباركود والضغط على زر انتر", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        MatirialBarcod = Convert.ToInt64(txtBarcode.Text);
                        dbEntities db = new dbEntities();
                        var cn = db.Matirails.Where(x => x.MatirialBarcode == MatirialBarcod && x.Shopid == Form5.ShopID).ToList();
                        foreach (var i in cn)
                        {
                            db.Matirails.Remove(i);
                            db.SaveChanges();
                            btnNew.PerformClick();
                        }
                        MessageBox.Show("تم الحذف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }
        private void cbMatirialName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMatirialName.Text==""||cbMatirialName.Text==null)
            {
                MessageBox.Show("الرجاء قم باختيار اسم الصنف", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Matirails.Where(x => x.MatirialName == cbMatirialName.Text.Trim() && x.Shopid == Form5.ShopID).ToList();
                    foreach (var i in cn)
                    {
                        txtBarcode.Text = i.MatirialBarcode.ToString();
                        GetMatirialName();
                    }
                 
                    txtPriceIn.Text = string.Format("{0:N}", Convert.ToDecimal(txtPriceIn.Text));
                    txtPriceOut.Text = string.Format("{0:N}", Convert.ToDecimal(txtPriceOut.Text));
                    txtProfits.Text = string.Format("{0:N}", Convert.ToDecimal(txtProfits.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sorry");
                }
            }
        }
        private void cbMatirialName_DropDown(object sender, EventArgs e)
        {
          
        }
        private void cbMatirialName_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetMatirials();
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            
            txtBarcode.Text = txtPriceIn.Text = txtPriceOut.Text = txtProfits.Text = cbMatirialName.Text = "";
            dt1.Value = DateTime.Today;
            txtBarcode.Focus();            
        }
    }
}
