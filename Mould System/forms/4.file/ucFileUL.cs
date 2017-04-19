using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using System.Diagnostics;
using System.Data.SqlClient;
using Mould_System.functions.file;
using Mould_System.file.csv;
using CustomUtil.utils.import;
using Mould_System.file.excel;

namespace Mould_System.forms._4.file
{
    public partial class ucFileUL : UserControl
    {
        private DataTable table = null;

        public ucFileUL()
        {
            InitializeComponent();

            this.setupCombobox();

            for (int i = 0; i < dgvR3UL.Columns.Count; i++)
                Debug.WriteLine(dgvR3UL.Columns[i].HeaderText);
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Chase No.");
            this.cbSearch.Items.Add("Mould No.");
            this.cbSearch.Items.Add("Item Code");
            this.cbSearch.Items.Add("Vendor");
            this.cbSearch.Items.Add("Downloaded");
            this.cbSearch.Items.Add("Ref Id");
            this.cbSearch.Items.Add("Currency");
            this.cbSearch.SelectedIndex = 0;

            this.cbYesNo.Items.Add("All");
            this.cbYesNo.Items.Add("Yes");
            this.cbYesNo.Items.Add("No");
            this.cbYesNo.SelectedIndex = 0;
        }

        private void checkIfSelected()
        {
            foreach (DataGridViewRow row in dgvR3UL.Rows)
            {
                string dgvChaseno = row.Cells[2].Value.ToString();

                if (GlobalService.fileUlList.Contains(dgvChaseno))
                    //row.Cells[1].Value = "S";
                    row.Cells[1].Value = Properties.Resources.clipboard_paste;
                else
                    // row.Cells[1].Value = "";
                    row.Cells[1].Value = Properties.Resources.na;
            }
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select tm_chaseno as chaseno, tm_vendor_code as vendor, tm_itemcode as itemcode, tm_rev as rev, tm_mouldno as mouldno" +
                ", tm_mouldcode_code as mouldcode, tm_status as status, tm_mpa as mpa, tm_currency as currency, tm_amount as amount"+
                ", tm_rm as remarks, tm_oemasset as oemasset, tm_st_code as stcode from tb_betamould";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText + " where (tm_st_code = 'D' or tm_st_code = 'U')";

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" where (tm_st_code = 'D' or tm_st_code = 'U') and tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" where (tm_st_code = 'D' or tm_st_code = 'U') and tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" where (tm_st_code = 'D' or tm_st_code = 'U') and tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" where (tm_st_code = 'D' or tm_st_code = 'U') and tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)
            {
                if (cbYesNo.SelectedIndex == 0)
                    commandText = _commandText + " where (tm_st_code = 'U' or tm_st_code = 'D')";
                if (cbYesNo.SelectedIndex == 1)
                    commandText = _commandText + " where tm_st_code = 'U'";
                if (cbYesNo.SelectedIndex == 2)
                    commandText = _commandText + " where tm_st_code = 'D'";
            }

            if (cbSearch.SelectedIndex == 6)
                commandText = _commandText + string.Format(" where (tm_st_code = 'D' or tm_st_code = 'U') and tm_pdfid like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 7)
                commandText = _commandText + string.Format(" where tm_currency = '{0}'", txtSearch.Text);

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvR3UL.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvR3UL.Rows.Count;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Visible = true;
                this.txtSearch.Enabled = false;
                this.cbYesNo.Visible = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 5)
            {
                this.txtSearch.Visible = false;
                this.cbYesNo.Visible = true;
            }
            else
            {
                this.txtSearch.Visible = true;
                this.txtSearch.Enabled = true;
                this.cbYesNo.Visible = false;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }

        private void cbYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void dgvR3UL_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvR3UL.Rows)
                {
                    string stcode = row.Cells[14].Value.ToString();

                    if (stcode == "U")
                        row.Cells[0].Value = Properties.Resources.cross_icon;
                    else
                        row.Cells[0].Value = Properties.Resources.tick_icon;

                    string dgvChaseno = row.Cells[2].Value.ToString();

                    /*if (GlobalService.fileUlList.Contains(dgvChaseno))
                        row.Cells[1].Value = "S";
                    else
                        row.Cells[1].Value = "";*/

                    if (GlobalService.fileUlList.Contains(dgvChaseno))
                        //row.Cells[1].Value = "S";
                        row.Cells[1].Value = Properties.Resources.clipboard_paste;
                    else
                        // row.Cells[1].Value = "";
                        row.Cells[1].Value = Properties.Resources.na;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void addData()
        {
            foreach (DataGridViewRow row in dgvR3UL.SelectedRows)
            {
                string chaseno = row.Cells[2].Value.ToString();

                Debug.WriteLine(chaseno);
                GlobalService.fileUlList.Add(chaseno);
                //row.Cells[1].Value = "S";
                row.Cells[1].Value = Properties.Resources.clipboard_paste;
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmULlist list = new frmULlist(GlobalService.fileUlList);
            list.ShowDialog();

            this.checkIfSelected();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvR3UL.SelectedRows)
            {
                string chaseno = row.Cells[2].Value.ToString();

                Debug.WriteLine(chaseno);
                GlobalService.fileUlList.Add(chaseno);
                row.Cells[1].Value = Properties.Resources.clipboard_paste;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvR3UL.Rows.Count == 0)
            {
                MessageBox.Show("No record can be downloaded");
                return;
            }
            DataTable tmptable = new DataTable();

            string[] headers = {"Chase No.", "Vendor", "Part No.", "Rev", "Mould No.", "Mould Code", "Div.", "MPA","Currency", "Amount",
                                   "Remarks", "OEM Asset"};

            foreach (string header in headers)
                tmptable.Columns.Add(header);

            foreach (DataGridViewRow row in dgvR3UL.Rows)
            {
                string chaseno = row.Cells[2].Value.ToString();
                string vendor = row.Cells[3].Value.ToString();
                string itemcode = row.Cells[4].Value.ToString();
                string rev = row.Cells[5].Value.ToString();
                string mouldno = row.Cells[6].Value.ToString();
                string mouldcode = row.Cells[7].Value.ToString();
                string status = row.Cells[8].Value.ToString();
                string mpa = row.Cells[9].FormattedValue.ToString();
                string currency = row.Cells[10].Value.ToString();
                string amount = row.Cells[11].Value.ToString();
                string remarks = row.Cells[12].Value.ToString();
                string oemasset = row.Cells[13].Value.ToString();

                tmptable.Rows.Add(new object[] { chaseno, vendor, itemcode, rev, mouldno, mouldcode, status, mpa, currency, amount, remarks, oemasset });
            }
 
            ExportCsvUtil.ExportCsv(tmptable, "", "R3UL ALL");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DataTable tmptable = new DataTable();

            string[] headers = {"リランフラグ", "伝票タイプ", "勘定設定カテゴリ", "品目", "品目テキスト", "数量",
                                   "納期", "正味價格", "価格単位", "単位", "品目グループ", "購買グループ", "希望仕入先",
                                   "購買依頼者", "保管場所", "プラント", "購買組織", "勘定コード", "原価センタ", "固定資産番号",
                                   "稟議番号", "納入先住所コード", "通貨コード", "追跡番号", "項目テキスト", "WBS要素"};

            foreach (string header in headers)
                tmptable.Columns.Add(header);

            string flag = "", document = "", category = "", item = "", itemtext = "", qty = "";
            string deliverydate = "", amount = "", priceunit = "", level = "", itemgroup = "";
            string group = "", vendor = "", request = "", store = "", workspace = "", organization = "";
            string accountcode = "", costcentre = "", fixedassetcode = "", ringi = "", address = "";
            string currency = "", chaseno = "", projecttext = "", wbs = "", tmpfac = "", mpa = "", oemasset = "";

            string delivery = DateTime.Today.AddMonths(3).ToString("yyyy/MM/dd");

            string fixedValueText = "select fv_flag, fv_document, fv_item, fv_priceunit, fv_level, fv_store, fv_workspace, fv_organization, fv_address, fv_wbs from tb_betafixedvalue";
            GlobalService.reader = DataService.GetInstance().ExecuteReader(fixedValueText);

            while (GlobalService.reader.Read())
            {
                flag = GlobalService.reader.GetString(0);
                document = GlobalService.reader.GetString(1);
                item = GlobalService.reader.GetString(2);
                priceunit = GlobalService.reader.GetString(3);
                level = GlobalService.reader.GetString(4);
                store = GlobalService.reader.GetString(5);
                workspace = GlobalService.reader.GetString(6);
                organization = GlobalService.reader.GetString(7);
                address = GlobalService.reader.GetString(8);
                wbs = GlobalService.reader.GetString(9);
            }
            GlobalService.reader.Close();

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            if(ofd.ShowDialog()==DialogResult.OK)
            {
                DataTable caltable = ImportExcel2003.TranslateToTable(ofd.FileName);

                List<string> tmplist = new List<string>();

                foreach (DataRow row in caltable.Rows)
                {
                    string rowchaseno = row.ItemArray[0].ToString();
                    string rowcurrency = row.ItemArray[8].ToString();
                    string rowamount = row.ItemArray[9].ToString();

                    string updateText = string.Format("update tb_betamould set tm_deliverydate = '{0}' where tm_chaseno = '{1}'", delivery, rowchaseno);
                    DataService.GetInstance().ExecuteNonQuery(updateText);

                    string text = string.Format("select t.tm_category, t.tm_itemtext, t.tm_qty, t.tm_deliverydate, t.tm_amount" +
                    ", m.mc_itemgroup, t.tm_group, t.tm_vendor_code, t.tm_request" +
                    ", t.tm_accountcode, t.tm_costcentre, t.tm_fixedassetcode, t.tm_ringi_code, t.tm_currency, t.tm_chaseno, t.tm_projecttext, t.tm_tmpfixedassetcode, t.tm_mpa, t.tm_oemasset" +
                    " from tb_betamould as t, tbm_mouldcode as m where t.tm_mouldcode_code = m.mc_mouldcode and t.tm_chaseno = '{0}'", rowchaseno);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                    while (GlobalService.reader.Read())
                    {
                        category = GlobalService.reader.GetString(0);
                        itemtext = GlobalService.reader.GetString(1);
                        qty = GlobalService.reader.GetString(2);
                        deliverydate = GlobalService.reader.GetString(3);
                        amount = GlobalService.reader.GetString(4);
                        itemgroup = GlobalService.reader.GetString(5);
                        group = GlobalService.reader.GetString(6);
                        vendor = GlobalService.reader.GetString(7);
                        request = GlobalService.reader.GetString(8);
                        accountcode = GlobalService.reader.GetString(9);
                        costcentre = GlobalService.reader.GetString(10);
                        fixedassetcode = GlobalService.reader.GetString(11);
                        ringi = GlobalService.reader.GetString(12);
                        currency = GlobalService.reader.GetString(13);
                        chaseno = GlobalService.reader.GetString(14);
                        projecttext = GlobalService.reader.GetString(15);
                        tmpfac = GlobalService.reader.GetString(16);
                        mpa = GlobalService.reader.GetString(17);
                        oemasset = GlobalService.reader.GetString(18);

                        if (vendor.Length == 9)
                            vendor = "0" + vendor;

                        if (mpa == "True" && tmpfac == "" && oemasset == "")
                        {
                            MessageBox.Show("Temp Fixed Asset Code not saved yet. Please contact Account Division.");
                            return;
                        }

                        if (mpa == "True")
                        {
                            decimal decamount = Convert.ToDecimal(amount) / 2;
                            amount = decamount.ToString();

                            tmptable.Rows.Add(new object[] { flag, document, category, item, itemtext, qty, deliverydate, amount, 
                        priceunit, level, itemgroup, group, vendor, request, store, workspace, organization, 
                        accountcode, costcentre, tmpfac, ringi, address, currency, chaseno, projecttext, wbs });
                        }
                        else
                            tmptable.Rows.Add(new object[] { flag, document, category, item, itemtext, qty, deliverydate, amount, 
                        priceunit, level, itemgroup, group, vendor, request, store, workspace, organization, 
                        accountcode, costcentre, fixedassetcode, ringi, address, currency, chaseno, projecttext, wbs });

                        tmplist.Add(rowchaseno);
                    }
                    GlobalService.reader.Close();
                }

                for (int i = 0; i < tmplist.Count; i++)
                {
                    string tmpchaseno = tmplist[i].ToString();

                    string commandText = string.Format("update tb_betamould set tm_st_code = 'D', tm_modify = 'Yes', tm_moulditemviewer = 'Yes' where tm_chaseno = '{0}'", tmpchaseno);
                    DataService.GetInstance().ExecuteNonQuery(commandText);
                }


                if (tmptable.Rows.Count == 0)
                    MessageBox.Show("No Record can be downloaded");
                else
                {
                    DataView dv = tmptable.DefaultView;
                    dv.Sort = "追跡番号 ASC";

                    DataTable sorted = dv.ToTable();

                    ExportXlsUtil.XlsUtil(sorted);
                }
            }


            
        }
    }
}
