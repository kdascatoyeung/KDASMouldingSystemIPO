namespace Mould_System.forms._5.reporting
{
    partial class ucModifyCheck
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvModifyCheck = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instockdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModifyCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvModifyCheck
            // 
            this.dgvModifyCheck.AllowUserToAddRows = false;
            this.dgvModifyCheck.AllowUserToDeleteRows = false;
            this.dgvModifyCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModifyCheck.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModifyCheck.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvModifyCheck.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvModifyCheck.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvModifyCheck.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvModifyCheck.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvModifyCheck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModifyCheck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendor,
            this.vendorname,
            this.ic,
            this.model,
            this.partno,
            this.rev,
            this.mouldno,
            this.type,
            this.mouldcode,
            this.curr,
            this.amount,
            this.amounthkd,
            this.remarks,
            this.po,
            this.instockdate});
            this.dgvModifyCheck.Location = new System.Drawing.Point(4, 32);
            this.dgvModifyCheck.Name = "dgvModifyCheck";
            this.dgvModifyCheck.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvModifyCheck.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvModifyCheck.ReadOnly = true;
            this.dgvModifyCheck.RowHeadersVisible = false;
            this.dgvModifyCheck.SecondaryLength = 2;
            this.dgvModifyCheck.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvModifyCheck.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvModifyCheck.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvModifyCheck.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvModifyCheck.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvModifyCheck.Size = new System.Drawing.Size(1063, 580);
            this.dgvModifyCheck.TabIndex = 13;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendorcode";
            this.vendor.HeaderText = "VENDOR CODE";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            // 
            // ic
            // 
            this.ic.DataPropertyName = "pgroup";
            this.ic.HeaderText = "I/C";
            this.ic.Name = "ic";
            this.ic.ReadOnly = true;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "MODEL";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            // 
            // partno
            // 
            this.partno.DataPropertyName = "itemcode";
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            this.partno.ReadOnly = true;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.ReadOnly = true;
            // 
            // curr
            // 
            this.curr.DataPropertyName = "currency";
            this.curr.HeaderText = "CURR";
            this.curr.Name = "curr";
            this.curr.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // amounthkd
            // 
            this.amounthkd.DataPropertyName = "amounthkd";
            this.amounthkd.HeaderText = "AMOUNT HKD";
            this.amounthkd.Name = "amounthkd";
            this.amounthkd.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // po
            // 
            this.po.DataPropertyName = "po";
            this.po.HeaderText = "PO";
            this.po.Name = "po";
            this.po.ReadOnly = true;
            // 
            // instockdate
            // 
            this.instockdate.DataPropertyName = "instockdate";
            this.instockdate.HeaderText = "IN STOCK DATE";
            this.instockdate.Name = "instockdate";
            this.instockdate.ReadOnly = true;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(4, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 15;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(947, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Non In-Stock",
            "In Stock Date"});
            this.cbSearch.Location = new System.Drawing.Point(809, 4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 18;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // ucModifyCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvModifyCheck);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucModifyCheck";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModifyCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvModifyCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ic;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn curr;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn instockdate;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
    }
}
