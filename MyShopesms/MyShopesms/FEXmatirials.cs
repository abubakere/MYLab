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
    public partial class FEXmatirials : Form
    {
        public FEXmatirials()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void FEXmatirials_Load(object sender, EventArgs e)
        {           
            try
            {
                dbEntities db = new dbEntities();
                var ExDate = DateTime.Now;
                var cn = db.Matirails.Where(x => x.exDate <= ExDate).ToList().OrderBy(x => x.exDate);
                matirailsBindingSource.DataSource = cn.ToList();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
