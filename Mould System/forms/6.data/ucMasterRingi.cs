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
using Mould_System.functions.ringi;
using CustomUtil.utils.export;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterRingi : UserControl
    {
        private DataTable table = null;

        public ucMasterRingi()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Ringi No.");
            this.cbSearch.Items.Add("Content");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = string.Format("select rg_no as ringi, rg_content as content, rg_currency as currency" +
                ", convert(varchar, cast(rg_amount as money), 1) as amount, convert(varchar, cast(rg_amounthkd as money), 1) as amounthkd" +
                ", convert(varchar, cast(rg_balance as money), 1) as balance, rg_r3date as r3confirm, rg_expired as expired" +
                " from tb_ringi where convert(datetime, rg_expired) >= convert(datetime, '{0}')", DateTime.Today.AddYears(-2).ToString("yyyy/MM/dd"));

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" and rg_no like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" and rg_content like '%{0}%'", txtSearch.Text);

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvRingi.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvRingi.Rows.Count;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
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

        private void dgvRingi_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRingi.SelectedRows == null)
                return;
            else
            {
                string ringi = dgvRingi.SelectedRows[0].Cells[0].Value.ToString();

                frmRingiItems ringiItem = new frmRingiItems(ringi);
                ringiItem.ShowDialog();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable sourcetable = (DataTable)dgvRingi.DataSource;

            ExportCsvUtil.ExportCsv(sourcetable, "", "Ringi list");
        }
    }
}
