using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.excel;
using Mould_System.checking;
using System.Diagnostics;

namespace Mould_System.functions.file
{
    public partial class frmULlist : Form
    {
        private DataTable table = null;

        public frmULlist(List<string> list)
        {
            InitializeComponent();

            this.loadData(list);
        }

        private void loadData(List<string> list)
        {
            table = new DataTable();

            string[] headers = { "chaseno", "mouldno", "itemcode", "rev", "currency", "amount", "vendor" };
            foreach (string header in headers)
                table.Columns.Add(header);

            List<string> removeRepeat = list.Distinct().ToList();

            for (int i = 0; i < removeRepeat.Count; i++)
            {
                string source = removeRepeat[i].ToString();

                string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev" +
                    ", tm_currency as currency, tm_amount as amount, tm_vendor_code as vendor from tb_betamould where tm_chaseno = '{0}'", source);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
                while (GlobalService.reader.Read())
                {
                    string chaseno = GlobalService.reader.GetString(0);
                    string mouldno = GlobalService.reader.GetString(1);
                    string itemcode = GlobalService.reader.GetString(2);
                    string rev = GlobalService.reader.GetString(3);
                    string currency = GlobalService.reader.GetString(4);
                    string amount = GlobalService.reader.GetString(5);
                    string vendor = GlobalService.reader.GetString(6);

                    table.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, currency, amount, vendor });
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                dgvR3UL.DataSource = table;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvR3UL.SelectedRows)
            {
                string chaseno = row.Cells[0].Value.ToString();

                GlobalService.fileUlList.Remove(chaseno);

                this.dgvR3UL.Rows.Remove(row);
            }
        }

        private void download()
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
            //GlobalService.reader.Dispose();

            decimal finalAmount = 0;

            List<string> tmpList = new List<string>();

            foreach (DataGridViewRow row in dgvR3UL.Rows)
            {
                string rowChaseno = row.Cells[0].Value.ToString();
                string rowCurrency = row.Cells[4].Value.ToString();
                string rowAmount = row.Cells[5].Value.ToString();

                string q1 = string.Format("select f_fixedasset from TB_FA_APPROVAL where f_chaseno = '{0}' and f_mpa = 'Temp'", rowChaseno);
                string result = "";
                try
                {
                    result = DataServiceNew.GetInstance().ExecuteScalar(q1).ToString();
                }
                catch
                {
                    result = "";
                }

                string u1 = string.Format("update tb_betamould set tm_tmpfixedassetcode = '{0}' where tm_chaseno = '{1}' and tm_mpa = 'True'", result, rowChaseno);
                DataService.GetInstance().ExecuteNonQuery(u1);

                string updateText = string.Format("update tb_betamould set tm_deliverydate = '{0}' where tm_chaseno = '{1}'", delivery, rowChaseno);
                DataService.GetInstance().ExecuteNonQuery(updateText);

                string text = string.Format("select t.tm_category, t.tm_itemtext, t.tm_qty, t.tm_deliverydate, t.tm_amount" +
                    ", m.mc_itemgroup, t.tm_group, t.tm_vendor_code, t.tm_request" +
                    ", t.tm_accountcode, t.tm_costcentre, t.tm_fixedassetcode, t.tm_ringi_code, t.tm_currency, t.tm_chaseno, t.tm_projecttext, t.tm_tmpfixedassetcode, t.tm_mpa, t.tm_oemasset" +
                    " from tb_betamould as t, tbm_mouldcode as m where t.tm_mouldcode_code = m.mc_mouldcode and t.tm_chaseno = '{0}'", rowChaseno);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                //Debug.WriteLine(rowChaseno + rowCurrency + rowAmount);

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

                    if (mpa == "True" && tmpfac == "" && oemasset == "" && currency != "RMB")
                    {
                        MessageBox.Show("Temp Fixed Asset Code not saved yet. Please contact Account Division.");
                        return;
                    }

                    if (currency == "RMB")
                    {
                        double tmpAmount = Convert.ToDouble(amount);
                        if (mpa == "True")
                        {
                            tmpAmount = Convert.ToDouble(amount) / 2;

                            tmptable.Rows.Add(new object[]{ flag, "Z008", category, item, itemtext, qty, deliverydate, tmpAmount,
                            priceunit, level, itemgroup, group, vendor, request, store, "2100", "2000", "", "", fixedassetcode,
                            ringi, "", currency, chaseno, projecttext, wbs});

                            tmptable.Rows.Add(new object[]{ flag, "Z008", category, item, itemtext, qty, deliverydate, tmpAmount,
                            priceunit, level, itemgroup, group, vendor, request, store, "2100", "2000", "", "", fixedassetcode,
                            ringi, "", currency, chaseno, projecttext, wbs});
                        }
                        else
                            tmptable.Rows.Add(new object[]{ flag, "Z008", category, item, itemtext, qty, deliverydate, tmpAmount,
                            priceunit, level, itemgroup, group, vendor, request, store, "2100", "2000", "", "", fixedassetcode,
                            ringi, "", currency, chaseno, projecttext, wbs});
                    }
                    else
                    {
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
                    }

                    tmpList.Add(rowChaseno);
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }

            for (int i = 0; i < tmpList.Count; i++)
            {
                string tmpchaseno = tmpList[i].ToString();

                if (tmpchaseno.StartsWith("CM"))
                {
                    string commandText = string.Format("update tb_betamould set tm_st_code = 'D', tm_cndatetime = '{0}', tm_cndownload = 'Yes' where tm_chaseno = '{1}'", DateTime.Today.ToString("yyyy/MM/dd"), tmpchaseno);
                    DataService.GetInstance().ExecuteNonQuery(commandText);
                }
                else
                {
                    string commandText = string.Format("update tb_betamould set tm_st_code = 'D', tm_modify = 'Yes', tm_moulditemviewer = 'Yes' where tm_chaseno = '{0}'", tmpchaseno);
                    DataService.GetInstance().ExecuteNonQuery(commandText);
                }
            }
            
            if (tmptable.Rows.Count == 0)
                MessageBox.Show("No Record can be downloaded");
            else
            {
                //ExportTextUtil.ExportR3(tmptable, "R3 UL");
                DataView dv = tmptable.DefaultView;
                dv.Sort = "追跡番号 ASC";

                DataTable sorted = dv.ToTable();

                ExportXlsUtil.XlsUtil(sorted);
                GlobalService.fileUlList.Clear();
                this.Hide();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            this.download();
        }
    }
}
