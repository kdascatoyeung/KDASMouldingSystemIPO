namespace Mould_System.forms._3.disposal
{
    partial class ucDisposalView
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
            this.dgvDisposalDetail = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.btnDelete = new CustomUtil.controls.button.CustomButton();
            this.cid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disposaltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2003no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2003ans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2003result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2003update = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2004no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2004ans = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2004result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.p2004update = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdcno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colkdcissued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdcrps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdcseisan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdcresult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kdcupdated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assetdesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquishkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accumhkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingmonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookhkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookhkd2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disposalringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportissued = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportreceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorresult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fadisposal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposalDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDisposalDetail
            // 
            this.dgvDisposalDetail.AllowUserToAddRows = false;
            this.dgvDisposalDetail.AllowUserToDeleteRows = false;
            this.dgvDisposalDetail.AllowUserToResizeRows = false;
            this.dgvDisposalDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDisposalDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDisposalDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDisposalDetail.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvDisposalDetail.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvDisposalDetail.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDisposalDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisposalDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cid,
            this.disposaltype,
            this.status,
            this.mouldno,
            this.partno,
            this.rev,
            this.fa,
            this.vendorcode,
            this.vendorname,
            this.p2003no,
            this.p2003ans,
            this.p2003result,
            this.p2003update,
            this.p2004no,
            this.p2004ans,
            this.p2004result,
            this.p2004update,
            this.kdcno,
            this.colkdcissued,
            this.kdcrps,
            this.kdcseisan,
            this.kdcresult,
            this.kdcupdated,
            this.assetdesc,
            this.capdate,
            this.acquishkd,
            this.accumhkd,
            this.closingmonth,
            this.bookhkd,
            this.fy,
            this.bookhkd2,
            this.disposalringi,
            this.reportno,
            this.reportissued,
            this.reportreceived,
            this.vendorresult,
            this.fadisposal,
            this.remarks});
            this.dgvDisposalDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDisposalDetail.Location = new System.Drawing.Point(3, 32);
            this.dgvDisposalDetail.Name = "dgvDisposalDetail";
            this.dgvDisposalDetail.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDisposalDetail.RowHeadersWidth = 20;
            this.dgvDisposalDetail.SecondaryLength = 2;
            this.dgvDisposalDetail.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDisposalDetail.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDisposalDetail.Size = new System.Drawing.Size(1084, 609);
            this.dgvDisposalDetail.TabIndex = 13;
            this.dgvDisposalDetail.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisposalDetail_CellEndEdit);
            this.dgvDisposalDetail.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDisposalDetail_RowHeaderMouseClick);
            this.dgvDisposalDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDisposalDetail_KeyDown);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(3, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(967, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSearch_MouseDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Mould",
            "Part No.",
            "Fixed Asset",
            "Vendor Code",
            "Vendor Name",
            "Report No."});
            this.cbSearch.Location = new System.Drawing.Point(829, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 18;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            this.cbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSearch_KeyPress);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(103, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 20;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightGray;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDelete.Location = new System.Drawing.Point(203, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 23);
            this.btnDelete.TabIndex = 21;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cid
            // 
            this.cid.DataPropertyName = "id";
            this.cid.HeaderText = "id";
            this.cid.Name = "cid";
            this.cid.Visible = false;
            this.cid.Width = 43;
            // 
            // disposaltype
            // 
            this.disposaltype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.disposaltype.DataPropertyName = "disposaltype";
            this.disposaltype.FillWeight = 120F;
            this.disposaltype.HeaderText = "廢棄類別";
            this.disposaltype.Name = "disposaltype";
            this.disposaltype.Width = 63;
            // 
            // status
            // 
            this.status.DataPropertyName = "qstatus";
            this.status.FillWeight = 130F;
            this.status.HeaderText = "狀態";
            this.status.Name = "status";
            this.status.Width = 52;
            // 
            // mouldno
            // 
            this.mouldno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "金型番號";
            this.mouldno.Name = "mouldno";
            this.mouldno.Width = 63;
            // 
            // partno
            // 
            this.partno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.partno.DataPropertyName = "itemcode";
            this.partno.HeaderText = "品番";
            this.partno.Name = "partno";
            this.partno.Width = 52;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "Rev";
            this.rev.Name = "rev";
            this.rev.Width = 51;
            // 
            // fa
            // 
            this.fa.DataPropertyName = "facode";
            this.fa.HeaderText = "資產番號";
            this.fa.Name = "fa";
            this.fa.Width = 63;
            // 
            // vendorcode
            // 
            this.vendorcode.DataPropertyName = "vendor";
            this.vendorcode.HeaderText = "Vendor Code";
            this.vendorcode.Name = "vendorcode";
            this.vendorcode.Width = 92;
            // 
            // vendorname
            // 
            this.vendorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "Vendor Name";
            this.vendorname.Name = "vendorname";
            this.vendorname.Width = 5;
            // 
            // p2003no
            // 
            this.p2003no.DataPropertyName = "p2003no";
            this.p2003no.HeaderText = "P2003調查依賴書no.";
            this.p2003no.Name = "p2003no";
            this.p2003no.Width = 95;
            // 
            // p2003ans
            // 
            this.p2003ans.DataPropertyName = "p2003ans";
            this.p2003ans.HeaderText = "P2003回答";
            this.p2003ans.Name = "p2003ans";
            this.p2003ans.Width = 73;
            // 
            // p2003result
            // 
            this.p2003result.DataPropertyName = "p2003result";
            this.p2003result.HeaderText = "P2003可/不可";
            this.p2003result.Name = "p2003result";
            this.p2003result.Width = 78;
            // 
            // p2003update
            // 
            this.p2003update.DataPropertyName = "p2003updated";
            this.p2003update.HeaderText = "P2003更新日";
            this.p2003update.Name = "p2003update";
            this.p2003update.Width = 73;
            // 
            // p2004no
            // 
            this.p2004no.DataPropertyName = "p2004no";
            this.p2004no.HeaderText = "P2004調查依賴書no.";
            this.p2004no.Name = "p2004no";
            this.p2004no.Width = 95;
            // 
            // p2004ans
            // 
            this.p2004ans.DataPropertyName = "p2004ans";
            this.p2004ans.HeaderText = "P2004回答";
            this.p2004ans.Name = "p2004ans";
            this.p2004ans.Width = 73;
            // 
            // p2004result
            // 
            this.p2004result.DataPropertyName = "p2004result";
            this.p2004result.HeaderText = "P2004可/不可";
            this.p2004result.Name = "p2004result";
            this.p2004result.Width = 78;
            // 
            // p2004update
            // 
            this.p2004update.DataPropertyName = "p2004updated";
            this.p2004update.HeaderText = "P2004更新日";
            this.p2004update.Name = "p2004update";
            this.p2004update.Width = 73;
            // 
            // kdcno
            // 
            this.kdcno.DataPropertyName = "kdcno";
            this.kdcno.HeaderText = "事業部依賴書no.";
            this.kdcno.Name = "kdcno";
            this.kdcno.Width = 85;
            // 
            // colkdcissued
            // 
            this.colkdcissued.DataPropertyName = "kdcissued";
            this.colkdcissued.HeaderText = "事業部依賴日";
            this.colkdcissued.Name = "colkdcissued";
            this.colkdcissued.Width = 74;
            // 
            // kdcrps
            // 
            this.kdcrps.DataPropertyName = "kdcrps";
            this.kdcrps.HeaderText = "事業部RPS";
            this.kdcrps.Name = "kdcrps";
            this.kdcrps.Width = 81;
            // 
            // kdcseisan
            // 
            this.kdcseisan.DataPropertyName = "kdcseisan";
            this.kdcseisan.HeaderText = "事業部";
            this.kdcseisan.Name = "kdcseisan";
            this.kdcseisan.Width = 63;
            // 
            // kdcresult
            // 
            this.kdcresult.DataPropertyName = "kdcresult";
            this.kdcresult.HeaderText = "可/不可";
            this.kdcresult.Name = "kdcresult";
            this.kdcresult.Width = 57;
            // 
            // kdcupdated
            // 
            this.kdcupdated.DataPropertyName = "kdcupdated";
            this.kdcupdated.HeaderText = "事業部更新日";
            this.kdcupdated.Name = "kdcupdated";
            this.kdcupdated.Width = 74;
            // 
            // assetdesc
            // 
            this.assetdesc.DataPropertyName = "assetdesc";
            this.assetdesc.HeaderText = "Asset description";
            this.assetdesc.Name = "assetdesc";
            this.assetdesc.Width = 115;
            // 
            // capdate
            // 
            this.capdate.DataPropertyName = "capdate";
            this.capdate.HeaderText = "Cap. Date";
            this.capdate.Name = "capdate";
            this.capdate.Width = 78;
            // 
            // acquishkd
            // 
            this.acquishkd.DataPropertyName = "acquis";
            this.acquishkd.HeaderText = "Acquis.val. HKD";
            this.acquishkd.Name = "acquishkd";
            this.acquishkd.Width = 108;
            // 
            // accumhkd
            // 
            this.accumhkd.DataPropertyName = "accum";
            this.accumhkd.HeaderText = "Accum.dep. HKD";
            this.accumhkd.Name = "accumhkd";
            this.accumhkd.Width = 110;
            // 
            // closingmonth
            // 
            this.closingmonth.DataPropertyName = "cmonth";
            this.closingmonth.HeaderText = "Closing Month";
            this.closingmonth.Name = "closingmonth";
            this.closingmonth.Width = 103;
            // 
            // bookhkd
            // 
            this.bookhkd.DataPropertyName = "bookhkd";
            this.bookhkd.HeaderText = "Book val. HKD";
            this.bookhkd.Name = "bookhkd";
            this.bookhkd.Width = 78;
            // 
            // fy
            // 
            this.fy.DataPropertyName = "fy";
            this.fy.HeaderText = "Financial Year";
            this.fy.Name = "fy";
            this.fy.Width = 101;
            // 
            // bookhkd2
            // 
            this.bookhkd2.DataPropertyName = "bookhkd2";
            this.bookhkd2.HeaderText = "Book val. HKD";
            this.bookhkd2.Name = "bookhkd2";
            this.bookhkd2.Width = 78;
            // 
            // disposalringi
            // 
            this.disposalringi.DataPropertyName = "disposalringi";
            this.disposalringi.HeaderText = "廢棄稟議番號";
            this.disposalringi.Name = "disposalringi";
            this.disposalringi.Width = 74;
            // 
            // reportno
            // 
            this.reportno.DataPropertyName = "reportno";
            this.reportno.HeaderText = "報告書番號";
            this.reportno.Name = "reportno";
            this.reportno.Width = 74;
            // 
            // reportissued
            // 
            this.reportissued.DataPropertyName = "reportissued";
            this.reportissued.HeaderText = "報告書依賴日";
            this.reportissued.Name = "reportissued";
            this.reportissued.Width = 74;
            // 
            // reportreceived
            // 
            this.reportreceived.DataPropertyName = "reportreceived";
            this.reportreceived.HeaderText = "報告書回收日";
            this.reportreceived.Name = "reportreceived";
            this.reportreceived.Width = 74;
            // 
            // vendorresult
            // 
            this.vendorresult.DataPropertyName = "vendorresult";
            this.vendorresult.HeaderText = "Vendor 回答";
            this.vendorresult.Name = "vendorresult";
            this.vendorresult.Width = 78;
            // 
            // fadisposal
            // 
            this.fadisposal.DataPropertyName = "fadisposal";
            this.fadisposal.HeaderText = "資產廢棄日";
            this.fadisposal.Name = "fadisposal";
            this.fadisposal.Width = 74;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.Width = 79;
            // 
            // ucDisposalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.dgvDisposalDetail);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucDisposalView";
            this.Size = new System.Drawing.Size(1090, 644);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposalDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvDisposalDetail;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.button.CustomButton btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn cid;
        private System.Windows.Forms.DataGridViewTextBoxColumn disposaltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2003no;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2003ans;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2003result;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2003update;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2004no;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2004ans;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2004result;
        private System.Windows.Forms.DataGridViewTextBoxColumn p2004update;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdcno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colkdcissued;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdcrps;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdcseisan;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdcresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn kdcupdated;
        private System.Windows.Forms.DataGridViewTextBoxColumn assetdesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn capdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn acquishkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn accumhkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingmonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookhkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn fy;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookhkd2;
        private System.Windows.Forms.DataGridViewTextBoxColumn disposalringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportno;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportissued;
        private System.Windows.Forms.DataGridViewTextBoxColumn reportreceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn fadisposal;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
    }
}
