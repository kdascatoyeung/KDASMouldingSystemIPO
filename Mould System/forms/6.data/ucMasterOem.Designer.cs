namespace Mould_System.forms._6.data
{
    partial class ucMasterOem
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
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvOem = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.oemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemcontent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costcentre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(948, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 15;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Code",
            "Content",
            "Remarks",
            "Account Code",
            "Cost Centre"});
            this.cbSearch.Location = new System.Drawing.Point(810, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 14;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(103, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 18;
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
            this.btnDownload.TabIndex = 17;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvOem
            // 
            this.dgvOem.AllowUserToAddRows = false;
            this.dgvOem.AllowUserToDeleteRows = false;
            this.dgvOem.AllowUserToResizeRows = false;
            this.dgvOem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOem.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvOem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvOem.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvOem.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvOem.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvOem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.oemcode,
            this.oemcontent,
            this.oemremarks,
            this.accountcode,
            this.costcentre});
            this.dgvOem.Location = new System.Drawing.Point(3, 32);
            this.dgvOem.Name = "dgvOem";
            this.dgvOem.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvOem.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvOem.ReadOnly = true;
            this.dgvOem.RowHeadersVisible = false;
            this.dgvOem.SecondaryLength = 2;
            this.dgvOem.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvOem.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvOem.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvOem.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvOem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOem.Size = new System.Drawing.Size(1065, 580);
            this.dgvOem.TabIndex = 19;
            // 
            // oemcode
            // 
            this.oemcode.DataPropertyName = "oemcode";
            this.oemcode.HeaderText = "CODE";
            this.oemcode.Name = "oemcode";
            this.oemcode.ReadOnly = true;
            // 
            // oemcontent
            // 
            this.oemcontent.DataPropertyName = "oemcontent";
            this.oemcontent.HeaderText = "CONTENT";
            this.oemcontent.Name = "oemcontent";
            this.oemcontent.ReadOnly = true;
            // 
            // oemremarks
            // 
            this.oemremarks.DataPropertyName = "oemremarks";
            this.oemremarks.HeaderText = "REMARKS";
            this.oemremarks.Name = "oemremarks";
            this.oemremarks.ReadOnly = true;
            // 
            // accountcode
            // 
            this.accountcode.DataPropertyName = "accountcode";
            this.accountcode.HeaderText = "ACCOUNT CODE";
            this.accountcode.Name = "accountcode";
            this.accountcode.ReadOnly = true;
            // 
            // costcentre
            // 
            this.costcentre.DataPropertyName = "costcentre";
            this.costcentre.HeaderText = "COST CENTRE";
            this.costcentre.Name = "costcentre";
            this.costcentre.ReadOnly = true;
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // ucMasterOem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvOem);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMasterOem";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvOem;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemcontent;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemremarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn costcentre;
        private System.ComponentModel.BackgroundWorker worker;
    }
}
