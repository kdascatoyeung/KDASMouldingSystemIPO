namespace Mould_System.forms._2.transfer
{
    partial class ucTransferOwner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTransferOwner));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new CustomUtil.controls.button.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvTransferPreview = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFromOwner = new System.Windows.Forms.ComboBox();
            this.cbToOwner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPreview = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.mould = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instockdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.venname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prefac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromowner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toowner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transferremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRemove = new CustomUtil.controls.button.CustomButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferPreview)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnPreview);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.dgvTransferPreview);
            this.groupBox1.Location = new System.Drawing.Point(3, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1066, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOULD";
            // 
            // btnPreview
            // 
            this.btnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPreview.BackColor = System.Drawing.Color.LightGray;
            this.btnPreview.ForeColor = System.Drawing.Color.Black;
            this.btnPreview.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnPreview.Location = new System.Drawing.Point(966, 271);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(94, 23);
            this.btnPreview.TabIndex = 21;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Part No. :";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(66, 21);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 19;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // dgvTransferPreview
            // 
            this.dgvTransferPreview.AllowUserToAddRows = false;
            this.dgvTransferPreview.AllowUserToDeleteRows = false;
            this.dgvTransferPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransferPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransferPreview.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvTransferPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvTransferPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTransferPreview.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvTransferPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mould,
            this.mouldcode,
            this.vendor,
            this.vendorname,
            this.fac,
            this.remarks,
            this.instockdate,
            this.owner});
            this.dgvTransferPreview.Location = new System.Drawing.Point(6, 50);
            this.dgvTransferPreview.Name = "dgvTransferPreview";
            this.dgvTransferPreview.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvTransferPreview.RowHeadersVisible = false;
            this.dgvTransferPreview.SecondaryLength = 2;
            this.dgvTransferPreview.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvTransferPreview.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvTransferPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferPreview.Size = new System.Drawing.Size(1054, 215);
            this.dgvTransferPreview.TabIndex = 17;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cbToOwner);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbFromOwner);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1066, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OWNER";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.dgvPreview);
            this.groupBox3.Location = new System.Drawing.Point(3, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1066, 260);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PREVIEW";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "From Owner :";
            // 
            // cbFromOwner
            // 
            this.cbFromOwner.FormattingEnabled = true;
            this.cbFromOwner.Items.AddRange(new object[] {
            "KDTHK",
            "KDTCN",
            "KDTVN",
            "KDC"});
            this.cbFromOwner.Location = new System.Drawing.Point(92, 27);
            this.cbFromOwner.Name = "cbFromOwner";
            this.cbFromOwner.Size = new System.Drawing.Size(163, 23);
            this.cbFromOwner.TabIndex = 1;
            // 
            // cbToOwner
            // 
            this.cbToOwner.FormattingEnabled = true;
            this.cbToOwner.Items.AddRange(new object[] {
            "KDTHK",
            "KDTCN",
            "KDTVN",
            "KDC"});
            this.cbToOwner.Location = new System.Drawing.Point(369, 27);
            this.cbToOwner.Name = "cbToOwner";
            this.cbToOwner.Size = new System.Drawing.Size(163, 23);
            this.cbToOwner.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(299, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "To Owner :";
            // 
            // dgvPreview
            // 
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;
            this.dgvPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPreview.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPreview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPreview.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvPreview.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.venname,
            this.prefac,
            this.fromowner,
            this.toowner,
            this.transferremarks});
            this.dgvPreview.Location = new System.Drawing.Point(6, 22);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvPreview.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvPreview.RowHeadersVisible = false;
            this.dgvPreview.SecondaryLength = 2;
            this.dgvPreview.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvPreview.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvPreview.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvPreview.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreview.Size = new System.Drawing.Size(1054, 201);
            this.dgvPreview.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(966, 229);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mould
            // 
            this.mould.DataPropertyName = "mouldno";
            this.mould.HeaderText = "MOULD NO.";
            this.mould.Name = "mould";
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            // 
            // fac
            // 
            this.fac.HeaderText = "FIXED ASSET";
            this.fac.Name = "fac";
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            // 
            // instockdate
            // 
            this.instockdate.DataPropertyName = "instockdate";
            this.instockdate.HeaderText = "IN STOCK DATE";
            this.instockdate.Name = "instockdate";
            // 
            // owner
            // 
            this.owner.DataPropertyName = "owner";
            this.owner.HeaderText = "OWNER";
            this.owner.Name = "owner";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mouldno";
            this.dataGridViewTextBoxColumn1.HeaderText = "MOULD NO.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "mouldcode";
            this.dataGridViewTextBoxColumn2.HeaderText = "MOULD CODE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "vendor";
            this.dataGridViewTextBoxColumn3.HeaderText = "VENDOR";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // venname
            // 
            this.venname.HeaderText = "VENDOR NAME";
            this.venname.Name = "venname";
            this.venname.ReadOnly = true;
            // 
            // prefac
            // 
            this.prefac.HeaderText = "FIXED ASSET";
            this.prefac.Name = "prefac";
            // 
            // fromowner
            // 
            this.fromowner.HeaderText = "FROM OWNER";
            this.fromowner.Name = "fromowner";
            this.fromowner.ReadOnly = true;
            // 
            // toowner
            // 
            this.toowner.HeaderText = "TO OWNER";
            this.toowner.Name = "toowner";
            this.toowner.ReadOnly = true;
            // 
            // transferremarks
            // 
            this.transferremarks.HeaderText = "TRANSFER REMARKS";
            this.transferremarks.Name = "transferremarks";
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(192, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 21);
            this.btnSearch.TabIndex = 31;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRemove.Location = new System.Drawing.Point(6, 229);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 23);
            this.btnRemove.TabIndex = 23;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ucTransferOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucTransferOwner";
            this.Size = new System.Drawing.Size(1077, 646);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferPreview)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvTransferPreview;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private CustomUtil.controls.button.CustomButton btnPreview;
        private System.Windows.Forms.ComboBox cbToOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFromOwner;
        private System.Windows.Forms.Label label2;
        private CustomUtil.controls.button.CustomButton btnSave;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn mould;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fac;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn instockdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn venname;
        private System.Windows.Forms.DataGridViewTextBoxColumn prefac;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromowner;
        private System.Windows.Forms.DataGridViewTextBoxColumn toowner;
        private System.Windows.Forms.DataGridViewTextBoxColumn transferremarks;
        private System.Windows.Forms.Button btnSearch;
        private CustomUtil.controls.button.CustomButton btnRemove;
    }
}
