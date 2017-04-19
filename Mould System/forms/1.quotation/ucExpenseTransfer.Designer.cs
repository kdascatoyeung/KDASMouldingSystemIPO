namespace Mould_System.forms._1.quotation
{
    partial class ucExpenseTransfer
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvExpenseTransfer = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.btnNonFinish = new CustomUtil.controls.button.CustomButton();
            this.btnTemplate = new CustomUtil.controls.button.CustomButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incharge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitnote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finish = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epsonno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenseTransfer)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(951, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 39;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "In-Charge",
            "Asset",
            "Chase No.",
            "Part No.",
            "Mould No.",
            "Vendor",
            "PO"});
            this.cbSearch.Location = new System.Drawing.Point(813, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 38;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(6, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 41;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvExpenseTransfer
            // 
            this.dgvExpenseTransfer.AllowUserToAddRows = false;
            this.dgvExpenseTransfer.AllowUserToDeleteRows = false;
            this.dgvExpenseTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExpenseTransfer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvExpenseTransfer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvExpenseTransfer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvExpenseTransfer.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvExpenseTransfer.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvExpenseTransfer.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvExpenseTransfer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenseTransfer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.date,
            this.incharge,
            this.asset,
            this.partno,
            this.rev,
            this.mouldno,
            this.type,
            this.mouldcode,
            this.currency,
            this.amount,
            this.vendor,
            this.vendorname,
            this.chaseno,
            this.remarks,
            this.po,
            this.issued,
            this.instock,
            this.debitnote,
            this.sales,
            this.ringi,
            this.finish,
            this.epsonno});
            this.dgvExpenseTransfer.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvExpenseTransfer.Location = new System.Drawing.Point(6, 32);
            this.dgvExpenseTransfer.Name = "dgvExpenseTransfer";
            this.dgvExpenseTransfer.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvExpenseTransfer.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvExpenseTransfer.RowHeadersVisible = false;
            this.dgvExpenseTransfer.SecondaryLength = 2;
            this.dgvExpenseTransfer.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvExpenseTransfer.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvExpenseTransfer.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvExpenseTransfer.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvExpenseTransfer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenseTransfer.Size = new System.Drawing.Size(1065, 580);
            this.dgvExpenseTransfer.TabIndex = 40;
            this.dgvExpenseTransfer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvExpenseTransfer_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(6, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 42;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(106, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 43;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // btnNonFinish
            // 
            this.btnNonFinish.BackColor = System.Drawing.Color.LightGray;
            this.btnNonFinish.ForeColor = System.Drawing.Color.Black;
            this.btnNonFinish.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnNonFinish.Location = new System.Drawing.Point(510, 3);
            this.btnNonFinish.Name = "btnNonFinish";
            this.btnNonFinish.Size = new System.Drawing.Size(94, 23);
            this.btnNonFinish.TabIndex = 44;
            this.btnNonFinish.Text = "Non-Finished";
            this.btnNonFinish.Visible = false;
            this.btnNonFinish.Click += new System.EventHandler(this.btnNonFinish_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.LightGray;
            this.btnTemplate.ForeColor = System.Drawing.Color.Black;
            this.btnTemplate.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnTemplate.Location = new System.Drawing.Point(206, 3);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(94, 23);
            this.btnTemplate.TabIndex = 45;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "etid";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            this.id.Width = 25;
            // 
            // date
            // 
            this.date.DataPropertyName = "etdate";
            this.date.HeaderText = "DATE";
            this.date.Name = "date";
            this.date.Width = 58;
            // 
            // incharge
            // 
            this.incharge.DataPropertyName = "etincharge";
            this.incharge.HeaderText = "I/C";
            this.incharge.Name = "incharge";
            this.incharge.Width = 48;
            // 
            // asset
            // 
            this.asset.DataPropertyName = "etasset";
            this.asset.HeaderText = "ASSET";
            this.asset.Name = "asset";
            this.asset.Width = 63;
            // 
            // partno
            // 
            this.partno.DataPropertyName = "etitemcode";
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            this.partno.Width = 81;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "etrev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.Width = 52;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "etmouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.Width = 96;
            // 
            // type
            // 
            this.type.DataPropertyName = "ettype";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.Width = 57;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "etmouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.Width = 106;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "etcurrency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            this.currency.Width = 88;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "etamount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.Width = 81;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "etvendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.Width = 77;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "etvendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.Width = 112;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "etchaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.Width = 89;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "etremarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.Width = 83;
            // 
            // po
            // 
            this.po.DataPropertyName = "etpo";
            this.po.HeaderText = "PO";
            this.po.Name = "po";
            this.po.Width = 48;
            // 
            // issued
            // 
            this.issued.DataPropertyName = "etissued";
            this.issued.HeaderText = "ISSUED";
            this.issued.Name = "issued";
            this.issued.Width = 70;
            // 
            // instock
            // 
            this.instock.DataPropertyName = "etinstock";
            this.instock.HeaderText = "IN STOCK";
            this.instock.Name = "instock";
            this.instock.Width = 82;
            // 
            // debitnote
            // 
            this.debitnote.DataPropertyName = "etdebit";
            this.debitnote.HeaderText = "DEBIT NOTE";
            this.debitnote.Name = "debitnote";
            this.debitnote.Width = 95;
            // 
            // sales
            // 
            this.sales.DataPropertyName = "etsales";
            this.sales.HeaderText = "FA SALES";
            this.sales.Name = "sales";
            this.sales.Width = 77;
            // 
            // ringi
            // 
            this.ringi.DataPropertyName = "etringi";
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.Width = 63;
            // 
            // finish
            // 
            this.finish.DataPropertyName = "etfinish";
            this.finish.HeaderText = "FINISH";
            this.finish.Name = "finish";
            this.finish.Width = 68;
            // 
            // epsonno
            // 
            this.epsonno.DataPropertyName = "etepsonno";
            this.epsonno.HeaderText = "EPSON NO.";
            this.epsonno.Name = "epsonno";
            this.epsonno.Width = 91;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(306, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 46;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucExpenseTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnNonFinish);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvExpenseTransfer);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucExpenseTransfer";
            this.Size = new System.Drawing.Size(1077, 646);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenseTransfer)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvExpenseTransfer;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.ComponentModel.BackgroundWorker worker;
        private CustomUtil.controls.button.CustomButton btnNonFinish;
        private CustomUtil.controls.button.CustomButton btnTemplate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn incharge;
        private System.Windows.Forms.DataGridViewTextBoxColumn asset;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn issued;
        private System.Windows.Forms.DataGridViewTextBoxColumn instock;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitnote;
        private System.Windows.Forms.DataGridViewTextBoxColumn sales;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn finish;
        private System.Windows.Forms.DataGridViewTextBoxColumn epsonno;
        private CustomUtil.controls.button.CustomButton btnSave;
    }
}
