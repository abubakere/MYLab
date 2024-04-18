
namespace MyShopesms
{
    partial class FEXmatirials
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matirialBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matirialNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceOutDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shopidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matirailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matirailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.exDateDataGridViewTextBoxColumn,
            this.matirialBarcodeDataGridViewTextBoxColumn,
            this.matirialNameDataGridViewTextBoxColumn,
            this.priceinDataGridViewTextBoxColumn,
            this.priceOutDataGridViewTextBoxColumn,
            this.profitDataGridViewTextBoxColumn,
            this.userIDDataGridViewTextBoxColumn,
            this.userNameDataGridViewTextBoxColumn,
            this.shopidDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.matirailsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(817, 710);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // exDateDataGridViewTextBoxColumn
            // 
            this.exDateDataGridViewTextBoxColumn.DataPropertyName = "exDate";
            this.exDateDataGridViewTextBoxColumn.HeaderText = "تاريخ انتهاء الصلاحية";
            this.exDateDataGridViewTextBoxColumn.Name = "exDateDataGridViewTextBoxColumn";
            this.exDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.exDateDataGridViewTextBoxColumn.Width = 200;
            // 
            // matirialBarcodeDataGridViewTextBoxColumn
            // 
            this.matirialBarcodeDataGridViewTextBoxColumn.DataPropertyName = "MatirialBarcode";
            this.matirialBarcodeDataGridViewTextBoxColumn.HeaderText = "الباركود";
            this.matirialBarcodeDataGridViewTextBoxColumn.Name = "matirialBarcodeDataGridViewTextBoxColumn";
            this.matirialBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.matirialBarcodeDataGridViewTextBoxColumn.Width = 250;
            // 
            // matirialNameDataGridViewTextBoxColumn
            // 
            this.matirialNameDataGridViewTextBoxColumn.DataPropertyName = "MatirialName";
            this.matirialNameDataGridViewTextBoxColumn.HeaderText = "اسم الصنف";
            this.matirialNameDataGridViewTextBoxColumn.Name = "matirialNameDataGridViewTextBoxColumn";
            this.matirialNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.matirialNameDataGridViewTextBoxColumn.Width = 300;
            // 
            // priceinDataGridViewTextBoxColumn
            // 
            this.priceinDataGridViewTextBoxColumn.DataPropertyName = "Pricein";
            this.priceinDataGridViewTextBoxColumn.HeaderText = "Pricein";
            this.priceinDataGridViewTextBoxColumn.Name = "priceinDataGridViewTextBoxColumn";
            this.priceinDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceinDataGridViewTextBoxColumn.Visible = false;
            // 
            // priceOutDataGridViewTextBoxColumn
            // 
            this.priceOutDataGridViewTextBoxColumn.DataPropertyName = "PriceOut";
            this.priceOutDataGridViewTextBoxColumn.HeaderText = "PriceOut";
            this.priceOutDataGridViewTextBoxColumn.Name = "priceOutDataGridViewTextBoxColumn";
            this.priceOutDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceOutDataGridViewTextBoxColumn.Visible = false;
            // 
            // profitDataGridViewTextBoxColumn
            // 
            this.profitDataGridViewTextBoxColumn.DataPropertyName = "Profit";
            this.profitDataGridViewTextBoxColumn.HeaderText = "Profit";
            this.profitDataGridViewTextBoxColumn.Name = "profitDataGridViewTextBoxColumn";
            this.profitDataGridViewTextBoxColumn.ReadOnly = true;
            this.profitDataGridViewTextBoxColumn.Visible = false;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "User_ID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "User_ID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.userIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            this.userNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.userNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // shopidDataGridViewTextBoxColumn
            // 
            this.shopidDataGridViewTextBoxColumn.DataPropertyName = "Shopid";
            this.shopidDataGridViewTextBoxColumn.HeaderText = "Shopid";
            this.shopidDataGridViewTextBoxColumn.Name = "shopidDataGridViewTextBoxColumn";
            this.shopidDataGridViewTextBoxColumn.ReadOnly = true;
            this.shopidDataGridViewTextBoxColumn.Visible = false;
            // 
            // matirailsBindingSource
            // 
            this.matirailsBindingSource.DataSource = typeof(MyShopesms.Matirails);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(861, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FEXmatirials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FEXmatirials";
            this.Text = "الاصناف المنتهية الصلاحية";
            this.Load += new System.EventHandler(this.FEXmatirials_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matirailsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource matirailsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matirialBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matirialNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceOutDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn profitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopidDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
    }
}