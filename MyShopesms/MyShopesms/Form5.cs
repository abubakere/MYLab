using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyShopesms
{
    public partial class Form5 : Form
    {
        public static string UserName, ShopName, Password;
        public static long UserID;
        public static int ShopID;
        ArrayList hardDriveDetails = new ArrayList();
       
        public Form5()
        {
            InitializeComponent();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            dbEntities db = new dbEntities();
            try
            {
                var cn = db.Users.Where(x => x.User_Name == cbUserName.Text.Trim() && x.Password == txtPassWord.Text.Trim()).ToList();
                if (cn.Count == 1)
                {
                    foreach (var i in cn)
                    {
                        UserID = i.User_ID;
                        UserName = i.User_Name;
                        Password = i.Password;
                        ShopID = i.ShopId;
                        ShopName = i.ShopName;
                    }
                    //GtMatriials();
                    HdDS();
                }
                else
                {
                    MessageBox.Show("البيانات غير مطابقة ", "نأسف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sorry");
            }
        }
        private void txtPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)Keys.Enter)
            {
                btnEnter.PerformClick();
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            Get_HDD();
            UsersTolist();
            
    }
        private void HdDS()
        {
            dbEntities db = new dbEntities();
            var cn2 = db.HDD.Where(x => x.HardDiskNo == txthddid.Text.Trim()).ToList();
            if (cn2.Count == 0)
            {
                MessageBox.Show("هدا الجهاز  غير مفعل ");
                return;
            }
            else
            {
                Form11 frm = new Form11();
                this.Hide();
                frm.Show();
            }
        }
        private void UsersTolist()
        {
            dbEntities db = new dbEntities();
            try
            {
                var cn = db.Users.ToList();
                cbUserName.Items.Clear();
                foreach (var i in cn)
                {
                    cbUserName.Items.Add(i.User_Name);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Sorry");

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassWord.Text=="بسم الله الرحمن الرحيم")
            {
                dbEntities db = new dbEntities();
                HDD a = new HDD();
                a.HardDiskNo = txthddid.Text.Trim();
                db.HDD.Add(a);
                db.SaveChanges();
                MessageBox.Show("All Don Successfully.", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void cbUserName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }
        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
      
        }

        private void Get_HDD()
        {
            ManagementObjectSearcher moSearcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");

            foreach (ManagementObject wmi_HD in moSearcher.Get())
            {
                HardDrive hd = new HardDrive();  // User Defined Class
                hd.Model = wmi_HD["Model"].ToString();  //Model Number
                hd.Type = wmi_HD["InterfaceType"].ToString();  //Interface Type
                hd.SerialNo = wmi_HD["SerialNumber"].ToString(); // Serial Number
                hardDriveDetails.Add(hd);
                label11.Text = "Model : " + hd.Model;
                label21.Text = " Type : " + hd.Type;
                txthddid.Text = hd.SerialNo;
            }

        }
        //private void GtMatriials()
        //{
        //    try
        //    {
        //        dbEntities db = new dbEntities();
        //        var cn = db.Matirails.Where(x => x.Shopid == ShopID).ToList();
        //        foreach (var i in cn)
        //        {
        //            Ts.Add(i.MatirialName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
     
  
}
