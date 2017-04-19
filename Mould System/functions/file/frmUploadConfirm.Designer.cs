namespace Mould_System.functions.file
{
    partial class frmUploadConfirm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirm = new CustomUtil.controls.button.CustomButton();
            this.btnCancel = new CustomUtil.controls.button.CustomButton();
            this.dgvUpload = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpload)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1148, 32);
            this.panel1.TabIndex = 13;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.LightGray;
            this.btnConfirm.ForeColor = System.Drawing.Color.Black;
            this.btnConfirm.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnConfirm.Location = new System.Drawing.Point(951, 6);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(94, 23);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(1051, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvUpload
            // 
            this.dgvUpload.AllowUserToAddRows = false;
            this.dgvUpload.AllowUserToDeleteRows = false;
            this.dgvUpload.AllowUserToResizeRows = false;
            this.dgvUpload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUpload.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvUpload.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUpload.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUpload.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvUpload.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUpload.Location = new System.Drawing.Point(0, 0);
            this.dgvUpload.Name = "dgvUpload";
            this.dgvUpload.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvUpload.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvUpload.ReadOnly = true;
            this.dgvUpload.RowHeadersVisible = false;
            this.dgvUpload.SecondaryLength = 2;
            this.dgvUpload.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvUpload.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvUpload.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvUpload.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvUpload.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUpload.Size = new System.Drawing.Size(1148, 543);
            this.dgvUpload.TabIndex = 14;
            // 
            // frmUploadConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1148, 575);
            this.Controls.Add(this.dgvUpload);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUploadConfirm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Upload Data Preview";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUpload)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvUpload;
        private CustomUtil.controls.button.CustomButton btnConfirm;
        private CustomUtil.controls.button.CustomButton btnCancel;
    }
}