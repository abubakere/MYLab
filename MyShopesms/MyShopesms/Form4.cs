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
    public partial class Form4 : Form
    {
        private long BarCode;
        private long InvoiceNo;
        private decimal PriceIn;
        private decimal PriceOut;
        private decimal Quantity;

        public Form4()
        {
            InitializeComponent();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            buingInvoiceBindingSource.DataSource = null;
            lbTotalOfInvoice.Text = "0.00";
        }
        private void Clear()
        {
            txtBarcode.Text = txtInvoiceNo.Text = txtPriceIn.Text = txtPriceOut.Text = txtQuantity.Text = cbMatirialName.Text = "";
            txtBarcode.Focus();
        }
        private void GetListOfMatirials()
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

                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            GetListOfMatirials();
        }
        private void cbMatirialName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMatirialName.Text==""|| cbMatirialName.Text==null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Matirails.Where(x => x.MatirialName == cbMatirialName.Text.Trim() && x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count==1)
                    {
                        foreach (var i in cn)
                        {
                            txtBarcode.Text = i.MatirialBarcode.ToString();
                            txtPriceIn.Text = i.Pricein.ToString();
                            txtPriceOut.Text = i.PriceOut.ToString();
                        }
                    }
                    else
                    {
                        txtBarcode.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory.");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            txtBarcode.Text = txtPriceIn.Text = txtPriceOut.Text = txtQuantity.Text = cbMatirialName.Text = "";
            txtBarcode.Focus();
        }
        private void GetMatiralByCode()
        {
            if (txtBarcode.Text==""||txtBarcode.Text==null)
            {
                return;
            }
            else
            {
                BarCode = Convert.ToInt64(txtBarcode.Text);
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Matirails.Where(x => x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count==0)
                    {
                        btnAddNewMatirial.PerformClick();
                    }
                    else
                    {
                        foreach (var i in cn)
                        {
                            cbMatirialName.Text = i.MatirialName;
                            txtPriceIn.Text = i.Pricein.ToString();
                            txtPriceOut.Text = i.PriceOut.ToString();
                        }
                        txtQuantity.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                GetMatiralByCode();
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPriceIn.Focus();
            }
        }
        private void txtPriceIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               txtPriceOut.Focus();
            }
        }
        private void txtPriceOut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            dbEntities db = new dbEntities();
            if (txtBarcode.Text == "" || txtPriceIn.Text == "" || txtPriceOut.Text == "" || txtQuantity.Text == "" || cbMatirialName.Text == "")
            {
                return;
            }
            //======================================== convert values to....
            BarCode = Convert.ToInt64(txtBarcode.Text);
            PriceIn = Convert.ToDecimal(txtPriceIn.Text);
            PriceOut = Convert.ToDecimal(txtPriceOut.Text);
            Quantity = Convert.ToDecimal(txtQuantity.Text);
            if (txtInvoiceNo.Text==""||txtInvoiceNo.Text==null)
            {
                try
                {
                    var cn = db.BuingInvoice.Where(x=>x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count==0)
                    {
                        txtInvoiceNo.Text = "1";
                        InvoiceNo = 1;
                    }
                    else
                    {
                        InvoiceNo = cn.Max(x => x.InvoiceNo + 1);
                        txtInvoiceNo.Text = InvoiceNo.ToString();
                    }
                    //==========================================Insert New Item To New Invoice
                    
                    BuingInvoice a = new BuingInvoice();
                    a.exDate = dt1.Value;
                    a.InvoiceNo = InvoiceNo;
                    a.MatirialBarcode = BarCode;
                    a.MatirialName = cbMatirialName.Text.Trim();
                    a.Pricein = PriceIn;
                    a.PriceOut = PriceOut;
                    a.Quantity = Quantity;
                    a.Shopid = Form5.ShopID;
                    a.UserName = Form5.UserName;
                    a.User_Id = Form5.UserID;
                    a.Ddate = DateTime.Today;
                    db.BuingInvoice.Add(a);
                    db.SaveChanges();
                    txtInvoiceNo.Text = a.InvoiceNo.ToString();
                    //================================================= Update The Price On The Matirial Table  ================
                    var UpdatePrice = db.Matirails.Where(x => x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();
                    foreach (var PR in UpdatePrice)
                    {
                        PR.Pricein = PriceIn;
                        PR.PriceOut = PriceOut;
                        PR.exDate = dt1.Value;
                        db.SaveChanges();
                    }
                    //===========================================================================================================
                    FillDG();
                    GetInvoiceTotal();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory...");
                }
            }
            else
            {
                try
                {
                    //=========================check item else Case 
                    InvoiceNo =Convert.ToInt64(txtInvoiceNo.Text);
                    var cnn = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();

                    //=========================drop new item
                    if (cnn.Count==0)
                    {                       
                        BuingInvoice a = new BuingInvoice();
                        a.exDate = dt1.Value;
                        a.InvoiceNo = InvoiceNo;
                        a.MatirialBarcode = BarCode;
                        a.MatirialName = cbMatirialName.Text.Trim();
                        a.Pricein = PriceIn;
                        a.PriceOut = PriceOut;
                        a.Quantity = Quantity;
                        a.Shopid = Form5.ShopID;
                        a.UserName = Form5.UserName;
                        a.User_Id = Form5.UserID;
                        a.Ddate = DateTime.Today;
                        db.BuingInvoice.Add(a);
                        db.SaveChanges();
                        //================================================= Update The Price On The Matirial Table  ================
                        var UpdatePrice = db.Matirails.Where(x => x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();
                        foreach (var PR in UpdatePrice)
                        {
                            PR.Pricein = PriceIn;
                            PR.PriceOut = PriceOut;
                            PR.exDate = dt1.Value;
                            db.SaveChanges();
                        }
                        //===========================================================================================================
                        FillDG();
                        GetInvoiceTotal();
                    }

                    //=========================Update existed item
                    else
                    {                      
                        var cni = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();
                        if (cni.Count==1)
                        {
                            foreach (var ii in cni)
                            {
                                ii.Quantity = Quantity;
                                ii.Pricein = PriceIn;
                                ii.PriceOut = PriceOut;
                                db.SaveChanges();
                                //=====================================Procedures
                                Procedures p = new Procedures();
                                p.Ammount =Convert.ToDecimal( ii.Total);
                                p.ddate = DateTime.Today;
                                p.InvoiceNo = InvoiceNo;
                                p.Procedure_type = "تعديل كمية صنف بفاتورة مشتريات";
                                p.ShopId = Form5.ShopID;
                                p.User_Id = Form5.UserID;
                                p.User_Name = Form5.UserName;
                                db.Procedures.Add(p);
                                db.SaveChanges();
                            }
                            //================================================= Update The Price On The Matirial Table  ================
                            var UpdatePrice = db.Matirails.Where(x => x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();
                            foreach (var PR in UpdatePrice)
                            {
                                PR.Pricein = PriceIn;
                                PR.PriceOut = PriceOut;
                                PR.exDate = dt1.Value;
                                db.SaveChanges();
                            }
                            //===========================================================================================================

                            FillDG();
                            GetInvoiceTotal();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory");
                }
            }
            btnAddNewMatirial.Focus();
        }
        private void FillDG()
        {
            dbEntities db = new dbEntities();
            try
            {
                buingInvoiceBindingSource.DataSource = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.Shopid == Form5.ShopID).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "soory   .");
            }
            
        }
        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(Char)Keys.Enter)
            {
                if (txtInvoiceNo.Text==""||txtInvoiceNo.Text==null)
                {
                    return;
                }
                else
                {
                    dbEntities db = new dbEntities();
                    InvoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                    var cn = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count==0)
                    {
                        btnNew.PerformClick();
                    }
                    else
                    {
                        foreach (var i in cn)
                        {
                            txtBarcode.Text = i.MatirialBarcode.ToString();
                            cbMatirialName.Text = i.MatirialName;
                            txtInvoiceNo.Text = i.InvoiceNo.ToString();
                            txtPriceIn.Text = i.Pricein.ToString();
                            txtPriceOut.Text = i.PriceOut.ToString();
                            txtQuantity.Text = i.Quantity.ToString();
                        }
                    }
                    FillDG();
                }
             
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow a = dataGridView1.Rows[e.RowIndex];
            txtBarcode.Text = a.Cells["matirialBarcodeDataGridViewTextBoxColumn"].Value.ToString();
            cbMatirialName.Text = a.Cells["matirialNameDataGridViewTextBoxColumn"].Value.ToString();
            txtQuantity.Text = a.Cells["quantityDataGridViewTextBoxColumn"].Value.ToString();
            txtPriceIn.Text = a.Cells["priceinDataGridViewTextBoxColumn"].Value.ToString();
            txtPriceOut.Text = a.Cells["priceOutDataGridViewTextBoxColumn"].Value.ToString();
            dt1.Value = (DateTime)a.Cells["exDateDataGridViewTextBoxColumn"].Value;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text==""||txtInvoiceNo.Text==null||txtBarcode.Text=="" || txtBarcode.Text == null)
            {
                return;
            }
            else
            {
                dbEntities db = new dbEntities();
                if (MessageBox.Show("هل أنت متأكد؟","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    try
                    {

                        InvoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                        BarCode = Convert.ToInt64(txtBarcode.Text);
                        var cn = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.MatirialBarcode == BarCode && x.Shopid == Form5.ShopID).ToList();
                        if (cn.Count == 0)
                        {
                            MessageBox.Show("لاتوجد بيانات", "نأسف", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            foreach (var i in cn)
                            {
                                db.BuingInvoice.Remove(i);
                                db.SaveChanges();
                            }
                            //=====================================Procedures
                            Procedures p = new Procedures();
                            p.Ammount = Convert.ToDecimal(lbTotalOfInvoice.Text);
                            p.ddate = DateTime.Today;
                            p.InvoiceNo = InvoiceNo ;
                            p.Procedure_type = "حدف صنف بفاتورة مشتريات";
                            p.ShopId = Form5.ShopID;
                            p.User_Id = Form5.UserID;
                            p.User_Name = Form5.UserName;
                            db.Procedures.Add(p);
                            db.SaveChanges();
                            GetInvoiceTotal();
                            var cwn = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.Shopid == Form5.ShopID).ToList();
                            if (cwn.Count == 0)
                            {
                                btnNew.PerformClick();
                            }
                            else
                            {
                                FillDG();
                                btnAddNewMatirial.PerformClick();
                            }
                      
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "sory");
                    }
                }
              
            }
        }
        private void GetInvoiceTotal()
        {
            if (txtInvoiceNo.Text==""||txtInvoiceNo.Text==null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    InvoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                    var cn = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count==0)
                    {
                        lbTotalOfInvoice.Text = "0.00";
                        lbTotalOfInvoice.Text = string.Format("{0:N}", Convert.ToDecimal(lbTotalOfInvoice.Text));
                    }
                    else
                    {
                        lbTotalOfInvoice.Text = cn.Sum(x => x.Total).ToString();
                        lbTotalOfInvoice.Text = string.Format("{0:N}", Convert.ToDecimal(lbTotalOfInvoice.Text));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory");
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد ؟","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (txtInvoiceNo.Text==""||txtInvoiceNo.Text==null)
                {
                    return;
                }
                else
                {
                    dbEntities db = new dbEntities();
                    var cn = db.BuingInvoice.Where(x => x.InvoiceNo == InvoiceNo && x.Shopid == Form5.ShopID).ToList();
                    foreach (var i in cn)
                    {
                        db.BuingInvoice.Remove(i);
                        db.SaveChanges();
                    }
                    //=====================================Procedures
                    Procedures p = new Procedures();
                    p.Ammount = Convert.ToDecimal(lbTotalOfInvoice.Text);
                    p.ddate = DateTime.Today;
                    p.InvoiceNo = InvoiceNo;
                    p.Procedure_type = "حذف فاتورة مشتريات بالكامل";
                    p.ShopId = Form5.ShopID;
                    p.User_Id = Form5.UserID;
                    p.User_Name = Form5.UserName;
                    db.Procedures.Add(p);
                    db.SaveChanges();
                    btnNew.PerformClick();
                }
            }
        }
        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }
        private void cbMatirialName_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
