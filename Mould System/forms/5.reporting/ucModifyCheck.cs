using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.csv;
using Mould_System.file.excel;

namespace Mould_System.forms._5.reporting
{
    public partial class ucModifyCheck : UserControl
    {
        public ucModifyCheck()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;

        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select t.tm_vendor_code as vendorcode, v.v_name as vendorname, t.tm_group as pgroup, t.tm_model as model" +
                ", t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_mouldno as mouldno, t.tm_status as type, t.tm_mouldcode_code as mouldcode, t.tm_currency as currency" +
                ", t.tm_amount as amount, t.tm_amounthkd as amounthkd, t.tm_rm as remarks, t.tm_po as po, t.tm_instockdate as instockdate" +
                " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_ismodify = 'True'";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            else if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + " and (t.tm_instockdate != '' or t.tm_instockdate != 'Received' or t.tm_instockdate != '#N/A')";

            else
                commandText = _commandText + string.Format(" and t.tm_instockdate like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter.Fill(table);

            dgvModifyCheck.DataSource = table;

            lblTotal.Text = "ROWS COUNT : " + dgvModifyCheck.Rows.Count;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 2)
                this.txtSearch.Enabled = true;
            else
            {
                this.txtSearch.Enabled = false;
                this.loadData();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dlTable = (DataTable)dgvModifyCheck.DataSource;

            ExportXlsUtil.XlsUtil(dlTable);
            //ExportCsvUtil.ExportCsv(dlTable, "", "MODIFYCHECK");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }
    }
}
