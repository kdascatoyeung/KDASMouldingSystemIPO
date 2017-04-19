namespace Mould_System.functions.quotation
{
    partial class ucQuotationModify
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.lblSet = new System.Windows.Forms.Label();
            this.lblCommon = new System.Windows.Forms.Label();
            this.lblSingle = new System.Windows.Forms.Label();
            this.btnCancel = new CustomUtil.controls.button.CustomButton();
            this.btnSave = new CustomUtil.controls.button.CustomButton();
            this.dgvRelationship = new CustomUtil.controls.datagrid.CustomDatagrid();
            this.chaseno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mouldno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbOwner = new System.Windows.Forms.ComboBox();
            this.ckbModify = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbGroup = new System.Windows.Forms.ComboBox();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiv = new System.Windows.Forms.TextBox();
            this.txtPcs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtMouldCode = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblVendorname = new System.Windows.Forms.Label();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblPurchaser = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.txtVendor = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtOemasset = new System.Windows.Forms.TextBox();
            this.ckbMpa = new System.Windows.Forms.CheckBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtRev = new System.Windows.Forms.TextBox();
            this.txtItemcode = new System.Windows.Forms.TextBox();
            this.txtMouldno = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblChaseno = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationship)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panelMenu);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.dgvRelationship);
            this.groupBox2.Location = new System.Drawing.Point(500, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 640);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RELATIONSHIP";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.lblSet);
            this.panelMenu.Controls.Add(this.lblCommon);
            this.panelMenu.Controls.Add(this.lblSingle);
            this.panelMenu.Location = new System.Drawing.Point(6, 15);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(326, 25);
            this.panelMenu.TabIndex = 45;
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSet.Location = new System.Drawing.Point(79, 3);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(33, 19);
            this.lblSet.TabIndex = 43;
            this.lblSet.Tag = "set";
            this.lblSet.Text = "SET";
            this.lblSet.Click += new System.EventHandler(this.labelClick);
            // 
            // lblCommon
            // 
            this.lblCommon.AutoSize = true;
            this.lblCommon.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCommon.Location = new System.Drawing.Point(131, 3);
            this.lblCommon.Name = "lblCommon";
            this.lblCommon.Size = new System.Drawing.Size(78, 19);
            this.lblCommon.TabIndex = 44;
            this.lblCommon.Tag = "common";
            this.lblCommon.Text = "COMMON";
            this.lblCommon.Click += new System.EventHandler(this.labelClick);
            // 
            // lblSingle
            // 
            this.lblSingle.AutoSize = true;
            this.lblSingle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSingle.Location = new System.Drawing.Point(5, 3);
            this.lblSingle.Name = "lblSingle";
            this.lblSingle.Size = new System.Drawing.Size(57, 19);
            this.lblSingle.TabIndex = 42;
            this.lblSingle.Tag = "single";
            this.lblSingle.Text = "SINGLE";
            this.lblSingle.Click += new System.EventHandler(this.labelClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightGray;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnCancel.Location = new System.Drawing.Point(470, 611);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.LightGray;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.InnerBorderColor = System.Drawing.Color.Gray;
            this.btnSave.Location = new System.Drawing.Point(370, 611);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvRelationship
            // 
            this.dgvRelationship.AllowUserToAddRows = false;
            this.dgvRelationship.AllowUserToDeleteRows = false;
            this.dgvRelationship.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRelationship.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRelationship.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvRelationship.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRelationship.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRelationship.ColumnHeaderColor1 = System.Drawing.Color.WhiteSmoke;
            this.dgvRelationship.ColumnHeaderColor2 = System.Drawing.Color.WhiteSmoke;
            this.dgvRelationship.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRelationship.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRelationship.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chaseno,
            this.mouldno,
            this.itemcode,
            this.rev});
            this.dgvRelationship.Location = new System.Drawing.Point(6, 41);
            this.dgvRelationship.Name = "dgvRelationship";
            this.dgvRelationship.PrimaryRowcolor1 = System.Drawing.Color.White;
            this.dgvRelationship.PrimaryRowcolor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(249)))), ((int)(((byte)(232)))));
            this.dgvRelationship.ReadOnly = true;
            this.dgvRelationship.RowHeadersVisible = false;
            this.dgvRelationship.SecondaryLength = 2;
            this.dgvRelationship.SecondaryRowColor1 = System.Drawing.Color.White;
            this.dgvRelationship.SecondaryRowColor2 = System.Drawing.Color.White;
            this.dgvRelationship.SelectedRowColor1 = System.Drawing.Color.White;
            this.dgvRelationship.SelectedRowColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(217)))), ((int)(((byte)(254)))));
            this.dgvRelationship.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRelationship.Size = new System.Drawing.Size(558, 564);
            this.dgvRelationship.TabIndex = 6;
            // 
            // chaseno
            // 
            this.chaseno.DataPropertyName = "chaseno";
            this.chaseno.HeaderText = "CHASE NO.";
            this.chaseno.Name = "chaseno";
            this.chaseno.ReadOnly = true;
            // 
            // mouldno
            // 
            this.mouldno.DataPropertyName = "mouldno";
            this.mouldno.HeaderText = "MOULD NO.";
            this.mouldno.Name = "mouldno";
            this.mouldno.ReadOnly = true;
            // 
            // itemcode
            // 
            this.itemcode.DataPropertyName = "itemcode";
            this.itemcode.HeaderText = "PART NO.";
            this.itemcode.Name = "itemcode";
            this.itemcode.ReadOnly = true;
            // 
            // rev
            // 
            this.rev.DataPropertyName = "rev";
            this.rev.HeaderText = "REV";
            this.rev.Name = "rev";
            this.rev.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cbOwner);
            this.groupBox1.Controls.Add(this.ckbModify);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.cbGroup);
            this.groupBox1.Controls.Add(this.txtOwner);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDiv);
            this.groupBox1.Controls.Add(this.txtPcs);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lblContent);
            this.groupBox1.Controls.Add(this.lblType);
            this.groupBox1.Controls.Add(this.txtMouldCode);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lblVendorname);
            this.groupBox1.Controls.Add(this.lblCurrency);
            this.groupBox1.Controls.Add(this.lblPurchaser);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Controls.Add(this.txtVendor);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.txtOemasset);
            this.groupBox1.Controls.Add(this.ckbMpa);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtRev);
            this.groupBox1.Controls.Add(this.txtItemcode);
            this.groupBox1.Controls.Add(this.txtMouldno);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblChaseno);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 640);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MODIFY";
            // 
            // cbOwner
            // 
            this.cbOwner.FormattingEnabled = true;
            this.cbOwner.Items.AddRange(new object[] {
            "KDTHK",
            "KDC",
            "KDTCN",
            "KDTVN"});
            this.cbOwner.Location = new System.Drawing.Point(334, 137);
            this.cbOwner.Name = "cbOwner";
            this.cbOwner.Size = new System.Drawing.Size(136, 23);
            this.cbOwner.TabIndex = 6;
            this.cbOwner.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // ckbModify
            // 
            this.ckbModify.AutoSize = true;
            this.ckbModify.Checked = true;
            this.ckbModify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbModify.Location = new System.Drawing.Point(337, 112);
            this.ckbModify.Name = "ckbModify";
            this.ckbModify.Size = new System.Drawing.Size(15, 14);
            this.ckbModify.TabIndex = 102;
            this.ckbModify.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(254, 111);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 15);
            this.label21.TabIndex = 101;
            this.label21.Text = "Is Modify ? :";
            // 
            // cbGroup
            // 
            this.cbGroup.FormattingEnabled = true;
            this.cbGroup.Location = new System.Drawing.Point(103, 334);
            this.cbGroup.Name = "cbGroup";
            this.cbGroup.Size = new System.Drawing.Size(136, 23);
            this.cbGroup.TabIndex = 11;
            this.cbGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(337, 15);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(136, 23);
            this.txtOwner.TabIndex = 5;
            this.txtOwner.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(279, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 15);
            this.label12.TabIndex = 50;
            this.label12.Text = "Owner :";
            // 
            // txtType
            // 
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(103, 195);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(136, 23);
            this.txtType.TabIndex = 4;
            this.txtType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 48;
            this.label7.Text = "Type :";
            // 
            // txtDiv
            // 
            this.txtDiv.Location = new System.Drawing.Point(103, 166);
            this.txtDiv.Name = "txtDiv";
            this.txtDiv.Size = new System.Drawing.Size(136, 23);
            this.txtDiv.TabIndex = 3;
            this.txtDiv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // txtPcs
            // 
            this.txtPcs.Location = new System.Drawing.Point(334, 224);
            this.txtPcs.Name = "txtPcs";
            this.txtPcs.Size = new System.Drawing.Size(136, 23);
            this.txtPcs.TabIndex = 9;
            this.txtPcs.Text = "1";
            this.txtPcs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(296, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 15);
            this.label11.TabIndex = 45;
            this.label11.Text = "Pcs :";
            // 
            // lblContent
            // 
            this.lblContent.Location = new System.Drawing.Point(103, 546);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(367, 69);
            this.lblContent.TabIndex = 39;
            this.lblContent.Text = "Unknown";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(103, 515);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(58, 15);
            this.lblType.TabIndex = 38;
            this.lblType.Text = "Unknown";
            // 
            // txtMouldCode
            // 
            this.txtMouldCode.Location = new System.Drawing.Point(103, 481);
            this.txtMouldCode.Name = "txtMouldCode";
            this.txtMouldCode.Size = new System.Drawing.Size(136, 23);
            this.txtMouldCode.TabIndex = 12;
            this.txtMouldCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMouldCode_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(42, 546);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 36;
            this.label20.Text = "Content :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(60, 515);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 15);
            this.label19.TabIndex = 35;
            this.label19.Text = "Type :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 484);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 15);
            this.label18.TabIndex = 34;
            this.label18.Text = "Mould Code :";
            // 
            // lblVendorname
            // 
            this.lblVendorname.Location = new System.Drawing.Point(103, 427);
            this.lblVendorname.Name = "lblVendorname";
            this.lblVendorname.Size = new System.Drawing.Size(367, 51);
            this.lblVendorname.TabIndex = 33;
            this.lblVendorname.Text = "Unknown";
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(103, 396);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(58, 15);
            this.lblCurrency.TabIndex = 32;
            this.lblCurrency.Text = "Unknown";
            // 
            // lblPurchaser
            // 
            this.lblPurchaser.AutoSize = true;
            this.lblPurchaser.Location = new System.Drawing.Point(103, 367);
            this.lblPurchaser.Name = "lblPurchaser";
            this.lblPurchaser.Size = new System.Drawing.Size(58, 15);
            this.lblPurchaser.TabIndex = 31;
            this.lblPurchaser.Text = "Unknown";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(245, 337);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(58, 15);
            this.lblGroup.TabIndex = 30;
            this.lblGroup.Text = "Unknown";
            this.lblGroup.Visible = false;
            // 
            // txtVendor
            // 
            this.txtVendor.Location = new System.Drawing.Point(103, 301);
            this.txtVendor.Name = "txtVendor";
            this.txtVendor.Size = new System.Drawing.Size(136, 23);
            this.txtVendor.TabIndex = 10;
            this.txtVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendor_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 427);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 15);
            this.label17.TabIndex = 28;
            this.label17.Text = "Vendor Name :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 396);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 15);
            this.label16.TabIndex = 27;
            this.label16.Text = "Currency :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 367);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 15);
            this.label15.TabIndex = 26;
            this.label15.Text = "Purchaser :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(50, 337);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 25;
            this.label14.Text = "Group :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(46, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "Vendor :";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(334, 195);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(136, 23);
            this.txtRemarks.TabIndex = 8;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // txtOemasset
            // 
            this.txtOemasset.Location = new System.Drawing.Point(334, 166);
            this.txtOemasset.Name = "txtOemasset";
            this.txtOemasset.Size = new System.Drawing.Size(136, 23);
            this.txtOemasset.TabIndex = 7;
            this.txtOemasset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // ckbMpa
            // 
            this.ckbMpa.AutoSize = true;
            this.ckbMpa.Location = new System.Drawing.Point(337, 83);
            this.ckbMpa.Name = "ckbMpa";
            this.ckbMpa.Size = new System.Drawing.Size(15, 14);
            this.ckbMpa.TabIndex = 18;
            this.ckbMpa.UseVisualStyleBackColor = true;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(103, 224);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(136, 23);
            this.txtAmount.TabIndex = 5;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // txtRev
            // 
            this.txtRev.Location = new System.Drawing.Point(103, 137);
            this.txtRev.Name = "txtRev";
            this.txtRev.Size = new System.Drawing.Size(136, 23);
            this.txtRev.TabIndex = 2;
            this.txtRev.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // txtItemcode
            // 
            this.txtItemcode.Location = new System.Drawing.Point(103, 108);
            this.txtItemcode.Name = "txtItemcode";
            this.txtItemcode.Size = new System.Drawing.Size(136, 23);
            this.txtItemcode.TabIndex = 1;
            this.txtItemcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // txtMouldno
            // 
            this.txtMouldno.Location = new System.Drawing.Point(103, 79);
            this.txtMouldno.Name = "txtMouldno";
            this.txtMouldno.Size = new System.Drawing.Size(136, 23);
            this.txtMouldno.TabIndex = 0;
            this.txtMouldno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(268, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Remarks :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(257, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "OEM Asset :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(265, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "50% MPA :";
            // 
            // lblChaseno
            // 
            this.lblChaseno.AutoSize = true;
            this.lblChaseno.Location = new System.Drawing.Point(103, 54);
            this.lblChaseno.Name = "lblChaseno";
            this.lblChaseno.Size = new System.Drawing.Size(58, 15);
            this.lblChaseno.TabIndex = 6;
            this.lblChaseno.Text = "Unknown";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Div. :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Rev :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Part No. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mould No. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chase No. :";
            // 
            // ucQuotationModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucQuotationModify";
            this.Size = new System.Drawing.Size(1077, 646);
            this.groupBox2.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRelationship)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.Label lblCommon;
        private System.Windows.Forms.Label lblSingle;
        private CustomUtil.controls.button.CustomButton btnCancel;
        private CustomUtil.controls.button.CustomButton btnSave;
        private CustomUtil.controls.datagrid.CustomDatagrid dgvRelationship;
        private System.Windows.Forms.DataGridViewTextBoxColumn chaseno;
        private System.Windows.Forms.DataGridViewTextBoxColumn mouldno;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn rev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtMouldCode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblVendorname;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblPurchaser;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.TextBox txtVendor;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtOemasset;
        private System.Windows.Forms.CheckBox ckbMpa;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtRev;
        private System.Windows.Forms.TextBox txtItemcode;
        private System.Windows.Forms.TextBox txtMouldno;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblChaseno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPcs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiv;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbGroup;
        private System.Windows.Forms.CheckBox ckbModify;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cbOwner;
    }
}
