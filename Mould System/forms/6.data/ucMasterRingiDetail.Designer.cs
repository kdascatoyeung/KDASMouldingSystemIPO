namespace Mould_System.forms._6.data
{
    partial class ucMasterRingiDetail
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cbSearch = new System.Windows.Forms.ComboBox();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.btnTemplate = new CustomUtil.controls.button.CustomButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRingi = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.dgvRingi = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.colringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcontent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colcurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colamounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colbalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colconfirmed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colexpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPreRingi = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuPreRingi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRingi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreRingi)).BeginInit();
            this.menuPreRingi.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(947, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 27;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Items.AddRange(new object[] {
            "All",
            "Ringi",
            "Model Name",
            "Part No.",
            "Subject",
            "Remarks"});
            this.cbSearch.Location = new System.Drawing.Point(809, 4);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 26;
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
            this.btnUpload.TabIndex = 29;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.BackColor = System.Drawing.Color.LightGray;
            this.btnTemplate.ForeColor = System.Drawing.Color.Black;
            this.btnTemplate.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnTemplate.Location = new System.Drawing.Point(3, 3);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(94, 23);
            this.btnTemplate.TabIndex = 28;
            this.btnTemplate.Text = "Template";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblRingi);
            this.groupBox1.Controls.Add(this.txtSubject);
            this.groupBox1.Controls.Add(this.txtModelName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1064, 115);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATA INPUT";
            // 
            // lblRingi
            // 
            this.lblRingi.AutoSize = true;
            this.lblRingi.Location = new System.Drawing.Point(97, 24);
            this.lblRingi.Name = "lblRingi";
            this.lblRingi.Size = new System.Drawing.Size(58, 15);
            this.lblRingi.TabIndex = 31;
            this.lblRingi.Text = "Unknown";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(97, 79);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(205, 23);
            this.txtSubject.TabIndex = 5;
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(97, 50);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(205, 23);
            this.txtModelName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subject :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Model Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ringi :";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(973, 616);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(203, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 32;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dgvRingi
            // 
            this.dgvRingi.AllowUserToAddRows = false;
            this.dgvRingi.AllowUserToDeleteRows = false;
            this.dgvRingi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRingi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRingi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRingi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRingi.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRingi.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvRingi.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvRingi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRingi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colringi,
            this.colcontent,
            this.colcurrency,
            this.colamount,
            this.colamounthkd,
            this.colbalance,
            this.colconfirmed,
            this.colexpiry});
            this.dgvRingi.Location = new System.Drawing.Point(3, 33);
            this.dgvRingi.MultiSelect = false;
            this.dgvRingi.Name = "dgvRingi";
            this.dgvRingi.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvRingi.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvRingi.ReadOnly = true;
            this.dgvRingi.RowHeadersVisible = false;
            this.dgvRingi.SecondaryLength = 2;
            this.dgvRingi.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvRingi.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvRingi.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvRingi.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvRingi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRingi.Size = new System.Drawing.Size(1064, 153);
            this.dgvRingi.TabIndex = 26;
            this.dgvRingi.DoubleClick += new System.EventHandler(this.dgvRingi_DoubleClick);
            // 
            // colringi
            // 
            this.colringi.DataPropertyName = "ringi";
            this.colringi.HeaderText = "RINGI";
            this.colringi.Name = "colringi";
            this.colringi.ReadOnly = true;
            // 
            // colcontent
            // 
            this.colcontent.DataPropertyName = "content";
            this.colcontent.HeaderText = "CONTENT";
            this.colcontent.Name = "colcontent";
            this.colcontent.ReadOnly = true;
            // 
            // colcurrency
            // 
            this.colcurrency.DataPropertyName = "currency";
            this.colcurrency.HeaderText = "CURRENCY";
            this.colcurrency.Name = "colcurrency";
            this.colcurrency.ReadOnly = true;
            // 
            // colamount
            // 
            this.colamount.DataPropertyName = "amount";
            this.colamount.HeaderText = "AMOUNT";
            this.colamount.Name = "colamount";
            this.colamount.ReadOnly = true;
            // 
            // colamounthkd
            // 
            this.colamounthkd.DataPropertyName = "amounthkd";
            this.colamounthkd.HeaderText = "AMOUNT(HKD)";
            this.colamounthkd.Name = "colamounthkd";
            this.colamounthkd.ReadOnly = true;
            // 
            // colbalance
            // 
            this.colbalance.DataPropertyName = "balance";
            this.colbalance.HeaderText = "BALANCE";
            this.colbalance.Name = "colbalance";
            this.colbalance.ReadOnly = true;
            // 
            // colconfirmed
            // 
            this.colconfirmed.DataPropertyName = "r3confirmed";
            this.colconfirmed.HeaderText = "R3 CONFIRMED";
            this.colconfirmed.Name = "colconfirmed";
            this.colconfirmed.ReadOnly = true;
            // 
            // colexpiry
            // 
            this.colexpiry.DataPropertyName = "expiry";
            this.colexpiry.HeaderText = "EXPIRY";
            this.colexpiry.Name = "colexpiry";
            this.colexpiry.ReadOnly = true;
            // 
            // dgvPreRingi
            // 
            this.dgvPreRingi.AllowUserToDeleteRows = false;
            this.dgvPreRingi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreRingi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreRingi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPreRingi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPreRingi.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvPreRingi.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvPreRingi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreRingi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.model,
            this.partno,
            this.currency,
            this.amount,
            this.vendor,
            this.remarks,
            this.id});
            this.dgvPreRingi.ContextMenuStrip = this.menuPreRingi;
            this.dgvPreRingi.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPreRingi.Location = new System.Drawing.Point(3, 313);
            this.dgvPreRingi.Name = "dgvPreRingi";
            this.dgvPreRingi.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvPreRingi.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvPreRingi.RowHeadersWidth = 20;
            this.dgvPreRingi.SecondaryLength = 2;
            this.dgvPreRingi.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvPreRingi.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvPreRingi.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvPreRingi.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvPreRingi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPreRingi.Size = new System.Drawing.Size(1064, 297);
            this.dgvPreRingi.TabIndex = 6;
            this.dgvPreRingi.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPreRingi_RowHeaderMouseClick);
            this.dgvPreRingi.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvPreRingi_MouseDown);
            // 
            // model
            // 
            this.model.DataPropertyName = "model";
            this.model.HeaderText = "MODEL";
            this.model.Name = "model";
            // 
            // partno
            // 
            this.partno.DataPropertyName = "itemcode";
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // menuPreRingi
            // 
            this.menuPreRingi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuPreRingi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.menuPreRingi.Name = "menuPreRingi";
            this.menuPreRingi.Size = new System.Drawing.Size(117, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // ucMasterRingiDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.dgvPreRingi);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvRingi);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnTemplate);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMasterRingiDetail";
            this.Size = new System.Drawing.Size(1073, 642);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRingi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreRingi)).EndInit();
            this.menuPreRingi.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private CustomUtil.controls.button.CustomButton btnTemplate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CustomUtil.controls.button.CustomButton btnSave;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvRingi;
        private System.Windows.Forms.Label lblRingi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcontent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colcurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colamount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colamounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colbalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colconfirmed;
        private System.Windows.Forms.DataGridViewTextBoxColumn colexpiry;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvPreRingi;
        private System.Windows.Forms.ContextMenuStrip menuPreRingi;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn model;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.ComponentModel.BackgroundWorker worker;
    }
}
