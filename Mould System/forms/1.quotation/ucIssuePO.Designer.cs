namespace Mould_System.forms._1.quotation
{
    partial class ucIssuePO
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvIssuePo = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.qstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.btnUploadCn = new CustomUtil.controls.button.CustomButton();
            this.btnDownloadCn = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuePo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(947, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 9;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(809, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 8;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            this.cbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSearch_KeyPress);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvIssuePo
            // 
            this.dgvIssuePo.AllowUserToAddRows = false;
            this.dgvIssuePo.AllowUserToDeleteRows = false;
            this.dgvIssuePo.AllowUserToResizeRows = false;
            this.dgvIssuePo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIssuePo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIssuePo.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvIssuePo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvIssuePo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvIssuePo.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvIssuePo.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvIssuePo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvIssuePo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIssuePo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qstatus,
            this.chaseno,
            this.mouldno,
            this.partno,
            this.rev,
            this.vendor});
            this.dgvIssuePo.Location = new System.Drawing.Point(4, 32);
            this.dgvIssuePo.Name = "dgvIssuePo";
            this.dgvIssuePo.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvIssuePo.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvIssuePo.ReadOnly = true;
            this.dgvIssuePo.RowHeadersVisible = false;
            this.dgvIssuePo.SecondaryLength = 2;
            this.dgvIssuePo.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvIssuePo.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvIssuePo.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvIssuePo.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvIssuePo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIssuePo.Size = new System.Drawing.Size(1063, 580);
            this.dgvIssuePo.TabIndex = 11;
            // 
            // qstatus
            // 
            this.qstatus.DataPropertyName = "qstatus";
            this.qstatus.HeaderText = "QUOTATION STATUS";
            this.qstatus.Name = "qstatus";
            this.qstatus.ReadOnly = true;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
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
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(4, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(108, 23);
            this.btnDownload.TabIndex = 13;
            this.btnDownload.Text = "Download (HK)";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(118, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(108, 23);
            this.btnUpload.TabIndex = 14;
            this.btnUpload.Text = "Upload (HK)";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // btnUploadCn
            // 
            this.btnUploadCn.BackColor = System.Drawing.Color.LightGray;
            this.btnUploadCn.ForeColor = System.Drawing.Color.Black;
            this.btnUploadCn.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUploadCn.Location = new System.Drawing.Point(346, 3);
            this.btnUploadCn.Name = "btnUploadCn";
            this.btnUploadCn.Size = new System.Drawing.Size(108, 23);
            this.btnUploadCn.TabIndex = 15;
            this.btnUploadCn.Text = "Upload (CN)";
            this.btnUploadCn.Click += new System.EventHandler(this.btnUploadCn_Click);
            // 
            // btnDownloadCn
            // 
            this.btnDownloadCn.BackColor = System.Drawing.Color.LightGray;
            this.btnDownloadCn.ForeColor = System.Drawing.Color.Black;
            this.btnDownloadCn.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownloadCn.Location = new System.Drawing.Point(232, 3);
            this.btnDownloadCn.Name = "btnDownloadCn";
            this.btnDownloadCn.Size = new System.Drawing.Size(108, 23);
            this.btnDownloadCn.TabIndex = 16;
            this.btnDownloadCn.Text = "Download (CN)";
            this.btnDownloadCn.Click += new System.EventHandler(this.btnDownloadCn_Click);
            // 
            // ucIssuePO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnDownloadCn);
            this.Controls.Add(this.btnUploadCn);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvIssuePo);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucIssuePO";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIssuePo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvIssuePo;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn qstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.ComponentModel.BackgroundWorker worker;
        private CustomUtil.controls.button.CustomButton btnUploadCn;
        private CustomUtil.controls.button.CustomButton btnDownloadCn;
    }
}
