namespace Mould_System.forms._1.quotation
{
    partial class ucMouldViewer
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
            this.btnDownload = new CustomUtil.controls.button.CustomButton();
            this.btnSearch = new CustomUtil.controls.button.CustomButton();
            this.txtMouldno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMouldViewer = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUpload = new CustomUtil.controls.button.CustomButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouldViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtMouldno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1061, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOULD SEARCH";
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.LightGray;
            this.btnDownload.ForeColor = System.Drawing.Color.Black;
            this.btnDownload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnDownload.Location = new System.Drawing.Point(411, 27);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(94, 23);
            this.btnDownload.TabIndex = 16;
            this.btnDownload.Text = "Download All";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.LightGray;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSearch.Location = new System.Drawing.Point(311, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 23);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtMouldno
            // 
            this.txtMouldno.Location = new System.Drawing.Point(103, 27);
            this.txtMouldno.Name = "txtMouldno";
            this.txtMouldno.Size = new System.Drawing.Size(202, 23);
            this.txtMouldno.TabIndex = 1;
            this.txtMouldno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMouldno_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mould No. :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvMouldViewer);
            this.groupBox2.Location = new System.Drawing.Point(3, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1061, 575);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SEARCH RESULT";
            // 
            // dgvMouldViewer
            // 
            this.dgvMouldViewer.AllowUserToAddRows = false;
            this.dgvMouldViewer.AllowUserToDeleteRows = false;
            this.dgvMouldViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMouldViewer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMouldViewer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvMouldViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvMouldViewer.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvMouldViewer.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvMouldViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMouldViewer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mouldno,
            this.partno,
            this.type,
            this.remarks});
            this.dgvMouldViewer.Location = new System.Drawing.Point(6, 22);
            this.dgvMouldViewer.Name = "dgvMouldViewer";
            this.dgvMouldViewer.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvMouldViewer.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvMouldViewer.ReadOnly = true;
            this.dgvMouldViewer.RowHeadersVisible = false;
            this.dgvMouldViewer.SecondaryLength = 2;
            this.dgvMouldViewer.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvMouldViewer.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvMouldViewer.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvMouldViewer.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvMouldViewer.Size = new System.Drawing.Size(1049, 547);
            this.dgvMouldViewer.TabIndex = 12;
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
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "TYPE";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "REMARKS";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.LightGray;
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnUpload.Location = new System.Drawing.Point(511, 27);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(94, 23);
            this.btnUpload.TabIndex = 17;
            this.btnUpload.Text = "Upload";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // ucMouldViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucMouldViewer";
            this.Size = new System.Drawing.Size(1073, 642);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouldViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMouldno;
        private System.Windows.Forms.Label label1;
        private CustomUtil.controls.button.CustomButton btnSearch;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvMouldViewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn partno;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private CustomUtil.controls.button.CustomButton btnDownload;
        private CustomUtil.controls.button.CustomButton btnUpload;
    }
}
