
namespace MyShopesms
{
    partial class Form8
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.button20 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matiralBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matiralNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalProfitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitOneItemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shopidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashOrCreditDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesInvoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbprofits = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbank = new System.Windows.Forms.RadioButton();
            this.rdcash = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesInvoiceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lbtotal
            // 
            this.lbtotal.BackColor = System.Drawing.Color.White;
            this.lbtotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotal.Location = new System.Drawing.Point(36, 10);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(256, 34);
            this.lbtotal.TabIndex = 40;
            this.lbtotal.Text = "0.000";
            this.lbtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(298, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 19);
            this.label3.TabIndex = 39;
            this.label3.Text = "اجمالي المبيعات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(953, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 19);
            this.label2.TabIndex = 38;
            this.label2.Text = "الى";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(953, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 37;
            this.label1.Text = "من";
            // 
            // dt2
            // 
            this.dt2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt2.Location = new System.Drawing.Point(709, 43);
            this.dt2.Name = "dt2";
            this.dt2.Size = new System.Drawing.Size(238, 27);
            this.dt2.TabIndex = 36;
            // 
            // dt1
            // 
            this.dt1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt1.Location = new System.Drawing.Point(709, 10);
            this.dt1.Name = "dt1";
            this.dt1.Size = new System.Drawing.Size(238, 27);
            this.dt1.TabIndex = 35;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button20.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(480, 10);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(97, 60);
            this.button20.TabIndex = 34;
            this.button20.Text = "عـــرض";
            this.button20.UseVisualStyleBackColor = false;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.invoiceNoDataGridViewTextBoxColumn,
            this.matiralBarcodeDataGridViewTextBoxColumn,
            this.matiralNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.totalProfitsDataGridViewTextBoxColumn,
            this.ddateDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.profitOneItemDataGridViewTextBoxColumn,
            this.shopidDataGridViewTextBoxColumn,
            this.cashOrCreditDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.salesInvoiceBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 89);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(991, 629);
            this.dataGridView1.TabIndex = 33;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // invoiceNoDataGridViewTextBoxColumn
            // 
            this.invoiceNoDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNo";
            this.invoiceNoDataGridViewTextBoxColumn.HeaderText = "رقم الفاتورة";
            this.invoiceNoDataGridViewTextBoxColumn.Name = "invoiceNoDataGridViewTextBoxColumn";
            this.invoiceNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // matiralBarcodeDataGridViewTextBoxColumn
            // 
            this.matiralBarcodeDataGridViewTextBoxColumn.DataPropertyName = "MatiralBarcode";
            this.matiralBarcodeDataGridViewTextBoxColumn.HeaderText = "رقم الباركود";
            this.matiralBarcodeDataGridViewTextBoxColumn.Name = "matiralBarcodeDataGridViewTextBoxColumn";
            this.matiralBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // matiralNameDataGridViewTextBoxColumn
            // 
            this.matiralNameDataGridViewTextBoxColumn.DataPropertyName = "MatiralName";
            this.matiralNameDataGridViewTextBoxColumn.HeaderText = "اسم الصنف";
            this.matiralNameDataGridViewTextBoxColumn.Name = "matiralNameDataGridViewTextBoxColumn";
            this.matiralNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.matiralNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "الكمية";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "سعر البيع";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total_";
            this.totalDataGridViewTextBoxColumn.HeaderText = "الاجمالي";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalProfitsDataGridViewTextBoxColumn
            // 
            this.totalProfitsDataGridViewTextBoxColumn.DataPropertyName = "Total_Profits";
            this.totalProfitsDataGridViewTextBoxColumn.HeaderText = "الارباح";
            this.totalProfitsDataGridViewTextBoxColumn.Name = "totalProfitsDataGridViewTextBoxColumn";
            this.totalProfitsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ddateDataGridViewTextBoxColumn
            // 
            this.ddateDataGridViewTextBoxColumn.DataPropertyName = "Ddate";
            this.ddateDataGridViewTextBoxColumn.HeaderText = "التاريخ";
            this.ddateDataGridViewTextBoxColumn.Name = "ddateDataGridViewTextBoxColumn";
            this.ddateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "اسم المستخدم";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "User_ID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "User_ID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // profitOneItemDataGridViewTextBoxColumn
            // 
            this.profitOneItemDataGridViewTextBoxColumn.DataPropertyName = "Profit_One_Item";
            this.profitOneItemDataGridViewTextBoxColumn.HeaderText = "Profit_One_Item";
            this.profitOneItemDataGridViewTextBoxColumn.Name = "profitOneItemDataGridViewTextBoxColumn";
            this.profitOneItemDataGridViewTextBoxColumn.ReadOnly = true;
            this.profitOneItemDataGridViewTextBoxColumn.Visible = false;
            // 
            // shopidDataGridViewTextBoxColumn
            // 
            this.shopidDataGridViewTextBoxColumn.DataPropertyName = "Shopid";
            this.shopidDataGridViewTextBoxColumn.HeaderText = "Shopid";
            this.shopidDataGridViewTextBoxColumn.Name = "shopidDataGridViewTextBoxColumn";
            this.shopidDataGridViewTextBoxColumn.ReadOnly = true;
            this.shopidDataGridViewTextBoxColumn.Visible = false;
            // 
            // cashOrCreditDataGridViewTextBoxColumn
            // 
            this.cashOrCreditDataGridViewTextBoxColumn.DataPropertyName = "CashOrCredit";
            this.cashOrCreditDataGridViewTextBoxColumn.HeaderText = "CashOrCredit";
            this.cashOrCreditDataGridViewTextBoxColumn.Name = "cashOrCreditDataGridViewTextBoxColumn";
            this.cashOrCreditDataGridViewTextBoxColumn.ReadOnly = true;
            this.cashOrCreditDataGridViewTextBoxColumn.Visible = false;
            // 
            // salesInvoiceBindingSource
            // 
            this.salesInvoiceBindingSource.DataSource = typeof(MyShopesms.SalesInvoice);
            // 
            // lbprofits
            // 
            this.lbprofits.BackColor = System.Drawing.Color.White;
            this.lbprofits.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbprofits.Location = new System.Drawing.Point(36, 50);
            this.lbprofits.Name = "lbprofits";
            this.lbprofits.Size = new System.Drawing.Size(256, 34);
            this.lbprofits.TabIndex = 42;
            this.lbprofits.Text = "0.000";
            this.lbprofits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(298, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "اجمالي الارباح";
            // 
            // rdbank
            // 
            this.rdbank.AutoSize = true;
            this.rdbank.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbank.Location = new System.Drawing.Point(583, 43);
            this.rdbank.Name = "rdbank";
            this.rdbank.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdbank.Size = new System.Drawing.Size(120, 23);
            this.rdbank.TabIndex = 59;
            this.rdbank.TabStop = true;
            this.rdbank.Text = "سداد بالبطاقة";
            this.rdbank.UseVisualStyleBackColor = true;
            // 
            // rdcash
            // 
            this.rdcash.AutoSize = true;
            this.rdcash.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdcash.Location = new System.Drawing.Point(583, 10);
            this.rdcash.Name = "rdcash";
            this.rdcash.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rdcash.Size = new System.Drawing.Size(93, 23);
            this.rdcash.TabIndex = 58;
            this.rdcash.TabStop = true;
            this.rdcash.Text = "سداد نقدا";
            this.rdcash.UseVisualStyleBackColor = true;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.rdbank);
            this.Controls.Add(this.rdcash);
            this.Controls.Add(this.lbprofits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المبيعات";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesInvoiceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbprofits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matiralBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matiralNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalProfitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ddateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitOneItemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashOrCreditDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource salesInvoiceBindingSource;
        private System.Windows.Forms.RadioButton rdbank;
        private System.Windows.Forms.RadioButton rdcash;
    }
}