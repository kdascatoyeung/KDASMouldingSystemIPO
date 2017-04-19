namespace Mould_System.forms._1.quotation
{
    partial class ucCustomViewCn
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
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.btnRefresh = new CustomUtil.controls.button.CustomButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new CustomUtil.controls.button.CustomButton();
            this.cbCriteria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCustomview = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.quostatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemasset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costcentre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmpFa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.projecttext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.request = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.instock50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cav = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instockremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ismodify = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vnonly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.camounttotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccndownload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csenddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomview)).BeginInit();
            this.SuspendLayout();
            // 
            // cbStatus
            // 
            this.cbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(988, 3);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(153, 23);
            this.cbStatus.TabIndex = 28;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            this.cbStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(401, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 27;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.LightGray;
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRefresh.Location = new System.Drawing.Point(501, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 23);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(988, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(153, 23);
            this.txtSearch.TabIndex = 25;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Chase No.",
            "Mould No.",
            "Part No.",
            "Vendor Code",
            "Fixed Asset Code",
            "Ringi",
            "PO",
            "Issued Date",
            "In Stock 50%",
            "In Stock Date",
            "Quotation Status",
            "OEM Asset"});
            this.cbSearch.Location = new System.Drawing.Point(850, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 24;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            this.cbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSearch.Location = new System.Drawing.Point(221, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(174, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Criteria Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbCriteria
            // 
            this.cbCriteria.FormattingEnabled = true;
            this.cbCriteria.Location = new System.Drawing.Point(58, 3);
            this.cbCriteria.Name = "cbCriteria";
            this.cbCriteria.Size = new System.Drawing.Size(157, 23);
            this.cbCriteria.TabIndex = 22;
            this.cbCriteria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Criteria";
            // 
            // dgvCustomview
            // 
            this.dgvCustomview.AllowUserToAddRows = false;
            this.dgvCustomview.AllowUserToDeleteRows = false;
            this.dgvCustomview.AllowUserToResizeRows = false;
            this.dgvCustomview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCustomview.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCustomview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCustomview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomview.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomview.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvCustomview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quostatus,
            this.oemasset,
            this.category,
            this.itemtext,
            this.accountcode,
            this.costcentre,
            this.tmpFa,
            this.fa,
            this.ringi,
            this.chaseno,
            this.projecttext,
            this.vendor,
            this.vendorname,
            this.group,
            this.model,
            this.itemcode,
            this.rev,
            this.mouldno,
            this.status,
            this.colType,
            this.mouldcode,
            this.currency,
            this.amount,
            this.amounthkd,
            this.pcs,
            this.remarks,
            this.request,
            this.po,
            this.porev,
            this.issued,
            this.mpa,
            this.instock50,
            this.instock,
            this.checkdate,
            this.cav,
            this.weight,
            this.equipment,
            this.shot,
            this.length,
            this.width,
            this.height,
            this.instockremarks,
            this.createdby,
            this.created,
            this.ismodify,
            this.vnonly,
            this.camounttotal,
            this.ccndownload,
            this.csenddate});
            this.dgvCustomview.Location = new System.Drawing.Point(3, 28);
            this.dgvCustomview.Name = "dgvCustomview";
            this.dgvCustomview.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvCustomview.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvCustomview.ReadOnly = true;
            this.dgvCustomview.RowHeadersVisible = false;
            this.dgvCustomview.SecondaryLength = 2;
            this.dgvCustomview.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvCustomview.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvCustomview.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvCustomview.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvCustomview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomview.Size = new System.Drawing.Size(1138, 607);
            this.dgvCustomview.TabIndex = 29;
            this.dgvCustomview.VirtualMode = true;
            this.dgvCustomview.Visible = false;
            // 
            // quostatus
            // 
            this.quostatus.DataPropertyName = "status";
            this.quostatus.HeaderText = "QUOTATION STATUS";
            this.quostatus.Name = "quostatus";
            this.quostatus.ReadOnly = true;
            this.quostatus.Width = 124;
            // 
            // oemasset
            // 
            this.oemasset.DataPropertyName = "oemasset";
            this.oemasset.HeaderText = "OEM ASSET";
            this.oemasset.Name = "oemasset";
            this.oemasset.ReadOnly = true;
            this.oemasset.Width = 85;
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "CATEGORY";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            this.category.Width = 87;
            // 
            // itemtext
            // 
            this.itemtext.DataPropertyName = "itemtext";
            this.itemtext.HeaderText = "ITEM TEXT";
            this.itemtext.Name = "itemtext";
            this.itemtext.ReadOnly = true;
            this.itemtext.Width = 80;
            // 
            // accountcode
            // 
            this.accountcode.DataPropertyName = "accountcode";
            this.accountcode.HeaderText = "ACCOUNT CODE";
            this.accountcode.Name = "accountcode";
            this.accountcode.ReadOnly = true;
            this.accountcode.Width = 107;
            // 
            // costcentre
            // 
            this.costcentre.DataPropertyName = "costcentre";
            this.costcentre.HeaderText = "COST CENTRE";
            this.costcentre.Name = "costcentre";
            this.costcentre.ReadOnly = true;
            this.costcentre.Width = 95;
            // 
            // tmpFa
            // 
            this.tmpFa.DataPropertyName = "tmpfac";
            this.tmpFa.HeaderText = "FA (TEMP)";
            this.tmpFa.Name = "tmpFa";
            this.tmpFa.ReadOnly = true;
            this.tmpFa.Width = 79;
            // 
            // fa
            // 
            this.fa.DataPropertyName = "fac";
            this.fa.HeaderText = "FA";
            this.fa.Name = "fa";
            this.fa.ReadOnly = true;
            this.fa.Width = 44;
            // 
            // ringi
            // 
            this.ringi.DataPropertyName = "ringi";
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.ReadOnly = true;
            this.ringi.Width = 63;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            this.chaseno.Width = 82;
            // 
            // projecttext
            // 
            this.projecttext.DataPropertyName = "projecttext";
            this.projecttext.HeaderText = "PROJECT TEXT";
            this.projecttext.Name = "projecttext";
            this.projecttext.ReadOnly = true;
            this.projecttext.Width = 97;
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
            this.group.HeaderText = "I/C";
            this.group.Name = "group";
            this.group.ReadOnly = true;
            this.group.Width = 48;
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "MODEL";
            this.model.Name = "model";
            this.model.ReadOnly = true;
            this.model.Width = 71;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "PART NO.";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            this.itemcode.Width = 75;
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
            this.status.DataPropertyName = "div";
            this.status.HeaderText = "DIV.";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 53;
            // 
            // colType
            // 
            this.colType.DataPropertyName = "type";
            this.colType.HeaderText = "TYPE";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 57;
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
            this.amounthkd.Width = 106;
            // 
            // pcs
            // 
            this.pcs.DataPropertyName = "pcs";
            this.pcs.HeaderText = "PCS";
            this.pcs.Name = "pcs";
            this.pcs.ReadOnly = true;
            this.pcs.Width = 52;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 83;
            // 
            // request
            // 
            this.request.DataPropertyName = "purchaserequest";
            this.request.HeaderText = "REQUEST";
            this.request.Name = "request";
            this.request.ReadOnly = true;
            this.request.Width = 80;
            // 
            // po
            // 
            this.po.DataPropertyName = "pono";
            this.po.HeaderText = "PO";
            this.po.Name = "po";
            this.po.ReadOnly = true;
            this.po.Width = 48;
            // 
            // porev
            // 
            this.porev.DataPropertyName = "porev";
            this.porev.HeaderText = "PO REV";
            this.porev.Name = "porev";
            this.porev.ReadOnly = true;
            this.porev.Width = 66;
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
            this.mpa.HeaderText = "MPA";
            this.mpa.Name = "mpa";
            this.mpa.ReadOnly = true;
            this.mpa.Width = 37;
            // 
            // instock50
            // 
            this.instock50.DataPropertyName = "instock50";
            this.instock50.HeaderText = "IN STOCK 50%";
            this.instock50.Name = "instock50";
            this.instock50.ReadOnly = true;
            this.instock50.Width = 99;
            // 
            // instock
            // 
            this.instock.DataPropertyName = "instockdate";
            this.instock.HeaderText = "IN STOCK";
            this.instock.Name = "instock";
            this.instock.ReadOnly = true;
            this.instock.Width = 76;
            // 
            // checkdate
            // 
            this.checkdate.DataPropertyName = "checkdate";
            this.checkdate.HeaderText = "CHECK DATE";
            this.checkdate.Name = "checkdate";
            this.checkdate.ReadOnly = true;
            this.checkdate.Width = 88;
            // 
            // cav
            // 
            this.cav.DataPropertyName = "cav";
            this.cav.HeaderText = "CAV";
            this.cav.Name = "cav";
            this.cav.ReadOnly = true;
            this.cav.Width = 52;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "WEIGHT";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 76;
            // 
            // equipment
            // 
            this.equipment.DataPropertyName = "Equipment";
            this.equipment.HeaderText = "EQUIPMENT";
            this.equipment.Name = "equipment";
            this.equipment.ReadOnly = true;
            this.equipment.Width = 97;
            // 
            // shot
            // 
            this.shot.DataPropertyName = "Shot";
            this.shot.HeaderText = "SHOT";
            this.shot.Name = "shot";
            this.shot.ReadOnly = true;
            this.shot.Width = 61;
            // 
            // length
            // 
            this.length.DataPropertyName = "length";
            this.length.HeaderText = "LENGTH";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            this.length.Width = 73;
            // 
            // width
            // 
            this.width.DataPropertyName = "width";
            this.width.HeaderText = "WIDTH";
            this.width.Name = "width";
            this.width.ReadOnly = true;
            this.width.Width = 70;
            // 
            // height
            // 
            this.height.DataPropertyName = "height";
            this.height.HeaderText = "HEIGHT";
            this.height.Name = "height";
            this.height.ReadOnly = true;
            this.height.Width = 72;
            // 
            // instockremarks
            // 
            this.instockremarks.DataPropertyName = "instockremarks";
            this.instockremarks.HeaderText = "IN STOCK REMARKS";
            this.instockremarks.Name = "instockremarks";
            this.instockremarks.ReadOnly = true;
            this.instockremarks.Width = 124;
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
            // ismodify
            // 
            this.ismodify.DataPropertyName = "ismodify";
            this.ismodify.HeaderText = "IS MODIFY";
            this.ismodify.Name = "ismodify";
            this.ismodify.ReadOnly = true;
            this.ismodify.Width = 82;
            // 
            // vnonly
            // 
            this.vnonly.DataPropertyName = "vnonly";
            this.vnonly.HeaderText = "VN ONLY";
            this.vnonly.Name = "vnonly";
            this.vnonly.ReadOnly = true;
            this.vnonly.Width = 71;
            // 
            // camounttotal
            // 
            this.camounttotal.DataPropertyName = "total";
            this.camounttotal.HeaderText = "TOTAL";
            this.camounttotal.Name = "camounttotal";
            this.camounttotal.ReadOnly = true;
            this.camounttotal.Width = 64;
            // 
            // ccndownload
            // 
            this.ccndownload.DataPropertyName = "cnsend";
            this.ccndownload.HeaderText = "CN SEND";
            this.ccndownload.Name = "ccndownload";
            this.ccndownload.ReadOnly = true;
            this.ccndownload.Width = 72;
            // 
            // csenddate
            // 
            this.csenddate.DataPropertyName = "cnreturn";
            this.csenddate.HeaderText = "CN RETURN";
            this.csenddate.Name = "csenddate";
            this.csenddate.ReadOnly = true;
            this.csenddate.Width = 85;
            // 
            // ucCustomViewCn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.dgvCustomview);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cbCriteria);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucCustomViewCn";
            this.Size = new System.Drawing.Size(1144, 638);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbStatus;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.button.CustomButton btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnSearch;
        private System.Windows.Forms.ComboBox cbCriteria;
        private System.Windows.Forms.Label label1;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvCustomview;
        private System.Windows.Forms.DataGridViewTextBoxColumn quostatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemasset;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtext;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn costcentre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmpFa;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn projecttext;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcs;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn request;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn porev;
        private System.Windows.Forms.DataGridViewTextBoxColumn issued;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn instock50;
        private System.Windows.Forms.DataGridViewTextBoxColumn instock;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cav;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn shot;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn width;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewTextBoxColumn instockremarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdby;
        private System.Windows.Forms.DataGridViewTextBoxColumn created;
        private System.Windows.Forms.DataGridViewTextBoxColumn ismodify;
        private System.Windows.Forms.DataGridViewTextBoxColumn vnonly;
        private System.Windows.Forms.DataGridViewTextBoxColumn camounttotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccndownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn csenddate;

    }
}
