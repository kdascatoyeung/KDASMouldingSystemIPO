using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using System.Data.SqlClient;

namespace Mould_System.forms._1.quotation
{
    public partial class ucPoCancel : UserControl
    {
        private DataTable table = null;

        public ucPoCancel()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Chase No.");
            this.cbSearch.Items.Add("Mould No.");
            this.cbSearch.Items.Add("Part No.");
            this.cbSearch.Items.Add("Vendor");
            this.cbSearch.Items.Add("PO");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select m.tm_chaseno as chaseno, m.tm_mouldno as mouldno, m.tm_itemcode as itemcode" +
                ", m.tm_rev as rev, m.tm_vendor_code as vendor, m.tm_po as pono" +
                " from tb_betamould as m, tb_pocancel as c where m.tm_st_code = 'C' and m.tm_chaseno = c.poc_tm_chaseno";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)//All
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)//Chase No.
                commandText = _commandText + string.Format(" and m.tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)//Mould No.
                commandText = _commandText + string.Format(" and m.tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)//Item Code
                commandText = _commandText + string.Format(" and m.tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" and m.tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)//PO
                commandText = _commandText + string.Format(" and m.tm_po like '%{0}%'", txtSearch.Text);

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvPoCancel.DataSource = table;

            dgvPoCancel.Sort(dgvPoCancel.Columns[0], ListSortDirection.Ascending);

            lblTotal.Text = "ROWS COUNT: " + dgvPoCancel.Rows.Count;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 3)
            {
                this.txtSearch.Enabled = true;
                this.loadData();
            }
            else
                this.txtSearch.Enabled = true;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }
    }
}
