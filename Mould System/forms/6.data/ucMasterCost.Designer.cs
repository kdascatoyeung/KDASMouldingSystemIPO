namespace Mould_System.forms._6.data
{
    partial class ucMasterCost
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
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvVendor = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.citemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccurr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.camount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(103, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 25;
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
            this.btnDownload.TabIndex = 24;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(954, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(174, 23);
            this.txtSearch.TabIndex = 26;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            this.citemcode,
            this.crev,
            this.ccurr,
            this.camount,
            this.cremarks});
            this.dgvVendor.Location = new System.Drawing.Point(3, 33);
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
            this.dgvVendor.Size = new System.Drawing.Size(1125, 620);
            this.dgvVendor.TabIndex = 27;
            // 
            // citemcode
            // 
            this.citemcode.DataPropertyName = "itemcode";
            this.citemcode.FillWeight = 93.27411F;
            this.citemcode.HeaderText = "ITEM CODE";
            this.citemcode.Name = "citemcode";
            this.citemcode.ReadOnly = true;
            // 
            // crev
            // 
            this.crev.DataPropertyName = "rev";
            this.crev.FillWeight = 25F;
            this.crev.HeaderText = "REV.";
            this.crev.Name = "crev";
            this.crev.ReadOnly = true;
            // 
            // ccurr
            // 
            this.ccurr.DataPropertyName = "curr";
            this.ccurr.FillWeight = 93.27411F;
            this.ccurr.HeaderText = "CURRENCY";
            this.ccurr.Name = "ccurr";
            this.ccurr.ReadOnly = true;
            // 
            // camount
            // 
            this.camount.DataPropertyName = "cost";
            this.camount.FillWeight = 93.27411F;
            this.camount.HeaderText = "COST";
            this.camount.Name = "camount";
            this.camount.ReadOnly = true;
            // 
            // cremarks
            // 
            this.cremarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cremarks.DataPropertyName = "remarks";
            this.cremarks.FillWeight = 93.27411F;
            this.cremarks.HeaderText = "REMARKS";
            this.cremarks.Name = "cremarks";
            this.cremarks.ReadOnly = true;
            this.cremarks.Width = 83;
            // 
            // ucMasterCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvVendor);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMasterCost";
            this.Size = new System.Drawing.Size(1131, 653);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.TextBox txtSearch;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn citemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn crev;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccurr;
        private System.Windows.Forms.DataGridViewTextBoxColumn camount;
        private System.Windows.Forms.DataGridViewTextBoxColumn cremarks;
    }
}
