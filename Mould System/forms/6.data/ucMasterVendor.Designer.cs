namespace Mould_System.forms._6.data
{
    partial class ucMasterVendor
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
            this.dgvVendor = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paycurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payterms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.request = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.btnUpdate = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(948, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(810, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 18;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 21;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvVendor
            // 
            this.dgvVendor.AllowUserToAddRows = false;
            this.dgvVendor.AllowUserToDeleteRows = false;
            this.dgvVendor.AllowUserToResizeRows = false;
            this.dgvVendor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVendor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendor.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVendor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvVendor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVendor.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvVendor.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvVendor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.group,
            this.paycurr,
            this.payterms,
            this.request,
            this.EDI,
            this.remarks});
            this.dgvVendor.Location = new System.Drawing.Point(3, 32);
            this.dgvVendor.Name = "dgvVendor";
            this.dgvVendor.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvVendor.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvVendor.ReadOnly = true;
            this.dgvVendor.RowHeadersVisible = false;
            this.dgvVendor.SecondaryLength = 2;
            this.dgvVendor.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvVendor.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvVendor.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvVendor.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvVendor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendor.Size = new System.Drawing.Size(1065, 580);
            this.dgvVendor.TabIndex = 20;
            // 
            // code
            // 
            this.code.DataPropertyName = "vendorcode";
            this.code.HeaderText = "VENDOR";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "vendorname";
            this.name.HeaderText = "VENDOR NAME";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // group
            // 
            this.group.DataPropertyName = "pgroup";
            this.group.HeaderText = "I/C";
            this.group.Name = "group";
            this.group.ReadOnly = true;
            // 
            // paycurr
            // 
            this.paycurr.DataPropertyName = "paycurr";
            this.paycurr.HeaderText = "PAY CURRENCY";
            this.paycurr.Name = "paycurr";
            this.paycurr.ReadOnly = true;
            // 
            // payterms
            // 
            this.payterms.DataPropertyName = "payterms";
            this.payterms.HeaderText = "PAY TERMS";
            this.payterms.Name = "payterms";
            this.payterms.ReadOnly = true;
            // 
            // request
            // 
            this.request.DataPropertyName = "request";
            this.request.HeaderText = "REQUEST";
            this.request.Name = "request";
            this.request.ReadOnly = true;
            // 
            // EDI
            // 
            this.EDI.DataPropertyName = "edi";
            this.EDI.HeaderText = "EDI";
            this.EDI.Name = "EDI";
            this.EDI.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(103, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 23;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(3, 3);
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
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightGray;
            this.btnUpdate.ForeColor = System.Drawing.Color.Black;
            this.btnUpdate.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpdate.Location = new System.Drawing.Point(203, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(145, 23);
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update purchaser";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ucMasterVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvVendor);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMasterVendor";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvVendor;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn group;
        private System.Windows.Forms.DataGridViewTextBoxColumn paycurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn payterms;
        private System.Windows.Forms.DataGridViewTextBoxColumn request;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.ComponentModel.BackgroundWorker worker;
        private CustomUtil.controls.button.CustomButton btnUpdate;
    }
}
