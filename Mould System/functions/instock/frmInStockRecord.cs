using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.csv;

namespace Mould_System.functions.instock
{
    public partial class frmInStockRecord : Form
    {
        private DataTable table = null;

        public frmInStockRecord()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("PO No.");
            this.cbSearch.Items.Add("Chase No.");
            this.cbSearch.Items.Add("Item Code");
            this.cbSearch.Items.Add("Mould No.");
            this.cbSearch.Items.Add("Vendor Code");
            this.cbSearch.SelectedIndex = 1;
        }

        private void loadData()
        {
            table = new DataTable();
            string[] headers = { "po", "chaseno", "mouldno", "itemcode", "rev", "vendor", "instockdate" };
            foreach (string header in headers)
                table.Columns.Add(header);

            string _query = "select tm_po, tm_porev, tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_vendor_code, tm_instockdate from tb_betamould" +
                " where tm_st_code = 'S'";
            string query = "";

            if (cbSearch.SelectedIndex == 0)
                query = _query;
            if (cbSearch.SelectedIndex == 1)
                query = _query + string.Format(" and tm_po like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 2)
                query = _query + string.Format(" and tm_chaseno like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 3)
                query = _query + string.Format(" and tm_itemcode like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 4)
                query = _query + string.Format(" and tm_mouldno like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 5)
                query = _query + string.Format(" and tm_vendor_code like '%{0}%'", txtSearch.Text);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            while (GlobalService.reader.Read())
            {
                string po = GlobalService.reader.GetString(0);
                string porev = GlobalService.reader.GetString(1);
                string chaseno = GlobalService.reader.GetString(2);
                string mouldno = GlobalService.reader.GetString(3);
                string itemcode = GlobalService.reader.GetString(4);
                string rev = GlobalService.reader.GetString(5);
                string vendor = GlobalService.reader.GetString(6);
                string instockdate = GlobalService.reader.GetString(7);

                string finalpo = po + porev;

                table.Rows.Add(new object[] { finalpo, chaseno, mouldno, itemcode, rev, vendor, instockdate });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            dgvInStockHistory.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvInStockHistory.Rows.Count;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 1)
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable tmptable = (DataTable)(dgvInStockHistory.DataSource);

            ExportCsvUtil.ExportCsv(tmptable, "", "INSTOCKRECORD");
        }
    }
}
