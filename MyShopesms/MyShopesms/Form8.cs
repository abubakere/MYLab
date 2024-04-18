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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                dbEntities db = new dbEntities();

                if (rdcash.Checked==true)
                {

                    var cn = db.SalesInvoice.Where(x => x.Ddate >= dt1.Value && x.Ddate <= dt2.Value && x.Shopid == Form5.ShopID && x.CashOrCredit==1).ToList();
                    salesInvoiceBindingSource.DataSource = cn.ToList();
                    if (cn.Count > 0)
                    {
                        lbtotal.Text = cn.Sum(x => x.Total_).ToString();
                        lbprofits.Text = cn.Sum(x => x.Total_Profits).ToString();
                        lbtotal.Text = string.Format("{0:N}", Convert.ToDecimal(lbtotal.Text));
                        lbprofits.Text = string.Format("{0:N}", Convert.ToDecimal(lbprofits.Text));

                    }
                    else
                    {
                        lbtotal.Text = "0.00";
                        lbprofits.Text = "0.00";
                    }
                }
                if (rdbank.Checked==true)
                {
                    var cn = db.SalesInvoice.Where(x => x.Ddate >= dt1.Value && x.Ddate <= dt2.Value && x.Shopid == Form5.ShopID && x.CashOrCredit == 2).ToList();
                    salesInvoiceBindingSource.DataSource = cn.ToList();
                    if (cn.Count > 0)
                    {
                        lbtotal.Text = cn.Sum(x => x.Total_).ToString();
                        lbprofits.Text = cn.Sum(x => x.Total_Profits).ToString();
                        lbtotal.Text = string.Format("{0:N}", Convert.ToDecimal(lbtotal.Text));
                        lbprofits.Text = string.Format("{0:N}", Convert.ToDecimal(lbprofits.Text));

                    }
                    else
                    {
                        lbtotal.Text = "0.00";
                        lbprofits.Text = "0.00";
                    }
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
