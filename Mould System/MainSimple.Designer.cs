namespace Mould_System
{
    partial class MainSimple
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSimple));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tsbtnApproval = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHkView = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCnView = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(74)))), ((int)(((byte)(95)))));
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnApproval,
            this.toolStripSeparator1,
            this.tsbtnHkView,
            this.toolStripSeparator2,
            this.tsbtnCnView});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(60, 616);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(58, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(58, 6);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Location = new System.Drawing.Point(60, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1124, 611);
            this.pnlMain.TabIndex = 14;
            // 
            // tsbtnApproval
            // 
            this.tsbtnApproval.ForeColor = System.Drawing.Color.White;
            this.tsbtnApproval.Image = global::Mould_System.Properties.Resources.tick_white_24;
            this.tsbtnApproval.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnApproval.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnApproval.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.tsbtnApproval.Name = "tsbtnApproval";
            this.tsbtnApproval.Size = new System.Drawing.Size(58, 43);
            this.tsbtnApproval.Tag = "approval";
            this.tsbtnApproval.Text = "Approval";
            this.tsbtnApproval.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnApproval.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // tsbtnHkView
            // 
            this.tsbtnHkView.ForeColor = System.Drawing.Color.White;
            this.tsbtnHkView.Image = global::Mould_System.Properties.Resources.magnifier_white_24;
            this.tsbtnHkView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnHkView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHkView.Name = "tsbtnHkView";
            this.tsbtnHkView.Size = new System.Drawing.Size(58, 43);
            this.tsbtnHkView.Tag = "hkview";
            this.tsbtnHkView.Text = "HK Items";
            this.tsbtnHkView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnHkView.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // tsbtnCnView
            // 
            this.tsbtnCnView.ForeColor = System.Drawing.Color.White;
            this.tsbtnCnView.Image = global::Mould_System.Properties.Resources.magnifier_white_24;
            this.tsbtnCnView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnCnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCnView.Name = "tsbtnCnView";
            this.tsbtnCnView.Size = new System.Drawing.Size(58, 43);
            this.tsbtnCnView.Tag = "cnview";
            this.tsbtnCnView.Text = "CN Items";
            this.tsbtnCnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCnView.Click += new System.EventHandler(this.ButtonClicked);
            // 
            // MainSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1184, 612);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "-";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnApproval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbtnHkView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbtnCnView;
        private System.Windows.Forms.Panel pnlMain;

    }
}