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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            fillme();
        }
        private void fillme()
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.Procedures.ToList();
                proceduresBindingSource.DataSource = cn.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dbEntities db = new dbEntities();
                var cn = db.Procedures.ToList();
                foreach (var i in cn)
                {
                    db.Procedures.Remove(i);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "sory");
            }
            fillme();
        }
    }
}
