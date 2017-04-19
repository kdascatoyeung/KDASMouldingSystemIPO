namespace Mould_System.forms._1.quotation
{
    partial class ucApplyRingi
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
            this.btnRingiList = new CustomUtil.controls.button.CustomButton();
            this.dgvApplyRingi = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmodel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAssign = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyRingi)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(947, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(809, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 4;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // btnRingiList
            // 
            this.btnRingiList.BackColor = System.Drawing.Color.LightGray;
            this.btnRingiList.ForeColor = System.Drawing.Color.Black;
            this.btnRingiList.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRingiList.Location = new System.Drawing.Point(3, 3);
            this.btnRingiList.Name = "btnRingiList";
            this.btnRingiList.Size = new System.Drawing.Size(94, 23);
            this.btnRingiList.TabIndex = 6;
            this.btnRingiList.Text = "List";
            this.btnRingiList.Click += new System.EventHandler(this.btnRingiList_Click);
            // 
            // dgvApplyRingi
            // 
            this.dgvApplyRingi.AllowUserToAddRows = false;
            this.dgvApplyRingi.AllowUserToDeleteRows = false;
            this.dgvApplyRingi.AllowUserToResizeRows = false;
            this.dgvApplyRingi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApplyRingi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplyRingi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvApplyRingi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvApplyRingi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvApplyRingi.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvApplyRingi.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvApplyRingi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApplyRingi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplyRingi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.partno,
            this.rev,
            this.mouldno,
            this.cmodel,
            this.currency,
            this.amount,
            this.amounthkd,
            this.remarks,
            this.vendor,
            this.vendorname,
            this.group,
            this.ringi});
            this.dgvApplyRingi.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvApplyRingi.Location = new System.Drawing.Point(3, 32);
            this.dgvApplyRingi.Name = "dgvApplyRingi";
            this.dgvApplyRingi.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvApplyRingi.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvApplyRingi.ReadOnly = true;
            this.dgvApplyRingi.RowHeadersVisible = false;
            this.dgvApplyRingi.SecondaryLength = 2;
            this.dgvApplyRingi.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvApplyRingi.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvApplyRingi.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvApplyRingi.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvApplyRingi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplyRingi.Size = new System.Drawing.Size(1064, 580);
            this.dgvApplyRingi.TabIndex = 7;
            this.dgvApplyRingi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvApplyRingi_MouseDown);
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
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
            // cmodel
            // 
            this.cmodel.DataPropertyName = "model";
            this.cmodel.HeaderText = "MODEL";
            this.cmodel.Name = "cmodel";
            this.cmodel.ReadOnly = true;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
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
            this.amounthkd.HeaderText = "AMOUNT (HKD)";
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
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
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
            // group
            // 
            this.group.DataPropertyName = "pgroup";
            this.group.HeaderText = "I/C";
            this.group.Name = "group";
            this.group.ReadOnly = true;
            // 
            // ringi
            // 
            this.ringi.DataPropertyName = "ringi";
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAssign});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 26);
            // 
            // menuAssign
            // 
            this.menuAssign.Name = "menuAssign";
            this.menuAssign.Size = new System.Drawing.Size(165, 22);
            this.menuAssign.Text = "ASSIGN TO RINGI";
            this.menuAssign.Click += new System.EventHandler(this.menuAssign_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Unknown";
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(103, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 9;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // ucApplyRingi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvApplyRingi);
            this.Controls.Add(this.btnRingiList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucApplyRingi";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplyRingi)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnRingiList;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvApplyRingi;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuAssign;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cmodel;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
    }
}
