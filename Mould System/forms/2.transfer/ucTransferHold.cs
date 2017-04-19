using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;

namespace Mould_System.forms._2.transfer
{
    public partial class ucTransferHold : UserControl
    {
        private DataTable table = null;

        public ucTransferHold()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select his_tmchaseno as chaseno, his_mouldno as mouldno, his_itemcode as itemcode, his_rev as rev" +
                ", his_ownerafter as ownerafter, his_locationafter as vendorafter from tb_transferhistory where his_remarks = 'Hold'";


            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" and his_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" and his_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" and his_ownerafter like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" and his_locationafter like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter.Fill(table);

            dgvTransferHold.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvTransferHold.Rows.Count;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                txtSearch.Enabled = false;
                this.loadData();
            }
            else
                txtSearch.Enabled = true;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }
    }
}
