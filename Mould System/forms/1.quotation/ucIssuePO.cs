using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mould_System.services;
using Mould_System.checking;
using Mould_System.file.excel;
using System.Diagnostics;
using CustomUtil.utils.authentication;
using Mould_System.file.csv;
using Mould_System.functions.file;

namespace Mould_System.forms._1.quotation
{
    public partial class ucIssuePO : UserControl
    {
        private DataTable table = null;

        public ucIssuePO()
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
            this.cbSearch.Items.Add("Currency");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select st.st_status as qstatus, t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev as rev" +
                ", t.tm_vendor_code as vendor from tb_betamould as t, tb_betaqstatus as st where t.tm_st_code = st.st_code and (t.tm_st_code = 'D' or t.tm_st_code = 'T') and t.tm_instockdate = '#N/A'";

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
                commandText = _commandText + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 5)
                commandText = _commandText + string.Format(" and t.tm_currency = '{0}'", txtSearch.Text);

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvIssuePo.DataSource = table;

            dgvIssuePo.Sort(dgvIssuePo.Columns[1], ListSortDirection.Ascending);

            lblTotal.Text = "ROWS COUNT: " + dgvIssuePo.Rows.Count;

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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvIssuePo.Rows.Count == 0)
            {
                MessageBox.Show("No Record can be downloaded");
                return;
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dlTable = new DataTable();
                string[] headers = { "Chase No.", "Mould No.", "Item Code", "Rev", "Vendor", "Vendor Name", "購買依賴 No.", "PO", "PO Rev" };
                foreach (string header in headers)
                    dlTable.Columns.Add(header);

                foreach (DataGridViewRow row in dgvIssuePo.Rows)
                {
                    string chaseno = row.Cells[1].Value.ToString();

                    if (chaseno.StartsWith("CN"))
                        continue;
                    /*string query = string.Format("select t.tm_chaseno, t.tm_mouldno, t.tm_itemcode, t.tm_rev, t.tm_vendor_code, v.v_name, t.tm_po from tb_betamould as t" +
                        ", tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_chaseno = '{0}'", chaseno);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    while (GlobalService.reader.Read())
                    {
                        string rdrChaseno = GlobalService.reader.GetString(0);
                        string rdrMouldno = GlobalService.reader.GetString(1);
                        string rdrItemcode = GlobalService.reader.GetString(2);
                        string rdrRev = GlobalService.reader.GetString(3);
                        string rdrVendor = GlobalService.reader.GetString(4);
                        string rdrVendorname = GlobalService.reader.GetString(5);
                        string rdrpo = GlobalService.reader.GetString(6);

                        dlTable.Rows.Add(new object[] { rdrChaseno, rdrMouldno, rdrItemcode, rdrRev, rdrVendor, rdrVendorname, "", rdrpo, "" });
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();*/
                    string status = row.Cells[0].Value.ToString();
                    
                    string mouldno = row.Cells[2].Value.ToString();
                    string itemcode = row.Cells[3].Value.ToString();
                    string rev = row.Cells[4].Value.ToString();
                    string vendor = row.Cells[5].Value.ToString();
                    string vendorname = DataChecking.getVendorName(vendor);
                    string po = "";
                    string porev = "";

                    if (status == "移管對象")
                        po = DataChecking.getTransferNo(chaseno);

                    dlTable.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, vendor, vendorname, "", po, porev });
                }

                //ExportXlsUtil.XlsUtil(dlTable);

                this.Cursor = Cursors.Default;
                ExportCsvUtil.ExportCsv(dlTable, "", "PO LIST");
            }
        }

        DataTable potable;
        bool validData = true;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = "";
            
            potable = new DataTable();

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                try
                {
                    potable = ImportXlsUtil.TranslateToTable(filename);

                    frmUploadConfirm form = new frmUploadConfirm(potable);
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (!worker.IsBusy)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            dgvIssuePo.Cursor = Cursors.WaitCursor;
                            worker.RunWorkerAsync();
                        }
                        else
                            MessageBox.Show("File is using by other process");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ex.StackTrace);
                    validData = false;
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataRow datarow in potable.Rows)
                {
                    string chaseno = datarow[0].ToString();
                    string vendor = datarow[4].ToString();
                    string purchaserequest = datarow[6].ToString();
                    string po = datarow[7].ToString();
                    string porev = datarow[8].ToString();

                    string paydate = "-----";

                    if (!po.StartsWith("TM"))
                    {
                        if (porev.Length == 2)
                            po = po + "000" + porev;
                        else
                            po = po + "00" + porev;
                    }

                    //string status = DataChecking.getStatusCodeByPo(po);
                    string status = DataChecking.getStatusByChaseno(chaseno);

                    string query = "";

                    if (status == "K")
                        query = string.Format("update tb_betamould set tm_po = '{0}', tm_porev = '{1}', tm_poissued = '{2}'" +
                        ", tm_modify = 'Yes', tm_moulditemviewer = 'Yes', tm_purchaserequest = '{4}' where tm_chaseno = '{5}'", po, porev, DateTime.Today.ToString("yyyy/MM/dd")
                        , purchaserequest, chaseno);
                    else
                        query = string.Format("update tb_betamould set tm_st_code = case when tm_status = 'New' then 'P' else 'K' end, tm_po = '{0}', tm_porev = '{1}', tm_poissued = '{2}'" +
                        ", tm_modify = 'Yes', tm_moulditemviewer = 'Yes', tm_purchaserequest = '{3}' where tm_chaseno = '{4}'", po, porev, DateTime.Today.ToString("yyyy/MM/dd")
                        , purchaserequest, chaseno);

                    DataService.GetInstance().ExecuteNonQuery(query);

                    string text = string.Format("update tb_expensetransfer set et_pono = '{0}', et_poissued = '{1}' where et_chaseno = '{2}'", po, DateTime.Today.ToString("yyyy/MM/dd"), chaseno);

                    DataService.GetInstance().ExecuteNonQuery(text);

                    string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "PO Issued", "-", po, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), chaseno, "PO Issued");

                    DataService.GetInstance().ExecuteNonQuery(logText);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!validData)
                MessageBox.Show("Invalid Data Format.");
            else
            {
                //List<string> distinctList = new List<string>();
                //distinctList = GlobalService.PurchaseGroupList.Distinct().ToList();
                //this.exportMOFile(distinctList);

                this.Cursor = Cursors.Default;
                dgvIssuePo.Cursor = Cursors.Default;
                MessageBox.Show("Data Uploaded");
                this.loadData();
            }
        }

        private void btnUploadCn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ImportXlsUtil.TranslateToTable(ofd.FileName);

                foreach (DataRow row in table.Rows)
                {
                    string organization = row.ItemArray[14].ToString().Trim();
                    string accountcode = row.ItemArray[17].ToString().Trim();
                    string costcenter = row.ItemArray[18].ToString().Trim();
                    string fixedasset = row.ItemArray[19].ToString().Trim();
                    string location = row.ItemArray[21].ToString().Trim();
                    string chaseno = row.ItemArray[23].ToString().Trim();
                    string request = row.ItemArray[26].ToString().Trim();
                    string po = row.ItemArray[27].ToString().Trim();
                    string porev = row.ItemArray[28].ToString().Trim();

                    string today = DateTime.Today.ToString("yyyy/MM/dd");

                    if (porev.Length == 2)
                        po = po + "000" + porev;
                    else
                        po = po + "00" + porev;

                    string query = string.Format("update tb_betamould set tm_accountcode = '{0}', tm_costcentre = '{1}', tm_fixedassetcode = '{2}', tm_request = '{3}'" +
                        ", tm_po = '{4}', tm_porev = '{5}', tm_poissued = '{6}', tm_cnsendtime = '{7}', tm_st_code = 'K' where tm_chaseno = '{8}'", accountcode, costcenter, fixedasset, request,
                        po, porev, today, today, chaseno);
                    Debug.WriteLine(query);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }

                MessageBox.Show("Record has been uploaded.");
            }

            loadData();
        }

        private void btnDownloadCn_Click(object sender, EventArgs e)
        {
            DataTable tmptable = new DataTable();

            string[] headers = {"リランフラグ", "伝票タイプ", "勘定設定カテゴリ", "品目", "品目テキスト", "数量",
                                   "納期", "正味價格", "価格単位", "単位", "品目グループ", "購買グループ", "希望仕入先",
                                   "購買依頼者", "保管場所", "プラント", "購買組織", "勘定コード", "原価センタ", "固定資産番号",
                                   "稟議番号", "納入先住所コード", "通貨コード", "追跡番号", "項目テキスト", "WBS要素", "依賴No.", "PO", "PO Rev"};

            foreach (string header in headers)
                tmptable.Columns.Add(header);

            foreach (DataGridViewRow row in dgvIssuePo.Rows)
            {
                string chaseno = row.Cells[1].Value.ToString().Trim();
                if (chaseno.StartsWith("MS"))
                    continue;

                string text = string.Format("select t.tm_category, t.tm_itemtext, t.tm_qty, t.tm_deliverydate, t.tm_amount" +
                    ", m.mc_itemgroup, t.tm_group, t.tm_vendor_code, t.tm_request, t.tm_currency, t.tm_projecttext" +
                    " from tb_betamould as t, tbm_mouldcode as m where t.tm_mouldcode_code = m.mc_mouldcode and t.tm_chaseno = '{0}'", chaseno);

                using (IDataReader reader = DataService.GetInstance().ExecuteReader(text))
                {
                    while (reader.Read())
                    {
                        string category = reader.GetString(0).Trim();
                        string itemText = reader.GetString(1).Trim();
                        string quantity = reader.GetString(2).Trim();
                        string delivery = reader.GetString(3).Trim();
                        string amount = reader.GetString(4).Trim();
                        string itemGroup = reader.GetString(5).Trim();
                        string group = reader.GetString(6).Trim();
                        string vendor = reader.GetString(7).Trim();
                        string request = reader.GetString(8).Trim();
                        string currency = reader.GetString(9).Trim();
                        string projectText = reader.GetString(10).Trim();

                        if (vendor.Length == 9)
                            vendor = "0" + vendor;

                        tmptable.Rows.Add(new object[]{ "", "Z008", category, "", itemText, quantity, delivery, amount,
                            "1", "PC", itemGroup, group, vendor, request, "", "2100", "2000", "", "", "",
                            "", "", currency, chaseno, projectText, "", "", "", ""});
                    }
                }
            }

            ExportXlsUtil.XlsUtil(tmptable);
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
