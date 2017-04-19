using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.buffer;
using System.Data.SqlClient;
using Mould_System.services;
using Mould_System.lists;
using Mould_System.file.csv;
using Mould_System.file.excel;

namespace Mould_System.forms._1.quotation
{
    public partial class ucTestFa : UserControl
    {
        public ucTestFa()
        {
            InitializeComponent();

            BufferUtil.DoubleBuffered(dgvFa, true);

            LoadData("");

            Application.Idle += new EventHandler(Application_Idle);

            cbSearch.SelectedIndex = 0;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = dgvFa.SelectedRows.Count > 0 ? true : false;
        }

        private void LoadData(string source)
        {
            DataTable table = new DataTable();
            string[] headers = { "chaseno", "partno", "model", "mouldcode", "itemtext", "curr", "amount", "amounthkd", "vendor", "vendorname", "ringi", "apptype", "category", "mould", "rev", "div", "mpa", "remarks" };
            foreach (string header in headers)
                table.Columns.Add(header);

            string query = "select tm_chaseno as chaseno, tm_itemcode as partno, tm_model as model, tm_mouldcode_code as mouldcode, tm_itemtext as itemtext, tm_currency as curr, tm_amount as amount, tm_amounthkd as amounthkd" +
                ", tm_vendor_code as vendor, v_name as vendorname, tm_ringi_code as ringi, tm_apptype as apptype, tm_category as category, tm_mouldno as mould, tm_rev as rev, tm_status as div, tm_mpa as mpa, tm_rm as remarks from tb_betamould, tb_vendor" +
                " where tm_vendor_code = v_code and tm_st_code = 'F'";

            if (cbSearch.SelectedIndex == 1)
                query = query + string.Format(" and tm_chaseno like '%{0}%'", source);
            else if (cbSearch.SelectedIndex == 2)
                query = query + string.Format(" and tm_mouldno like '%{0}%'", source);
            else if (cbSearch.SelectedIndex == 3)
                query = query + string.Format(" and tm_itemcode like '%{0}%'", source);
            else
                query = query + "";

            SqlDataAdapter adapter = new SqlDataAdapter(query, DataService.GetInstance().Connection);
            adapter.Fill(table);

            dgvFa.DataSource = table;
        }

        private void dgvFa_MouseDown(object sender, MouseEventArgs e)
        {
            if (dgvFa.Rows.Count > 0)
            {
                if (((dgvFa.Rows[0].Height * dgvFa.Rows.Count) + dgvFa.ColumnHeadersHeight) < e.Location.Y)
                    dgvFa.ClearSelection();
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        var hti = dgvFa.HitTest(e.X, e.Y);

                        if (dgvFa.SelectedRows.Count == 1)
                        {
                            dgvFa.ClearSelection();

                            if (((dgvFa.Rows[0].Height * dgvFa.Rows.Count) + dgvFa.ColumnHeadersHeight) >= e.Location.Y)
                                dgvFa.Rows[hti.RowIndex].Selected = true;
                        }
                        else
                        {
                            if (((dgvFa.Rows[0].Height * dgvFa.Rows.Count) + dgvFa.ColumnHeadersHeight) >= e.Location.Y)
                                dgvFa.Rows[hti.RowIndex].Selected = true;
                        }
                    }
                }
            }
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal selectedTotal = 0;

            foreach (DataGridViewRow row in dgvFa.SelectedRows)
            {
                decimal hkd = Convert.ToDecimal(row.Cells[7].Value);

                selectedTotal += hkd;
            }

            if (selectedTotal > 0)
            {
                AssignRingiForm form = new AssignRingiForm(selectedTotal);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvFa.SelectedRows)
                    {
                        string chaseno = row.Cells[0].Value.ToString();
                        row.Cells[10].Value = GlobalService.Ringi;

                        string query = string.Format("update tb_betamould set tm_ringi_code = '{0}' where tm_chaseno = '{1}'", GlobalService.Ringi, chaseno);
                        DataService.GetInstance().ExecuteNonQuery(query);
                    }
                }
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFa.SelectedRows)
                row.Cells[10].Value = "";
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            FixedAssetStatusForm form = new FixedAssetStatusForm();
            form.ShowDialog();
        }

        private void tsbtnList_Click(object sender, EventArgs e)
        {
            List<TempAssignList> list = new List<TempAssignList>();

            foreach (DataGridViewRow row in dgvFa.Rows)
            {
                string ringi = row.Cells[10].Value.ToString().Trim();

                if (ringi != "-" && ringi != "")
                {
                    string chaseno = row.Cells[0].Value.ToString().Trim();
                    string partno = row.Cells[1].Value.ToString().Trim();
                    string mouldcode = row.Cells[3].Value.ToString().Trim();
                    string itemtext = row.Cells[4].Value.ToString().Trim();
                    string currency = row.Cells[5].Value.ToString().Trim();
                    string amount = row.Cells[6].Value.ToString().Trim();
                    string amounthkd = row.Cells[7].Value.ToString().Trim();
                    string vendor = row.Cells[8].Value.ToString().Trim();
                    string vendorname = row.Cells[9].Value.ToString().Trim();
                    string category = row.Cells[12].Value.ToString().Trim();
                    string mould = row.Cells[13].Value.ToString().Trim();
                    string rev = row.Cells[14].Value.ToString().Trim();
                    string div = row.Cells[15].Value.ToString().Trim();
                    string mpa = row.Cells[16].Value.ToString().Trim();

                    string mouldJig = mouldcode == "611" || mouldcode == "612" || mouldcode == "613" || mouldcode == "614" ? "Jigs" : "Mould";
                    list.Add(new TempAssignList { ChaseNo = chaseno, PartNo = partno, ItemText = itemtext, Currency = currency, Amount = amount, AmountHkd = amounthkd, Vendor = vendor, VendorName = vendorname, Ringi = ringi, Category = category, Mould = mould, Rev = rev, Div = div, Mpa = mpa, MouldJig = mouldJig });
                }
            }

            if (list.Count > 0)
            {
                FixedAssetConfirmForm form = new FixedAssetConfirmForm(list);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData(txtSearch.Text);
            }
        }

        private void tsbtnDownload_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            string[] headers = { "ChaseNo.", "PartNo.", "Rev", "MouldNo.", "Model", "Currency", "Amount", "Amount(HKD)", "Remarks", "Vendor", "VendorName", "Ringi" };
            foreach (string header in headers)
                table.Columns.Add(header);

            foreach (DataGridViewRow row in dgvFa.Rows)
            {
                string chaseno = row.Cells[0].Value.ToString();
                string partno = row.Cells[1].Value.ToString();
                string rev = row.Cells[14].Value.ToString();
                string mould = row.Cells[13].Value.ToString();
                string model = row.Cells[2].Value.ToString();
                string currency = row.Cells[5].Value.ToString().Trim();
                string amount = row.Cells[6].Value.ToString().Trim();
                string amounthkd = row.Cells[7].Value.ToString().Trim();
                string vendor = row.Cells[8].Value.ToString().Trim();
                string vendorname = row.Cells[9].Value.ToString().Trim();
                string ringi = row.Cells[10].Value.ToString();
                string remarks = row.Cells[17].Value.ToString();

                table.Rows.Add(chaseno, partno, rev, mould, model, currency, amount, amounthkd, remarks, vendor, vendorname, ringi);
            }

            ExportXlsUtil.XlsUtil(table);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtSearch.Text);
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                txtSearch.Text = "";
                LoadData("");
            }
        }
    }
}
