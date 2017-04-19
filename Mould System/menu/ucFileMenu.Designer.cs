namespace Mould_System.menu
{
    partial class ucFileMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFileMenu));
            this.panel = new CustomUtil.controls.panel.CustomPanel();
            this.lblApplyRingi = new System.Windows.Forms.Label();
            this.lblQuotation = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.Window;
            this.panel.BackColor2 = System.Drawing.SystemColors.Window;
            this.panel.BorderColor = System.Drawing.Color.Silver;
            this.panel.BorderWidth = 2;
            this.panel.Controls.Add(this.lblApplyRingi);
            this.panel.Controls.Add(this.lblQuotation);
            this.panel.Curvature = 0;
            this.panel.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight)
                        | CustomUtil.controls.panel.CornerCurveMode.BottomLeft)
                        | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(212, 519);
            this.panel.TabIndex = 2;
            // 
            // lblApplyRingi
            // 
            this.lblApplyRingi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplyRingi.ForeColor = System.Drawing.Color.DimGray;
            this.lblApplyRingi.Image = ((System.Drawing.Image)(resources.GetObject("lblApplyRingi.Image")));
            this.lblApplyRingi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApplyRingi.Location = new System.Drawing.Point(3, 50);
            this.lblApplyRingi.Name = "lblApplyRingi";
            this.lblApplyRingi.Size = new System.Drawing.Size(206, 24);
            this.lblApplyRingi.TabIndex = 1;
            this.lblApplyRingi.Tag = "kdcfile";
            this.lblApplyRingi.Text = "         KDC";
            this.lblApplyRingi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApplyRingi.Click += new System.EventHandler(this.labelClick);
            // 
            // lblQuotation
            // 
            this.lblQuotation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuotation.ForeColor = System.Drawing.Color.DimGray;
            this.lblQuotation.Image = ((System.Drawing.Image)(resources.GetObject("lblQuotation.Image")));
            this.lblQuotation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuotation.Location = new System.Drawing.Point(3, 10);
            this.lblQuotation.Name = "lblQuotation";
            this.lblQuotation.Size = new System.Drawing.Size(206, 24);
            this.lblQuotation.TabIndex = 0;
            this.lblQuotation.Tag = "r3ulfile";
            this.lblQuotation.Text = "         R3 UL";
            this.lblQuotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQuotation.Click += new System.EventHandler(this.labelClick);
            // 
            // ucFileMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucFileMenu";
            this.Size = new System.Drawing.Size(212, 519);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanel panel;
        private System.Windows.Forms.Label lblApplyRingi;
        private System.Windows.Forms.Label lblQuotation;
    }
}
