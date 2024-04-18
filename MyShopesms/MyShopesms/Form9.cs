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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.ViewAllBalance.Where(x=>x.TotalOfQuantity > 0 && x.Shopid==Form5.ShopID).ToList();
                if (cn.Count>0)
                {
                    viewAllBalanceBindingSource.DataSource = cn.ToList();
                    lbtotal.Text = cn.Sum(x => x.Balanco).ToString();
                    lbtotal.Text = string.Format("{0:N}", Convert.ToDecimal(lbtotal.Text));
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erorr");
            }
        }
    }
}
