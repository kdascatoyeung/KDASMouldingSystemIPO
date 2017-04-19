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
using Mould_System.file.excel;
using System.Diagnostics;

namespace Mould_System.forms._1.quotation
{
    public partial class ucApplyRingi : UserControl
    {
        public event EventHandler toRingiEvent;

        private DataTable table = null;

        public ucApplyRingi()
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
            this.cbSearch.Items.Add("Model");
            this.cbSearch.Items.Add("Vendor Code");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string[] headers = {"chaseno", "itemcode", "rev", "mouldno", "model", "currency", "amount", "amounthkd", "remarks",
                                   "vendor", "vendorname", "pgroup", "ringi"};

            foreach (string header in headers)
                table.Columns.Add(header);

            string _commandText = "select t.tm_chaseno, t.tm_itemcode, t.tm_rev, t.tm_mouldno" +
                ", t.tm_currency, t.tm_amount, t.tm_amounthkd, t.tm_rm, t.tm_vendor_code"+
                ", v.v_name, t.tm_group, t.tm_model from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_st_code = 'F'";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" and t.tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" and t.tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" and t.tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" and t.tm_model like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)
                commandText = _commandText + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(commandText);

            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string itemcode = GlobalService.reader.GetString(1);
                string rev = GlobalService.reader.GetString(2);
                string mouldno = GlobalService.reader.GetString(3);
                string currency = GlobalService.reader.GetString(4);
                string amount = GlobalService.reader.GetString(5);
                string amounthkd = GlobalService.reader.GetString(6);
                string remarks = GlobalService.reader.GetString(7);
                string vendor = GlobalService.reader.GetString(8);
                string vendorname = GlobalService.reader.GetString(9);
                string pgroup = GlobalService.reader.GetString(10);
                string model = GlobalService.reader.GetString(11);

                table.Rows.Add(new object[] { chaseno, itemcode, rev, mouldno, model, currency, amount, amounthkd, remarks, vendor, vendorname, pgroup, "" });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            dgvApplyRingi.DataSource = table;

            dgvApplyRingi.Sort(dgvApplyRingi.Columns[0], ListSortDirection.Ascending);

            string ringi = "N/A";
            string refid = "N/A";

            foreach ( DataGridViewRow row in dgvApplyRingi.Rows)
            {
                string chaseno = row.Cells[0].Value.ToString();

                string query = string.Format("select tmp_ringi from tb_tempringi where tmp_chaseno = '{0}'", chaseno);

                try
                {
                    ringi = DataService.GetInstance().ExecuteScalar(query).ToString();
                }
                catch
                {
                    ringi = "N/A";
                }
                row.Cells[12].Value = ringi;

                /*string text = string.Format("select tm_portalid from tb_betamould where tm_chaseno = '{0}'", chaseno);

                try
                {
                    refid = DataService.GetInstance().ExecuteScalar(text).ToString();
                    if (refid == "")
                        refid = "N/A";
                }
                catch
                {
                    refid = "N/A";
                }
                row.Cells[12].Value = refid;*/
            }
            lblTotal.Text = "ROWS COUNT: " + dgvApplyRingi.Rows.Count;
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

        private void btnRingiList_Click(object sender, EventArgs e)
        {
            frmRingiList ringiList = new frmRingiList();
            ringiList.ShowDialog();
        }

        private void menuAssign_Click(object sender, EventArgs e)
        {
            GlobalService.toRingiList = new List<string>();
            List<string> itemCodeList = new List<string>();
            if (dgvApplyRingi.SelectedRows == null || dgvApplyRingi.Rows.Count == 0)
                return;
            else
            {
                bool isValidSelection = true;

                foreach (DataGridViewRow row in dgvApplyRingi.SelectedRows)
                {
                    string chaseno = row.Cells[0].Value.ToString();
                    GlobalService.toRingiList.Add(chaseno);
                    itemCodeList.Add(row.Cells[1].Value.ToString());
                }

                foreach (string itemcode in itemCodeList)
                {
                    string selectedItemcode = dgvApplyRingi.SelectedRows[0].Cells[1].Value.ToString();
                    if (itemcode != selectedItemcode)
                        isValidSelection = false;
                }

                if (!isValidSelection)
                {
                    MessageBox.Show("Only Allow Selection with Same Item Code");
                    return;
                }

                if (toRingiEvent != null)
                    toRingiEvent(this, new EventArgs());
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            ExportXlsUtil.ExportDatagridview(dgvApplyRingi);
        }

        private void dgvApplyRingi_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (((dgvApplyRingi.Rows[0].Height * dgvApplyRingi.Rows.Count) + dgvApplyRingi.ColumnHeadersHeight) < e.Location.Y)
                {
                    dgvApplyRingi.ClearSelection();
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (dgvApplyRingi.SelectedRows.Count == 1)
                        {
                            var hti = dgvApplyRingi.HitTest(e.X, e.Y);
                            dgvApplyRingi.ClearSelection();
                            if (((dgvApplyRingi.Rows[0].Height * dgvApplyRingi.Rows.Count) + dgvApplyRingi.ColumnHeadersHeight) >= e.Location.Y)
                                dgvApplyRingi.Rows[hti.RowIndex].Selected = true;
                        }
                        else
                        {
                            var hti = dgvApplyRingi.HitTest(e.X, e.Y);
                            if (((dgvApplyRingi.Rows[0].Height * dgvApplyRingi.Rows.Count) + dgvApplyRingi.ColumnHeadersHeight) >= e.Location.Y)
                                dgvApplyRingi.Rows[hti.RowIndex].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }
    }
}
