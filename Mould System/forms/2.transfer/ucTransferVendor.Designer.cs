namespace Mould_System.forms._2.transfer
{
    partial class ucTransferVendor
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
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new CustomUtil.controls.button.CustomButton();
            this.dgvTransferPreview = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorbefore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorafter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetail = new CustomUtil.controls.button.CustomButton();
            this.cbMouldno = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new CustomUtil.controls.button.CustomButton();
            this.txtItemcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVendorAfter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGo = new CustomUtil.controls.button.CustomButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(964, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(3, 3);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 29;
            this.btnUpload.Text = "Upload";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.dgvTransferPreview);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Location = new System.Drawing.Point(3, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1064, 466);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PREVIEW";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRemove.Location = new System.Drawing.Point(6, 437);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 23);
            this.btnRemove.TabIndex = 31;
            this.btnRemove.Text = "Remove";
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
            this.chaseno,
            this.mouldno,
            this.partno,
            this.rev,
            this.fee,
            this.vendorbefore,
            this.vendorafter,
            this.ringi,
            this.fa});
            this.dgvTransferPreview.Location = new System.Drawing.Point(6, 22);
            this.dgvTransferPreview.Name = "dgvTransferPreview";
            this.dgvTransferPreview.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvTransferPreview.ReadOnly = true;
            this.dgvTransferPreview.RowHeadersVisible = false;
            this.dgvTransferPreview.SecondaryLength = 2;
            this.dgvTransferPreview.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvTransferPreview.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvTransferPreview.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvTransferPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferPreview.Size = new System.Drawing.Size(1052, 411);
            this.dgvTransferPreview.TabIndex = 16;
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
            // fee
            // 
            this.fee.HeaderText = "FEE";
            this.fee.Name = "fee";
            this.fee.ReadOnly = true;
            // 
            // vendorbefore
            // 
            this.vendorbefore.HeaderText = "VENDOR (BEFORE)";
            this.vendorbefore.Name = "vendorbefore";
            this.vendorbefore.ReadOnly = true;
            // 
            // vendorafter
            // 
            this.vendorafter.HeaderText = "VENDOR (AFTER)";
            this.vendorafter.Name = "vendorafter";
            this.vendorafter.ReadOnly = true;
            // 
            // ringi
            // 
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.ReadOnly = true;
            // 
            // fa
            // 
            this.fa.HeaderText = "FA CODE";
            this.fa.Name = "fa";
            this.fa.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDetail);
            this.groupBox1.Controls.Add(this.cbMouldno);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtRev);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtItemcode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 135);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TRANSFER";
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.Color.LightGray;
            this.btnDetail.ForeColor = System.Drawing.Color.Black;
            this.btnDetail.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDetail.Location = new System.Drawing.Point(327, 92);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(94, 23);
            this.btnDetail.TabIndex = 24;
            this.btnDetail.Text = "Detail";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // cbMouldno
            // 
            this.cbMouldno.FormattingEnabled = true;
            this.cbMouldno.Location = new System.Drawing.Point(100, 92);
            this.cbMouldno.Name = "cbMouldno";
            this.cbMouldno.Size = new System.Drawing.Size(221, 23);
            this.cbMouldno.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mould No. :";
            // 
            // txtRev
            // 
            this.txtRev.Location = new System.Drawing.Point(100, 63);
            this.txtRev.Name = "txtRev";
            this.txtRev.Size = new System.Drawing.Size(221, 23);
            this.txtRev.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Rev :";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSearch.Location = new System.Drawing.Point(327, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 23);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtItemcode
            // 
            this.txtItemcode.Location = new System.Drawing.Point(100, 34);
            this.txtItemcode.Name = "txtItemcode";
            this.txtItemcode.Size = new System.Drawing.Size(221, 23);
            this.txtItemcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Part No. :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFee);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtVendorAfter);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(453, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(350, 135);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TARGET";
            // 
            // txtFee
            // 
            this.txtFee.Location = new System.Drawing.Point(104, 63);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(221, 23);
            this.txtFee.TabIndex = 29;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Fee :";
            // 
            // txtVendorAfter
            // 
            this.txtVendorAfter.Location = new System.Drawing.Point(104, 34);
            this.txtVendorAfter.Name = "txtVendorAfter";
            this.txtVendorAfter.Size = new System.Drawing.Size(221, 23);
            this.txtVendorAfter.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.label9.TabIndex = 26;
            this.label9.Text = "Vendor (After) :";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.BackColor = System.Drawing.Color.LightGray;
            this.btnGo.ForeColor = System.Drawing.Color.Black;
            this.btnGo.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnGo.Location = new System.Drawing.Point(6, 33);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(246, 53);
            this.btnGo.TabIndex = 30;
            this.btnGo.Text = "Preview";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnGo);
            this.groupBox4.Location = new System.Drawing.Point(809, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 135);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "FUNCTION";
            // 
            // ucTransferVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucTransferVendor";
            this.Size = new System.Drawing.Size(1073, 642);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.button.CustomButton btnSave;
        private CustomUtil.controls.button.CustomButton btnUpload;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvTransferPreview;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorbefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorafter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomUtil.controls.button.CustomButton btnDetail;
        private System.Windows.Forms.ComboBox cbMouldno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRev;
        private System.Windows.Forms.Label label2;
        private CustomUtil.controls.button.CustomButton btnSearch;
        private System.Windows.Forms.TextBox txtItemcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private CustomUtil.controls.button.CustomButton btnGo;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVendorAfter;
        private System.Windows.Forms.Label label9;
        private CustomUtil.controls.button.CustomButton btnRemove;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}
