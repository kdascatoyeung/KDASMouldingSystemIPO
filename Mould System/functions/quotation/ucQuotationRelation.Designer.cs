namespace Mould_System.functions.quotation
{
    partial class ucQuotationRelation
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new CustomUtil.controls.button.CustomButton();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.dgvSetup = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setcommon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMouldDetail = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gtcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCheck = new CustomUtil.controls.button.CustomButton();
            this.dgvRelationship = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationitemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationremarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.btnRemove = new CustomUtil.controls.button.CustomButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouldDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationship)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.dgvSetup);
            this.groupBox1.Controls.Add(this.dgvMouldDetail);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 640);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOULD INFO";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(525, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(425, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvSetup
            // 
            this.dgvSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSetup.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSetup.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvSetup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSetup.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvSetup.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemcode,
            this.setcommon,
            this.remarks});
            this.dgvSetup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSetup.EnableHeadersVisualStyles = false;
            this.dgvSetup.Location = new System.Drawing.Point(6, 129);
            this.dgvSetup.Name = "dgvSetup";
            this.dgvSetup.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvSetup.PrimaryRowcolor2 = System.Drawing.Color.SteelBlue;
            this.dgvSetup.SecondaryLength = 2;
            this.dgvSetup.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvSetup.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvSetup.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvSetup.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvSetup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSetup.Size = new System.Drawing.Size(613, 476);
            this.dgvSetup.TabIndex = 17;
            this.dgvSetup.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSetup_RowHeaderMouseClick);
            // 
            // itemcode
            // 
            this.itemcode.HeaderText = "PARTS NO.";
            this.itemcode.Name = "itemcode";
            // 
            // setcommon
            // 
            this.setcommon.HeaderText = "1=Common, 2=Set";
            this.setcommon.Name = "setcommon";
            // 
            // remarks
            // 
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            // 
            // dgvMouldDetail
            // 
            this.dgvMouldDetail.AllowUserToAddRows = false;
            this.dgvMouldDetail.AllowUserToDeleteRows = false;
            this.dgvMouldDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMouldDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMouldDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvMouldDetail.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMouldDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMouldDetail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMouldDetail.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvMouldDetail.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvMouldDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMouldDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mouldno,
            this.mouldcode,
            this.vendor,
            this.vendorname,
            this.gtcode});
            this.dgvMouldDetail.EnableHeadersVisualStyles = false;
            this.dgvMouldDetail.Location = new System.Drawing.Point(6, 22);
            this.dgvMouldDetail.Name = "dgvMouldDetail";
            this.dgvMouldDetail.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvMouldDetail.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvMouldDetail.ReadOnly = true;
            this.dgvMouldDetail.RowHeadersVisible = false;
            this.dgvMouldDetail.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvMouldDetail.SecondaryLength = 2;
            this.dgvMouldDetail.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvMouldDetail.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvMouldDetail.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvMouldDetail.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvMouldDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMouldDetail.Size = new System.Drawing.Size(613, 78);
            this.dgvMouldDetail.TabIndex = 16;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.FillWeight = 92.38579F;
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.FillWeight = 83F;
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.ReadOnly = true;
            // 
            // vendor
            // 
            this.vendor.DataPropertyName = "vendor";
            this.vendor.FillWeight = 92.38579F;
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.FillWeight = 210F;
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            // 
            // gtcode
            // 
            this.gtcode.DataPropertyName = "pgroup";
            this.gtcode.FillWeight = 70F;
            this.gtcode.HeaderText = "GT CODE";
            this.gtcode.Name = "gtcode";
            this.gtcode.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDownload);
            this.groupBox2.Controls.Add(this.dgvRelationship);
            this.groupBox2.Location = new System.Drawing.Point(634, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 640);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RELATIONSHIP";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.LightGray;
            this.btnCheck.ForeColor = System.Drawing.Color.Black;
            this.btnCheck.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCheck.Location = new System.Drawing.Point(325, 611);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(94, 23);
            this.btnCheck.TabIndex = 20;
            this.btnCheck.Text = "Check";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dgvRelationship
            // 
            this.dgvRelationship.AllowUserToAddRows = false;
            this.dgvRelationship.AllowUserToDeleteRows = false;
            this.dgvRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelationship.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelationship.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvRelationship.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRelationship.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRelationship.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRelationship.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvRelationship.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvRelationship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelationship.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.relationitemcode,
            this.type,
            this.relationremarks});
            this.dgvRelationship.EnableHeadersVisualStyles = false;
            this.dgvRelationship.Location = new System.Drawing.Point(6, 22);
            this.dgvRelationship.Name = "dgvRelationship";
            this.dgvRelationship.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvRelationship.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvRelationship.ReadOnly = true;
            this.dgvRelationship.RowHeadersVisible = false;
            this.dgvRelationship.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvRelationship.SecondaryLength = 2;
            this.dgvRelationship.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvRelationship.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvRelationship.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvRelationship.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvRelationship.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelationship.Size = new System.Drawing.Size(423, 583);
            this.dgvRelationship.TabIndex = 17;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "mouldno";
            this.dataGridViewTextBoxColumn1.FillWeight = 92.38579F;
            this.dataGridViewTextBoxColumn1.HeaderText = "MOULD NO.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // relationitemcode
            // 
            this.relationitemcode.DataPropertyName = "itemcode";
            this.relationitemcode.HeaderText = "PART NO.";
            this.relationitemcode.Name = "relationitemcode";
            this.relationitemcode.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // relationremarks
            // 
            this.relationremarks.DataPropertyName = "remarks";
            this.relationremarks.HeaderText = "REMARKS";
            this.relationremarks.Name = "relationremarks";
            this.relationremarks.ReadOnly = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(335, 611);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 21;
            this.btnDownload.Text = "Download";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRemove.Location = new System.Drawing.Point(6, 611);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 23);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // ucQuotationRelation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucQuotationRelation";
            this.Size = new System.Drawing.Size(1077, 646);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSetup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouldDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationship)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvMouldDetail;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvSetup;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn setcommon;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private CustomUtil.controls.button.CustomButton btnCancel;
        private CustomUtil.controls.button.CustomButton btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gtcode;
        private CustomUtil.controls.button.CustomButton btnCheck;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvRelationship;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationitemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationremarks;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.button.CustomButton btnRemove;
    }
}
