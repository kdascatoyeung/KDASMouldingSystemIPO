namespace Mould_System.forms._1.quotation
{
    partial class FixedAssetStatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixedAssetStatusForm));
            this.dgvFa = new System.Windows.Forms.DataGridView();
            this.cstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cchaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.citemtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpdfid = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cattach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdSearch = new CustomUtil.controls.panel.CustomPanel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new CustomUtil.controls.textbox.WatermarkTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFa)).BeginInit();
            this.bdSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFa
            // 
            this.dgvFa.AllowUserToAddRows = false;
            this.dgvFa.AllowUserToDeleteRows = false;
            this.dgvFa.AllowUserToResizeRows = false;
            this.dgvFa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFa.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvFa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dgvFa.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dgvFa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFa.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cstatus,
            this.capptype,
            this.cchaseno,
            this.crequest,
            this.citemtext,
            this.cpdfid,
            this.cattach});
            this.dgvFa.Location = new System.Drawing.Point(2, 27);
            this.dgvFa.Name = "dgvFa";
            this.dgvFa.ReadOnly = true;
            this.dgvFa.RowHeadersVisible = false;
            this.dgvFa.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvFa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFa.Size = new System.Drawing.Size(1233, 559);
            this.dgvFa.TabIndex = 21;
            this.dgvFa.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFa_CellContentClick);
            // 
            // cstatus
            // 
            this.cstatus.DataPropertyName = "st";
            this.cstatus.HeaderText = "Status";
            this.cstatus.Name = "cstatus";
            this.cstatus.ReadOnly = true;
            // 
            // capptype
            // 
            this.capptype.DataPropertyName = "apptype";
            this.capptype.FillWeight = 30F;
            this.capptype.HeaderText = "Type";
            this.capptype.Name = "capptype";
            this.capptype.ReadOnly = true;
            // 
            // cchaseno
            // 
            this.cchaseno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cchaseno.DataPropertyName = "chaseno";
            this.cchaseno.HeaderText = "ChaseNo.";
            this.cchaseno.Name = "cchaseno";
            this.cchaseno.ReadOnly = true;
            this.cchaseno.Width = 83;
            // 
            // crequest
            // 
            this.crequest.DataPropertyName = "request";
            this.crequest.HeaderText = "Request";
            this.crequest.Name = "crequest";
            this.crequest.ReadOnly = true;
            // 
            // citemtext
            // 
            this.citemtext.DataPropertyName = "itemtext";
            this.citemtext.HeaderText = "Item Text";
            this.citemtext.Name = "citemtext";
            this.citemtext.ReadOnly = true;
            // 
            // cpdfid
            // 
            this.cpdfid.DataPropertyName = "pdfid";
            this.cpdfid.HeaderText = "Ref No.";
            this.cpdfid.Name = "cpdfid";
            this.cpdfid.ReadOnly = true;
            this.cpdfid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cpdfid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cattach
            // 
            this.cattach.DataPropertyName = "attachment";
            this.cattach.HeaderText = "attachment";
            this.cattach.Name = "cattach";
            this.cattach.ReadOnly = true;
            this.cattach.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cattach.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cattach.Visible = false;
            // 
            // bdSearch
            // 
            this.bdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdSearch.BackColor = System.Drawing.SystemColors.Window;
            this.bdSearch.BackColor2 = System.Drawing.SystemColors.Window;
            this.bdSearch.BorderColor = System.Drawing.Color.Silver;
            this.bdSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bdSearch.BorderWidth = 1;
            this.bdSearch.Controls.Add(this.btnSearch);
            this.bdSearch.Controls.Add(this.txtSearch);
            this.bdSearch.Curvature = 2;
            this.bdSearch.CurveMode = ((CustomUtil.controls.panel.CornerCurveMode)((((CustomUtil.controls.panel.CornerCurveMode.TopLeft | CustomUtil.controls.panel.CornerCurveMode.TopRight) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomLeft) 
            | CustomUtil.controls.panel.CornerCurveMode.BottomRight)));
            this.bdSearch.GradientMode = CustomUtil.controls.panel.LinearGradientMode.None;
            this.bdSearch.Location = new System.Drawing.Point(1038, 2);
            this.bdSearch.Name = "bdSearch";
            this.bdSearch.Size = new System.Drawing.Size(197, 22);
            this.bdSearch.TabIndex = 20;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(177, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(16, 16);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.FocusSelect = true;
            this.txtSearch.Location = new System.Drawing.Point(4, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PromptFont = new System.Drawing.Font("Calibri", 9F);
            this.txtSearch.PromptForeColor = System.Drawing.SystemColors.GrayText;
            this.txtSearch.PromptText = "Search here";
            this.txtSearch.Size = new System.Drawing.Size(167, 16);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // FixedAssetStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1236, 586);
            this.Controls.Add(this.dgvFa);
            this.Controls.Add(this.bdSearch);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FixedAssetStatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixed Asset - Status";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFa)).EndInit();
            this.bdSearch.ResumeLayout(false);
            this.bdSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFa;
        private System.Windows.Forms.DataGridViewTextBoxColumn cstatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn capptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn cchaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn crequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn citemtext;
        private System.Windows.Forms.DataGridViewLinkColumn cpdfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cattach;
        private CustomUtil.controls.panel.CustomPanel bdSearch;
        private System.Windows.Forms.Button btnSearch;
        private CustomUtil.controls.textbox.WatermarkTextbox txtSearch;
    }
}