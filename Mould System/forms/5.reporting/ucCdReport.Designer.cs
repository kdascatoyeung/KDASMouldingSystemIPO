namespace Mould_System.forms._5.reporting
{
    partial class ucCdReport
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
            this.components = new System.ComponentModel.Container();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.dgvCdReport = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.btnCheck = new CustomUtil.controls.button.CustomButton();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.btnConfirm = new CustomUtil.controls.button.CustomButton();
            this.btnTemplate = new CustomUtil.controls.button.CustomButton();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managementno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountbefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountafter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountcalculated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cdtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instockdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.month = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCdReport)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(3, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 20;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // dgvCdReport
            // 
            this.dgvCdReport.AllowUserToAddRows = false;
            this.dgvCdReport.AllowUserToDeleteRows = false;
            this.dgvCdReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCdReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCdReport.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCdReport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCdReport.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCdReport.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvCdReport.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvCdReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCdReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.managementno,
            this.ic,
            this.vendor,
            this.vendorname,
            this.group,
            this.partno,
            this.rev,
            this.currency,
            this.amountbefore,
            this.amountafter,
            this.amountcalculated,
            this.cdtotal,
            this.instockdate,
            this.month,
            this.remarks,
            this.confirm});
            this.dgvCdReport.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvCdReport.Location = new System.Drawing.Point(3, 32);
            this.dgvCdReport.Name = "dgvCdReport";
            this.dgvCdReport.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvCdReport.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvCdReport.SecondaryLength = 2;
            this.dgvCdReport.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvCdReport.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvCdReport.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvCdReport.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvCdReport.Size = new System.Drawing.Size(1063, 580);
            this.dgvCdReport.TabIndex = 21;
            this.dgvCdReport.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCdReport_CellFormatting);
            this.dgvCdReport.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCdReport_DataError);
            this.dgvCdReport.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCdReport_RowHeaderMouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "Unknown";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(946, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 24;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Date",
            "Management No.",
            "Vendor Code",
            "Group",
            "Part No.",
            "CD Month"});
            this.cbSearch.Location = new System.Drawing.Point(808, 4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 23;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(103, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 25;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.LightGray;
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCheck.Location = new System.Drawing.Point(303, 3);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(94, 23);
            this.btnCheck.TabIndex = 26;
            this.btnCheck.Text = "1. Check";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(403, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "2. Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.LightGray;
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnConfirm.Location = new System.Drawing.Point(503, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(94, 23);
            this.btnConfirm.TabIndex = 28;
            this.btnConfirm.Text = "3. Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.LightGray;
            this.btnTemplate.ForeColor = System.Drawing.Color.Black;
            this.btnTemplate.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnTemplate.Location = new System.Drawing.Point(203, 3);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(94, 23);
            this.btnTemplate.TabIndex = 29;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // date
            // 
            this.date.DataPropertyName = "cddate";
            this.date.HeaderText = "DATE";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 58;
            // 
            // managementno
            // 
            this.managementno.DataPropertyName = "managementno";
            this.managementno.HeaderText = "MANAGEMENT NO.";
            this.managementno.Name = "managementno";
            this.managementno.ReadOnly = true;
            this.managementno.Width = 122;
            // 
            // ic
            // 
            this.ic.DataPropertyName = "ic";
            this.ic.HeaderText = "I/C";
            this.ic.Name = "ic";
            this.ic.ReadOnly = true;
            this.ic.Width = 48;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR CODE";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.Width = 101;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            this.vendorname.Width = 77;
            // 
            // group
            // 
            this.group.DataPropertyName = "pgroup";
            this.group.HeaderText = "GROUP";
            this.group.Name = "group";
            this.group.ReadOnly = true;
            this.group.Width = 71;
            // 
            // partno
            // 
            this.partno.DataPropertyName = "itemcode";
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            this.partno.ReadOnly = true;
            this.partno.Width = 75;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            this.rev.Width = 52;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CUR";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Width = 54;
            // 
            // amountbefore
            // 
            this.amountbefore.DataPropertyName = "amountbefore";
            this.amountbefore.HeaderText = "AMOUNT (BEFORE)";
            this.amountbefore.Name = "amountbefore";
            this.amountbefore.ReadOnly = true;
            this.amountbefore.Width = 122;
            // 
            // amountafter
            // 
            this.amountafter.DataPropertyName = "amountafter";
            this.amountafter.HeaderText = "AMOUNT (AFTER)";
            this.amountafter.Name = "amountafter";
            this.amountafter.ReadOnly = true;
            this.amountafter.Width = 114;
            // 
            // amountcalculated
            // 
            this.amountcalculated.DataPropertyName = "amountsystem";
            this.amountcalculated.HeaderText = "AMOUNT (QUOTATION)";
            this.amountcalculated.Name = "amountcalculated";
            this.amountcalculated.ReadOnly = true;
            this.amountcalculated.Width = 142;
            // 
            // cdtotal
            // 
            this.cdtotal.DataPropertyName = "cdtotal";
            this.cdtotal.HeaderText = "CD TOTAL";
            this.cdtotal.Name = "cdtotal";
            this.cdtotal.ReadOnly = true;
            this.cdtotal.Width = 76;
            // 
            // instockdate
            // 
            this.instockdate.DataPropertyName = "instockdate";
            this.instockdate.HeaderText = "IN STOCK";
            this.instockdate.Name = "instockdate";
            this.instockdate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.instockdate.Width = 76;
            // 
            // month
            // 
            this.month.DataPropertyName = "cdmonth";
            this.month.HeaderText = "CD MONTH";
            this.month.Name = "month";
            this.month.ReadOnly = true;
            this.month.Width = 85;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "DIFFERENCE";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 96;
            // 
            // confirm
            // 
            this.confirm.DataPropertyName = "locked";
            this.confirm.HeaderText = "CONFIRM";
            this.confirm.Name = "confirm";
            this.confirm.ReadOnly = true;
            this.confirm.Width = 65;
            // 
            // ucCdReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvCdReport);
            this.Controls.Add(this.btnUpload);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucCdReport";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCdReport)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvCdReport;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.ComponentModel.BackgroundWorker worker;
        private CustomUtil.controls.button.CustomButton btnCheck;
        private CustomUtil.controls.button.CustomButton btnSave;
        private CustomUtil.controls.button.CustomButton btnConfirm;
        private CustomUtil.controls.button.CustomButton btnTemplate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn managementno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ic;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountbefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountafter;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountcalculated;
        private System.Windows.Forms.DataGridViewTextBoxColumn cdtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn instockdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn month;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn confirm;
    }
}
