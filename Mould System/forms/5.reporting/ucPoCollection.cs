using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.excel;
using Mould_System.file.csv;
using Mould_System.checking;
using Mould_System.functions.others;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Mould_System.forms._5.reporting
{
    public partial class ucPoCollection : UserControl
    {
        public ucPoCollection()
        {
            InitializeComponent();

            try
            {
                this.loadData();
            }
            catch
            {
                //MessageBox.Show("Mould PO Collection could not load properly");
            }
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string[] headers = {"passstatus", "passdate", "collectdate", "vendorcode", "vendorname", "ic", "model", "itemcode", "rev", "mouldno", "status", "mouldcode",
                                   "currency", "amount", "amounthkd", "remarks", "itemtext", "fac", "chaseno", "pono", "porev", "stname", "issued", "mpa", "oem"};
            foreach (string header in headers)
                table.Columns.Add(header);

            string query = "select t.tm_passremarks as passstatus, t.tm_passdate as passdate, t.tm_collectdate as collectdate, t.tm_vendor_code as vendorcode, v.v_name as vendorname, v.v_group as ic, t.tm_model as model" +
                ", t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_mouldno as mouldno, t.tm_status as status, t.tm_mouldcode_code as mouldcode" +
                ", t.tm_currency as currency, t.tm_amount as amount, t.tm_amounthkd as amounthkd, t.tm_rm as remarks, t.tm_itemtext as itemtext" +
                ", t.tm_fixedassetcode as fac, t.tm_chaseno as chaseno, t.tm_po as pono, st.st_status as stname, t.tm_poissued as issued, t.tm_instockdate50 as mpa, t.tm_oemasset as oem, t.tm_porev as porev" +
                " from tb_betamould as t, tb_vendor as v, tb_betaqstatus as st where t.tm_vendor_code = v.v_code and t.tm_st_code = st.st_code" +
                " and (t.tm_st_code = 'K' or t.tm_st_code = 'P' or t.tm_st_code = 'HS' or t.tm_st_code = 'PR') and t.tm_chaseno not like 'CM%'";

            SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(query, DataService.GetInstance().Connection);

            sda.Fill(table);

            LoadSpecialData(table);

            dgvPoCollection.DataSource = table;

            lblTotal.Text = "ROW COUNT : " + dgvPoCollection.Rows.Count;
        }

        private void LoadSpecialData(DataTable table)
        {
            string query = "select t.tm_passremarks, t.tm_passdate, t.tm_collectdate, t.tm_vendor_code, v.v_name, v.v_group, t.tm_model" +
                ", t.tm_itemcode, t.tm_rev, t.tm_mouldno, t.tm_status, t.tm_mouldcode_code" +
                ", t.tm_currency, t.tm_amount, t.tm_amounthkd, t.tm_rm, t.tm_itemtext" +
                ", t.tm_fixedassetcode, t.tm_chaseno, t.tm_po, t.tm_porev, st.st_status, t.tm_poissued, t.tm_instockdate50, t.tm_oemasset, t.tm_mpa" +
                " from tb_betamould as t, tb_vendor as v, tb_betaqstatus as st where t.tm_vendor_code = v.v_code and t.tm_st_code = st.st_code" +
                " and (t.tm_st_code = 'K' or t.tm_st_code = 'P' or t.tm_st_code = 'HS' or t.tm_st_code = 'PR') and t.tm_chaseno like 'CM%'";

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string pst = reader.GetString(0).Trim();
                    string pdate = reader.GetString(1).Trim();
                    string cdate = reader.GetString(2).Trim();
                    string vcode = reader.GetString(3).Trim();
                    string vname = reader.GetString(4).Trim();
                    string checkdate = reader.GetString(5).Trim();
                    string model = reader.GetString(6).Trim();
                    string itemcode = reader.GetString(7).Trim();
                    string rev = reader.GetString(8).Trim();
                    string mouldno = reader.GetString(9).Trim();
                    string div = reader.GetString(10).Trim();
                    string mouldcode = reader.GetString(11).Trim();
                    string currency = reader.GetString(12).Trim();
                    string amount = reader.GetString(13).Trim();
                    string amounthkd = reader.GetString(14).Trim();
                    string remarks = reader.GetString(15).Trim();
                    string itemtext = reader.GetString(16).Trim();
                    string fa = reader.GetString(17).Trim();
                    string chaseno = reader.GetString(18).Trim();
                    string pono = reader.GetString(19).Trim();
                    string porev = reader.GetString(20).Trim();
                    string status = reader.GetString(21).Trim();
                    string issued = reader.GetString(22).Trim();
                    string instock50 = reader.GetString(23).Trim();
                    string oem = reader.GetString(24).Trim();
                    string mpa = reader.GetString(25).Trim();

                    if (mpa == "True" && porev == "20")
                    {
                        decimal amt = Math.Round(Convert.ToDecimal(amount) / 2, 2);

                        table.Rows.Add(pst, pdate, cdate, vcode, vname, checkdate, model, itemcode, rev, mouldno, div, mouldcode, currency, amt, amounthkd, remarks, itemtext, fa, chaseno, pono.Substring(0, pono.Length - 2) + "10", "10", status, issued, instock50, oem);
                        table.Rows.Add(pst, pdate, cdate, vcode, vname, checkdate, model, itemcode, rev, mouldno, div, mouldcode, currency, amt, amounthkd, remarks, itemtext, fa, chaseno, pono, "20", status, issued, instock50, oem);
                    }
                    else
                        table.Rows.Add(pst, pdate, cdate, vcode, vname, checkdate, model, itemcode, rev, mouldno, div, mouldcode, currency, amount, amounthkd, remarks, itemtext, fa, chaseno, pono, porev, status, issued, instock50, oem);
                }
            }

            string text = "select distinct tp_po from tb_temppo";

            List<string> list = new List<string>();

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(text))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            foreach (string item in list)
            {
                var q = table.AsEnumerable().Where(x => x.Field<string>("pono") == item.Trim());

                foreach (var r in q.ToList())
                    r.Delete();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dlTable = new DataTable();

            string[] headers = {"Vendor Code", "Vendor Name", "I/C", "Model", "Part No.", "Rev", "Mould No.", "Type", "Mould Code", "Curr", "Amount", "Amount (HKD)",
                                   "Remarks", "品目テキスト", "固定資産番号", "追跡番号", "訂單號碼", "Status", "發行日", "50% MPA", 
                                   "部品認定／仕様書状況", "合格／承認日", "予定回收日", "I/C&Issued Month", "Not Yet Payment HKD", "Oem"};

            foreach (string header in headers)
                dlTable.Columns.Add(header);

            foreach (DataGridViewRow row in dgvPoCollection.Rows)
            {
                string passstatus = row.Cells[0].Value.ToString();
                string passdate = row.Cells[1].Value.ToString();
                string collectdate = row.Cells[2].Value.ToString();
                string vendorcode = row.Cells[3].Value.ToString();
                string vendorname = row.Cells[4].Value.ToString();
                string group = row.Cells[5].Value.ToString();
                //string group = DataChecking.getVendorGroup(vendorcode);
                string model = row.Cells[6].Value.ToString();
                string partno = row.Cells[7].Value.ToString();
                string rev = row.Cells[8].Value.ToString();
                string mouldno = row.Cells[9].Value.ToString();
                string status = row.Cells[10].Value.ToString();
                string mouldcode = row.Cells[11].Value.ToString();
                string currency = row.Cells[12].Value.ToString();
                string amount = row.Cells[13].Value.ToString();
                string amounthkd = row.Cells[14].Value.ToString();
                string remarks = row.Cells[15].Value.ToString();
                string itemtext = row.Cells[16].Value.ToString();
                string fac = row.Cells[17].Value.ToString();
                string chaseno = row.Cells[18].Value.ToString();
                string pono = row.Cells[19].Value.ToString();
                string porev = row.Cells[20].Value.ToString();
                string stname = row.Cells[21].Value.ToString();
                string issued = row.Cells[22].Value.ToString();
                string mpa = row.Cells[23].Value.ToString();
                string oem = row.Cells[24].Value.ToString();
                
                string icissued = "";
                string mpaamount = "";

                if (issued != "")
                {
                    try
                    {
                        DateTime yymm = Convert.ToDateTime(issued);
                        icissued = group + yymm.ToString("yyyyMM");
                    }
                    catch
                    {
                        icissued = "";
                    }
                }
                if (stname == "已付50% MPA")
                {
                    mpaamount = amounthkd == "-" || amounthkd == "" ? "-" : (Convert.ToDecimal(amounthkd) / 2).ToString();
                }
                else
                    mpaamount = amounthkd;

                dlTable.Rows.Add(new object[]{vendorcode, vendorname, group, model, partno, rev, mouldno, status, mouldcode, currency, amount, amounthkd,
                    remarks, itemtext, fac, chaseno, pono, stname, issued, mpa, passstatus, passdate, collectdate, icissued, mpaamount, oem});
            }

            ExportCsvUtil.ExportCsv(dlTable, "", "MOULD PO COLLECTION");
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable tmptable = ImportXlsUtil.TranslateToTable(filename);

            int count = 0;

            foreach (DataRow row in tmptable.Rows)
            {
                string rowGroup = row.ItemArray[2].ToString();

                string rowChaseno = row.ItemArray[15].ToString();

                string rowPassremarks = row.ItemArray[20].ToString();

                string rowPassdate = row.ItemArray[21].ToString();

                string rowCollectdate = row.ItemArray[22].ToString();

                //if (rowPassdate.Contains("4"))
                    //rowPassdate = ImportXlsUtil.ParseDateTime(rowPassdate).ToString("yyyy/MM/dd");

                rowPassremarks = rowPassremarks.Replace("'", "''");

                string query = string.Format("update tb_betamould set tm_passdate = '{0}', tm_collectdate = '{1}', tm_passremarks = '{2}', tm_checkdate2 = '{4}' where tm_chaseno = '{3}'",
                    rowPassdate, rowCollectdate, rowPassremarks, rowChaseno, rowGroup);

                DataService.GetInstance().ExecuteNonQuery(query);

                string query2 = string.Format("update tb_betamould set tm_facremarks = tm_collectdate where tm_chaseno = '{0}' and tm_fixedAssetCode != ''", rowChaseno);

                DataService.GetInstance().ExecuteNonQuery(query2);

                if (rowCollectdate != "")
                {
                    string query3 = string.Format("update TB_FA_APPROVAL set f_remarks = N'{0}' where f_mould = '{1}'", rowCollectdate, rowChaseno);
                    DataServiceNew.GetInstance().ExecuteNonQuery(query3);
                }

                count += 1;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            MessageBox.Show("Data uploaded");
        }

        string filename = "";

        private void btnUpload_Click(object sender, EventArgs e)
        {
             OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

             DataTable tmptable = new DataTable();

             if (ofd.ShowDialog() == DialogResult.OK)
             {
                 this.Cursor = Cursors.WaitCursor;

                 filename = ofd.FileName;

                 if (!worker.IsBusy)
                     worker.RunWorkerAsync();
                 else
                     MessageBox.Show("Using by other process");
             }

             this.Cursor = Cursors.WaitCursor;

             int count = 0;

             //MessageBox.Show("Record has been saved");
             this.Cursor = Cursors.Default;
        }
    }
}
