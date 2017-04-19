namespace Mould_System.forms._5.reporting
{
    partial class ucPoCollection
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
            this.dgvPoCollection = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.dpSearch = new System.Windows.Forms.DateTimePicker();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.passstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collectdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cporev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoCollection)).BeginInit();
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
            this.lblTotal.TabIndex = 18;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvPoCollection
            // 
            this.dgvPoCollection.AllowUserToAddRows = false;
            this.dgvPoCollection.AllowUserToDeleteRows = false;
            this.dgvPoCollection.AllowUserToResizeRows = false;
            this.dgvPoCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPoCollection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPoCollection.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPoCollection.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPoCollection.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPoCollection.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvPoCollection.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvPoCollection.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPoCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoCollection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.passstatus,
            this.passdate,
            this.collectdate,
            this.vendor,
            this.vendorname,
            this.ic,
            this.model,
            this.partno,
            this.rev,
            this.mouldno,
            this.type,
            this.mouldcode,
            this.currency,
            this.amount,
            this.amounthkd,
            this.remarks,
            this.itemtext,
            this.fac,
            this.chaseno,
            this.po,
            this.cporev,
            this.status,
            this.issued,
            this.mpa,
            this.coem});
            this.dgvPoCollection.Location = new System.Drawing.Point(7, 32);
            this.dgvPoCollection.Name = "dgvPoCollection";
            this.dgvPoCollection.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvPoCollection.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvPoCollection.ReadOnly = true;
            this.dgvPoCollection.RowHeadersVisible = false;
            this.dgvPoCollection.SecondaryLength = 2;
            this.dgvPoCollection.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvPoCollection.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvPoCollection.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvPoCollection.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvPoCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoCollection.Size = new System.Drawing.Size(1064, 580);
            this.dgvPoCollection.TabIndex = 17;
            // 
            // dpSearch
            // 
            this.dpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dpSearch.CustomFormat = "yyyy.MM";
            this.dpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpSearch.Location = new System.Drawing.Point(966, 3);
            this.dpSearch.Name = "dpSearch";
            this.dpSearch.Size = new System.Drawing.Size(105, 23);
            this.dpSearch.TabIndex = 20;
            this.dpSearch.Visible = false;
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Issued Month"});
            this.cbSearch.Location = new System.Drawing.Point(829, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(131, 23);
            this.cbSearch.TabIndex = 19;
            this.cbSearch.Visible = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(7, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 21;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(107, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 22;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // passstatus
            // 
            this.passstatus.DataPropertyName = "passstatus";
            this.passstatus.HeaderText = "仕樣書狀況";
            this.passstatus.Name = "passstatus";
            this.passstatus.ReadOnly = true;
            this.passstatus.Width = 92;
            // 
            // passdate
            // 
            this.passdate.DataPropertyName = "passdate";
            this.passdate.HeaderText = "合格日";
            this.passdate.Name = "passdate";
            this.passdate.ReadOnly = true;
            this.passdate.Width = 68;
            // 
            // collectdate
            // 
            this.collectdate.DataPropertyName = "collectdate";
            this.collectdate.HeaderText = "予定回收日";
            this.collectdate.Name = "collectdate";
            this.collectdate.ReadOnly = true;
            this.collectdate.Width = 92;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendorcode";
            this.vendor.HeaderText = "VENDOR CODE";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.Width = 110;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            this.vendorname.Width = 112;
            // 
            // ic
            // 
            this.ic.DataPropertyName = "ic";
            this.ic.HeaderText = "I/C";
            this.ic.Name = "ic";
            this.ic.ReadOnly = true;
            this.ic.Width = 48;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "MODEL";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Width = 71;
            // 
            // partno
            // 
            this.partno.DataPropertyName = "itemcode";
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            this.partno.ReadOnly = true;
            this.partno.Width = 81;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            this.rev.Width = 52;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            this.mouldno.Width = 96;
            // 
            // type
            // 
            this.type.DataPropertyName = "status";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 57;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.ReadOnly = true;
            this.mouldcode.Width = 106;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CUR";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Width = 54;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 81;
            // 
            // amounthkd
            // 
            this.amounthkd.DataPropertyName = "amounthkd";
            this.amounthkd.HeaderText = "AMOUNT (HKD)";
            this.amounthkd.Name = "amounthkd";
            this.amounthkd.ReadOnly = true;
            this.amounthkd.Width = 105;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 83;
            // 
            // itemtext
            // 
            this.itemtext.DataPropertyName = "itemtext";
            this.itemtext.HeaderText = "ITEM TEXT";
            this.itemtext.Name = "itemtext";
            this.itemtext.ReadOnly = true;
            this.itemtext.Width = 80;
            // 
            // fac
            // 
            this.fac.DataPropertyName = "fac";
            this.fac.HeaderText = "FA";
            this.fac.Name = "fac";
            this.fac.ReadOnly = true;
            this.fac.Width = 44;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            this.chaseno.Width = 82;
            // 
            // po
            // 
            this.po.DataPropertyName = "pono";
            this.po.HeaderText = "PO";
            this.po.Name = "po";
            this.po.ReadOnly = true;
            this.po.Width = 48;
            // 
            // cporev
            // 
            this.cporev.DataPropertyName = "porev";
            this.cporev.HeaderText = "POREV";
            this.cporev.Name = "cporev";
            this.cporev.ReadOnly = true;
            this.cporev.Width = 68;
            // 
            // status
            // 
            this.status.DataPropertyName = "stname";
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 69;
            // 
            // issued
            // 
            this.issued.DataPropertyName = "issued";
            this.issued.HeaderText = "ISSUED";
            this.issued.Name = "issued";
            this.issued.ReadOnly = true;
            this.issued.Width = 70;
            // 
            // mpa
            // 
            this.mpa.DataPropertyName = "mpa";
            this.mpa.HeaderText = "INSTOCK50%";
            this.mpa.Name = "mpa";
            this.mpa.ReadOnly = true;
            this.mpa.Width = 102;
            // 
            // coem
            // 
            this.coem.DataPropertyName = "oem";
            this.coem.HeaderText = "OEM";
            this.coem.Name = "coem";
            this.coem.ReadOnly = true;
            this.coem.Width = 58;
            // 
            // ucPoCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.dpSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvPoCollection);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPoCollection";
            this.Size = new System.Drawing.Size(1077, 646);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoCollection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvPoCollection;
        private System.Windows.Forms.DateTimePicker dpSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.DataGridViewTextBoxColumn passstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn passdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn collectdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ic;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtext;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn cporev;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn issued;
        private System.Windows.Forms.DataGridViewTextBoxColumn mpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn coem;
    }
}
