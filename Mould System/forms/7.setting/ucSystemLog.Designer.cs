namespace Mould_System.forms._7.setting
{
    partial class ucSystemLog
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
            this.cbOperator = new System.Windows.Forms.ComboBox();
            this.dgvLog = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tovalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedby = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.dpDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(950, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 23);
            this.txtSearch.TabIndex = 19;
            // 
            // cbSearch
            // 
            this.cbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSearch.FormattingEnabled = true;
            this.cbSearch.Location = new System.Drawing.Point(722, 3);
            this.cbSearch.Name = "cbSearch";
            this.cbSearch.Size = new System.Drawing.Size(132, 23);
            this.cbSearch.TabIndex = 18;
            // 
            // cbOperator
            // 
            this.cbOperator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbOperator.FormattingEnabled = true;
            this.cbOperator.Items.AddRange(new object[] {
            "All",
            "Code",
            "Content",
            "Remarks",
            "Account Code",
            "Cost Centre"});
            this.cbOperator.Location = new System.Drawing.Point(860, 3);
            this.cbOperator.Name = "cbOperator";
            this.cbOperator.Size = new System.Drawing.Size(84, 23);
            this.cbOperator.TabIndex = 20;
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvLog.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvLog.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datetime,
            this.module,
            this.chaseno,
            this.fromvalue,
            this.tovalue,
            this.msg,
            this.modifiedby});
            this.dgvLog.Location = new System.Drawing.Point(3, 32);
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvLog.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvLog.ReadOnly = true;
            this.dgvLog.RowHeadersVisible = false;
            this.dgvLog.SecondaryLength = 2;
            this.dgvLog.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvLog.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvLog.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvLog.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvLog.Size = new System.Drawing.Size(1067, 580);
            this.dgvLog.TabIndex = 21;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "dt";
            this.datetime.HeaderText = "DATETIME";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            // 
            // module
            // 
            this.module.DataPropertyName = "module";
            this.module.HeaderText = "MODULE";
            this.module.Name = "module";
            this.module.ReadOnly = true;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            // 
            // fromvalue
            // 
            this.fromvalue.DataPropertyName = "fromvalue";
            this.fromvalue.HeaderText = "FROM VALUE";
            this.fromvalue.Name = "fromvalue";
            this.fromvalue.ReadOnly = true;
            // 
            // tovalue
            // 
            this.tovalue.DataPropertyName = "tovalue";
            this.tovalue.HeaderText = "TO VALUE";
            this.tovalue.Name = "tovalue";
            this.tovalue.ReadOnly = true;
            // 
            // msg
            // 
            this.msg.DataPropertyName = "msg";
            this.msg.HeaderText = "MESSAGE";
            this.msg.Name = "msg";
            this.msg.ReadOnly = true;
            // 
            // modifiedby
            // 
            this.modifiedby.DataPropertyName = "modifiedby";
            this.modifiedby.HeaderText = "MODIFIED BY";
            this.modifiedby.Name = "modifiedby";
            this.modifiedby.ReadOnly = true;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(3, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 23;
            this.btnDownload.Text = "Download";
            // 
            // dpDate
            // 
            this.dpDate.CustomFormat = "yyyy/MM/dd";
            this.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpDate.Location = new System.Drawing.Point(954, 3);
            this.dpDate.Name = "dpDate";
            this.dpDate.Size = new System.Drawing.Size(120, 23);
            this.dpDate.TabIndex = 24;
            this.dpDate.Visible = false;
            // 
            // ucSystemLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.dpDate);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvLog);
            this.Controls.Add(this.cbOperator);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cbSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucSystemLog";
            this.Size = new System.Drawing.Size(1073, 642);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cbSearch;
        private System.Windows.Forms.ComboBox cbOperator;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvLog;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn module;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromvalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn tovalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedby;
        private System.Windows.Forms.DateTimePicker dpDate;
    }
}
