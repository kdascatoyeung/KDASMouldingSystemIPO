namespace Mould_System.forms._1.quotation
{
    partial class ucQuotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuotation));
            this.btnNew = new CustomUtil.controls.button.CustomButton();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvQuotation = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quostatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.qstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdcstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemasset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.common = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCommon = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.dELETEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnTemplate = new CustomUtil.controls.button.CustomButton();
            this.btnInsert = new CustomUtil.controls.button.CustomButton();
            this.customPanel1 = new CustomUtil.controls.panel.CustomPanel();
            this.customPanel2 = new CustomUtil.controls.panel.CustomPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotation)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.customPanel1.SuspendLayout();
            this.customPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.LightGray;
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(94, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(813, 4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 2;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            this.cbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSearch_KeyPress);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(951, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgvQuotation
            // 
            this.dgvQuotation.AllowUserToAddRows = false;
            this.dgvQuotation.AllowUserToDeleteRows = false;
            this.dgvQuotation.AllowUserToResizeRows = false;
            this.dgvQuotation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuotation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvQuotation.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvQuotation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQuotation.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvQuotation.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvQuotation.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvQuotation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuotation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.quostatus,
            this.chaseno,
            this.vendor,
            this.vendorname,
            this.group,
            this.itemcode,
            this.rev,
            this.mouldno,
            this.status,
            this.type,
            this.mouldcode,
            this.currency,
            this.amount,
            this.amounthkd,
            this.mpa,
            this.qstatus,
            this.kdcstatus,
            this.oemasset,
            this.remarks,
            this.common,
            this.createdby,
            this.created});
            this.dgvQuotation.ContextMenuStrip = this.contextMenuStrip;
            this.dgvQuotation.Location = new System.Drawing.Point(0, 32);
            this.dgvQuotation.Name = "dgvQuotation";
            this.dgvQuotation.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvQuotation.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvQuotation.ReadOnly = true;
            this.dgvQuotation.RowHeadersVisible = false;
            this.dgvQuotation.SecondaryLength = 2;
            this.dgvQuotation.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvQuotation.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvQuotation.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvQuotation.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvQuotation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuotation.Size = new System.Drawing.Size(1077, 585);
            this.dgvQuotation.TabIndex = 4;
            this.dgvQuotation.DoubleClick += new System.EventHandler(this.dgvQuotation_DoubleClick);
            this.dgvQuotation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvQuotation_MouseDown);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "ID";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 25;
            // 
            // quostatus
            // 
            this.quostatus.DataPropertyName = "quostatus";
            this.quostatus.HeaderText = "QUOTATION STATUS";
            this.quostatus.Name = "quostatus";
            this.quostatus.ReadOnly = true;
            this.quostatus.Width = 124;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            this.chaseno.Width = 82;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            this.vendor.Width = 77;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            this.vendorname.Width = 103;
            // 
            // group
            // 
            this.group.DataPropertyName = "pgroup";
            this.group.HeaderText = "GT CODE";
            this.group.Name = "group";
            this.group.ReadOnly = true;
            this.group.Width = 73;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "ITEM CODE";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            this.itemcode.Width = 85;
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
            this.mouldno.Width = 88;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "DIV.";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 53;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
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
            this.mouldcode.Width = 97;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            this.currency.Width = 88;
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
            // mpa
            // 
            this.mpa.DataPropertyName = "mpa";
            this.mpa.HeaderText = "MPA";
            this.mpa.Name = "mpa";
            this.mpa.ReadOnly = true;
            this.mpa.Width = 37;
            // 
            // qstatus
            // 
            this.qstatus.DataPropertyName = "qstatus";
            this.qstatus.HeaderText = "QSTATUS";
            this.qstatus.Name = "qstatus";
            this.qstatus.ReadOnly = true;
            this.qstatus.Visible = false;
            this.qstatus.Width = 78;
            // 
            // kdcstatus
            // 
            this.kdcstatus.DataPropertyName = "kdcstatus";
            this.kdcstatus.HeaderText = "KDC STATUS";
            this.kdcstatus.Name = "kdcstatus";
            this.kdcstatus.ReadOnly = true;
            this.kdcstatus.Width = 87;
            // 
            // oemasset
            // 
            this.oemasset.DataPropertyName = "oemasset";
            this.oemasset.HeaderText = "OEM ASSET";
            this.oemasset.Name = "oemasset";
            this.oemasset.ReadOnly = true;
            this.oemasset.Width = 85;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 83;
            // 
            // common
            // 
            this.common.DataPropertyName = "common";
            this.common.HeaderText = "COMMON";
            this.common.Name = "common";
            this.common.ReadOnly = true;
            this.common.Width = 87;
            // 
            // createdby
            // 
            this.createdby.DataPropertyName = "createdby";
            this.createdby.HeaderText = "CREATED BY";
            this.createdby.Name = "createdby";
            this.createdby.ReadOnly = true;
            this.createdby.Width = 87;
            // 
            // created
            // 
            this.created.DataPropertyName = "created";
            this.created.HeaderText = "CREATED";
            this.created.Name = "created";
            this.created.ReadOnly = true;
            this.created.Width = 78;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuModify,
            this.menuSet,
            this.menuCommon,
            this.menuDetail,
            this.dELETEToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(214, 114);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // menuModify
            // 
            this.menuModify.Name = "menuModify";
            this.menuModify.Size = new System.Drawing.Size(213, 22);
            this.menuModify.Text = "MODIFY";
            this.menuModify.Click += new System.EventHandler(this.menuModify_Click);
            // 
            // menuSet
            // 
            this.menuSet.Name = "menuSet";
            this.menuSet.Size = new System.Drawing.Size(213, 22);
            this.menuSet.Text = "SET OR COMMON MOULD";
            this.menuSet.Click += new System.EventHandler(this.menuSet_Click);
            // 
            // menuCommon
            // 
            this.menuCommon.Enabled = false;
            this.menuCommon.Name = "menuCommon";
            this.menuCommon.Size = new System.Drawing.Size(213, 22);
            this.menuCommon.Text = "COMMON MOULD";
            this.menuCommon.Visible = false;
            this.menuCommon.Click += new System.EventHandler(this.menuCommon_Click);
            // 
            // menuDetail
            // 
            this.menuDetail.Name = "menuDetail";
            this.menuDetail.Size = new System.Drawing.Size(213, 22);
            this.menuDetail.Text = "MOULD DETAIL";
            this.menuDetail.Click += new System.EventHandler(this.menuDetail_Click);
            // 
            // dELETEToolStripMenuItem
            // 
            this.dELETEToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dELETEToolStripMenuItem.Image")));
            this.dELETEToolStripMenuItem.Name = "dELETEToolStripMenuItem";
            this.dELETEToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.dELETEToolStripMenuItem.Text = "DELETE";
            this.dELETEToolStripMenuItem.Click += new System.EventHandler(this.dELETEToolStripMenuItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 620);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 19);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Unknown";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(3, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 10;
            this.btnUpload.Text = "Update";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.LightGray;
            this.btnTemplate.ForeColor = System.Drawing.Color.Black;
            this.btnTemplate.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnTemplate.Location = new System.Drawing.Point(103, 3);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(94, 23);
            this.btnTemplate.TabIndex = 11;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.LightGray;
            this.btnInsert.ForeColor = System.Drawing.Color.Black;
            this.btnInsert.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnInsert.Location = new System.Drawing.Point(103, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(94, 23);
            this.btnInsert.TabIndex = 12;
            this.btnInsert.Text = "Upload";
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // customPanel1
            // 
            this.customPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel1.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel1.BorderColor = System.Drawing.Color.Silver;
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.BorderWidth = 1;
            this.customPanel1.Controls.Add(this.btnNew);
            this.customPanel1.Controls.Add(this.btnInsert);
            this.customPanel1.Curvature = 1;
            this.customPanel1.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel1.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel1.Location = new System.Drawing.Point(2, 1);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(200, 29);
            this.customPanel1.TabIndex = 13;
            // 
            // customPanel2
            // 
            this.customPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.customPanel2.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanel2.BorderColor = System.Drawing.Color.Silver;
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.BorderWidth = 1;
            this.customPanel2.Controls.Add(this.btnUpload);
            this.customPanel2.Controls.Add(this.btnTemplate);
            this.customPanel2.Curvature = 1;
            this.customPanel2.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanel2.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanel2.Location = new System.Drawing.Point(208, 1);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(200, 29);
            this.customPanel2.TabIndex = 14;
            // 
            // ucQuotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.customPanel2);
            this.Controls.Add(this.customPanel1);
            this.Controls.Add(this.dgvQuotation);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucQuotation";
            this.Size = new System.Drawing.Size(1077, 646);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuotation)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.customPanel1.ResumeLayout(false);
            this.customPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.button.CustomButton btnNew;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvQuotation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuModify;
        private System.Windows.Forms.ToolStripMenuItem menuSet;
        private System.Windows.Forms.ToolStripMenuItem menuCommon;
        private System.Windows.Forms.ToolStripMenuItem menuDetail;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripMenuItem dELETEToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn quostatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn qstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdcstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemasset;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn common;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdby;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnTemplate;
        private CustomUtil.controls.button.CustomButton btnInsert;
        private CustomUtil.controls.panel.CustomPanel customPanel1;
        private CustomUtil.controls.panel.CustomPanel customPanel2;
    }
}
