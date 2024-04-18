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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                dbEntities db = new dbEntities();     
                var cn = db.BuingInvoice.Where(x => x.Ddate >= dt1.Value && x.Ddate <= dt2.Value && x.Shopid==Form5.ShopID).ToList();
                buingInvoiceBindingSource.DataSource = cn.ToList();
                if (cn.Count>0)
                {
                    lbtotal.Text = cn.Sum(x => x.Total).ToString();
                    lbtotal.Text = string.Format("{0:N}", Convert.ToDecimal(lbtotal.Text));
                }
                else
                {
                    lbtotal.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
                throw;
            }
        }
    }
}
