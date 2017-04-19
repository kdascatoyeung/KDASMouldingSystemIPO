using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mould_System.menu
{
    public partial class ucReportingMenu : UserControl
    {
        public event EventHandler clickEvent;

        public ucReportingMenu()
        {
            InitializeComponent();
        }

        public string selectedTag { get; set; }

        private void labelClick(object sender, EventArgs e)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                    control.ForeColor = Color.DimGray;
                }
            }

            Label label = (Label)sender;
            label.BackColor = Color.LightSlateGray;
            label.ForeColor = Color.White;

            selectedTag = label.Tag.ToString();

            if (clickEvent != null)
                clickEvent(this, e);
        }
    }
}
