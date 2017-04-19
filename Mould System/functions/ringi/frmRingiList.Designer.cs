namespace Mould_System.functions.ringi
{
    partial class frmRingiList
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
            this.dgvRingiItemList = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.download = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCancel = new CustomUtil.controls.button.CustomButton();
            this.btnApply = new CustomUtil.controls.button.CustomButton();
            this.btnRemove = new CustomUtil.controls.button.CustomButton();
            this.ckbAll = new System.Windows.Forms.CheckBox();
            this.customButton1 = new CustomUtil.controls.button.CustomButton();
            this.customButton2 = new CustomUtil.controls.button.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRingiItemList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRingiItemList
            // 
            this.dgvRingiItemList.AllowUserToAddRows = false;
            this.dgvRingiItemList.AllowUserToDeleteRows = false;
            this.dgvRingiItemList.AllowUserToResizeRows = false;
            this.dgvRingiItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRingiItemList.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRingiItemList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRingiItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRingiItemList.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvRingiItemList.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvRingiItemList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRingiItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.mouldno,
            this.partno,
            this.rev,
            this.currency,
            this.amount,
            this.amounthkd,
            this.itemtext,
            this.vendor,
            this.ringi,
            this.mouldcode,
            this.category,
            this.remarks,
            this.download});
            this.dgvRingiItemList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvRingiItemList.Location = new System.Drawing.Point(0, 0);
            this.dgvRingiItemList.Name = "dgvRingiItemList";
            this.dgvRingiItemList.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvRingiItemList.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvRingiItemList.RowHeadersVisible = false;
            this.dgvRingiItemList.SecondaryLength = 2;
            this.dgvRingiItemList.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvRingiItemList.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvRingiItemList.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvRingiItemList.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvRingiItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRingiItemList.Size = new System.Drawing.Size(974, 526);
            this.dgvRingiItemList.TabIndex = 8;
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
            // amounthkd
            // 
            this.amounthkd.DataPropertyName = "amounthkd";
            this.amounthkd.HeaderText = "AMOUNT (HKD)";
            this.amounthkd.Name = "amounthkd";
            this.amounthkd.ReadOnly = true;
            // 
            // itemtext
            // 
            this.itemtext.DataPropertyName = "itemtext";
            this.itemtext.HeaderText = "ITEM TEXT";
            this.itemtext.Name = "itemtext";
            this.itemtext.ReadOnly = true;
            // 
            // vendor
            // 
            this.vendor.HeaderText = "VENDOR";
            this.vendor.Name = "vendor";
            this.vendor.ReadOnly = true;
            // 
            // ringi
            // 
            this.ringi.DataPropertyName = "ringi";
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.ReadOnly = true;
            // 
            // mouldcode
            // 
            this.mouldcode.DataPropertyName = "mouldcode";
            this.mouldcode.HeaderText = "MOULD CODE";
            this.mouldcode.Name = "mouldcode";
            this.mouldcode.ReadOnly = true;
            // 
            // category
            // 
            this.category.DataPropertyName = "category";
            this.category.HeaderText = "CATEGORY";
            this.category.Name = "category";
            this.category.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            // 
            // download
            // 
            this.download.HeaderText = "DOWNLOAD";
            this.download.Name = "download";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(868, 543);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.LightGray;
            this.btnApply.ForeColor = System.Drawing.Color.Black;
            this.btnApply.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnApply.Location = new System.Drawing.Point(668, 543);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(94, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.LightGray;
            this.btnRemove.ForeColor = System.Drawing.Color.Black;
            this.btnRemove.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRemove.Location = new System.Drawing.Point(768, 543);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(94, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "Remove";
            // 
            // ckbAll
            // 
            this.ckbAll.AutoSize = true;
            this.ckbAll.Location = new System.Drawing.Point(12, 546);
            this.ckbAll.Name = "ckbAll";
            this.ckbAll.Size = new System.Drawing.Size(76, 19);
            this.ckbAll.TabIndex = 12;
            this.ckbAll.Text = "Select All";
            this.ckbAll.UseVisualStyleBackColor = true;
            this.ckbAll.Visible = false;
            this.ckbAll.CheckedChanged += new System.EventHandler(this.ckbAll_CheckedChanged);
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.LightGray;
            this.customButton1.ForeColor = System.Drawing.Color.Black;
            this.customButton1.InnerBorderColor = System.Drawing.Color.Gray;
            this.customButton1.Location = new System.Drawing.Point(153, 542);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(94, 23);
            this.customButton1.TabIndex = 13;
            this.customButton1.Text = "Temp";
            this.customButton1.Visible = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.LightGray;
            this.customButton2.ForeColor = System.Drawing.Color.Black;
            this.customButton2.InnerBorderColor = System.Drawing.Color.Gray;
            this.customButton2.Location = new System.Drawing.Point(253, 542);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(94, 23);
            this.customButton2.TabIndex = 14;
            this.customButton2.Text = "Temp2";
            this.customButton2.Visible = false;
            this.customButton2.Click += new System.EventHandler(this.customButton2_Click);
            // 
            // frmRingiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(974, 578);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.ckbAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvRingiItemList);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRingiList";
            this.Text = "Items to Apply RINGI";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRingiItemList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvRingiItemList;
        private CustomUtil.controls.button.CustomButton btnCancel;
        private CustomUtil.controls.button.CustomButton btnApply;
        private CustomUtil.controls.button.CustomButton btnRemove;
        private System.Windows.Forms.CheckBox ckbAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtext;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn category;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.DataGridViewCheckBoxColumn download;
        private CustomUtil.controls.button.CustomButton customButton1;
        private CustomUtil.controls.button.CustomButton customButton2;
    }
}