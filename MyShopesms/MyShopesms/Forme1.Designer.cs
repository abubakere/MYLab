
namespace MyShopesms
{
    partial class Forme1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SalesInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SalesInvoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SalesInvoiceBindingSource
            // 
            this.SalesInvoiceBindingSource.DataSource = typeof(MyShopesms.SalesInvoice);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SalesInvoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MyShopesms.RptInvoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(450, 335);
            this.reportViewer1.TabIndex = 0;
            // 
            // Forme1
            // 
            this.ClientSize = new System.Drawing.Size(450, 335);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Forme1";
            this.Load += new System.EventHandler(this.Forme1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.SalesInvoiceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SalesInvoiceBindingSource;
    }
}