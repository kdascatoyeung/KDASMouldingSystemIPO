using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.simple;

namespace Mould_System
{
    public partial class MainSimple : Form
    {
        Color cyan = ColorTranslator.FromHtml("#00FFFF");

        ApprovalView approval = new ApprovalView();
        HkItemView hkview = new HkItemView();
        CnItemView cnview = new CnItemView();

        public MainSimple()
        {
            InitializeComponent();

            LoadControl(approval);

            tsbtnApproval.Image = Properties.Resources.tick_cyan_24;
            tsbtnApproval.ForeColor = cyan;
        }

        private void LoadControl(UserControl uc)
        {
            pnlMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(uc);
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            string tag = btn.Tag.ToString().Trim();

            tsbtnApproval.Image = Properties.Resources.tick_white_24;
            tsbtnApproval.ForeColor = Color.White;

            tsbtnHkView.Image = Properties.Resources.magnifier_white_24;
            tsbtnHkView.ForeColor = Color.White;

            tsbtnCnView.Image = Properties.Resources.magnifier_white_24;
            tsbtnCnView.ForeColor = Color.White;

            switch (tag)
            {
                case "approval":
                    tsbtnApproval.Image = Properties.Resources.tick_cyan_24;
                    tsbtnApproval.ForeColor = cyan;
                    LoadControl(approval);
                    break;

                case "hkview":
                    tsbtnHkView.Image = Properties.Resources.magnifier_cyan_24;
                    tsbtnHkView.ForeColor = cyan;
                    LoadControl(hkview);
                    break;

                case "cnview":
                    tsbtnCnView.Image = Properties.Resources.magnifier_cyan_24;
                    tsbtnCnView.ForeColor = cyan;
                    LoadControl(cnview);
                    break;
            }
        }
    }
}
