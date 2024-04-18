using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
//using Microsoft.Reporting.WinForms;

namespace MyShopesms
{
    public partial class Forme1 : Form
    {
        public static Int64 InvoiceNo;

        public Forme1()
        {
            InitializeComponent();
        }

     

        private void Forme1_Load(object sender, EventArgs e)
        {
            
        }

        private void Forme1_Load_1(object sender, EventArgs e)
        {
            dbEntities db = new dbEntities();
            SalesInvoiceBindingSource.DataSource = db.SalesInvoice.Where(x=>x.InvoiceNo==InvoiceNo).ToList();
            reportViewer1.RefreshReport();

            //LocalReport localReport = new LocalReport();
            //localReport.ReportPath = Application.StartupPath + "\\RptInvoice.rdlc";
            //localReport
        }
    }
}
