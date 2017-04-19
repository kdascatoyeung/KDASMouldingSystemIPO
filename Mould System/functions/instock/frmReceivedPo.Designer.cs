namespace Mould_System.functions.instock
{
    partial class frmReceivedPo
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
            this.dgvResult = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmpfac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instock50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCheckdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCav = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvResult.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResult.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvResult.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.po,
            this.partno,
            this.rev,
            this.mouldno,
            this.mouldcode,
            this.vendor,
            this.vendorname,
            this.tmpfac,
            this.fac,
            this.currency,
            this.amount,
            this.issued,
            this.instock50,
            this.instock,
            this.mpa,
            this.colCheckdate,
            this.colCav,
            this.colWeight,
            this.colEquipment,
            this.colShot,
            this.colLength,
            this.colWidth,
            this.colHeight});
            this.dgvResult.Location = new System.Drawing.Point(2, 31);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvResult.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvResult.RowHeadersVisible = false;
            this.dgvResult.SecondaryLength = 2;
            this.dgvResult.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvResult.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvResult.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvResult.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvResult.Size = new System.Drawing.Size(1028, 547);
            this.dgvResult.TabIndex = 47;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.Width = 89;
            // 
            // po
            // 
            this.po.DataPropertyName = "pono";
            this.po.HeaderText = "PO";
            this.po.Name = "po";
            this.po.Width = 48;
            // 
            // partno
            // 
            this.partno.DataPropertyName = "itemcode";
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            this.partno.Width = 81;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.Width = 52;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.Width = 96;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.Width = 106;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.Width = 77;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.Width = 112;
            // 
            // tmpfac
            // 
            this.tmpfac.DataPropertyName = "tmpfac";
            this.tmpfac.HeaderText = "FA (TEMP)";
            this.tmpfac.Name = "tmpfac";
            this.tmpfac.Width = 85;
            // 
            // fac
            // 
            this.fac.DataPropertyName = "fac";
            this.fac.HeaderText = "FA";
            this.fac.Name = "fac";
            this.fac.Width = 44;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            this.currency.Width = 88;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.Width = 81;
            // 
            // issued
            // 
            this.issued.DataPropertyName = "issued";
            this.issued.HeaderText = "ISSUED";
            this.issued.Name = "issued";
            this.issued.Width = 70;
            // 
            // instock50
            // 
            this.instock50.DataPropertyName = "instock50";
            this.instock50.HeaderText = "INSTOCK50";
            this.instock50.Name = "instock50";
            this.instock50.Width = 93;
            // 
            // instock
            // 
            this.instock.DataPropertyName = "instockdate";
            this.instock.HeaderText = "INSTOCK DATE";
            this.instock.Name = "instock";
            this.instock.Width = 108;
            // 
            // mpa
            // 
            this.mpa.DataPropertyName = "mpa";
            this.mpa.HeaderText = "MPA";
            this.mpa.Name = "mpa";
            this.mpa.Width = 56;
            // 
            // colCheckdate
            // 
            this.colCheckdate.DataPropertyName = "checkdate";
            this.colCheckdate.HeaderText = "CHECK DATE";
            this.colCheckdate.Name = "colCheckdate";
            this.colCheckdate.Width = 96;
            // 
            // colCav
            // 
            this.colCav.DataPropertyName = "cav";
            this.colCav.HeaderText = "CAV";
            this.colCav.Name = "colCav";
            this.colCav.Width = 52;
            // 
            // colWeight
            // 
            this.colWeight.DataPropertyName = "weight";
            this.colWeight.HeaderText = "WEIGHT";
            this.colWeight.Name = "colWeight";
            this.colWeight.Width = 76;
            // 
            // colEquipment
            // 
            this.colEquipment.DataPropertyName = "equipment";
            this.colEquipment.HeaderText = "EQUIPMENT";
            this.colEquipment.Name = "colEquipment";
            this.colEquipment.Width = 97;
            // 
            // colShot
            // 
            this.colShot.DataPropertyName = "shot";
            this.colShot.HeaderText = "SHOT";
            this.colShot.Name = "colShot";
            this.colShot.Width = 61;
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "length";
            this.colLength.HeaderText = "LENGTH";
            this.colLength.Name = "colLength";
            this.colLength.Width = 73;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "width";
            this.colWidth.HeaderText = "WIDTH";
            this.colWidth.Name = "colWidth";
            this.colWidth.Width = 70;
            // 
            // colHeight
            // 
            this.colHeight.DataPropertyName = "height";
            this.colHeight.HeaderText = "HEIGHT";
            this.colHeight.Name = "colHeight";
            this.colHeight.Width = 72;
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "All",
            "Normal 100%",
            "1st 50%",
            "2nd 50%",
            "100% (1 PO)",
            "100% (2 PO)",
            "Transfer (TM)"});
            this.cbType.Location = new System.Drawing.Point(856, 2);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(174, 23);
            this.cbType.TabIndex = 48;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(926, 588);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 49;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // frmReceivedPo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1032, 623);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.dgvResult);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReceivedPo";
            this.ShowInTaskbar = false;
            this.Text = "Received PO";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvResult;
        private System.Windows.Forms.ComboBox cbType;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmpfac;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn issued;
        private System.Windows.Forms.DataGridViewTextBoxColumn instock50;
        private System.Windows.Forms.DataGridViewTextBoxColumn instock;
        private System.Windows.Forms.DataGridViewTextBoxColumn mpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCheckdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCav;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShot;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeight;
    }
}