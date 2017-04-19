namespace Mould_System.functions.instock
{
    partial class frmInStockRollBack
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
            this.txtPO = new System.Windows.Forms.TextBox();
            this.btnRollBack = new CustomUtil.controls.button.CustomButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnK = new System.Windows.Forms.RadioButton();
            this.rbtnPRpass = new System.Windows.Forms.RadioButton();
            this.rbtnHS = new System.Windows.Forms.RadioButton();
            this.rbtnPRfail = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(12, 12);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(217, 23);
            this.txtPO.TabIndex = 0;
            this.txtPO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPO_KeyDown);
            // 
            // btnRollBack
            // 
            this.btnRollBack.BackColor = System.Drawing.Color.LightGray;
            this.btnRollBack.ForeColor = System.Drawing.Color.Black;
            this.btnRollBack.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnRollBack.Location = new System.Drawing.Point(235, 12);
            this.btnRollBack.Name = "btnRollBack";
            this.btnRollBack.Size = new System.Drawing.Size(119, 23);
            this.btnRollBack.TabIndex = 28;
            this.btnRollBack.Text = "Roll Back";
            this.btnRollBack.Click += new System.EventHandler(this.btnRollBack_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rbtnPRfail);
            this.panel1.Controls.Add(this.rbtnHS);
            this.panel1.Controls.Add(this.rbtnPRpass);
            this.panel1.Controls.Add(this.rbtnK);
            this.panel1.Location = new System.Drawing.Point(12, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 104);
            this.panel1.TabIndex = 29;
            // 
            // rbtnK
            // 
            this.rbtnK.AutoSize = true;
            this.rbtnK.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnK.Location = new System.Drawing.Point(3, 3);
            this.rbtnK.Name = "rbtnK";
            this.rbtnK.Size = new System.Drawing.Size(75, 24);
            this.rbtnK.TabIndex = 0;
            this.rbtnK.TabStop = true;
            this.rbtnK.Text = "待入庫";
            this.rbtnK.UseVisualStyleBackColor = true;
            // 
            // rbtnPRpass
            // 
            this.rbtnPRpass.AutoSize = true;
            this.rbtnPRpass.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPRpass.Location = new System.Drawing.Point(3, 28);
            this.rbtnPRpass.Name = "rbtnPRpass";
            this.rbtnPRpass.Size = new System.Drawing.Size(121, 24);
            this.rbtnPRpass.TabIndex = 1;
            this.rbtnPRpass.TabStop = true;
            this.rbtnPRpass.Text = "已回收 (合格)";
            this.rbtnPRpass.UseVisualStyleBackColor = true;
            // 
            // rbtnHS
            // 
            this.rbtnHS.AutoSize = true;
            this.rbtnHS.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnHS.Location = new System.Drawing.Point(3, 78);
            this.rbtnHS.Name = "rbtnHS";
            this.rbtnHS.Size = new System.Drawing.Size(91, 24);
            this.rbtnHS.TabIndex = 2;
            this.rbtnHS.TabStop = true;
            this.rbtnHS.Text = "已付50%";
            this.rbtnHS.UseVisualStyleBackColor = true;
            // 
            // rbtnPRfail
            // 
            this.rbtnPRfail.AutoSize = true;
            this.rbtnPRfail.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPRfail.Location = new System.Drawing.Point(3, 53);
            this.rbtnPRfail.Name = "rbtnPRfail";
            this.rbtnPRfail.Size = new System.Drawing.Size(137, 24);
            this.rbtnPRfail.TabIndex = 3;
            this.rbtnPRfail.TabStop = true;
            this.rbtnPRfail.Text = "已回收 (不合格)";
            this.rbtnPRfail.UseVisualStyleBackColor = true;
            // 
            // frmInStockRollBack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(370, 157);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnRollBack);
            this.Controls.Add(this.txtPO);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInStockRollBack";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Please input PO to roll back from In Stock";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPO;
        private CustomUtil.controls.button.CustomButton btnRollBack;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnHS;
        private System.Windows.Forms.RadioButton rbtnPRpass;
        private System.Windows.Forms.RadioButton rbtnK;
        private System.Windows.Forms.RadioButton rbtnPRfail;
    }
}