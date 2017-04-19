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
using Mould_System.file.csv;
using Mould_System.file.excel;

namespace Mould_System.forms._1.quotation
{
    public partial class ucMouldViewer : UserControl
    {
        private DataTable table = null;

        public ucMouldViewer()
        {
            InitializeComponent();
        }

        private void setupTable()
        {
            table = new DataTable();
            table.Columns.Add("mouldno");
            table.Columns.Add("itemcode");
            table.Columns.Add("type");
            table.Columns.Add("remarks");
        }

        private void loadData2()
        {
            this.setupTable();

            string query = string.Format("select distinct sc_itemcode, sc_mouldno, sc_type, sc_remarks from tb_setcommon where sc_mouldno = '{0}'", txtMouldno.Text);

            List<string> mouldList = new List<string>();
            List<string> filterList = new List<string>();

            string mould = "";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string itemcode = GlobalService.reader.GetString(0);
                mould = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);
                mouldList.Add(mould);

                filterList.Add(itemcode);

                table.Rows.Add(new object[] { mould, itemcode, type, remarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            this.loadMainData(mould, filterList);

            this.loadCommonData(mould);

            DataView view = table.DefaultView;

            table = view.ToTable(true, "mouldno", "itemcode", "type", "remarks");
            dgvMouldViewer.DataSource = table;
        }

        private void loadMainData(string mouldno, List<string> filterList)
        {
            filterList = filterList.Distinct().ToList();

            for (int i = 0; i < filterList.Count; i++)
            {
                string filter = filterList[i];
                string query = string.Format("select tm_mouldno, tm_itemcode, tm_type, tm_rm from tb_betamould where tm_mouldno = '{0}' and tm_itemcode != '{1}'", mouldno, filter);

                Debug.WriteLine("MAIN QUERY: " + query);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string mould = GlobalService.reader.GetString(0);
                    string itemcode = GlobalService.reader.GetString(1);
                    string type = GlobalService.reader.GetString(2);
                    string remarks = GlobalService.reader.GetString(3);

                    table.Rows.Add(new object[] { mould, itemcode, type, remarks });

                    Debug.WriteLine("Main Row Added");
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }
        }

        private void loadCommonData(string mouldno)
        {
            string query = string.Format("select t.tm_mouldno, t.tm_itemcode, t.tm_type, t.tm_rm from tb_betamould as t, tb_setcommon as sc" +
                " where t.tm_mouldno = sc.sc_oldmouldno and sc.sc_mouldno = '{0}' and sc.sc_type = 'Common'", mouldno);

            Debug.WriteLine("QUERY: " + query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string mould = GlobalService.reader.GetString(0);
                string itemcode = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                table.Rows.Add(new object[] { mould, itemcode, type, remarks });

                Debug.WriteLine("Common Row Added");
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadData()
        {
            this.setupTable();

            string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev, tm_status as status" +
                ", tm_type as type, tm_common as common from tb_betamould where tm_mouldno = '{0}'", txtMouldno.Text);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string mouldno = GlobalService.reader.GetString(1);
                string itemcode = GlobalService.reader.GetString(2);
                string rev = GlobalService.reader.GetString(3);
                string status = GlobalService.reader.GetString(4);
                string type = GlobalService.reader.GetString(5);
                string common = GlobalService.reader.GetString(6);

                table.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, status, type, common });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            List<string> listChaseNo = new List<string>();

            this.loadCommon(listChaseNo);

            dgvMouldViewer.DataSource = table;
        }

        private void loadCommon(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string chasenoFromList = list[i].ToString();

                string query = string.Format("select distinct t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev, t.tm_status" +
                    ", t.tm_type as type, t.tm_common as common from tb_betamould as t, tb_relationcommon as rc where t.tm_mouldno = rc.rc_newmouldno" +
                    " and rc.rc_newmouldno = '{0}' and t.tm_common = 'Common' and t.tm_chaseno != '{1}'", txtMouldno.Text, chasenoFromList);

                //string query = string.Format("select rc_newmouldno as mouldno, rc_itemcode as itemcode from tb_relationcommon where rc_newmouldno = '{0}'", txtMouldno.Text);

                //Debug.WriteLine("Query: " + query);
                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
                while (GlobalService.reader.Read())
                {
                    /*string mouldno = GlobalService.reader.GetString(0);
                    string itemcode = GlobalService.reader.GetString(1);

                    table.Rows.Add(new object[] { "-", mouldno, itemcode, "-", "-", "-", "Common" });*/

                    string chaseno = GlobalService.reader.GetString(0);
                    string mouldno = GlobalService.reader.GetString(1);
                    string itemcode = GlobalService.reader.GetString(2);
                    string rev = GlobalService.reader.GetString(3);
                    string status = GlobalService.reader.GetString(4);
                    string type = GlobalService.reader.GetString(5);
                    string common = GlobalService.reader.GetString(6);

                    table.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, status, type, common });
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.loadData2();
        }

        private void txtMouldno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData2();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string[] headers = {"CHASE NO.", "PART NO.", "REV", "COMMON MOULD NO.", "MOULD NO.",
                                   "DIV.", "TYPE", "FIXED ASSET", "TEMP FIXED ASSET", "ITEM TEXT", "PROJECT TEXT",
                                   "MODEL", "PO", "VENDOR", "MOULDCODE", "REMARKS", "IN STOCK"};

            DataTable table = new DataTable();

            foreach (string header in headers)
                table.Columns.Add(header);

            string query = "select tm_chaseno, tm_itemcode, tm_rev, tm_mouldno, tm_status, tm_type"+
                ", tm_fixedassetcode, tm_tmpfixedassetcode, tm_itemtext, tm_projecttext, tm_model, tm_po"+
                ", tm_vendor_code, tm_mouldcode_code, tm_rm, tm_instockdate from tb_betamould"+
                " where (tm_model = '2P7' or tm_model = '2R1' or tm_model = '2R2' or tm_model = '3PN' or tm_model = '3PP' or tm_model = '3PR')";

            List<string> mlist = new List<string>();

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string itemcode = GlobalService.reader.GetString(1);
                string rev = GlobalService.reader.GetString(2);
                string mouldno = GlobalService.reader.GetString(3);
                string div = GlobalService.reader.GetString(4);
                string type = GlobalService.reader.GetString(5);
                string fac = GlobalService.reader.GetString(6);
                string tmpfac = GlobalService.reader.GetString(7);
                string itemtext = GlobalService.reader.GetString(8);
                string projecttext = GlobalService.reader.GetString(9);
                string model = GlobalService.reader.GetString(10);
                string po = GlobalService.reader.GetString(11);
                string vendor = GlobalService.reader.GetString(12);
                string mouldcode = GlobalService.reader.GetString(13);
                string remarks = GlobalService.reader.GetString(14);
                string instockdate = GlobalService.reader.GetString(15);

                mlist.Add(mouldno);

                table.Rows.Add(new object[]{chaseno, itemcode, rev, "-", mouldno, div, type, fac, tmpfac, itemtext,
                    projecttext, model, po, vendor, mouldcode, remarks, instockdate});
            }
            GlobalService.reader.Close();

            List<string> ml = new List<string>();
            List<string> il = new List<string>();

            foreach (string mould in mlist)
            {
                string query2 = string.Format("select sc_itemcode from tb_setcommon where sc_mouldno = '{0}' and sc_oldmouldno != ''", mould);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query2);

                if (!GlobalService.reader.HasRows)
                {
                    GlobalService.reader.Close();
                    continue;
                }
                else
                {
                    while (GlobalService.reader.Read())
                    {
                        string scitemcode = GlobalService.reader.GetString(0);
                        il.Add(scitemcode);
                    }
                    GlobalService.reader.Close();
                }
            }

            foreach (string mould in mlist)
            {
                string query2 = string.Format("select sc_itemcode, sc_mouldno, sc_type, sc_remarks from tb_setcommon where sc_mouldno = '{0}' and sc_oldmouldno = ''", mould);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query2);

                if (!GlobalService.reader.HasRows)
                {
                    GlobalService.reader.Close();
                    continue;
                }
                else
                {
                    while (GlobalService.reader.Read())
                    {
                        string scitemcode = GlobalService.reader.GetString(0);
                        string scmouldno = GlobalService.reader.GetString(1);
                        string sctype = GlobalService.reader.GetString(2);
                        string scremarks = GlobalService.reader.GetString(3);

                        table.Rows.Add(new object[]{"-", scitemcode, "-", scmouldno, "", "-", sctype, "-", "-", "-",
                    "-", "-", "-", "-", "-", scremarks, "-"});
                    }
                    GlobalService.reader.Close();
                }
            }

            foreach (string item in il)
            {
                string query3 = string.Format("select tm_chaseno, tm_itemcode, tm_rev, sc_mouldno, tm_mouldno, tm_status, tm_type" +
                ", tm_fixedassetcode, tm_tmpfixedassetcode, tm_itemtext, tm_projecttext, tm_model, tm_po" +
                ", tm_vendor_code, tm_mouldcode_code, tm_rm, tm_instockdate from tb_betamould, tb_setcommon" +
                " where sc_itemcode = tm_itemcode and tm_mouldno = sc_oldmouldno and tm_itemcode = '{0}'", item);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query3);

                while (GlobalService.reader.Read())
                {
                    string chaseno = GlobalService.reader.GetString(0);
                    string itemcode = GlobalService.reader.GetString(1);
                    string rev = GlobalService.reader.GetString(2);
                    string omouldno = GlobalService.reader.GetString(3);
                    string mouldno = GlobalService.reader.GetString(4);
                    string div = GlobalService.reader.GetString(5);
                    string type = GlobalService.reader.GetString(6);
                    string fac = GlobalService.reader.GetString(7);
                    string tmpfac = GlobalService.reader.GetString(8);
                    string itemtext = GlobalService.reader.GetString(9);
                    string projecttext = GlobalService.reader.GetString(10);
                    string model = GlobalService.reader.GetString(11);
                    string po = GlobalService.reader.GetString(12);
                    string vendor = GlobalService.reader.GetString(13);
                    string mouldcode = GlobalService.reader.GetString(14);
                    string remarks = GlobalService.reader.GetString(15);
                    string instockdate = GlobalService.reader.GetString(16);

                    table.Rows.Add(new object[]{chaseno, itemcode, rev, omouldno, mouldno, div, type, fac, tmpfac, itemtext,
                    projecttext, model, po, vendor, mouldcode, remarks, instockdate});
                }
                GlobalService.reader.Close();
            }

            ExportCsvUtil.ExportCsv(table, "", "SET COMMON");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            DataTable resulttable = new DataTable();

            string[] headers = {"狀態", "Chase No.", "Part No.", "Rev", "Mould No.", "Div.", "Type", "Pcs",
                "Currency", "Amount", "AmountHkd", "Mpa", "Fixedassetcode", "TmpFixedassetcode",
                "Quantity", "Ringi", "Model", "PO", "PO Issued", "Category", "ItemText", "Project Text",
                "Vendor", "Vendor Name", "Group", "Mould Code", "Remarks", "In Stock 50", "In Stock Date",
                "Check Date", "Cav", "Weight", "Equipment", "Shot", "Vertical", "Horizontal", "Height",
                "In Stock Remarks", "Collect Date", "Pass Remarks", "OEM Asset", "Account Code",
                "Cost Centre", "Created By"};

            foreach (string header in headers)
                resulttable.Columns.Add(header);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;

                DataTable caltable = ImportXlsUtil.TranslateToTable(filename);

                Debug.WriteLine(caltable.Columns[0].ColumnName);

                if (caltable.Columns.Count != 1)
                {
                    MessageBox.Show("Error format");
                }
                else
                {
                    foreach (DataRow row in caltable.Rows)
                    {
                        string chaseno = row.ItemArray[0].ToString();

                        string query = string.Format("select st_status, tm_chaseno, tm_itemcode, tm_rev, tm_mouldno" +
                            ", tm_status, tm_type, tm_pcs, tm_currency, tm_amount, tm_amounthkd, tm_mpa" +
                            ", tm_fixedassetcode, tm_tmpfixedassetcode, tm_qty, tm_ringi_code, tm_model, tm_po" +
                            ", tm_poissued, tm_category, tm_itemtext, tm_projecttext, tm_vendor_code, v_name" +
                            ", v_group, tm_mouldcode_code, tm_rm, tm_instockdate50, tm_instockdate, tm_checkdate" +
                            ", tm_cav, tm_weight, tm_accessory, tm_camera, tm_vertical, tm_horizontal, tm_height" +
                            ", tm_instockremarks, tm_collectdate, tm_passremarks, tm_oemasset, tm_accountcode" +
                            ", tm_costcentre, tm_createdby from TB_BETAMOULD, TB_BETAQSTATUS, TB_VENDOR" +
                            " where tm_vendor_code = v_code and tm_st_code = st_code and tm_chaseno = '{0}'", chaseno);

                        GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                        while (GlobalService.reader.Read())
                        {
                            string status = GlobalService.reader.GetString(0);
                            string chaseNo = GlobalService.reader.GetString(1);
                            string itemcode = GlobalService.reader.GetString(2);
                            string rev = GlobalService.reader.GetString(3);
                            string mouldno = GlobalService.reader.GetString(4);
                            string div = GlobalService.reader.GetString(5);
                            string type = GlobalService.reader.GetString(6);
                            string pcs = GlobalService.reader.GetString(7);
                            string currency = GlobalService.reader.GetString(8);
                            string amount = GlobalService.reader.GetString(9);
                            string amounthkd = GlobalService.reader.GetString(10);
                            string mpa = GlobalService.reader.GetString(11);
                            string fa = GlobalService.reader.GetString(12);
                            string tmpfa = GlobalService.reader.GetString(13);
                            string qty = GlobalService.reader.GetString(14);
                            string ringi = GlobalService.reader.GetString(15);
                            string model = GlobalService.reader.GetString(16);
                            string po = GlobalService.reader.GetString(17);
                            string poissued = GlobalService.reader.GetString(18);
                            string category = GlobalService.reader.GetString(19);
                            string itemtext = GlobalService.reader.GetString(20);
                            string projecttext = GlobalService.reader.GetString(21);
                            string vendor = GlobalService.reader.GetString(22);
                            string vendorname = GlobalService.reader.GetString(23);
                            string vgroup = GlobalService.reader.GetString(24);
                            string mouldcode = GlobalService.reader.GetString(25);
                            string remarks = GlobalService.reader.GetString(26);
                            string instock50 = GlobalService.reader.GetString(27);
                            string instock = GlobalService.reader.GetString(28);
                            string checkdate = GlobalService.reader.GetString(29);
                            string cav = GlobalService.reader.GetString(30);
                            string weight = GlobalService.reader.GetString(31);
                            string equipment = GlobalService.reader.GetString(32);
                            string shot = GlobalService.reader.GetString(33);
                            string vertical = GlobalService.reader.GetString(34);
                            string horizontal = GlobalService.reader.GetString(35);
                            string height = GlobalService.reader.GetString(36);
                            string instockremarks = GlobalService.reader.GetString(37);
                            string collectdate = GlobalService.reader.GetString(38);
                            string passremarks = GlobalService.reader.GetString(39);
                            string oemasset = GlobalService.reader.GetString(40);
                            string accountcode = GlobalService.reader.GetString(41);
                            string costcentre = GlobalService.reader.GetString(42);
                            string createdby = GlobalService.reader.GetString(43);

                            resulttable.Rows.Add(new object[]{status, chaseNo, itemcode, rev, mouldno, div, type, 
                                pcs, currency, amount, amounthkd, mpa, fa, tmpfa, qty, ringi, model, po, poissued, 
                                category, itemtext, projecttext, vendor, vendorname, vgroup, mouldcode, remarks,
                                instock50, instock, checkdate, cav, weight, equipment, shot, vertical, horizontal,
                                height, instockremarks, collectdate, passremarks, oemasset, accountcode, costcentre,
                                createdby});
                        }
                        GlobalService.reader.Close();
                    }

                    ExportCsvUtil.ExportCsv(resulttable, "", "DLRECORD");
                }
            }
        }
    }
}
