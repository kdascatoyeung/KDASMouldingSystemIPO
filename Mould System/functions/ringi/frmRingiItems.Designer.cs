namespace Mould_System.functions.ringi
{
    partial class frmRingiItems
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
            this.dgvRingiItems = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.ringi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amounthkd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.r3data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRingiItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRingiItems
            // 
            this.dgvRingiItems.AllowUserToAddRows = false;
            this.dgvRingiItems.AllowUserToDeleteRows = false;
            this.dgvRingiItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRingiItems.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRingiItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRingiItems.ColumnHeaderColor1 = System.Drawing.Color.White;
            this.dgvRingiItems.ColumnHeaderColor2 = System.Drawing.Color.LightSteelBlue;
            this.dgvRingiItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRingiItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ringi,
            this.content,
            this.currency,
            this.amount,
            this.amounthkd,
            this.balance,
            this.r3data,
            this.expiry});
            this.dgvRingiItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRingiItems.Location = new System.Drawing.Point(0, 0);
            this.dgvRingiItems.Name = "dgvRingiItems";
            this.dgvRingiItems.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvRingiItems.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvRingiItems.ReadOnly = true;
            this.dgvRingiItems.RowHeadersVisible = false;
            this.dgvRingiItems.SecondaryLength = 2;
            this.dgvRingiItems.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvRingiItems.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvRingiItems.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvRingiItems.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvRingiItems.Size = new System.Drawing.Size(848, 584);
            this.dgvRingiItems.TabIndex = 19;
            // 
            // ringi
            // 
            this.ringi.DataPropertyName = "ringi";
            this.ringi.HeaderText = "RINGI";
            this.ringi.Name = "ringi";
            this.ringi.ReadOnly = true;
            // 
            // content
            // 
            this.content.DataPropertyName = "content";
            this.content.HeaderText = "CONTENT";
            this.content.Name = "content";
            this.content.ReadOnly = true;
            // 
            // currency
            // 
            this.currency.DataPropertyName = "currency";
            this.currency.HeaderText = "CURRENCY";
            this.currency.Name = "currency";
            this.currency.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.DataPropertyName = "amount";
            this.amount.HeaderText = "AMOUNT";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // amounthkd
            // 
            this.amounthkd.DataPropertyName = "amounthkd";
            this.amounthkd.HeaderText = "AMOUNT (HKD)";
            this.amounthkd.Name = "amounthkd";
            this.amounthkd.ReadOnly = true;
            // 
            // balance
            // 
            this.balance.DataPropertyName = "balance";
            this.balance.HeaderText = "BALANCE";
            this.balance.Name = "balance";
            this.balance.ReadOnly = true;
            // 
            // r3data
            // 
            this.r3data.DataPropertyName = "r3confirm";
            this.r3data.HeaderText = "R3 CONFIRMED";
            this.r3data.Name = "r3data";
            this.r3data.ReadOnly = true;
            // 
            // expiry
            // 
            this.expiry.DataPropertyName = "expired";
            this.expiry.HeaderText = "EXPIRY";
            this.expiry.Name = "expiry";
            this.expiry.ReadOnly = true;
            // 
            // frmRingiItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(848, 584);
            this.Controls.Add(this.dgvRingiItems);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRingiItems";
            this.ShowInTaskbar = false;
            this.Text = "frmRingiItems";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRingiItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.datagrid.CustomDatagrid dgvRingiItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn ringi;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.DataGridViewTextBoxColumn currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn amounthkd;
        private System.Windows.Forms.DataGridViewTextBoxColumn balance;
        private System.Windows.Forms.DataGridViewTextBoxColumn r3data;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiry;
    }
}