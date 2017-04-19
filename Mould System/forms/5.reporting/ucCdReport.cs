using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.file.excel;
using Mould_System.services;
using Mould_System.checking;
using Mould_System.file.csv;
using System.Diagnostics;

namespace Mould_System.forms._5.reporting
{
    public partial class ucCdReport : UserControl
    {
        public ucCdReport()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;

            //foreach (DataGridViewColumn col in dgvCdReport.Columns)
               // Debug.WriteLine("Column: " + col.HeaderText);
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select cd_inputdate as cddate, cd_reportno as managementno, cd_purchaser as ic, cd_vendor_code as vendor, cd_vendor_name as vendorname" +
                ", cd_group as pgroup, cd_itemcode as itemcode, cd_rev as rev, cd_currency as currency, cd_pricehkdbefore as amountbefore, cd_pricehkdafter as amountafter, cd_pricecalculated as amountsystem" +
                ", cd_amount as cdtotal, cd_instockdate as instockdate, cd_calculated as cdmonth, cd_remarks as remarks, cd_locked as locked from tb_costdownreport";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)//Date
                commandText = _commandText + string.Format(" where cd_inputdate like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)//Management No.
                commandText = _commandText + string.Format(" where cd_reportno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)//Vendor Code
                commandText = _commandText + string.Format(" where cd_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)//Group
                commandText = _commandText + string.Format(" where cd_group like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)//Part No.
                commandText = _commandText + string.Format(" where cd_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 6)//CD Month
                commandText = _commandText + string.Format(" where cd_calculated like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvCdReport.DataSource = table;

            lblTotal.Text = "ROW COUNT : " + dgvCdReport.Rows.Count;
        }

        string filename = "";

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                if (!worker.IsBusy)
                    worker.RunWorkerAsync();
                else
                    MessageBox.Show("Using by other process. Please try again");
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable tmptable = ImportXlsUtil.TranslateToTable(filename);
                
                foreach (DataRow row in tmptable.Rows)
                {
                    string date = row.ItemArray[0].ToString();
                    string managementno = row.ItemArray[1].ToString();
                    string incharge = row.ItemArray[2].ToString();
                    string vendorcode = row.ItemArray[3].ToString();
                    string vendorname = row.ItemArray[4].ToString();
                    string group = row.ItemArray[5].ToString();
                    string partno = row.ItemArray[6].ToString();
                    string rev = row.ItemArray[7].ToString();
                    string currency = row.ItemArray[8].ToString();
                    string amountbefore = row.ItemArray[9].ToString();
                    string amountafter = row.ItemArray[10].ToString();
                    string amounthkdbefore = row.ItemArray[11].ToString();
                    string amounthkdafter = row.ItemArray[12].ToString();
                    string cdtotal = row.ItemArray[13].ToString();
                    string cdpercent = row.ItemArray[14].ToString();

                    if (rev.Length == 1)
                        rev = "0" + rev;

                    vendorname = vendorname.Replace("'", "''");

                    date = ImportXlsUtil.ParseDateTime(date).ToString("yyyy/MM/dd");

                    if (managementno == "")
                        continue;

                    string query = string.Format("if not exists (select * from tb_costdownreport where cd_reportno = '{0}') insert into tb_costdownreport (cd_inputdate, cd_reportno" +
                        ", cd_itemcode, cd_rev, cd_pricebefore, cd_priceafter, cd_amount, cd_currency, cd_vendor_code, cd_vendor_name, cd_group, cd_purchaser" +
                        ", cd_pricehkdbefore, cd_pricehkdafter, cd_percent) values ('{1}', '{0}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}')" +
                        " else update tb_costdownreport set cd_inputdate = '{1}', cd_itemcode = '{2}', cd_rev = '{3}', cd_pricebefore = '{4}', cd_priceafter = '{5}', cd_amount = '{6}'" +
                        ", cd_currency = '{7}', cd_vendor_code = '{8}', cd_vendor_name = '{9}', cd_group = '{10}', cd_purchaser = '{11}', cd_pricehkdbefore = '{12}'" +
                        ", cd_pricehkdafter = '{13}', cd_percent = '{14}' where cd_reportno = '{0}'", managementno, date, partno, rev, amountbefore, amountafter, cdtotal, currency, vendorcode,
                        vendorname, group, incharge, amounthkdbefore, amounthkdafter, cdpercent);

                    Debug.WriteLine("Query: " + query);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }

                MessageBox.Show("Data uploaded");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid data format");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.loadData();
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DataTable dlTable = new DataTable();

            string[] headers = {"日期", "管理番號", "担当者", "Vendor Code", "Vendor Name", "購買G", "部品番號", "REV", "CUR", "交涉前金型費",
                "最終金型費", "交涉前金型費HKD", "最終金型費HKD", "最終金型費HKD (Quotation)", "CD總金額", "入庫日", "CD計算月", "Remarks"};

            foreach (string header in headers)
                dlTable.Columns.Add(header);

            foreach (DataGridViewRow row in dgvCdReport.Rows)
            {
                string date = row.Cells[1].Value.ToString();
                string reportno = row.Cells[2].Value.ToString();
                string incharge = row.Cells[3].Value.ToString();
                string vendorcode = row.Cells[4].Value.ToString();
                string vendorname = row.Cells[5].Value.ToString();
                string group = row.Cells[6].Value.ToString();
                string partno = row.Cells[7].Value.ToString();
                string rev = row.Cells[8].Value.ToString();
                string currency = row.Cells[9].Value.ToString();
                string amountbefore = row.Cells[10].Value.ToString();
                string amountafter = row.Cells[11].Value.ToString();
                string amountsystem = row.Cells[0].Value.ToString();
                string remarks = row.Cells[15].Value.ToString();

                string cdmonth = "";

                cdmonth = row.Cells[14].Value.ToString();

                if (cdmonth != "#N/A")
                    cdmonth = Convert.ToDateTime(cdmonth).ToString("yyyy.MM");

                string query = string.Format("select cd_pricehkdbefore from tb_costdownreport where cd_itemcode = '{0}' and cd_rev = '{1}'", partno, rev);
                string amounthkdbefore = DataService.GetInstance().ExecuteScalar(query).ToString();

                string totalamount = DataChecking.getAmountByItemcodeRev(partno, rev);

                string totalamounthkd = DataChecking.getAmountHkdByItemcodeRev(partno, rev);

                string instockdate = DataChecking.getInstockdateByItemCodeRev(partno, rev);

                string cdtotal = (Convert.ToDecimal(amounthkdbefore) - Convert.ToDecimal(totalamounthkd)).ToString();

                dlTable.Rows.Add(new object[]{date, reportno, incharge, vendorcode, vendorname, group, partno, rev, currency, amountbefore, amountafter, amountsystem, amounthkdbefore,
                    totalamounthkd, cdtotal, instockdate, cdmonth, remarks});
            }

            this.Cursor = Cursors.Default;

            ExportCsvUtil.ExportCsv(dlTable, "", "CD REPORT");
        }

        List<CdReportList> updateList;

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                updateList = new List<CdReportList>();

                this.Cursor = Cursors.WaitCursor;

                foreach (DataGridViewRow row in dgvCdReport.Rows)
                {
                    List<string> instockList = new List<string>();

                    string reportno = row.Cells[1].Value.ToString();

                    string vendor = row.Cells[3].Value.ToString();
                    string itemcode = row.Cells[6].Value.ToString();
                    string rev = row.Cells[7].Value.ToString();

                    decimal tmpAmountAfter = Convert.ToDecimal(row.Cells[10].Value);

                    decimal tmpCdTotal = Convert.ToDecimal(row.Cells[12].Value);

                    decimal total = Convert.ToDecimal(DataChecking.getAmountHkdByItemcodeRev(itemcode, rev));

                    row.Cells[11].Value = total;

                    decimal originalTotal = Convert.ToDecimal(DataChecking.getAmountByItemcodeRev(itemcode, rev));

                    string instockdate = "";

                    string query = string.Format("select tm_instockdate from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}'" +
                        " and tm_vendor_code = '{2}' and tm_st_code = 'S' group by tm_instockdate", itemcode, rev, vendor);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    //DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)dgvCdReport.Columns[12];
                    DataGridViewComboBoxCell comCell = new DataGridViewComboBoxCell();
                    //comCell = this.dgvCdReport[12, row.Index] as DataGridViewComboBoxCell;
                    dgvCdReport[13, row.Index] = comCell;

                    if (GlobalService.reader.HasRows)
                    {
                        while (GlobalService.reader.Read())
                        {
                            instockdate = GlobalService.reader.GetString(0);

                            instockList.Add(instockdate);
                        }
                    }
                    else
                        instockList.Add("沒有入庫紀錄");
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    comCell.DataSource = instockList;

                    comCell.Value = comCell.Items[0];
                    /*if (col.Items.Count > 0)
                        row.Cells[12].Value = instockdate;
                    else
                        row.Cells[12].Value = "未有入庫紀錄";*/

                    string cdmonth = "";

                    if (instockdate != "" && instockdate != "沒有入庫紀錄")
                        cdmonth = Convert.ToDateTime(row.Cells[13].Value).ToString("yyyy.MM");
                    else
                        cdmonth = "#N/A";

                    if (cdmonth != "#N/A")
                        row.Cells[16].ReadOnly = false;

                    row.Cells[14].Value = cdmonth;

                    //row.Cells[0].Value = total;

                    row.Cells[12].Value = Convert.ToDecimal(row.Cells[9].Value) - Convert.ToDecimal(total);

                    Debug.WriteLine("Total: " + total + "  Temp Amount: " + tmpAmountAfter);

                    if (total != tmpAmountAfter)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightYellow;

                        row.Cells[15].Value = tmpAmountAfter + "  \u2192  " + total;
                    }
                    else
                        row.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;

                    string amountsystem = row.Cells[0].Value.ToString();

                    updateList.Add(new CdReportList { ReportNo = reportno, AmountAfter = originalTotal.ToString(), AmountHkdAfter = total.ToString(), Remarks = row.Cells[15].Value.ToString(), InStockDate = instockdate, CdMonth = cdmonth, AmountSystem = amountsystem });
                }
                this.Cursor = Cursors.Default;

                MessageBox.Show("Checking completed");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < updateList.Count; i++)
            {
                string listReportNo = updateList[i].ReportNo;
                string listAmountAfter = updateList[i].AmountAfter;
                string listAmountHkdAfter = updateList[i].AmountHkdAfter;
                string listRemarks = updateList[i].Remarks;
                string listInStockDate = updateList[i].InStockDate;
                string listCdMonth = updateList[i].CdMonth;
                string listAmountSystem = updateList[i].AmountSystem;

                Debug.WriteLine("Remarks: " + listRemarks);
                Debug.WriteLine("Reportno: " + listReportNo + ", Amountafter: " + listAmountAfter + ", AmountHkdAfter: " + listAmountHkdAfter + ", Remarks: " + listRemarks);
                string query = string.Format("update tb_costdownreport set cd_priceafter = '{0}', cd_pricehkdafter = '{1}', cd_remarks = '{2}', cd_instockdate = '{3}', cd_calculated = '{4}', cd_pricecalculated = '{5}'" +
                    " where cd_reportno = '{6}'", listAmountAfter, listAmountHkdAfter, listRemarks, listInStockDate, listCdMonth, listAmountSystem, listReportNo);

                DataService.GetInstance().ExecuteNonQuery(query);
            }

            MessageBox.Show("Record has been saved");

            this.loadData();
        }

        private void dgvCdReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Confirm the CD Record? Data cannot be changed after confirmation", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvCdReport.Rows)
                    {
                        string reportno = row.Cells[2].Value.ToString();
                        string cdmonth = row.Cells[15].Value.ToString();
                        string confirm = row.Cells[16].FormattedValue.ToString();

                        if (confirm == "True")
                        {
                            string query = string.Format("update tb_costdownreport set cd_locked = 'True' where cd_reportno = '{0}'", reportno);

                            DataService.GetInstance().ExecuteNonQuery(query);
                        }
                    }
                    MessageBox.Show("Record have been confirmed");
                    break;

                case DialogResult.No:
                    break;
            }
            
        }

        private void dgvCdReport_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable tbTemplate = new DataTable();

            string[] headers = {"日期", "管理番號", "担當者", "Vendor Code", "Vendor Name", "購買G", "部品番號", "REV", "CUR",
                                   "交涉前金型費", "最終金型費", "交涉前金型費 HKD", "最終金型費 HKD", "CD 總金額", "CD %"};

            foreach (string header in headers)
                tbTemplate.Columns.Add(header);

            ExportXlsUtil.XlsUtil(tbTemplate);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Delete selected record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvCdReport.SelectedRows)
                    {
                        string reportno = row.Cells[2].Value.ToString();

                        Debug.WriteLine(reportno);
                        string query = string.Format("delete from tb_costdownreport where cd_reportno = '{0}'", reportno);

                        Debug.WriteLine(query);
                        DataService.GetInstance().ExecuteNonQuery(query);
                    }
                    MessageBox.Show("Record deleted");

                    this.loadData();
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void dgvCdReport_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvCdReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
