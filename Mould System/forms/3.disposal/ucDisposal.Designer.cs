﻿namespace Mould_System.forms._3.disposal
{
    partial class ucDisposal
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
            this.dgvDisposalDetail = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.cbDisposalStatus = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bgworker = new System.ComponentModel.BackgroundWorker();
            this.disposaltype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.final = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dgvDisposalDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDisposalDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvDisposalDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDisposalDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDisposalDetail.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvDisposalDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisposalDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.disposaltype,
            this.status,
            this.chaseno,
            this.mouldno,
            this.partno,
            this.rev,
            this.coldiv,
            this.type,
            this.amounthkd,
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
            this.final,
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
            this.dgvDisposalDetail.Location = new System.Drawing.Point(3, 38);
            this.dgvDisposalDetail.Name = "dgvDisposalDetail";
            this.dgvDisposalDetail.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDisposalDetail.ReadOnly = true;
            this.dgvDisposalDetail.RowHeadersVisible = false;
            this.dgvDisposalDetail.SecondaryLength = 2;
            this.dgvDisposalDetail.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDisposalDetail.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDisposalDetail.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDisposalDetail.Size = new System.Drawing.Size(1064, 580);
            this.dgvDisposalDetail.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(947, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.Visible = false;
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
            "Vendor",
            "Disposal No."});
            this.cbSearch.Location = new System.Drawing.Point(809, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 13;
            this.cbSearch.Visible = false;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(278, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 16;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(178, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 15;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cbDisposalStatus
            // 
            this.cbDisposalStatus.FormattingEnabled = true;
            this.cbDisposalStatus.Items.AddRange(new object[] {
            "廃棄対象",
            "調整依賴中",
            "日本生産本部確認中",
            "日本生産本部確認完了",
            "固定資産確認",
            "廃棄稟議書申請",
            "廃棄報告書発行済",
            "廃棄報告書回収済",
            "固定資産廃棄申請済",
            "廃棄済"});
            this.cbDisposalStatus.Location = new System.Drawing.Point(3, 3);
            this.cbDisposalStatus.Name = "cbDisposalStatus";
            this.cbDisposalStatus.Size = new System.Drawing.Size(169, 23);
            this.cbDisposalStatus.TabIndex = 17;
            this.cbDisposalStatus.SelectedIndexChanged += new System.EventHandler(this.cbDisposalStatus_SelectedIndexChanged);
            // 
            // bgworker
            // 
            this.bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgworker_DoWork);
            // 
            // disposaltype
            // 
            this.disposaltype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.disposaltype.DataPropertyName = "disposaltype";
            this.disposaltype.FillWeight = 120F;
            this.disposaltype.HeaderText = "DISPOSAL TYPE";
            this.disposaltype.Name = "disposaltype";
            this.disposaltype.ReadOnly = true;
            this.disposaltype.Width = 112;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.status.DataPropertyName = "qstatus";
            this.status.FillWeight = 130F;
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 69;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            this.chaseno.Width = 89;
            // 
            // mouldno
            // 
            this.mouldno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            this.mouldno.Width = 96;
            // 
            // partno
            // 
            this.partno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            // coldiv
            // 
            this.coldiv.DataPropertyName = "div";
            this.coldiv.HeaderText = "DIV";
            this.coldiv.Name = "coldiv";
            this.coldiv.ReadOnly = true;
            this.coldiv.Width = 51;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 57;
            // 
            // amounthkd
            // 
            this.amounthkd.DataPropertyName = "amounthkd";
            this.amounthkd.HeaderText = "AMOUNT (HKD)";
            this.amounthkd.Name = "amounthkd";
            this.amounthkd.ReadOnly = true;
            this.amounthkd.Width = 106;
            // 
            // fa
            // 
            this.fa.DataPropertyName = "facode";
            this.fa.HeaderText = "FA";
            this.fa.Name = "fa";
            this.fa.ReadOnly = true;
            this.fa.Width = 44;
            // 
            // vendorcode
            // 
            this.vendorcode.DataPropertyName = "vendor";
            this.vendorcode.HeaderText = "VENDOR";
            this.vendorcode.Name = "vendorcode";
            this.vendorcode.ReadOnly = true;
            this.vendorcode.Width = 77;
            // 
            // vendorname
            // 
            this.vendorname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            this.vendorname.Width = 5;
            // 
            // p2003no
            // 
            this.p2003no.DataPropertyName = "p2003no";
            this.p2003no.HeaderText = "P2003 CTRL NO.";
            this.p2003no.Name = "p2003no";
            this.p2003no.ReadOnly = true;
            this.p2003no.Width = 90;
            // 
            // p2003ans
            // 
            this.p2003ans.DataPropertyName = "p2003ans";
            this.p2003ans.HeaderText = "P2003 ANSWERS";
            this.p2003ans.Name = "p2003ans";
            this.p2003ans.ReadOnly = true;
            this.p2003ans.Width = 112;
            // 
            // p2003result
            // 
            this.p2003result.DataPropertyName = "p2003result";
            this.p2003result.HeaderText = "P2003 RESULT";
            this.p2003result.Name = "p2003result";
            this.p2003result.ReadOnly = true;
            this.p2003result.Width = 98;
            // 
            // p2003update
            // 
            this.p2003update.DataPropertyName = "p2003updated";
            this.p2003update.HeaderText = "P2003 UPDATED";
            this.p2003update.Name = "p2003update";
            this.p2003update.ReadOnly = true;
            this.p2003update.Width = 109;
            // 
            // p2004no
            // 
            this.p2004no.DataPropertyName = "p2004no";
            this.p2004no.HeaderText = "P2004 CTRL NO.";
            this.p2004no.Name = "p2004no";
            this.p2004no.ReadOnly = true;
            this.p2004no.Width = 90;
            // 
            // p2004ans
            // 
            this.p2004ans.DataPropertyName = "p2004ans";
            this.p2004ans.HeaderText = "P2004 ANSWERS";
            this.p2004ans.Name = "p2004ans";
            this.p2004ans.ReadOnly = true;
            this.p2004ans.Width = 112;
            // 
            // p2004result
            // 
            this.p2004result.DataPropertyName = "p2004result";
            this.p2004result.HeaderText = "P2004 RESULT";
            this.p2004result.Name = "p2004result";
            this.p2004result.ReadOnly = true;
            this.p2004result.Width = 98;
            // 
            // p2004update
            // 
            this.p2004update.DataPropertyName = "p2004updated";
            this.p2004update.HeaderText = "P2004 UPDATED";
            this.p2004update.Name = "p2004update";
            this.p2004update.ReadOnly = true;
            this.p2004update.Width = 109;
            // 
            // kdcno
            // 
            this.kdcno.DataPropertyName = "kdcno";
            this.kdcno.HeaderText = "KDC CTRL NO.";
            this.kdcno.Name = "kdcno";
            this.kdcno.ReadOnly = true;
            this.kdcno.Width = 97;
            // 
            // colkdcissued
            // 
            this.colkdcissued.DataPropertyName = "kdcissued";
            this.colkdcissued.HeaderText = "KDC ISSUED";
            this.colkdcissued.Name = "colkdcissued";
            this.colkdcissued.ReadOnly = true;
            this.colkdcissued.Width = 88;
            // 
            // kdcrps
            // 
            this.kdcrps.DataPropertyName = "kdcrps";
            this.kdcrps.HeaderText = "KDC RPS ANSWERS";
            this.kdcrps.Name = "kdcrps";
            this.kdcrps.ReadOnly = true;
            this.kdcrps.Width = 121;
            // 
            // kdcseisan
            // 
            this.kdcseisan.DataPropertyName = "kdcseisan";
            this.kdcseisan.HeaderText = "KDC SEISAN ANSWERS";
            this.kdcseisan.Name = "kdcseisan";
            this.kdcseisan.ReadOnly = true;
            this.kdcseisan.Width = 136;
            // 
            // kdcresult
            // 
            this.kdcresult.DataPropertyName = "kdcresult";
            this.kdcresult.HeaderText = "KDC RESULT";
            this.kdcresult.Name = "kdcresult";
            this.kdcresult.ReadOnly = true;
            this.kdcresult.Width = 87;
            // 
            // kdcupdated
            // 
            this.kdcupdated.DataPropertyName = "kdcupdated";
            this.kdcupdated.HeaderText = "KDC UPDATED";
            this.kdcupdated.Name = "kdcupdated";
            this.kdcupdated.ReadOnly = true;
            this.kdcupdated.Width = 97;
            // 
            // final
            // 
            this.final.DataPropertyName = "finalresult";
            this.final.HeaderText = "FINAL";
            this.final.Name = "final";
            this.final.ReadOnly = true;
            this.final.Visible = false;
            this.final.Width = 62;
            // 
            // assetdesc
            // 
            this.assetdesc.DataPropertyName = "assetdesc";
            this.assetdesc.HeaderText = "ASSET DESCRIPTION";
            this.assetdesc.Name = "assetdesc";
            this.assetdesc.ReadOnly = true;
            this.assetdesc.Width = 126;
            // 
            // capdate
            // 
            this.capdate.DataPropertyName = "capdate";
            this.capdate.HeaderText = "CAP. DATE";
            this.capdate.Name = "capdate";
            this.capdate.ReadOnly = true;
            this.capdate.Width = 79;
            // 
            // acquishkd
            // 
            this.acquishkd.DataPropertyName = "acquis";
            this.acquishkd.HeaderText = "ACQUIS.VAL.HKD";
            this.acquishkd.Name = "acquishkd";
            this.acquishkd.ReadOnly = true;
            this.acquishkd.Width = 120;
            // 
            // accumhkd
            // 
            this.accumhkd.DataPropertyName = "accum";
            this.accumhkd.HeaderText = "ACCUM.DEP.HKD";
            this.accumhkd.Name = "accumhkd";
            this.accumhkd.ReadOnly = true;
            this.accumhkd.Width = 122;
            // 
            // closingmonth
            // 
            this.closingmonth.DataPropertyName = "cmonth";
            this.closingmonth.HeaderText = "CLOSING MONTH";
            this.closingmonth.Name = "closingmonth";
            this.closingmonth.ReadOnly = true;
            this.closingmonth.Width = 114;
            // 
            // bookhkd
            // 
            this.bookhkd.DataPropertyName = "bookhkd";
            this.bookhkd.HeaderText = "BOOK.VAL.HKD";
            this.bookhkd.Name = "bookhkd";
            this.bookhkd.ReadOnly = true;
            this.bookhkd.Width = 111;
            // 
            // fy
            // 
            this.fy.DataPropertyName = "fy";
            this.fy.HeaderText = "FINICIAL YEAR";
            this.fy.Name = "fy";
            this.fy.ReadOnly = true;
            this.fy.Width = 97;
            // 
            // bookhkd2
            // 
            this.bookhkd2.DataPropertyName = "bookhkd2";
            this.bookhkd2.HeaderText = "BOOK.VAL.HKD";
            this.bookhkd2.Name = "bookhkd2";
            this.bookhkd2.ReadOnly = true;
            this.bookhkd2.Width = 111;
            // 
            // disposalringi
            // 
            this.disposalringi.DataPropertyName = "disposalringi";
            this.disposalringi.HeaderText = "DISPOSAL RINGI";
            this.disposalringi.Name = "disposalringi";
            this.disposalringi.ReadOnly = true;
            this.disposalringi.Width = 108;
            // 
            // reportno
            // 
            this.reportno.DataPropertyName = "reportno";
            this.reportno.HeaderText = "REPORT NO.";
            this.reportno.Name = "reportno";
            this.reportno.ReadOnly = true;
            this.reportno.Width = 89;
            // 
            // reportissued
            // 
            this.reportissued.DataPropertyName = "reportissued";
            this.reportissued.HeaderText = "REPORT ISSUED";
            this.reportissued.Name = "reportissued";
            this.reportissued.ReadOnly = true;
            this.reportissued.Width = 106;
            // 
            // reportreceived
            // 
            this.reportreceived.DataPropertyName = "reportreceived";
            this.reportreceived.HeaderText = "REPORT RECEIVED";
            this.reportreceived.Name = "reportreceived";
            this.reportreceived.ReadOnly = true;
            this.reportreceived.Width = 117;
            // 
            // vendorresult
            // 
            this.vendorresult.DataPropertyName = "vendorresult";
            this.vendorresult.HeaderText = "VENDOR RESULT";
            this.vendorresult.Name = "vendorresult";
            this.vendorresult.ReadOnly = true;
            this.vendorresult.Width = 107;
            // 
            // fadisposal
            // 
            this.fadisposal.DataPropertyName = "fadisposal";
            this.fadisposal.HeaderText = "FA DISPOSAL DATE";
            this.fadisposal.Name = "fadisposal";
            this.fadisposal.ReadOnly = true;
            this.fadisposal.Width = 117;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Width = 83;
            // 
            // ucDisposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.cbDisposalStatus);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.dgvDisposalDetail);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucDisposal";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposalDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvDisposalDetail;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.ComboBox cbDisposalStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.ComponentModel.BackgroundWorker bgworker;
        private System.Windows.Forms.DataGridViewTextBoxColumn disposaltype;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn final;
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
