namespace Mould_System.functions.others
{
    partial class frmProgressBar
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
            this.customPanelOutside1 = new CustomUtil.controls.panel.CustomPanelOutside();
            this.customProgressBar1 = new CustomUtil.controls.progressbar.CustomProgressBar();
            this.customPanelOutside1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customPanelOutside1
            // 
            this.customPanelOutside1.BackColor = System.Drawing.SystemColors.Window;
            this.customPanelOutside1.BackColor2 = System.Drawing.SystemColors.Window;
            this.customPanelOutside1.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.customPanelOutside1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanelOutside1.BorderWidth = 1;
            this.customPanelOutside1.Controls.Add(this.customProgressBar1);
            this.customPanelOutside1.Curvature = 5;
            this.customPanelOutside1.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight)
                        | CustomUtil.controls.panel.CornerCurveMode.BottomLeft)
                        | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.customPanelOutside1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customPanelOutside1.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.customPanelOutside1.Location = new System.Drawing.Point(0, 0);
            this.customPanelOutside1.Name = "customPanelOutside1";
            this.customPanelOutside1.Size = new System.Drawing.Size(83, 81);
            this.customPanelOutside1.TabIndex = 0;
            // 
            // customProgressBar1
            // 
            this.customProgressBar1.AutoStart = true;
            this.customProgressBar1.Location = new System.Drawing.Point(16, 12);
            this.customProgressBar1.Name = "customProgressBar1";
            this.customProgressBar1.Percentage = 0F;
            this.customProgressBar1.Size = new System.Drawing.Size(55, 55);
            this.customProgressBar1.TabIndex = 0;
            this.customProgressBar1.Text = "customProgressBar1";
            // 
            // frmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(83, 81);
            this.Controls.Add(this.customPanelOutside1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Uploading....";
            this.customPanelOutside1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomUtil.controls.panel.CustomPanelOutside customPanelOutside1;
        private CustomUtil.controls.progressbar.CustomProgressBar customProgressBar1;
    }
}