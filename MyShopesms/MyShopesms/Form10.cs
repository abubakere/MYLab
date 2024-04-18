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
    public partial class Form10 : Form
    {
        private long UserIdToCheck;
        private decimal TotalOfSales;
        private decimal TotalOfPayed;
        private decimal Balance;
        private string IdF;

        public Form10()
        {
            InitializeComponent();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            Get_Users();
        }
        private void Get_Users()
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.Users.ToList();
                cbUserNames.Items.Clear();
                foreach (var i in cn)
                {
                    cbUserNames.Items.Add(i.User_Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void clear()
        {
            txtBalance.Text = txtPayed.Text = cbUserNames.Text = "";
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void cbUserNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUserNames.Text==""||cbUserNames.Text==null)
            {
                return;
            }
            else
            {
                GetUserID();
                GetBalance();
                FillDG();
            }        
        }
        private void GetUserID()
        {
            dbEntities db = new dbEntities();
            var cn = db.Users.Where(x => x.User_Name == cbUserNames.Text.Trim()).ToList();
            if (cn.Count == 0)
            {
                MessageBox.Show("لاتوجد بيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBalance.Text = "0.000";
                return;
            }
            else
            {
                foreach (var i in cn)
                {
                    UserIdToCheck = i.User_ID;
                    lbUserid.Text = UserIdToCheck.ToString();
                }
            }

        }
        private void GetBalance()
        {
            dbEntities db = new dbEntities();
            try
            {
                //var cn = db.SalesInvoice.Where(x => x.User_ID == UserIdToCheck).ToList();
                var cn = db.SalesSum(Form5.ShopID, UserIdToCheck).ToList();
                // =================If There Is No Sales
                if (cn.Count == 0)
                {
                    TotalOfSales = 0;
                }
                // =========If There is Sales
                if (cn.Count > 0)
                {
                    //==============We Sum The Sales
                    TotalOfSales = Convert.ToDecimal(cn.Sum(x => x.Value));
                    //==After that we CHEK the Payment
                    var UT = db.UserPayment.Where(x => x.UserId == UserIdToCheck).ToList();
                    //==If there is No Payment
                    if (UT.Count == 0)
                    {
                        TotalOfPayed = 0;
                        Balance = TotalOfSales - TotalOfPayed;
                        txtBalance.Text = Balance.ToString();
                    }
                    //If There is Payment 
                    else
                    {
                        TotalOfPayed = UT.Sum(x => x.Ammount);
                        Balance = TotalOfSales - TotalOfPayed;
                        txtBalance.Text = Balance.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtPayed.Text=="" || txtPayed.Text ==null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    UserPayment a = new UserPayment();
                    a.Ammount = Convert.ToDecimal(txtPayed.Text);
                    a.Ddate = DateTime.Today;
                    a.ShopId = Form5.ShopID;
                    a.UserId = UserIdToCheck;
                    a.UserName = cbUserNames.Text.Trim();
                    db.UserPayment.Add(a);
                    db.SaveChanges();
                    FillDG();
                    txtPayed.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Sory");
                    throw;
                }
            }
        }
        private void FillDG()
        {
            try
            {
                dbEntities db = new dbEntities();
                userPaymentBindingSource.DataSource = db.UserPayment.Where(x => x.UserId == UserIdToCheck).ToList();
                GetBalance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");
            }
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow a = dataGridView1.Rows[e.RowIndex];
                 IdF = a.Cells["iDDataGridViewTextBoxColumn"].Value.ToString();
                txtPayed.Text = a.Cells["ammountDataGridViewTextBoxColumn"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sory");
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد ؟","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {

                try
                {
                    dbEntities db = new dbEntities();
                    Int64 idde = Convert.ToInt64(IdF);
                    var cn = db.UserPayment.Where(x => x.ID == idde).ToList();
                    if (cn.Count == 1)
                    {
                        foreach (var i in cn)
                        {
                            db.UserPayment.Remove(i);
                            db.SaveChanges();
                        }
                        FillDG();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erorr");
                }
                
            }
        }
    }
}
