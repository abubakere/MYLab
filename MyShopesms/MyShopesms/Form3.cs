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
    public partial class Form3 : Form
    {
        private long UserId;

        public Form3()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPassword.Text = cbShops.Text = cbUserNames.Text = "";
            txtUserId.Text = "0";
            cbUserNames.Focus();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            GetShops();
            Get_Users();
        }
        private void GetShops()
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.Shops.ToList();
                cbShops.Items.Clear();
                foreach (var i in cn)
                {
                    cbShops.Items.Add(i.Shopname);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void Get_Users()
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.Users.ToList();
                cbUserNames.Items.Clear();
                foreach (var i in  cn)
                {
                    cbUserNames.Items.Add(i.User_Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void cbShops_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbShops.Text==""|| cbShops.Text==null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Shops.Where(x => x.Shopname == cbShops.Text).ToList();
                    txtShopID.Text = "";
                    foreach (var i in cn)
                    {
                        txtShopID.Text = i.Shopid.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد من انك تريد اضافة محل مبيعات جديد؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (cbShops.Text == "" || cbShops.Text == null)
                {
                    return;
                }
                else
                {
                    try
                    {
                        dbEntities db = new dbEntities();
                        var cn = db.Shops.Where(x => x.Shopname == cbShops.Text).ToList();
                        txtShopID.Text = "";
                        foreach (var i in cn)
                        {
                            txtShopID.Text = i.Shopid.ToString();
                        }
                        if (txtShopID.Text == "")
                        {
                            Shops nshop = new Shops();
                            nshop.Shopname = cbShops.Text.Trim();
                            db.Shops.Add(nshop);
                            db.SaveChanges();
                            txtShopID.Text = nshop.Shopid.ToString();
                            GetShops();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "sory");
                    }
                }

            }            
        }
        private void cbUserNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbUserNames.Text==""|| cbUserNames.Text==null)
            {
                return;
            }
            else
            {
                try
                {
                    dbEntities db = new dbEntities();
                    var cn = db.Users.Where(x=>x.User_Name==cbUserNames.Text.Trim()).ToList();
                    if (cn.Count==1)
                    {
                        foreach (var i in cn)
                        {
                            txtPassword.Text = i.Password;
                            txtShopID.Text = i.ShopId.ToString();
                            cbShops.Text = i.ShopName;
                            txtUserId.Text = i.User_ID.ToString();
                            
                        }
                    }
                    else
                    {
                        txtPassword.Text ="";
                        txtShopID.Text = "";
                        cbShops.Text = "";
                        txtUserId.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "sory");
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text==""||txtShopID.Text==""||cbShops.Text==""||cbUserNames.Text==""||txtUserId.Text=="")
            {
                MessageBox.Show("الرجاء تعبئة البيانات لاضافتها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                dbEntities db = new dbEntities();
                UserId = Convert.ToInt64(txtUserId.Text);
                var cn = db.Users.Where(x => x.User_ID == UserId).ToList();
                if (cn.Count==1)
                {
                    foreach (var i in cn)
                    {
                        i.Password = txtPassword.Text.Trim();
                        i.ShopId = Convert.ToInt16(txtShopID.Text);
                        i.ShopName = cbShops.Text.Trim();
                        i.User_Name = cbUserNames.Text.Trim();
                        db.SaveChanges();
                    }
                }
                else
                {
                    Users U = new Users();
                    U.Password = txtPassword.Text.Trim();
                    U.ShopId = Convert.ToInt16(txtShopID.Text);
                    U.ShopName = cbShops.Text.Trim();
                    U.User_Name = cbUserNames.Text.Trim();
                    db.Users.Add(U);
                    db.SaveChanges();
                    txtUserId.Text = U.User_ID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
            }
            Get_Users();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {   
            if (MessageBox.Show("هل أنت متأكد من  انك تريد حذف هذا المستخدم؟","تنبيه",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (txtPassword.Text == "" || txtShopID.Text == "" || cbShops.Text == "" || cbUserNames.Text == "")
                {
                    MessageBox.Show("الرجاء تعبئة البيانات لاضافتها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    try
                    {
                        dbEntities db = new dbEntities();
                        var cn = db.Users.Where(x => x.User_Name == cbUserNames.Text.Trim()).ToList();
                        if (cn.Count == 1)
                        {
                            foreach (var i in cn)
                            {
                                db.Users.Remove(i);
                                db.SaveChanges();
                            }
                            btnNew.PerformClick();
                            Get_Users();

                        }
                        else
                        {
                            MessageBox.Show("لاتوجد بيانات لحذفها", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Sory");
                    }
                }

            }
        }
    }
}
