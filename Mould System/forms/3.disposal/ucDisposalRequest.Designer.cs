namespace Mould_System.forms._3.disposal
{
    partial class ucDisposalRequest
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
            this.dgvDisposal = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuRequest = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnList = new CustomUtil.controls.button.CustomButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnTemplate = new CustomUtil.controls.button.CustomButton();
            this.worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposal)).BeginInit();
            this.menuRequest.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDisposal
            // 
            this.dgvDisposal.AllowUserToAddRows = false;
            this.dgvDisposal.AllowUserToDeleteRows = false;
            this.dgvDisposal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDisposal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisposal.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvDisposal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDisposal.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvDisposal.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvDisposal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisposal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.mouldno,
            this.partno,
            this.rev,
            this.type,
            this.amounthkd,
            this.fa,
            this.ringi,
            this.vendorcode,
            this.vendorname});
            this.dgvDisposal.ContextMenuStrip = this.menuRequest;
            this.dgvDisposal.Location = new System.Drawing.Point(3, 36);
            this.dgvDisposal.Name = "dgvDisposal";
            this.dgvDisposal.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDisposal.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDisposal.ReadOnly = true;
            this.dgvDisposal.RowHeadersVisible = false;
            this.dgvDisposal.SecondaryLength = 2;
            this.dgvDisposal.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDisposal.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDisposal.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDisposal.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDisposal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisposal.Size = new System.Drawing.Size(1064, 580);
            this.dgvDisposal.TabIndex = 20;
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
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // amounthkd
            // 
            this.amounthkd.DataPropertyName = "amounthkd";
            this.amounthkd.HeaderText = "AMOUNT (HKD)";
            this.amounthkd.Name = "amounthkd";
            this.amounthkd.ReadOnly = true;
            // 
            // fa
            // 
            this.fa.DataPropertyName = "fa";
            this.fa.HeaderText = "FA";
            this.fa.Name = "fa";
            this.fa.ReadOnly = true;
            // 
            // ringi
            // 
            this.ringi.DataPropertyName = "ringi";
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.ReadOnly = true;
            // 
            // vendorcode
            // 
            this.vendorcode.DataPropertyName = "vendor";
            this.vendorcode.HeaderText = "VENDOR";
            this.vendorcode.Name = "vendorcode";
            this.vendorcode.ReadOnly = true;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            // 
            // menuRequest
            // 
            this.menuRequest.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuRequest.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToListToolStripMenuItem});
            this.menuRequest.Name = "menuRequest";
            this.menuRequest.Size = new System.Drawing.Size(132, 26);
            // 
            // addToListToolStripMenuItem
            // 
            this.addToListToolStripMenuItem.Name = "addToListToolStripMenuItem";
            this.addToListToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToListToolStripMenuItem.Text = "Add to List";
            this.addToListToolStripMenuItem.Click += new System.EventHandler(this.addToListToolStripMenuItem_Click);
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.LightGray;
            this.btnList.ForeColor = System.Drawing.Color.Black;
            this.btnList.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnList.Location = new System.Drawing.Point(3, 3);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(94, 23);
            this.btnList.TabIndex = 21;
            this.btnList.Text = "List";
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(947, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 23;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
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
            "Vendor Name"});
            this.cbSearch.Location = new System.Drawing.Point(809, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 22;
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
            this.btnUpload.TabIndex = 24;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.LightGray;
            this.btnTemplate.ForeColor = System.Drawing.Color.Black;
            this.btnTemplate.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnTemplate.Location = new System.Drawing.Point(203, 3);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(94, 23);
            this.btnTemplate.TabIndex = 25;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // ucDisposalRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnTemplate);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.dgvDisposal);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucDisposalRequest";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposal)).EndInit();
            this.menuRequest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvDisposal;
        private CustomUtil.controls.button.CustomButton btnList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.ContextMenuStrip menuRequest;
        private System.Windows.Forms.ToolStripMenuItem addToListToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnTemplate;
        private System.ComponentModel.BackgroundWorker worker;

    }
}
