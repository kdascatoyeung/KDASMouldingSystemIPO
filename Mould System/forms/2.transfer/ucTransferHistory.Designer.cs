namespace Mould_System.forms._2.transfer
{
    partial class ucTransferHistory
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
            this.dgvTransferHistory = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerbefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerafter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorbefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorafter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(950, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Mould No.",
            "Part No.",
            "Owner (Before)",
            "Owner (After)",
            "Vendor (Before)",
            "Vendor (After)"});
            this.cbSearch.Location = new System.Drawing.Point(812, 3);
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
            this.lblTotal.Location = new System.Drawing.Point(3, 615);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(75, 19);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvTransferHistory
            // 
            this.dgvTransferHistory.AllowUserToAddRows = false;
            this.dgvTransferHistory.AllowUserToDeleteRows = false;
            this.dgvTransferHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransferHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransferHistory.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTransferHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTransferHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransferHistory.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvTransferHistory.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvTransferHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.mouldno,
            this.partno,
            this.rev,
            this.status,
            this.ownerbefore,
            this.ownerafter,
            this.vendorbefore,
            this.vendorafter,
            this.date});
            this.dgvTransferHistory.Location = new System.Drawing.Point(3, 32);
            this.dgvTransferHistory.Name = "dgvTransferHistory";
            this.dgvTransferHistory.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvTransferHistory.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvTransferHistory.ReadOnly = true;
            this.dgvTransferHistory.RowHeadersVisible = false;
            this.dgvTransferHistory.SecondaryLength = 2;
            this.dgvTransferHistory.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvTransferHistory.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvTransferHistory.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvTransferHistory.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvTransferHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferHistory.Size = new System.Drawing.Size(1067, 580);
            this.dgvTransferHistory.TabIndex = 15;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "TM CHASE NO.";
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
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "DIV.";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // ownerbefore
            // 
            this.ownerbefore.DataPropertyName = "ownerbefore";
            this.ownerbefore.HeaderText = "OWNER (BEFORE)";
            this.ownerbefore.Name = "ownerbefore";
            this.ownerbefore.ReadOnly = true;
            // 
            // ownerafter
            // 
            this.ownerafter.DataPropertyName = "ownerafter";
            this.ownerafter.HeaderText = "OWNER (AFTER)";
            this.ownerafter.Name = "ownerafter";
            this.ownerafter.ReadOnly = true;
            // 
            // vendorbefore
            // 
            this.vendorbefore.DataPropertyName = "vendorbefore";
            this.vendorbefore.HeaderText = "VENDOR (BEFORE)";
            this.vendorbefore.Name = "vendorbefore";
            this.vendorbefore.ReadOnly = true;
            // 
            // vendorafter
            // 
            this.vendorafter.DataPropertyName = "vendorafter";
            this.vendorafter.HeaderText = "VENDOR (AFTER)";
            this.vendorafter.Name = "vendorafter";
            this.vendorafter.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "tdate";
            this.date.HeaderText = "DATE";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // ucTransferHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvTransferHistory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucTransferHistory";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvTransferHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerbefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerafter;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorbefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorafter;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
    }
}
