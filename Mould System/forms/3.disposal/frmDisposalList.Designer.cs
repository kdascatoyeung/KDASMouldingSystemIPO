namespace Mould_System.forms._3.disposal
{
    partial class frmDisposalList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDisposal = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.common = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Commonstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApply = new CustomUtil.controls.button.CustomButton();
            this.cbDisposalType = new System.Windows.Forms.ComboBox();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.btnClear = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposal)).BeginInit();
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
            this.selected,
            this.status,
            this.chaseno,
            this.mouldno,
            this.common,
            this.partno,
            this.rev,
            this.type,
            this.fa,
            this.vendorcode,
            this.vendorname,
            this.Commonstatus});
            this.dgvDisposal.Location = new System.Drawing.Point(12, 41);
            this.dgvDisposal.Name = "dgvDisposal";
            this.dgvDisposal.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvDisposal.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvDisposal.RowHeadersVisible = false;
            this.dgvDisposal.SecondaryLength = 2;
            this.dgvDisposal.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvDisposal.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvDisposal.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvDisposal.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvDisposal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDisposal.Size = new System.Drawing.Size(1089, 497);
            this.dgvDisposal.TabIndex = 21;
            // 
            // selected
            // 
            this.selected.DataPropertyName = "selected";
            this.selected.FillWeight = 30F;
            this.selected.HeaderText = "SELECT";
            this.selected.Name = "selected";
            // 
            // status
            // 
            this.status.DataPropertyName = "qstatus";
            this.status.FillWeight = 44.2978F;
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.FillWeight = 44.2978F;
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.FillWeight = 80F;
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            // 
            // common
            // 
            this.common.DataPropertyName = "common";
            this.common.FillWeight = 80F;
            this.common.HeaderText = "COMMON MOULD";
            this.common.Name = "common";
            // 
            // partno
            // 
            this.partno.DataPropertyName = "itemcode";
            this.partno.FillWeight = 44.2978F;
            this.partno.HeaderText = "PART NO.";
            this.partno.Name = "partno";
            this.partno.ReadOnly = true;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.FillWeight = 30F;
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.FillWeight = 44.2978F;
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // fa
            // 
            this.fa.DataPropertyName = "fa";
            this.fa.FillWeight = 44.2978F;
            this.fa.HeaderText = "FA";
            this.fa.Name = "fa";
            this.fa.ReadOnly = true;
            // 
            // vendorcode
            // 
            this.vendorcode.DataPropertyName = "vendor";
            this.vendorcode.FillWeight = 44.2978F;
            this.vendorcode.HeaderText = "VENDOR";
            this.vendorcode.Name = "vendorcode";
            this.vendorcode.ReadOnly = true;
            // 
            // vendorname
            // 
            this.vendorname.DataPropertyName = "vendorname";
            this.vendorname.FillWeight = 120F;
            this.vendorname.HeaderText = "VENDOR NAME";
            this.vendorname.Name = "vendorname";
            this.vendorname.ReadOnly = true;
            // 
            // Commonstatus
            // 
            this.Commonstatus.DataPropertyName = "cstatus";
            this.Commonstatus.HeaderText = "CSTATUS";
            this.Commonstatus.Name = "Commonstatus";
            this.Commonstatus.Visible = false;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.LightGray;
            this.btnApply.ForeColor = System.Drawing.Color.Black;
            this.btnApply.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnApply.Location = new System.Drawing.Point(1007, 544);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(94, 23);
            this.btnApply.TabIndex = 22;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbDisposalType
            // 
            this.cbDisposalType.FormattingEnabled = true;
            this.cbDisposalType.Items.AddRange(new object[] {
            "Please select....",
            "Vendor提出",
            "KDC生産本部室提出",
            "IPO関連担当者提出",
            "不要金型"});
            this.cbDisposalType.Location = new System.Drawing.Point(12, 12);
            this.cbDisposalType.Name = "cbDisposalType";
            this.cbDisposalType.Size = new System.Drawing.Size(169, 23);
            this.cbDisposalType.TabIndex = 25;
            // 
            // ckbSelectAll
            // 
            this.ckbSelectAll.AutoSize = true;
            this.ckbSelectAll.Location = new System.Drawing.Point(13, 549);
            this.ckbSelectAll.Name = "ckbSelectAll";
            this.ckbSelectAll.Size = new System.Drawing.Size(76, 19);
            this.ckbSelectAll.TabIndex = 26;
            this.ckbSelectAll.Text = "Select All";
            this.ckbSelectAll.UseVisualStyleBackColor = true;
            this.ckbSelectAll.CheckedChanged += new System.EventHandler(this.ckbSelectAll_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnClear.Location = new System.Drawing.Point(95, 546);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmDisposalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1113, 579);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.ckbSelectAll);
            this.Controls.Add(this.cbDisposalType);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.dgvDisposal);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmDisposalList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisposal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvDisposal;
        private CustomUtil.controls.button.CustomButton btnApply;
        private System.Windows.Forms.ComboBox cbDisposalType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn common;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fa;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Commonstatus;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private CustomUtil.controls.button.CustomButton btnClear;
    }
}