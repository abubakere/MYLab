using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace MyShopesms
{
    public partial class Form11 : Form
    {
        public static int KeyCheckW;
        public static Int64 Barcod;
        public static decimal PriceIn, PriceOut, Profit, Quantity;
        private long invoiceNo;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        //==========================

        public Form11()
        {
            InitializeComponent();
        }
        private void Form11_Load(object sender, EventArgs e)
        {
           
           
            Get_Matirial_Names();

            if (Form5.UserID == 3)
            {
                الاصنافToolStripMenuItem.Enabled = true;
                المشترياتToolStripMenuItem.Enabled = true;
                المستخدمونToolStripMenuItem.Enabled = true;
                المحدوفاتوالتعديلاتToolStripMenuItem.Enabled = true;
                تقريرالمشترياتToolStripMenuItem.Enabled = true;
                تقريرالمبيعاتToolStripMenuItem.Enabled = true;
                تقريررأسالمالToolStripMenuItem.Enabled = true;
                صناديقالمستخدمينToolStripMenuItem.Enabled = true;
            }
            btnNew.PerformClick();
        }
        private void Get_Matirial_Names()
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
        void clear()
        {
            txtBarcode.Text = txtInvoiceNo.Text = txtPrice.Text = txtQuantity.Text = txtTotal.Text = cbMatirialName.Text = "";
        }
        private void GetByBarCod()
        {
            if (txtBarcode.Text == "" || txtBarcode.Text == null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    Barcod = Convert.ToInt64(txtBarcode.Text);
                    var cn = db.Matirails.Where(x => x.MatirialBarcode == Barcod && x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count == 1)
                    {
                        foreach (var i in cn)
                        {
                            cbMatirialName.Text = i.MatirialName.Trim();
                            PriceIn = i.Pricein;
                            PriceOut = i.PriceOut;
                            Profit =Convert.ToDecimal(i.Profit);
                            Quantity = 1;
                            txtPrice.Text = PriceOut.ToString();
                            txtQuantity.Text = Quantity.ToString();
                            txtTotal.Text = (Quantity * PriceOut).ToString();
                            txtBarcode.Text = "";
                            txtPrice.Text = string.Format("{0:N2}", Convert.ToDecimal(txtPrice.Text));
                            txtQuantity.Text = string.Format("{0:N2}", Convert.ToDecimal(txtQuantity.Text));
                            txtTotal.Text = string.Format("{0:N2}", Convert.ToDecimal(txtTotal.Text));
                        }
                        checkInvoice();
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات", "نأسف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBarcode.Text  = txtPrice.Text = txtQuantity.Text = txtTotal.Text = cbMatirialName.Text = "";
                     
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory    .");
                    throw;
                }
            }
        }
        private void checkInvoice()
        {
            if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
            {
                InsertInvoiceNo();
            }
            else
            {
                invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                UpdateInvoiceNo();
            }
        }
        private void InsertInvoiceNo()
        {
            try
            {
                dbEntities db = new dbEntities();
                //var cn = db.SalesInvoice.Where(x=>x.Shopid == Form5.ShopID).ToList();
                
                var cn = db.MaxInvoice2(Form5.ShopID).ToList();
               
                if (cn.Count == 0)
                {
                    invoiceNo = 1;
                }
                else
                {
                    var nn = db.MaxInvoice2(Form5.ShopID).ToList();
                   foreach (var r in nn)
                    {
                        invoiceNo = r.Value;
                        invoiceNo = invoiceNo + 1;
                    }
                    

                }
                txtInvoiceNo.Text = invoiceNo.ToString();
                SalesInvoice sl = new SalesInvoice();
                if (rdcash.Checked == true)
                {
                    sl.CashOrCredit = 1;
                }
                else
                {
                    sl.CashOrCredit = 2;
                }
                sl.Ddate = DateTime.Today;
                sl.InvoiceNo = invoiceNo;
                sl.MatiralBarcode = Barcod;
                sl.MatiralName = cbMatirialName.Text.Trim();
                sl.Price = PriceOut;
                sl.Profit_One_Item = Profit;
                sl.Quantity = Quantity;
                sl.Shopid = Form5.ShopID;
                sl.UserName = Form5.UserName;
                sl.User_ID = Form5.UserID;
                db.SalesInvoice.Add(sl);
                db.SaveChanges();
                invoice_Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory... ");
            }
        }
        private void UpdateInvoiceNo()
        {
            dbEntities db = new dbEntities();
            //1=============================================================== بحت عن صنف في فاتورة موجودة
            try
            {
                //Barcod = Convert.ToInt64(txtBarcode.Text);
                var cn = db.SalesInvoice.Where(x => x.MatiralBarcode == Barcod && x.InvoiceNo == invoiceNo && x.Shopid == Form5.ShopID).ToList();


                if (cn.Count == 0)
                {
                    //2=============================================================== اضافة صنف جديد في فاتورة موجودة
                    InsertNewMatirialToExistedInvoice();

                }
                if (cn.Count > 0)
                {
                    //3===============================================================تعديل صنف موجود في فاتورة موجودة        
                    UpdateMatirialToExistedInvoice();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "sory");
            }


        }
        private void InsertNewMatirialToExistedInvoice()
        {
            try
            {
                dbEntities db = new dbEntities();
                SalesInvoice sl = new SalesInvoice();
                if (rdcash.Checked == true)
                {
                    sl.CashOrCredit = 1;
                }
                else
                {
                    sl.CashOrCredit = 2;
                }
                sl.MatiralBarcode = Barcod;
                sl.InvoiceNo = invoiceNo;
                sl.MatiralName = cbMatirialName.Text.Trim();
                sl.Price = PriceOut;
                sl.Profit_One_Item = Profit;
                sl.Quantity = Quantity;
                sl.Shopid = Form5.ShopID;
                sl.User_ID = Form5.UserID;
                sl.UserName = Form5.UserName;
                sl.Ddate = DateTime.Today;
                db.SalesInvoice.Add(sl);
                db.SaveChanges();
                invoice_Total();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void UpdateMatirialToExistedInvoice()
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.SalesInvoice.Where(x => x.MatiralBarcode == Barcod && x.InvoiceNo == invoiceNo && x.Shopid == Form5.ShopID).ToList();
                foreach (var i in cn)
                {
                    Quantity = i.Quantity + 1;
                    i.Quantity = Quantity;
                    db.SaveChanges();
                    txtQuantity.Text = Quantity.ToString();
                    txtTotal.Text = i.Total_.ToString();
                }
                txtPrice.Text = string.Format("{0:N}", Convert.ToDecimal(txtPrice.Text));
                txtQuantity.Text = string.Format("{0:N}", Convert.ToDecimal(txtQuantity.Text));
                txtTotal.Text = string.Format("{0:N}", Convert.ToDecimal(txtTotal.Text));
                invoice_Total();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void UpdateMatirialToExistedInvoice2()
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.SalesInvoice.Where(x => x.MatiralBarcode == Barcod && x.InvoiceNo == invoiceNo && x.Shopid == Form5.ShopID).ToList();
                Quantity = Convert.ToDecimal(txtQuantity.Text);
                
                foreach (var i in cn)
                {                   
                    i.Quantity = Quantity;
                    db.SaveChanges();
                    txtQuantity.Text = Quantity.ToString();
                    txtTotal.Text = i.Total_.ToString();
                }
                txtPrice.Text = string.Format("{0:N}", Convert.ToDecimal(txtPrice.Text));
                txtQuantity.Text = string.Format("{0:N}", Convert.ToDecimal(txtQuantity.Text));
                txtTotal.Text = string.Format("{0:N}", Convert.ToDecimal(txtTotal.Text));
                //=====================================Procedures
                Procedures p = new Procedures();
                p.Ammount = Convert.ToDecimal(txtTotal.Text);
                p.ddate = DateTime.Today;
                p.InvoiceNo = invoiceNo;
                p.Procedure_type = "تعديل كمية صنف في فاتورة مبيعات";
                p.ShopId = Form5.ShopID;
                p.User_Id = Form5.UserID;
                p.User_Name = Form5.UserName;
                db.Procedures.Add(p);
                db.SaveChanges();
                invoice_Total();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void invoice_Total()
        {
            if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                    lbInvoiceTotal.Text = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo && x.Shopid == Form5.ShopID).Sum(x => x.Total_).ToString();
                    lbInvoiceTotal.Text = string.Format("{0:N}", Convert.ToDecimal(lbInvoiceTotal.Text));
                    var cn = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo && x.Shopid == Form5.ShopID).ToList();
                    salesInvoiceBindingSource.DataSource = cn.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private void GetMyInvoiceDeteals()
        {
            if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
            {
                return;
            }
            else
            {
                dbEntities db = new dbEntities();
                invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                var cn = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo && x.Shopid == Form5.ShopID).ToList();
                salesInvoiceBindingSource.DataSource = cn.ToList();
                if (cn.Count > 0)
                {
                    foreach (var i in cn)
                    {
                        cbMatirialName.Text = i.MatiralName;
                        txtBarcode.Text = i.MatiralBarcode.ToString();
                        txtPrice.Text = i.Price.ToString();
                        txtQuantity.Text = i.Quantity.ToString();
                        txtTotal.Text = i.Total_.ToString();

                        if (i.CashOrCredit == 1)
                        {
                            rdcash.PerformClick();
                        }
                        if (i.CashOrCredit == 2)
                        {
                            rdbank.PerformClick();
                        }
                        txtPrice.Text = string.Format("{0:N}", Convert.ToDecimal(txtPrice.Text));
                        txtQuantity.Text = string.Format("{0:N}", Convert.ToDecimal(txtQuantity.Text));
                        txtTotal.Text = string.Format("{0:N}", Convert.ToDecimal(txtTotal.Text));
                    }
                    invoice_Total();
                }
                else
                {
                    btnNew.PerformClick();
                }

            }
        }
        private void المستخدمونToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Form3 frm = new Form3();
            frm.Show();
        }
        private void المشترياتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }
        private void الاصنافToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
        private void المحدوفاتوالتعديلاتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
        }
        private void Form11_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "1";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "1";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "1";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "1";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "2";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "2";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "2";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "2";
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "3";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "3";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "3";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "3";
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "6";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "6";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "6";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "6";
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "5";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "5";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "5";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "5";
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "4";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "4";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "4";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "4";
                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "9";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "9";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "9";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "9";
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "8";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "8";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "8";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "8";
                }
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "7";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "7";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "7";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "7";
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = "0";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + "0";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = "0";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + "0";
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                txtQuantity.Text = "";
            }
            else
            {
                txtBarcode.Text = "";
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                if (txtQuantity.Text == "" || txtQuantity.Text == null)
                {
                    txtQuantity.Text = ".";
                }
                else
                {
                    txtQuantity.Text = txtQuantity.Text + ".";
                }
            }
            else
            {
                if (txtBarcode.Text == "" || txtBarcode.Text == null)
                {
                    txtBarcode.Text = ".";
                }
                else
                {
                    txtBarcode.Text = txtBarcode.Text + ".";
                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            txtQuantity.Focus();
            KeyCheckW = 1;
            txtQuantity.Text = "";
        }
        private void button14_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            txtBarcode.Text = "";
            KeyCheckW = 2;
        }
        private void button15_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد؟", "sory", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
                {
                    MessageBox.Show("قم بكتابة رقم فاتورة لحذفها", "sory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    try
                    {
                        invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                        dbEntities db = new dbEntities();
                        var cn = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo).ToList();

                        //=====================================Procedures
                        Procedures p = new Procedures();
                        p.Ammount = Convert.ToDecimal(lbInvoiceTotal.Text);
                        p.ddate = DateTime.Today;
                        p.InvoiceNo = invoiceNo;
                        p.Procedure_type = "حذف فاتورة مبيعات بالكامل";
                        p.ShopId = Form5.ShopID;
                        p.User_Id = Form5.UserID;
                        p.User_Name = Form5.UserName;
                        db.Procedures.Add(p);

                        foreach (var i in cn)
                        {
                            db.SalesInvoice.Remove(i);
                            db.SaveChanges();
                        }
                        btnNew.PerformClick();
                        //invoice_Total();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }
        private void button16_Click(object sender, EventArgs e)
        {
            if (KeyCheckW == 1)
            {
                //الكمية
                UpdateMatirialToExistedInvoice2();
            }
            else
            {
                //الباركود

                GetByBarCod();
            }
            txtBarcode.Focus();
        }
        private void button17_Click(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            txtBarcode.Text = txtPrice.Text = txtQuantity.Text = txtTotal.Text = cbMatirialName.Text = "";
            invoice_Total();
        }
        private void button18_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
            {
                return;
            }
            else
            {
                invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                dbEntities db = new dbEntities();
                var cn = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo).ToList();

                if (rdcash.Checked == true)
                {
                    foreach (var i in cn)
                    {
                        i.CashOrCredit = 1;
                        db.SaveChanges();
                    }
                }
                if (rdbank.Checked == true)
                {
                    foreach (var i in cn)
                    {
                        i.CashOrCredit = 2;
                        db.SaveChanges();
                    }
                }
                //=====================================Procedures
                Procedures p = new Procedures();
                p.Ammount = Convert.ToDecimal(lbInvoiceTotal.Text);
                p.ddate = DateTime.Today;
                p.InvoiceNo = invoiceNo;
                p.Procedure_type = "تعديل نوع السداد فاتورة مبيعات";
                p.ShopId = Form5.ShopID;
                p.User_Id = Form5.UserID;
                p.User_Name = Form5.UserName;
                db.Procedures.Add(p);
                db.SaveChanges();
            }
        }
        private void button19_Click(object sender, EventArgs e)
        {
            if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
            {
                MessageBox.Show("قم بكتابة رقم فاتورة لحذفها", "sory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                try
                {
                    invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                    Barcod = Convert.ToInt64(txtBarcode.Text);
                    dbEntities db = new dbEntities();
                    var cn = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo && x.MatiralBarcode == Barcod).ToList();
                    if (MessageBox.Show("هل انت متأكد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (var i in cn)
                        {
                            db.SalesInvoice.Remove(i);
                            db.SaveChanges();
                        }
                        //=====================================Procedures
                        Procedures p = new Procedures();
                        p.Ammount = Convert.ToDecimal(txtTotal.Text);
                        p.ddate = DateTime.Today;
                        p.InvoiceNo = invoiceNo;
                        p.Procedure_type = " حدف صنف من فاتورة مبيعات";
                        p.ShopId = Form5.ShopID;
                        p.User_Id = Form5.UserID;
                        p.User_Name = Form5.UserName;
                        db.Procedures.Add(p);
                        db.SaveChanges();

                        var cn2 = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo).ToList();
                        if (cn2.Count > 0)
                        {
                            button17.PerformClick();
                        }
                        if (cn2.Count == 0)
                        {
                            btnNew.PerformClick();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sory");
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetMyInvoiceDeteals();
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
            rdcash.PerformClick();
            button14.PerformClick();
            lbInvoiceTotal.Text = "0.00";

            salesInvoiceBindingSource.DataSource = null;
        }
        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetByBarCod();
            }
        }
        private void cbMatirialName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMatirialName.Text == "" || cbMatirialName.Text == null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Matirails.Where(x => x.MatirialName == cbMatirialName.Text.Trim()&& x.Shopid == Form5.ShopID).ToList();
                    if (cn.Count == 1)
                    {
                        foreach (var i in cn)
                        {


                            Barcod = i.MatirialBarcode;
                            PriceIn = i.Pricein;
                            PriceOut = i.PriceOut;
                            Profit = Convert.ToDecimal(i.Profit);
                            Quantity = 1;
                            txtBarcode.Text = Barcod.ToString();
                            txtPrice.Text = PriceOut.ToString();
                            txtQuantity.Text = Quantity.ToString();
                            txtTotal.Text = (Quantity * PriceOut).ToString();
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات", "نأسف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clear();
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory    .");
                    throw;
                }
            }
        }
        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow a = dataGridView1.Rows[e.RowIndex];
                txtBarcode.Text = a.Cells["dataGridViewTextBoxColumn17"].Value.ToString();
                cbMatirialName.Text = a.Cells["dataGridViewTextBoxColumn18"].Value.ToString();
                txtQuantity.Text = a.Cells["dataGridViewTextBoxColumn19"].Value.ToString();
                txtPrice.Text = a.Cells["dataGridViewTextBoxColumn20"].Value.ToString();
                txtTotal.Text = a.Cells["dataGridViewTextBoxColumn21"].Value.ToString();
                txtPrice.Text = string.Format("{0:N}", Convert.ToDecimal(txtPrice.Text));
                txtQuantity.Text = string.Format("{0:N}", Convert.ToDecimal(txtQuantity.Text));
                txtTotal.Text = string.Format("{0:N}", Convert.ToDecimal(txtTotal.Text));
                string cashmoney;
                cashmoney = a.Cells["dataGridViewTextBoxColumn28"].Value.ToString();
                if (cashmoney == "1")
                {
                    rdcash.PerformClick();
                }
                if (cashmoney == "2")
                {
                    rdbank.PerformClick();
                }
                Barcod = Convert.ToInt64(txtBarcode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sory");
            }
        }
        private void صناديقالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                dbEntities db = new dbEntities();
                string cn = db.SalesInvoice.Where(x => x.Shopid == Form5.ShopID).Max(x => x.InvoiceNo).ToString();
                txtInvoiceNo.Text = cn;
                GetMyInvoiceDeteals();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtInvoiceNo.Text = "1";
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            Int64 invooo;
            if (txtInvoiceNo.Text==""||txtInvoiceNo.Text==null)
            {
                return;
            }
            else
            {
                invooo = Convert.ToInt64(txtInvoiceNo.Text);
                invooo = invooo - 1;
                txtInvoiceNo.Text = invooo.ToString();
                GetMyInvoiceDeteals();
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            Int64 invooo;
            if (txtInvoiceNo.Text == "" || txtInvoiceNo.Text == null)
            {
                return;
            }
            else
            {
                invooo = Convert.ToInt64(txtInvoiceNo.Text);
                invooo = invooo + 1;
                txtInvoiceNo.Text = invooo.ToString();
                GetMyInvoiceDeteals();
            }
        }
        private void cbMatirialName_MouseClick(object sender, MouseEventArgs e)
        {
            //Get_Matirial_Names();
        }
        private void button23_Click(object sender, EventArgs e)
        {
            //Forme1 frm = new Forme1();
            //Forme1.InvoiceNo = invoiceNo;
            //frm.ShowDialog();
            try
            {
                invoiceNo = Convert.ToInt64(txtInvoiceNo.Text);
                dbEntities db = new dbEntities();
                var cn = db.SalesInvoice.Where(x => x.InvoiceNo == invoiceNo).ToList();
                LocalReport report = new LocalReport();
                string path = Path.GetDirectoryName(Application.ExecutablePath);
                string FullPath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\RptInvoice.rdlc";
                report.ReportPath = FullPath;
                report.DataSources.Add(new ReportDataSource("DataSet1", cn));
                PrintToPrinter(report);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }         
        }
        private void cbMatirialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button16.PerformClick();
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {

        }
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {

                cbMatirialName.SelectedIndex = cbMatirialName.SelectedIndex - 1;
                txtBarcode.Focus();
                KeyCheckW = 2;
            }
            catch (Exception)
            {

                cbMatirialName.SelectedIndex = 0;
            }
        }
        private void button24_Click_1(object sender, EventArgs e)
        {
            try
            {

                cbMatirialName.SelectedIndex = cbMatirialName.SelectedIndex + 1;
                txtBarcode.Focus();
                KeyCheckW = 2;
            }
            catch (Exception)
            {

                cbMatirialName.SelectedIndex = 0;
            }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            Get_Matirial_Names();
        }
        private void تقريرالمشترياتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
        }
        private void تقريرالمبيعاتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form8 frm = new Form8();
            frm.Show();
        }
        private void تقريررأسالمالToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            Form9 frm = new Form9();
            frm.Show();
        }
        //========================================================
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);

        }
        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.5in</PageWidth>
                <PageHeight>8.3in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }
        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        private void الاصنافمنتهيةالصلاحيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FEXmatirials frm = new FEXmatirials();
            frm.Show();
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
    }
}
