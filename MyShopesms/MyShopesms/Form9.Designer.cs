
namespace MyShopesms
{
    partial class Form9
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
            this.matirialBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matirialNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalOfQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceinDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shopidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buingQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewAllBalanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbtotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAllBalanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matirialBarcodeDataGridViewTextBoxColumn,
            this.matirialNameDataGridViewTextBoxColumn,
            this.totalOfQuantityDataGridViewTextBoxColumn,
            this.priceinDataGridViewTextBoxColumn,
            this.balancoDataGridViewTextBoxColumn,
            this.shopidDataGridViewTextBoxColumn,
            this.buingQuantityDataGridViewTextBoxColumn,
            this.salesQuantityDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.viewAllBalanceBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(984, 586);
            this.dataGridView1.TabIndex = 0;
            // 
            // matirialBarcodeDataGridViewTextBoxColumn
            // 
            this.matirialBarcodeDataGridViewTextBoxColumn.DataPropertyName = "MatirialBarcode";
            this.matirialBarcodeDataGridViewTextBoxColumn.HeaderText = "رقم الباركود";
            this.matirialBarcodeDataGridViewTextBoxColumn.Name = "matirialBarcodeDataGridViewTextBoxColumn";
            this.matirialBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.matirialBarcodeDataGridViewTextBoxColumn.Width = 150;
            // 
            // matirialNameDataGridViewTextBoxColumn
            // 
            this.matirialNameDataGridViewTextBoxColumn.DataPropertyName = "MatirialName";
            this.matirialNameDataGridViewTextBoxColumn.HeaderText = "اسم الصنف";
            this.matirialNameDataGridViewTextBoxColumn.Name = "matirialNameDataGridViewTextBoxColumn";
            this.matirialNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.matirialNameDataGridViewTextBoxColumn.Width = 250;
            // 
            // totalOfQuantityDataGridViewTextBoxColumn
            // 
            this.totalOfQuantityDataGridViewTextBoxColumn.DataPropertyName = "TotalOfQuantity";
            this.totalOfQuantityDataGridViewTextBoxColumn.HeaderText = "الكمية المتبقية";
            this.totalOfQuantityDataGridViewTextBoxColumn.Name = "totalOfQuantityDataGridViewTextBoxColumn";
            this.totalOfQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceinDataGridViewTextBoxColumn
            // 
            this.priceinDataGridViewTextBoxColumn.DataPropertyName = "Pricein";
            this.priceinDataGridViewTextBoxColumn.HeaderText = "سعر الشراء";
            this.priceinDataGridViewTextBoxColumn.Name = "priceinDataGridViewTextBoxColumn";
            this.priceinDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // balancoDataGridViewTextBoxColumn
            // 
            this.balancoDataGridViewTextBoxColumn.DataPropertyName = "Balanco";
            this.balancoDataGridViewTextBoxColumn.HeaderText = "قيمة رأس المال";
            this.balancoDataGridViewTextBoxColumn.Name = "balancoDataGridViewTextBoxColumn";
            this.balancoDataGridViewTextBoxColumn.ReadOnly = true;
            this.balancoDataGridViewTextBoxColumn.Width = 200;
            // 
            // shopidDataGridViewTextBoxColumn
            // 
            this.shopidDataGridViewTextBoxColumn.DataPropertyName = "Shopid";
            this.shopidDataGridViewTextBoxColumn.HeaderText = "رقم المحل";
            this.shopidDataGridViewTextBoxColumn.Name = "shopidDataGridViewTextBoxColumn";
            this.shopidDataGridViewTextBoxColumn.ReadOnly = true;
            this.shopidDataGridViewTextBoxColumn.Visible = false;
            // 
            // buingQuantityDataGridViewTextBoxColumn
            // 
            this.buingQuantityDataGridViewTextBoxColumn.DataPropertyName = "BuingQuantity";
            this.buingQuantityDataGridViewTextBoxColumn.HeaderText = "BuingQuantity";
            this.buingQuantityDataGridViewTextBoxColumn.Name = "buingQuantityDataGridViewTextBoxColumn";
            this.buingQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.buingQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // salesQuantityDataGridViewTextBoxColumn
            // 
            this.salesQuantityDataGridViewTextBoxColumn.DataPropertyName = "SalesQuantity";
            this.salesQuantityDataGridViewTextBoxColumn.HeaderText = "SalesQuantity";
            this.salesQuantityDataGridViewTextBoxColumn.Name = "salesQuantityDataGridViewTextBoxColumn";
            this.salesQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // viewAllBalanceBindingSource
            // 
            this.viewAllBalanceBindingSource.DataSource = typeof(MyShopesms.ViewAllBalance);
            // 
            // lbtotal
            // 
            this.lbtotal.BackColor = System.Drawing.Color.White;
            this.lbtotal.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtotal.Location = new System.Drawing.Point(12, 617);
            this.lbtotal.Name = "lbtotal";
            this.lbtotal.Size = new System.Drawing.Size(256, 34);
            this.lbtotal.TabIndex = 42;
            this.lbtotal.Text = "0.000";
            this.lbtotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 625);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 19);
            this.label3.TabIndex = 41;
            this.label3.Text = "اجمالي رأس المال";
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.lbtotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير راس المال";
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewAllBalanceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource viewAllBalanceBindingSource;
        private System.Windows.Forms.Label lbtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn matirialBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn matirialNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalOfQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceinDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn balancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shopidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buingQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesQuantityDataGridViewTextBoxColumn;
    }
}