namespace Mould_System.forms._4.file
{
    partial class ucFileUL
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
            this.btnList = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.btnAdd = new CustomUtil.controls.button.CustomButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvR3UL = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.div = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mpa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oemasset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.down = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.downloaded = new System.Windows.Forms.DataGridViewImageColumn();
            this.selected = new System.Windows.Forms.DataGridViewImageColumn();
            this.cbYesNo = new System.Windows.Forms.ComboBox();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvR3UL)).BeginInit();
            this.SuspendLayout();
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.LightGray;
            this.btnList.ForeColor = System.Drawing.Color.Black;
            this.btnList.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnList.Location = new System.Drawing.Point(103, 3);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(94, 23);
            this.btnList.TabIndex = 31;
            this.btnList.Text = "List";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(3, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 30;
            this.btnDownload.Text = "Download All";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightGray;
            this.btnAdd.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnAdd.Location = new System.Drawing.Point(203, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 23);
            this.btnAdd.TabIndex = 32;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(948, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 34;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(810, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 33;
            this.cbSearch.SelectedIndexChanged += new System.EventHandler(this.cbSearch_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(3, 619);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 19);
            this.lblTotal.TabIndex = 36;
            this.lblTotal.Text = "Unknown";
            // 
            // dgvR3UL
            // 
            this.dgvR3UL.AllowUserToAddRows = false;
            this.dgvR3UL.AllowUserToDeleteRows = false;
            this.dgvR3UL.AllowUserToResizeRows = false;
            this.dgvR3UL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvR3UL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvR3UL.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvR3UL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvR3UL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvR3UL.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvR3UL.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvR3UL.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvR3UL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvR3UL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.vendor,
            this.itemcode,
            this.rev,
            this.mouldno,
            this.modelcode,
            this.div,
            this.mpa,
            this.currency,
            this.amount,
            this.remarks,
            this.oemasset,
            this.down,
            this.downloaded,
            this.selected});
            this.dgvR3UL.Location = new System.Drawing.Point(-1, 32);
            this.dgvR3UL.Name = "dgvR3UL";
            this.dgvR3UL.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvR3UL.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvR3UL.ReadOnly = true;
            this.dgvR3UL.RowHeadersVisible = false;
            this.dgvR3UL.SecondaryLength = 2;
            this.dgvR3UL.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvR3UL.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvR3UL.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvR3UL.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvR3UL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvR3UL.Size = new System.Drawing.Size(1078, 584);
            this.dgvR3UL.TabIndex = 35;
            this.dgvR3UL.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvR3UL_DataBindingComplete);
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
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
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            // 
            // modelcode
            // 
            this.modelcode.DataPropertyName = "mouldcode";
            this.modelcode.HeaderText = "MOULD CODE";
            this.modelcode.Name = "modelcode";
            this.modelcode.ReadOnly = true;
            // 
            // div
            // 
            this.div.DataPropertyName = "status";
            this.div.HeaderText = "DIV.";
            this.div.Name = "div";
            this.div.ReadOnly = true;
            // 
            // mpa
            // 
            this.mpa.DataPropertyName = "mpa";
            this.mpa.HeaderText = "50% MPA";
            this.mpa.Name = "mpa";
            this.mpa.ReadOnly = true;
            this.mpa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mpa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // oemasset
            // 
            this.oemasset.DataPropertyName = "oemasset";
            this.oemasset.HeaderText = "OEM ASSET";
            this.oemasset.Name = "oemasset";
            this.oemasset.ReadOnly = true;
            // 
            // down
            // 
            this.down.DataPropertyName = "stcode";
            this.down.HeaderText = "down";
            this.down.Name = "down";
            this.down.ReadOnly = true;
            // 
            // downloaded
            // 
            this.downloaded.HeaderText = "DOWNLOADED";
            this.downloaded.Name = "downloaded";
            this.downloaded.ReadOnly = true;
            this.downloaded.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.downloaded.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // selected
            // 
            this.selected.HeaderText = "SELECTED";
            this.selected.Name = "selected";
            this.selected.ReadOnly = true;
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cbYesNo
            // 
            this.cbYesNo.FormattingEnabled = true;
            this.cbYesNo.Location = new System.Drawing.Point(944, 3);
            this.cbYesNo.Name = "cbYesNo";
            this.cbYesNo.Size = new System.Drawing.Size(124, 23);
            this.cbYesNo.TabIndex = 37;
            this.cbYesNo.Visible = false;
            this.cbYesNo.SelectedIndexChanged += new System.EventHandler(this.cbYesNo_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(303, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 38;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // ucFileUL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.cbYesNo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvR3UL);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnDownload);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucFileUL";
            this.Size = new System.Drawing.Size(1077, 646);
            ((System.ComponentModel.ISupportInitialize)(this.dgvR3UL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.button.CustomButton btnList;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.button.CustomButton btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.Label lblTotal;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvR3UL;
        private System.Windows.Forms.ComboBox cbYesNo;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn div;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mpa;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn oemasset;
        private System.Windows.Forms.DataGridViewTextBoxColumn down;
        private System.Windows.Forms.DataGridViewImageColumn downloaded;
        private System.Windows.Forms.DataGridViewImageColumn selected;
    }
}
