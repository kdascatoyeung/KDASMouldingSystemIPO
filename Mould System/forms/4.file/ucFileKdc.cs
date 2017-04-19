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
using Mould_System.file.excel;
using System.Diagnostics;

namespace Mould_System.forms._4.file
{
    public partial class ucFileKdc : UserControl
    {
        private DataTable table = null;

        private List<string> list;

        public ucFileKdc()
        {
            InitializeComponent();

            //for (int i = 0; i < dgvKdc.Columns.Count; i++)
                //Debug.WriteLine(dgvKdc.Columns[i].HeaderText);

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            string[] items = { "All", "Chase No.", "Mould No.", "Item Code", "Vendor Code", "Mould Code", "PO", "Issued Date", "Currency" };

            foreach (string item in items)
                this.cbSearch.Items.Add(item);

            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev" +
                ", tm_status as status, tm_vendor_code as vendor, tm_mouldcode_code as mouldcode, tm_po as po" +
                ", tm_st_code as stcode from tb_betamould";

            string commandText = "";

            string _whereText = " where (tm_st_code = 'P' or tm_st_code = 'K')";
            string whereText = "";

            if (cbSearch.SelectedIndex == 0)
                whereText = _whereText;

            if (cbSearch.SelectedIndex == 1)
                whereText = _whereText + string.Format(" and tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                whereText = _whereText + string.Format(" and tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                whereText = _whereText + string.Format(" and tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                whereText = _whereText + string.Format(" and tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)
                whereText = _whereText + string.Format(" and tm_mouldcode_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 6)
                whereText = _whereText + string.Format(" and tm_po like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 7)
                whereText = _whereText + string.Format(" and tm_poissued like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 8)
                whereText = _whereText + string.Format(" and tm_currency = '{0}'", txtSearch.Text);

            commandText = _commandText + whereText;

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvKdc.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvKdc.Rows.Count;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
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

        private void dgvKdc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvKdc.Rows)
            {
                string stcode = row.Cells[8].Value.ToString();

                if (stcode == "P")
                    row.Cells[0].Value = Properties.Resources.cross_icon;
                else
                    row.Cells[0].Value = Properties.Resources.tick_icon;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            list = new List<string>();

            foreach (DataGridViewRow row in dgvKdc.SelectedRows)
            {
                string chaseno = row.Cells[1].Value.ToString();

                list.Add(chaseno);
            }

            DataTable table = mergeTable(list);

            for (int i = 0; i < list.Count; i++)
            {
                string query = string.Format("update tb_betamould set tm_st_code = 'K', tm_modify = 'Yes', tm_moulditemviewer = 'Yes' where tm_chaseno = '{0}'", list[i]);
                DataService.GetInstance().ExecuteNonQuery(query);
            }

            ExportXlsUtil.XlsUtil(table);

            this.loadData();
        }

        private DataTable mergeTable(List<string> list)
        {
            DataTable mergetable = new DataTable();

            string[] headers = {"品目CODE", "REVISION", "金型番号", "PLANT", "金型費", "通貨", "保管責任者", "製作区分",
                                   "固定資産番号", "枝番", "購買依頼TEXT", "WBS要素", "追跡番号", "通知書NO", "預り証発行", 
                                   "購買伝票", "明細", "備考1", "", "金型番號", "Plant", "廃棄状況", "移管状況", "金型Code", "取数", "重量(Kg)", "使用設備(tｏｎ)",
                                   "保管責任者 ", "耐用数", "型取り形式", "縦(mm)", "横(mm)", "高さ(mm)", "OEM資産", "銘板", "棚卸結果",
                                   "稼動状況", "廃棄報告書番号", "資産(廃棄)", "資産(移管)", "使用先Text", "備考", "", "品目コード", "金型番号 " };

            foreach (string header in headers)
                mergetable.Columns.Add(header);

            //Detail
            string detailItemCode = "", detailRev = "", detailMouldNo = "", detailPlant = "2000", detailAmount = "", detailCurrency = "", detailVendor = "";
            string detailMaking = "", detailFac = "", detailFixOption = "", detailRequestText = "", detailWbs = "", detailChaseNo = "", detailNotice = "", detailIssued = "1";
            string detailPo = "", detailPoRev = "", detailRemark = "";

            //Information
            string infoMouldNo = "", infoPlant = "2000", infoWasteStatus = "1", infoRelocateStatus = "1", infoMouldCode = "", infoQty = "", infoWeight = "", infoTon = "", infoVendor = "", infoUsage = "";
            string infoMethod = "", infoLength = "", infoWidth = "", infoHeight = "", infoOem = "", infoPlate = "1", infoResult = "1", infoStatus = "1";
            string infoReportno = "", infoAssetWaste = "1", infoAssetRelocate = "1", infoText = "", infoRemark = "";

            //bom
            string bomItemCode = "", bomMouldNo = "";


            mergetable.Rows.Add(new object[]{detailItemCode, detailRev, detailMouldNo, detailPlant, detailAmount, detailCurrency, detailVendor,
                        detailMaking, detailFac, detailFixOption, detailRequestText, detailWbs, detailChaseNo, detailNotice, detailIssued, detailPo, detailPoRev, detailRemark,
                        "", infoMouldNo, infoPlant, infoWasteStatus, infoRelocateStatus, infoMouldCode, infoQty, infoWeight, infoTon, infoVendor, infoUsage,
                        infoMethod, infoLength, infoWidth, infoHeight, infoOem, infoPlate, infoResult, infoStatus, infoReportno, infoAssetWaste, infoAssetRelocate, infoText, infoRemark,
                        "", bomItemCode, bomMouldNo});

            for (int i = 0; i < list.Count; i++)
            {
                string query = string.Format("select t.tm_chaseno, t.tm_itemcode, t.tm_rev, t.tm_mouldno, t.tm_amount, t.tm_currency, t.tm_fixedassetcode, t.tm_vendor_code, t.tm_mouldcode_code" +
                    ", t.tm_po, t.tm_porev, t.tm_status, t.tm_model, t.tm_rm, t.tm_type, t.tm_oemasset, v.v_name from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_chaseno = '{0}'", list[i]);

                using (GlobalService.reader = DataService.GetInstance().ExecuteReader(query))
                {
                    while (GlobalService.reader.Read())
                    {
                        detailItemCode = GlobalService.reader.GetString(1);
                        detailRev = GlobalService.reader.GetString(2);
                        detailMouldNo = GlobalService.reader.GetString(3);
                        detailAmount = GlobalService.reader.GetString(4);
                        detailCurrency = GlobalService.reader.GetString(5);
                        detailFac = GlobalService.reader.GetString(6);
                        detailVendor = GlobalService.reader.GetString(7);
                        detailChaseNo = GlobalService.reader.GetString(0);
                        detailPo = GlobalService.reader.GetString(9);
                        detailPo = detailPo.Substring(0, 10);
                        detailPoRev = GlobalService.reader.GetString(10);

                        infoMouldNo = GlobalService.reader.GetString(3);
                        infoMouldCode = GlobalService.reader.GetString(8);
                        infoVendor = GlobalService.reader.GetString(7);

                        bomItemCode = GlobalService.reader.GetString(1);
                        bomMouldNo = GlobalService.reader.GetString(3);

                        string status = GlobalService.reader.GetString(11);
                        if (status == "Modify")
                            detailMaking = "2";
                        else
                            detailMaking = "1";

                        detailWbs = GlobalService.reader.GetString(12);
                        detailRemark = GlobalService.reader.GetString(13);

                        string type = GlobalService.reader.GetString(14);
                        if (type == "Set")
                            infoMethod = "2";
                        else
                            infoMethod = "1";

                        infoOem = GlobalService.reader.GetString(15);
                        if (infoOem == "" || infoOem == "VN" || infoOem == "DM" || infoOem == "SY" || infoOem == "JP" || infoOem=="CN")
                            infoOem = "1";

                        infoText = GlobalService.reader.GetString(16);
                        infoRemark = detailRemark;

                        if (detailCurrency != "RMB")
                        {
                            mergetable.Rows.Add(new object[]{detailItemCode, detailRev, detailMouldNo, detailPlant, detailAmount, detailCurrency, detailVendor,
                        detailMaking, detailFac, detailFixOption, detailRequestText, detailWbs, detailChaseNo, detailNotice, detailIssued, detailPo, detailPoRev, detailRemark,
                        "", infoMouldNo, infoPlant, infoWasteStatus, infoRelocateStatus, infoMouldCode, infoQty, infoWeight, infoTon, infoVendor, infoUsage,
                        infoMethod, infoLength, infoWidth, infoHeight, infoOem, infoPlate, infoResult, infoStatus, infoReportno, infoAssetWaste, infoAssetRelocate, infoText, infoRemark,
                        "", bomItemCode, bomMouldNo});
                        }
                        else
                        {
                            mergetable.Rows.Add(new object[]{detailItemCode, detailRev, detailMouldNo, "2100", detailAmount, detailCurrency, detailVendor,
                        detailMaking, detailFac, detailFixOption, detailRequestText, detailWbs, detailChaseNo, detailNotice, detailIssued, detailPo, detailPoRev, detailRemark,
                        "", infoMouldNo, "2100", infoWasteStatus, infoRelocateStatus, infoMouldCode, infoQty, infoWeight, infoTon, infoVendor, infoUsage,
                        infoMethod, infoLength, infoWidth, infoHeight, infoOem, infoPlate, infoResult, infoStatus, infoReportno, infoAssetWaste, infoAssetRelocate, infoText, infoRemark,
                        "", bomItemCode, bomMouldNo});
                        }
                    }
                }
            }

            return mergetable;
        }

        private DataTable loadDetailTable(List<string> list)
        {
            DataTable detailtable = new DataTable();

            string[] headers = {"品目CODE", "REVISION", "金型番号", "PLANT", "金型費", "通貨", "保管責任者", "製作区分",
                                   "固定資産番号", "枝番", "購買依頼TEXT", "WBS要素", "追跡番号", "通知書NO", "預り証発行", 
                                   "購買伝票", "明細", "備考1"};

            foreach (string header in headers)
                detailtable.Columns.Add(header);

            string plant = "", making = "1", fixOption = "", requesttext = "", wbs = "", notice = "", issued = "1";

            for (int i = 0; i < list.Count; i++)
            {
                string query = string.Format("select tm_itemcode, tm_rev, tm_mouldno, tm_amount, tm_currency, tm_vendor_code, tm_fixedassetcode" +
                    ", tm_chaseno, tm_po, tm_porev from tb_betamould where tm_chaseno = '{0}'", list[i]);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string itemcode = GlobalService.reader.GetString(0);
                    string rev = GlobalService.reader.GetString(1);
                    string mouldno = GlobalService.reader.GetString(2);
                    string amount = GlobalService.reader.GetString(3);
                    string currency = GlobalService.reader.GetString(4);
                    string vendor = GlobalService.reader.GetString(5);
                    string fac = GlobalService.reader.GetString(6);
                    string chaseno = GlobalService.reader.GetString(7);
                    string po = GlobalService.reader.GetString(8);
                    string porev = GlobalService.reader.GetString(9);

                    detailtable.Rows.Add(new object[]{itemcode, rev, mouldno, plant, amount, currency, vendor, making,
                        fac, fixOption, requesttext, wbs, chaseno, notice, issued, po, porev});
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }

            return detailtable;
        }

        private DataTable loadInformationTable(List<string> list)
        {
            DataTable infotable = new DataTable();

            string[] headers = {"金型番号", "Plant", "廃棄状況", "移管状況", "金型Code", "取数", "重量(Kg)", "使用設備(tｏｎ)",
                                   "保管責任者", "耐用数", "型取り形式", "縦(mm)", "横(mm)", "高さ(mm)", "OEM資産", "銘板", "棚卸結果",
                                   "稼動状況", "廃棄報告書番号", "資産(廃棄)", "資産(移管)", "使用先Text", "備考"};

            string plant = "2000", wasteStatus = "1", relocateStatus = "1", qty = "", weight = "", ton = "", usage = "";
            string method = "", length = "", width = "", height = "", oem = "1", plate = "1", result = "1", status = "1";
            string reportno = "", assetWaste = "1", assetRelocate = "1", text = "", remark = "";

            foreach (string header in headers)
                infotable.Columns.Add(header);

            for (int i = 0; i < list.Count; i++)
            {
                string query = string.Format("select tm_mouldno, tm_mouldcode_code, tm_vendor_code from tb_betamould where tm_chaseno = '{0}'", list[i]);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string mouldno = GlobalService.reader.GetString(0);
                    string mouldcode = GlobalService.reader.GetString(1);
                    string vendor = GlobalService.reader.GetString(2);

                    infotable.Rows.Add(new object[]{mouldno, plant, wasteStatus, relocateStatus, mouldcode, qty, weight, ton, vendor,
                    usage, method, length, width, height, oem, plate, result, status, reportno, assetWaste, assetRelocate, text, remark});
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }

            return infotable;
        }

        private DataTable loadBomTable(List<string> list)
        {
            DataTable bomtable = new DataTable();

            string[] headers = { "品目コード", "金型番号" };

            foreach (string header in headers)
                bomtable.Columns.Add(header);

            for (int i = 0; i < list.Count; i++)
            {
                string query = string.Format("select tm_itemcode, tm_mouldno from tb_betamould where tm_chaseno = '{0}'", list[i]);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string itemcode = GlobalService.reader.GetString(0);
                    string mouldno = GlobalService.reader.GetString(1);

                    bomtable.Rows.Add(new object[] { itemcode, mouldno });
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }

            return bomtable;
        }
    }
}
