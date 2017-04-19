using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.lists;
using Mould_System.services;
using CustomUtil.utils.authentication;

namespace Mould_System.forms._1.quotation
{
    public partial class FixedAssetConfirmForm : Form
    {
        public FixedAssetConfirmForm(List<TempAssignList> list)
        {
            InitializeComponent();

            LoadData(list);
        }

        private void LoadData(List<TempAssignList> list)
        {
            foreach (TempAssignList item in list)
            {
                dgvMain.Rows.Add(item.ChaseNo, item.Vendor, item.VendorName, item.PartNo, item.Rev, item.Mould, item.Div, item.Currency, item.Amount
                    , item.AmountHkd, item.Mpa, item.ItemText, item.Category, item.Ringi, item.MouldJig, "False");
            }

            dgvMain.Sort(dgvMain.Columns[0], ListSortDirection.Ascending);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<FaApplicationList> list = new List<FaApplicationList>();

            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                string isChecked = row.Cells[15].FormattedValue.ToString();

                if (isChecked != "True")
                    continue;

                string chaseno = row.Cells[0].Value.ToString().Trim();
                string vendor = row.Cells[1].Value.ToString().Trim();
                string vendorname = row.Cells[2].Value.ToString().Trim();
                string partno = row.Cells[3].Value.ToString().Trim();
                string itemtext = row.Cells[11].Value.ToString().Trim();
                string ringi = row.Cells[13].Value.ToString().Trim();
                string mouldJig = row.Cells[14].Value.ToString().Trim();

                list.Add(new FaApplicationList { Chaseno = chaseno, Itemcode = partno, Itemtext = itemtext, Ringi = ringi, Vendor = vendor + " " + vendorname, AppType = mouldJig });
            }

            if (list.Count > 0)
            {
                switch (MessageBox.Show("Are you sure to apply " + list.Count + " item for Fixed Asset?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        DataTable pdfTable = new DataTable();
                        string[] headers = { "ChaseNo", "Item Text", "Item Code", "Ringi", "Vendor" };
                        foreach (string header in headers)
                            pdfTable.Columns.Add(header);

                        string pdfFile = DataUtil.GetLatestPdfId();

                        string today = DateTime.Today.ToString("yyyy/MM/dd");

                        int mouldCount = 0;
                        int jigCount = 0;

                        foreach (FaApplicationList item in list)
                        {
                            string query = string.Format("update tb_betamould set tm_st_code = 'A', tm_ringi_code = '{0}', tm_pdfid = '{1}' where tm_chaseno = '{2}'", item.Ringi, pdfFile, item.Chaseno);
                            DataService.GetInstance().ExecuteNonQuery(query);

                            pdfTable.Rows.Add(item.Chaseno, item.Itemtext, item.Itemcode, item.Ringi, item.Vendor);

                            string mpa = DataUtil.GetMpa(item.Chaseno) == "True" ? "Yes" : "No";
                            string vendor = DataUtil.GetVendor(item.Chaseno);
                            string path = @"\\kdthk-dm1\moss$\cm\FixedAssets\" + pdfFile + ".pdf";
                            string model = DataUtil.GetModel(item.Chaseno);
                            string currency = DataUtil.GetCurrency(item.Chaseno);
                            string amount = DataUtil.GetAmount(item.Chaseno);

                            string approvalText = string.Format("insert into TB_FA_APPROVAL (f_request, f_applicant, f_type, f_chaseno, f_pdfid, f_status, f_desc, f_mpa, f_vendor, f_attachment" +
                                ", f_mould, f_ringi, f_model, f_currency, f_amount, f_assetdesc, f_ipo1st, f_ipo2nd, f_partno, f_apptype) values ('{0}', N'{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', N'{16}', N'{17}', '{18}', '{19}')"
                                , today, GlobalService.Owner, "Acquisition", item.Chaseno, pdfFile, "IPO 1st Approval", item.Itemtext, mpa, vendor, path, item.Chaseno, item.Ringi, model, currency, amount
                                , item.Vendor, GlobalService.IPO1st, GlobalService.IPO2nd, item.Itemcode, item.AppType);

                            DataServiceNew.GetInstance().ExecuteNonQuery(approvalText);

                            if (item.AppType == "Mould") mouldCount += 1;
                            if (item.AppType == "Jigs") jigCount += 1;
                        }

                        pdfTable.DefaultView.Sort = "ChaseNo ASC";

                        PdfUtil.ApplyFixedAssetPdf(pdfTable, pdfFile, mouldCount, jigCount);

                        string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.Owner, "kmhk.local"), "kmhk.local");
                        string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.IPO1st, "kmhk.local"), "kmhk.local");

                        EmailUtil.SendEmail(from, to, "SpApp_Fixed Asset Application Approval Required");

                        DialogResult = DialogResult.OK;
                        break;

                    case DialogResult.No:
                        break;
                }
            }
        }

        private void dgvMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (dgvMain.Rows.Count > 0)
            {
                if (((dgvMain.Rows[0].Height * dgvMain.Rows.Count) + dgvMain.ColumnHeadersHeight) < e.Location.Y)
                    dgvMain.ClearSelection();
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        var hti = dgvMain.HitTest(e.X, e.Y);

                        if (dgvMain.SelectedRows.Count == 1)
                        {
                            dgvMain.ClearSelection();

                            if (((dgvMain.Rows[0].Height * dgvMain.Rows.Count) + dgvMain.ColumnHeadersHeight) >= e.Location.Y)
                                dgvMain.Rows[hti.RowIndex].Selected = true;
                        }
                        else
                        {
                            if (((dgvMain.Rows[0].Height * dgvMain.Rows.Count) + dgvMain.ColumnHeadersHeight) >= e.Location.Y)
                                dgvMain.Rows[hti.RowIndex].Selected = true;
                        }
                    }
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvMain.SelectedRows)
            {
                dgvMain.Rows.Remove(row);
            }
        }
    }
}
