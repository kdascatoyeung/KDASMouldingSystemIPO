using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.csv;
using Mould_System.file.excel;
using System.IO;
using System.Runtime.InteropServices;

namespace Mould_System.functions.instock
{
    public partial class frmReceivedPo : Form
    {
        public frmReceivedPo()
        {
            InitializeComponent();

            cbType.SelectedIndex = 0;

            this.loadData();

            string filepath = @"C:\ReceivedPO\";

            //if (!Directory.Exists(filepath))
               // Directory.CreateDirectory(filepath);
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select t.tm_chaseno as chaseno, t.tm_po as pono, t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_mouldno as mouldno" +
                ", t.tm_mouldcode_code as mouldcode, t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_tmpfixedassetcode as tmpfac, t.tm_fixedassetcode as fac" +
                ", t.tm_currency as currency, t.tm_amount as amount, t.tm_poissued as issued, t.tm_instockdate50 as instock50, t.tm_instockdate as instockdate, t.tm_mpa as mpa" +
                ", tm_checkdate as checkdate, tm_cav as cav, tm_weight as weight, tm_accessory as equipment, tm_camera as shot, tm_vertical as length, tm_horizontal as width, tm_height as height" +
                " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_st_code = 'PR'";

            string commandText = "";

            if (cbType.SelectedIndex == 0)
                commandText = _commandText;

            if (cbType.SelectedIndex == 1)//Normal 100%
                commandText = _commandText + " and t.tm_instockdate50 = '-----' and t.tm_instockdate = 'Received'";

            if (cbType.SelectedIndex == 2)//1st 50%
                commandText = _commandText + " and t.tm_instockdate50 = 'Received'";

            if (cbType.SelectedIndex == 3)//2nd 50%
                commandText = _commandText + " and t.tm_instockdate50 != '-----' and t.tm_instockdate50 != '一回合格入庫' and t.tm_instockdate50 != '已拆單、以合格同時入庫' and t.tm_instockdate = 'Received'";

            if (cbType.SelectedIndex == 4)//100% (1 PO)
                commandText = _commandText + " and t.tm_instockdate50 = '一回合格入庫' and t.tm_instockdate = 'Received'";

            if (cbType.SelectedIndex == 5)//100% (2 PO)
                commandText = _commandText + " and t.tm_instockdate50 = '已拆單、以合格同時入庫' and t.tm_instockdate = 'Received'";

            if (cbType.SelectedIndex == 6)//Transfer
                commandText = _commandText + "and t.tm_instockdate50 = '-----' and t.tm_instockdate != 'Received'";

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvResult.DataSource = table;
        }

        DataTable table100 = null;
        DataTable table50 = null;
        DataTable table50second = null;
        DataTable table50full = null;
        DataTable table5050 = null;
        DataTable tableCN = null;
        DataTable tableRMB = null;

        private void btnDownload_Click(object sender, EventArgs e)
        {
            
            table100 = new DataTable();

            /*string[] headers = {"勘定設定カテゴリ", "品目テキスト", "勘定コード", "原価センタ", "固定資產番号 (Temp)", "固定資産番号", "稟議番号", "追跡番号",
                                   "項目テキスト", "P/O", "P/O + 001", "檢查合格日", "交貨數量", "Vendor Name"};*/

            string[] headers = {"CATEGORY", "ITEM TEXT", "ACCOUNT CODE", "COST CENTRE", "FIXED ASSET (TEMP)", "FIXED ASSET", "RINGI", "CHASE NO.",
                                   "PROJECT", "P/O", "P/O + 001", "CHECK DATE", "QUANTITY", "VENDORNAME", "CURRENCY", "AMOUNT", "AMOUNT (HKD)",
                                    "CAV", "WEIGHT", "EQUIPMENT", "SHOT", "LENGTH", "WIDTH", "HEIGHT"};

            table50 = new DataTable();
            table50second = new DataTable();
            table50full = new DataTable();
            table5050 = new DataTable();
            tableCN = new DataTable();
            tableRMB = new DataTable();

            /*string[] headers50 = {"勘定設定カテゴリ", "品目テキスト", "勘定コード", "原価センタ", "固定資產番号 (Temp)", "固定資産番号", "稟議番号", "追跡番号",
                                   "項目テキスト", "P/O", "交貨號碼", "檢查合格日", "交貨數量", "Vendor Name"};*/
            string[] headers50 = {"CATEGORY", "ITEM TEXT", "ACCOUNT CODE", "COST CENTRE", "FIXED ASSET (TEMP)", "FIXED ASSET", "RINGI", "CHASE NO.",
                                   "PROJECT", "P/O", "DELIVERY NO.", "CHECK DATE", "QUANTITY", "VENDORNAME", "CURRENCY", "AMOUNT", "AMOUNT (HKD)",
                                    "CAV", "WEIGHT", "EQUIPMENT", "SHOT", "LENGTH", "WIDTH", "HEIGHT"};

            foreach (string header in headers)
            {
                table100.Columns.Add(header);
                tableCN.Columns.Add(header);
                tableRMB.Columns.Add(header);
            }

            foreach (string header in headers50)
            {
                table50.Columns.Add(header);
                table50second.Columns.Add(header);
                table50full.Columns.Add(header);
                table5050.Columns.Add(header);
            }

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                string chaseno = row.Cells[0].Value.ToString();

                string str50 = row.Cells[13].Value.ToString();
                string str100 = row.Cells[14].Value.ToString();
                string mpa = row.Cells[15].Value.ToString();

                if (chaseno.StartsWith("CM"))
                {
                    this.loadNonMpa(chaseno);
                }
                else
                {
                    if (mpa == "False")
                        this.loadNonMpa(chaseno);
                    else
                        this.loadMpa(chaseno, str50, str100);
                }
            }

            DataSet ds = new DataSet();

            DataView v100 = table100.DefaultView;
            v100.Sort = "VENDORNAME ASC, P/O ASC";
            table100 = v100.ToTable();

            DataView v50 = table50.DefaultView;
            v50.Sort = "VENDORNAME ASC, P/O ASC";
            table50 = v50.ToTable();

            DataView v50second = table50second.DefaultView;
            v50second.Sort = "VENDORNAME ASC, P/O ASC";
            table50second = v50second.ToTable();

            DataView v50full = table50full.DefaultView;
            v50full.Sort = "VENDORNAME ASC, P/O ASC";
            table50full = v50full.ToTable();

            DataView v5050 = table5050.DefaultView;
            v5050.Sort = "VENDORNAME ASC, P/O ASC";
            table5050 = v5050.ToTable();

            DataView vCn = tableCN.DefaultView;
            vCn.Sort = "VENDORNAME ASC, P/O ASC";
            tableCN = vCn.ToTable();

            DataView vRmb = tableRMB.DefaultView;
            vRmb.Sort = "VENDORNAME ASC, P/O ASC";
            tableRMB = vRmb.ToTable();

            ds.Tables.Add(table100);
            ds.Tables.Add(table50);
            ds.Tables.Add(table50second);
            ds.Tables.Add(table50full);
            ds.Tables.Add(table5050);
            ds.Tables.Add(tableCN);
            ds.Tables.Add(tableRMB);

            try
            {
                //ExportXlsUtil.ExcelMultiSheet(ds);
                ExportXlsUtil.multiSheetExcel(ds);
            }
            catch (Exception comex)
            {
                MessageBox.Show(comex.Message + comex.StackTrace);
            }
            /*if (table100.Rows.Count != 0)
                ExportCsvUtil.ExportCsv(table100, "", "Normal 100%");

            if (table50.Rows.Count != 0)
                ExportCsvUtil.ExportCsv(table50, "", "50% MPA");*/
        }

        private void loadNonMpa(string chaseno)
        {
            string query = string.Format("select top 1 t.tm_category, t.tm_itemtext, t.tm_accountcode, t.tm_costcentre, t.tm_fixedassetcode, t.tm_ringi_code" +
                    ", t.tm_chaseno, t.tm_projecttext, t.tm_po, t.tm_checkdate, v.v_name, t.tm_tmpfixedassetcode, t.tm_currency, t.tm_amount, t.tm_amounthkd"+
                    ", t.tm_cav, tm_weight, t.tm_accessory, t.tm_camera, t.tm_vertical, t.tm_horizontal, t.tm_height, t.tm_oemasset from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code" +
                    " and t.tm_chaseno = '{0}'", chaseno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string category = reader.GetString(0);
                    string itemtext = reader.GetString(1);
                    string accountcode = reader.GetString(2);
                    string costcentre = reader.GetString(3);
                    string fac = reader.GetString(4);
                    string ringi = reader.GetString(5);
                    string projecttext = reader.GetString(7);
                    string po = reader.GetString(8);
                    string checkdate = reader.GetString(9);
                    string vendorname = reader.GetString(10);
                    string tmpfac = reader.GetString(11);
                    string currency = reader.GetString(12);
                    string amount = reader.GetString(13);
                    string amounthkd = reader.GetString(14);
                    string cav = reader.GetString(15);
                    string weight = reader.GetString(16);
                    string equipment = reader.GetString(17);
                    string shot = reader.GetString(18);
                    string length = reader.GetString(19);
                    string width = reader.GetString(20);
                    string height = reader.GetString(21);
                    string oem = reader.GetString(22);

                    if (oem != "CN" && currency != "RMB")
                        table100.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + po, po + "+001", checkdate, "1", vendorname, currency, amount, amounthkd,
                                                                                cav, weight, equipment, shot, length, width, height});

                    if (oem == "CN")
                        tableCN.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + po, po + "+001", checkdate, "1", vendorname, currency, amount, amounthkd,
                                                                                cav, weight, equipment, shot, length, width, height});

                    if (currency == "RMB")
                        tableRMB.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + po, po + "+001", checkdate, "1", vendorname, currency, amount, amounthkd,
                                                                                cav, weight, equipment, shot, length, width, height});
                }
            }
        }

        private void loadMpa(string chaseno, string instock50, string instock100)
        {
            string deliveryno = "";

            string query = string.Format("select t.tm_category, t.tm_itemtext, t.tm_accountcode, t.tm_costcentre, t.tm_tmpfixedassetcode, t.tm_fixedassetcode, t.tm_ringi_code" +
                    ", t.tm_chaseno, t.tm_projecttext, t.tm_po, t.tm_checkdate, v.v_name, t.tm_currency, t.tm_amount, t.tm_amounthkd, t.tm_cav, t.tm_weight, t.tm_accessory, t.tm_camera"+
                    " , t.tm_vertical, t.tm_horizontal, t.tm_height from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code" +
                    " and t.tm_chaseno = '{0}'", chaseno);

            string category = "", itemtext = "", accountcode = "", costcentre = "", tmpfac = "", fac = "", ringi = "", projecttext = "", pono = "", checkdate = "", vendorname = "";

            string currency = "", amount = "", amounthkd = "";

            string cav = "", weight = "", equipment = "", shot = "", length = "", width = "", height = "";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                category = GlobalService.reader.GetString(0);
                itemtext = GlobalService.reader.GetString(1);
                accountcode = GlobalService.reader.GetString(2);
                costcentre = GlobalService.reader.GetString(3);
                tmpfac = GlobalService.reader.GetString(4);
                fac = GlobalService.reader.GetString(5);
                ringi = GlobalService.reader.GetString(6);
                projecttext = GlobalService.reader.GetString(8);
                pono = GlobalService.reader.GetString(9);
                checkdate = GlobalService.reader.GetString(10);
                vendorname = GlobalService.reader.GetString(11);
                currency = GlobalService.reader.GetString(12);
                amount = GlobalService.reader.GetString(13);
                amounthkd = GlobalService.reader.GetString(14);
                cav = GlobalService.reader.GetString(15);
                weight = GlobalService.reader.GetString(16);
                equipment = GlobalService.reader.GetString(17);
                shot = GlobalService.reader.GetString(18);
                length = GlobalService.reader.GetString(19);
                width = GlobalService.reader.GetString(20);
                height = GlobalService.reader.GetString(21);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            if (instock50 == "Received")//1st 50%
            {
                deliveryno = pono + "+001";
                table50.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + pono, deliveryno, checkdate, "1", vendorname, currency, amount, amounthkd,
                                                                            cav, weight, equipment, shot, length, width, height});
            }

            else if (instock50 == "一回合格入庫")//100% (1 PO)
            {
                deliveryno = pono + "+001";
                //table50.Rows.Add(new object[] { category, itemtext, accountcode, costcentre, tmpfac, fac, ringi, chaseno, projecttext, pono, deliveryno, checkdate, "2", vendorname });
                table50full.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + pono, deliveryno, checkdate, "2", vendorname, currency, amount, amounthkd,
                                                                                    cav, weight, equipment, shot, length, width, height});
            }

            else if (instock50 == "已拆單、以合格同時入庫")//100% (2 PO)
            {
                for (int i = 1; i <= 2; i++)
                {
                    deliveryno = pono + "+00" + i;
                    //table50.Rows.Add(new object[] { category, itemtext, accountcode, costcentre, tmpfac, fac, ringi, chaseno, projecttext, pono, deliveryno, checkdate, "1", vendorname });
                    table5050.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + pono, deliveryno, checkdate, "1", vendorname, currency, amount, amounthkd,
                                                                                        cav, weight, equipment, shot, length, width, height});
                }
            }

            else
            {
                deliveryno = pono + "+002";
                //table50.Rows.Add(new object[] { category, itemtext, accountcode, costcentre, tmpfac, fac, ringi, chaseno, projecttext, pono, deliveryno, checkdate, "1", vendorname });
                table50second.Rows.Add(new object[] { category, itemtext, "'" + accountcode, "'" + costcentre, tmpfac, fac, ringi, chaseno, projecttext, "'" + pono, deliveryno, checkdate, "1", vendorname, currency, amount, amounthkd,
                                                                                        cav, weight, equipment, shot, length, width, height});
            }

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadData();
        }
    }
}
