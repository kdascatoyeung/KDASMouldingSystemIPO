namespace Mould_System.forms._4.file
{
    partial class ucFileKdc
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
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvKdc = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.po = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.down = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloaded = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKdc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(948, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 39;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(810, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 38;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(3, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 41;
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
            this.lblTotal.TabIndex = 43;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvKdc
            // 
            this.dgvKdc.AllowUserToAddRows = false;
            this.dgvKdc.AllowUserToDeleteRows = false;
            this.dgvKdc.AllowUserToResizeRows = false;
            this.dgvKdc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKdc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKdc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvKdc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvKdc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvKdc.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvKdc.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvKdc.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvKdc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKdc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.mouldno,
            this.itemcode,
            this.rev,
            this.status,
            this.vendor,
            this.mouldcode,
            this.po,
            this.down,
            this.downloaded});
            this.dgvKdc.Location = new System.Drawing.Point(3, 32);
            this.dgvKdc.Name = "dgvKdc";
            this.dgvKdc.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvKdc.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvKdc.ReadOnly = true;
            this.dgvKdc.RowHeadersVisible = false;
            this.dgvKdc.SecondaryLength = 2;
            this.dgvKdc.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvKdc.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvKdc.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvKdc.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvKdc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKdc.Size = new System.Drawing.Size(1065, 580);
            this.dgvKdc.TabIndex = 42;
            this.dgvKdc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvKdc_DataBindingComplete);
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
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "PART NO.";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "DIV.";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.ReadOnly = true;
            // 
            // po
            // 
            this.po.DataPropertyName = "po";
            this.po.HeaderText = "PO";
            this.po.Name = "po";
            this.po.ReadOnly = true;
            // 
            // down
            // 
            this.down.DataPropertyName = "stcode";
            this.down.HeaderText = "down";
            this.down.Name = "down";
            this.down.ReadOnly = true;
            this.down.Visible = false;
            // 
            // downloaded
            // 
            this.downloaded.HeaderText = "DOWNLOADED";
            this.downloaded.Name = "downloaded";
            this.downloaded.ReadOnly = true;
            // 
            // ucFileKdc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvKdc);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucFileKdc";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKdc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvKdc;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn po;
        private System.Windows.Forms.DataGridViewTextBoxColumn down;
        private System.Windows.Forms.DataGridViewImageColumn downloaded;
    }
}
