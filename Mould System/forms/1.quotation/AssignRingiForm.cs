using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mould_System.services;

namespace Mould_System.forms._1.quotation
{
    public partial class AssignRingiForm : Form
    {
        decimal _selectedTotal;
        string _selectedRingi = "";

        public AssignRingiForm(decimal selectedTotal)
        {
            InitializeComponent();

            this.Text = "Total: " + selectedTotal;

            _selectedTotal = selectedTotal;
        }

        private void lklRingi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(@"http://km-square.km.local/kmhk-portal/General/BizSys/Lists/KMHKList/All.aspx?PageView=Shared");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            AssignRingiResult result = new AssignRingiResult();
            if (result.ShowDialog() == DialogResult.OK)
            {
                txtSearch.Text = GlobalService.SelectedRingiNo;
                txtContent.Text = GlobalService.SelectedRingiContent;
                txtBalance.Text = GlobalService.SelectedRingiBalance;

                txtVirtualBalance.Text = (Convert.ToDecimal(txtBalance.Text) - GetVirtualTotal(GlobalService.SelectedRingiNo)).ToString();

                btnSave.Enabled = true;
            }
        }

        private decimal GetVirtualTotal(string ringi)
        {
            decimal result = 0;

            string query = string.Format("select tm_amounthkd from tb_betamould where tm_ringi_code = '{0}' and tm_amounthkd != '-' and tm_st_code = 'A'", ringi);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string amt = reader.GetString(0).Trim();
                    result = result + Convert.ToDecimal(amt);
                }
            }

            return result;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal balance = Convert.ToDecimal(txtVirtualBalance.Text);

            if (_selectedTotal > balance)
            {
                MessageBox.Show("Ringi does not provide enough balance");
                return;
            }

            GlobalService.Ringi = txtSearch.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
