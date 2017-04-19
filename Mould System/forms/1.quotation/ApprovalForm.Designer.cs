namespace Mould_System.forms._1.quotation
{
    partial class ApprovalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovalForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dgvApproval = new System.Windows.Forms.DataGridView();
            this.cApproval = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.crequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cApplicant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAttachment = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnApproveAll = new System.Windows.Forms.ToolStripButton();
            this.btnReject = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproval)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApproveAll,
            this.btnReject,
            this.btnSave,
            this.btnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(1181, 24);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dgvApproval
            // 
            this.dgvApproval.AllowUserToAddRows = false;
            this.dgvApproval.AllowUserToDeleteRows = false;
            this.dgvApproval.AllowUserToResizeRows = false;
            this.dgvApproval.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvApproval.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApproval.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvApproval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvApproval.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvApproval.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvApproval.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApproval.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cApproval,
            this.crequest,
            this.cApplicant,
            this.cAttachment,
            this.cpath});
            this.dgvApproval.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvApproval.Location = new System.Drawing.Point(2, 26);
            this.dgvApproval.Name = "dgvApproval";
            this.dgvApproval.RowHeadersVisible = false;
            this.dgvApproval.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvApproval.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvApproval.Size = new System.Drawing.Size(1181, 573);
            this.dgvApproval.TabIndex = 101;
            this.dgvApproval.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApproval_CellContentClick);
            // 
            // cApproval
            // 
            this.cApproval.FillWeight = 30F;
            this.cApproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cApproval.HeaderText = "Approval";
            this.cApproval.Items.AddRange(new object[] {
            "---",
            "Approve",
            "Reject"});
            this.cApproval.Name = "cApproval";
            // 
            // crequest
            // 
            this.crequest.HeaderText = "Request Date";
            this.crequest.Name = "crequest";
            this.crequest.ReadOnly = true;
            // 
            // cApplicant
            // 
            this.cApplicant.HeaderText = "Applicant";
            this.cApplicant.Name = "cApplicant";
            this.cApplicant.ReadOnly = true;
            // 
            // cAttachment
            // 
            this.cAttachment.HeaderText = "Attachment";
            this.cAttachment.Name = "cAttachment";
            this.cAttachment.ReadOnly = true;
            // 
            // cpath
            // 
            this.cpath.HeaderText = "path";
            this.cpath.Name = "cpath";
            this.cpath.Visible = false;
            // 
            // btnApproveAll
            // 
            this.btnApproveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnApproveAll.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproveAll.ForeColor = System.Drawing.Color.Black;
            this.btnApproveAll.Image = ((System.Drawing.Image)(resources.GetObject("btnApproveAll.Image")));
            this.btnApproveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproveAll.Name = "btnApproveAll";
            this.btnApproveAll.Size = new System.Drawing.Size(85, 21);
            this.btnApproveAll.Text = "Approve All";
            this.btnApproveAll.Click += new System.EventHandler(this.btnApproveAll_Click);
            // 
            // btnReject
            // 
            this.btnReject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReject.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.ForeColor = System.Drawing.Color.Black;
            this.btnReject.Image = ((System.Drawing.Image)(resources.GetObject("btnReject.Image")));
            this.btnReject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(71, 21);
            this.btnReject.Text = "Reject All";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(41, 21);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.Black;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 21);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // ApprovalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1185, 600);
            this.Controls.Add(this.dgvApproval);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApprovalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ApprovalForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApproval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnApproveAll;
        private System.Windows.Forms.ToolStripButton btnReject;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridView dgvApproval;
        private System.Windows.Forms.DataGridViewComboBoxColumn cApproval;
        private System.Windows.Forms.DataGridViewTextBoxColumn crequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn cApplicant;
        private System.Windows.Forms.DataGridViewLinkColumn cAttachment;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpath;
    }
}