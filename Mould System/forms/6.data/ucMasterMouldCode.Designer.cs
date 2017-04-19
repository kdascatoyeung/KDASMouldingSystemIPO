namespace Mould_System.forms._6.data
{
    partial class ucMasterMouldCode
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
            this.dgvMouldCode = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentjp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contenteng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentchin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemgroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouldCode)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(948, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(810, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 12;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(0, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Unknown";
            this.lblTotal.Visible = false;
            // 
            // dgvMouldCode
            // 
            this.dgvMouldCode.AllowUserToAddRows = false;
            this.dgvMouldCode.AllowUserToDeleteRows = false;
            this.dgvMouldCode.AllowUserToResizeRows = false;
            this.dgvMouldCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMouldCode.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMouldCode.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMouldCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMouldCode.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMouldCode.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvMouldCode.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvMouldCode.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMouldCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMouldCode.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mouldcode,
            this.type,
            this.contentjp,
            this.contenteng,
            this.contentchin,
            this.itemgroup});
            this.dgvMouldCode.Location = new System.Drawing.Point(0, 32);
            this.dgvMouldCode.Name = "dgvMouldCode";
            this.dgvMouldCode.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvMouldCode.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvMouldCode.ReadOnly = true;
            this.dgvMouldCode.RowHeadersVisible = false;
            this.dgvMouldCode.SecondaryLength = 2;
            this.dgvMouldCode.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvMouldCode.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvMouldCode.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvMouldCode.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvMouldCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMouldCode.Size = new System.Drawing.Size(1068, 580);
            this.dgvMouldCode.TabIndex = 15;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // contentjp
            // 
            this.contentjp.DataPropertyName = "contentjp";
            this.contentjp.HeaderText = "CONTENT (JP)";
            this.contentjp.Name = "contentjp";
            this.contentjp.ReadOnly = true;
            // 
            // contenteng
            // 
            this.contenteng.DataPropertyName = "contenteng";
            this.contenteng.HeaderText = "CONTENT (ENG)";
            this.contenteng.Name = "contenteng";
            this.contenteng.ReadOnly = true;
            // 
            // contentchin
            // 
            this.contentchin.DataPropertyName = "contentchin";
            this.contentchin.HeaderText = "CONTENT (CHIN)";
            this.contentchin.Name = "contentchin";
            this.contentchin.ReadOnly = true;
            // 
            // itemgroup
            // 
            this.itemgroup.DataPropertyName = "itemgroup";
            this.itemgroup.HeaderText = "ITEM GROUP";
            this.itemgroup.Name = "itemgroup";
            this.itemgroup.ReadOnly = true;
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
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // ucMasterMouldCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvMouldCode);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMasterMouldCode";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouldCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvMouldCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentjp;
        private System.Windows.Forms.DataGridViewTextBoxColumn contenteng;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentchin;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemgroup;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.ComponentModel.BackgroundWorker worker;
    }
}
