namespace Mould_System.forms._5.reporting
{
    partial class ucPaymentList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvPaymentList = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.dpSearch = new System.Windows.Forms.DateTimePicker();
            this.cbOption = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colChaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payterm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paycurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentList)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "Vendor",
            "Payment Month"});
            this.cbSearch.Location = new System.Drawing.Point(135, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(131, 23);
            this.cbSearch.TabIndex = 11;
            this.cbSearch.Visible = false;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvPaymentList
            // 
            this.dgvPaymentList.AllowUserToAddRows = false;
            this.dgvPaymentList.AllowUserToDeleteRows = false;
            this.dgvPaymentList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPaymentList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPaymentList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPaymentList.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvPaymentList.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChaseno,
            this.account,
            this.vendorname,
            this.incharge,
            this.colMpa,
            this.colInStock50,
            this.colInStock,
            this.payterm,
            this.paycurr,
            this.hkd,
            this.colstatus});
            this.dgvPaymentList.Location = new System.Drawing.Point(7, 32);
            this.dgvPaymentList.Name = "dgvPaymentList";
            this.dgvPaymentList.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvPaymentList.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvPaymentList.ReadOnly = true;
            this.dgvPaymentList.RowHeadersVisible = false;
            this.dgvPaymentList.SecondaryLength = 2;
            this.dgvPaymentList.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvPaymentList.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvPaymentList.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvPaymentList.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentList.Size = new System.Drawing.Size(1064, 580);
            this.dgvPaymentList.TabIndex = 15;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(7, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 17;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dpSearch
            // 
            this.dpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpSearch.CustomFormat = "yyyy/MM";
            this.dpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpSearch.Location = new System.Drawing.Point(966, 5);
            this.dpSearch.Name = "dpSearch";
            this.dpSearch.Size = new System.Drawing.Size(105, 23);
            this.dpSearch.TabIndex = 18;
            this.dpSearch.ValueChanged += new System.EventHandler(this.dpSearch_ValueChanged);
            // 
            // cbOption
            // 
            this.cbOption.FormattingEnabled = true;
            this.cbOption.Items.AddRange(new object[] {
            "Payment List",
            "All PO List",
            "Selected PO List"});
            this.cbOption.Location = new System.Drawing.Point(272, 4);
            this.cbOption.Name = "cbOption";
            this.cbOption.Size = new System.Drawing.Size(159, 23);
            this.cbOption.TabIndex = 19;
            this.cbOption.Visible = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(777, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(105, 23);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(690, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Vendor Code :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(888, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Pay Month :";
            // 
            // colChaseno
            // 
            this.colChaseno.DataPropertyName = "chaseno";
            this.colChaseno.HeaderText = "CHASE NO.";
            this.colChaseno.Name = "colChaseno";
            this.colChaseno.ReadOnly = true;
            // 
            // account
            // 
            this.account.DataPropertyName = "vendor";
            this.account.HeaderText = "ACCOUNT";
            this.account.Name = "account";
            this.account.ReadOnly = true;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            // 
            // incharge
            // 
            this.incharge.DataPropertyName = "incharge";
            this.incharge.HeaderText = "I/C";
            this.incharge.Name = "incharge";
            this.incharge.ReadOnly = true;
            // 
            // colMpa
            // 
            this.colMpa.DataPropertyName = "mpa";
            this.colMpa.HeaderText = "MPA";
            this.colMpa.Name = "colMpa";
            this.colMpa.ReadOnly = true;
            // 
            // colInStock50
            // 
            this.colInStock50.DataPropertyName = "instock50";
            this.colInStock50.HeaderText = "IN STOCK 50%";
            this.colInStock50.Name = "colInStock50";
            this.colInStock50.ReadOnly = true;
            // 
            // colInStock
            // 
            this.colInStock.DataPropertyName = "instock";
            this.colInStock.HeaderText = "IN STOCK";
            this.colInStock.Name = "colInStock";
            this.colInStock.ReadOnly = true;
            // 
            // payterm
            // 
            this.payterm.DataPropertyName = "payterm";
            this.payterm.HeaderText = "PAY TERM";
            this.payterm.Name = "payterm";
            this.payterm.ReadOnly = true;
            // 
            // paycurr
            // 
            this.paycurr.DataPropertyName = "currency";
            this.paycurr.HeaderText = "PAY CURR";
            this.paycurr.Name = "paycurr";
            this.paycurr.ReadOnly = true;
            // 
            // hkd
            // 
            this.hkd.DataPropertyName = "amounthkd";
            this.hkd.HeaderText = "HKD";
            this.hkd.Name = "hkd";
            this.hkd.ReadOnly = true;
            // 
            // colstatus
            // 
            this.colstatus.DataPropertyName = "status";
            this.colstatus.HeaderText = "STATUS";
            this.colstatus.Name = "colstatus";
            this.colstatus.ReadOnly = true;
            // 
            // ucPaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbOption);
            this.Controls.Add(this.dpSearch);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvPaymentList);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPaymentList";
            this.Size = new System.Drawing.Size(1077, 646);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvPaymentList;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.DateTimePicker dpSearch;
        private System.Windows.Forms.ComboBox cbOption;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn account;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn incharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock50;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn payterm;
        private System.Windows.Forms.DataGridViewTextBoxColumn paycurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn hkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstatus;
    }
}
