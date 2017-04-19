using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.functions.others;
using Mould_System.services;
using System.Diagnostics;
using Mould_System.checking;
using Mould_System.file.pdf;
using CustomUtil.utils.authentication;
using Mould_System.file.excel;

namespace Mould_System.functions.ringi
{
    public partial class frmRingiList : Form
    {
        public frmRingiList()
        {
            InitializeComponent();

            this.loadData();

            for (int i = 0; i < dgvRingiItemList.Columns.Count; i++)
                Debug.WriteLine("Ringi Item List: " + i + " : " + dgvRingiItemList.Columns[i].HeaderText);
        }

        private void loadData()
        {
            this.dgvRingiItemList.Rows.Clear();

            string query = "select t.tm_chaseno, t.tm_mouldno, t.tm_itemcode, t.tm_rev, t.tm_currency, t.tm_amount, t.tm_amounthkd, t.tm_itemtext, r.tmp_ringi, t.tm_vendor_code, t.tm_mouldcode_code, t.tm_mpa" +
                " from tb_betamould as t, tb_tempringi as r where r.tmp_chaseno = t.tm_chaseno";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string mouldno = GlobalService.reader.GetString(1);
                string itemcode = GlobalService.reader.GetString(2);
                string rev = GlobalService.reader.GetString(3);
                string currency = GlobalService.reader.GetString(4);
                string amount = GlobalService.reader.GetString(5);
                string amounthkd = GlobalService.reader.GetString(6);
                string itemtext = GlobalService.reader.GetString(7);
                string ringi = GlobalService.reader.GetString(8);
                string vendor = GlobalService.reader.GetString(9);
                string mouldcode = GlobalService.reader.GetString(10);
                string mpa = GlobalService.reader.GetString(11);

                string category = "";

                if (mouldcode == "611" || mouldcode == "612" || mouldcode == "613" || mouldcode == "614")
                    category = "JIGS";

                else if (mpa == "True")
                    category = "50% MPA";

                else
                    category = "MOULD";

                this.dgvRingiItemList.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, currency, amount, amounthkd, itemtext, vendor, ringi, mouldcode, category, "", "False" });
            }

            dgvRingiItemList.Sort(dgvRingiItemList.Columns[0], ListSortDirection.Ascending);
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (dgvRingiItemList.Rows.Count == 0)
                return;

            switch (MessageBox.Show("Are you sure to save information to file? Ringi balance will be updated immediately.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    this.sendToFile();
                    break;

                case System.Windows.Forms.DialogResult.No:
                    break;
            }
        }

        private void 
            sendToFile()
        {
            DataTable pdfTable = new DataTable();
            pdfTable.Columns.Add("Chase No.");
            pdfTable.Columns.Add("Item Text");
            pdfTable.Columns.Add("Item Code");
            pdfTable.Columns.Add("Ringi");
            pdfTable.Columns.Add("Vendor");

            List<int> indexList = new List<int>();

            foreach (DataGridViewRow row in dgvRingiItemList.Rows)
            {
                string isSelected = row.Cells[13].FormattedValue.ToString();

                if (isSelected == "True")
                {
                    string chaseno = row.Cells[0].Value.ToString().Trim();
                    string mouldno = row.Cells[1].Value.ToString();
                    string rev = row.Cells[3].Value.ToString();
                    string currency = row.Cells[4].Value.ToString();
                    string amount = row.Cells[5].Value.ToString();
                    string amounthkd = row.Cells[6].Value.ToString();
                    string itemtext = row.Cells[7].Value.ToString();
                    string itemcode = row.Cells[2].Value.ToString();
                    string ringi = row.Cells[9].Value.ToString();
                    string vendor = row.Cells[8].Value.ToString();
                    string vendorname = DataChecking.getVendorName(vendor);
                    string resultVendor = vendor + " " + vendorname;
                    string remarks = row.Cells[12].Value.ToString();

                    string ringitext = string.Format("update tb_betamould set tm_ringi_code = '{0}', tm_modify = 'Yes', tm_ringiRemarks = '{1}' where tm_chaseno = '{2}'", ringi.Trim(), remarks, chaseno);
                    DataService.GetInstance().ExecuteNonQuery(ringitext);

                    string inserttext = string.Format("insert into tb_ringirelations (rr_chaseno, rr_mouldno, rr_itemcode, rr_rev, rr_ringi) values ('{0}', '{1}', '{2}', '{3}', '{4}')", chaseno, mouldno, itemcode, rev, ringi.Trim());
                    DataService.GetInstance().ExecuteNonQuery(inserttext);

                    string updatetext = string.Format("update tb_ringi set rg_balance = convert(decimal,rg_balance) - convert(decimal,'{0}') where rg_no = '{1}'", amounthkd, ringi.Trim());
                    DataService.GetInstance().ExecuteNonQuery(updatetext);

                    string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", "-", ringi, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), chaseno, "Assign Ringi");
                    DataService.GetInstance().ExecuteNonQuery(logText);

                    string delText = string.Format("delete from tb_tempringi where tmp_chaseno = '{0}'", chaseno);
                    DataService.GetInstance().ExecuteNonQuery(delText);

                    string expenseText = string.Format("update tb_expensetransfer set et_ringino = '{0}' where et_chaseno = '{1}'", ringi.Trim(), chaseno);

                    DataService.GetInstance().ExecuteNonQuery(expenseText);

                    pdfTable.Rows.Add(new object[] { chaseno, itemtext, itemcode, ringi, resultVendor });
                }
                else
                    continue;
            }

            foreach (DataColumn col in pdfTable.Columns)
                Debug.WriteLine("Column: " + col);

            foreach (DataRow row in pdfTable.Rows)
            {
                Debug.WriteLine(row.ItemArray[0].ToString() + row.ItemArray[1].ToString() + row.ItemArray[2].ToString() + row.ItemArray[3].ToString() + row.ItemArray[4].ToString());
            }
            ExportPdfUtil.ExportFixedAssetCode(pdfTable);

            Process.Start("http://km-square.km.local/kmhk-portal/General/BizSys/Lists/Fixed%20Assets%20Acquisition/NewForm.aspx?RootFolder=%2Fkmhk%2Dportal%2FGeneral%2FBizSys%2FLists%2FFixed%20Assets%20Acquisition&ContentTypeId=0x0100779070611ECD5E4AB0AE8AF49C2BA323&Source=http%3A%2F%2Fkm%2Dsquare%2Ekm%2Elocal%2Fkmhk%2Dportal%2FGeneral%2FBizSys%2FLists%2FFixed%2520Assets%2520Acquisition%2FApplication%2Easpx");
            
            this.loadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRingiItemList.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[13];
                chk.TrueValue = true;
                chk.FalseValue = false;
                if (chk.Value == chk.FalseValue)
                    chk.Value = chk.TrueValue;
                else
                    chk.Value = chk.FalseValue;
            }

            dgvRingiItemList.EndEdit();
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            DataTable pdfTable = new DataTable();
            pdfTable.Columns.Add("Chase No.");
            pdfTable.Columns.Add("Item Text");
            pdfTable.Columns.Add("Item Code");
            pdfTable.Columns.Add("Ringi");
            pdfTable.Columns.Add("Vendor");

            pdfTable.Rows.Add(new object[] { "MS-0052955", "K7PA0306BZZ+AH0106MP+615+New", "7PA0306BZZ+AH01", "B01014338", "AU01119016 KYOSHA HONG KONG CO., LTD." });
            pdfTable.Rows.Add(new object[] { "MS-0052957", "K302NG2480001MP+502+Modify", "302NG24800", "H27AMI136131", "AU01107901 KURODA KAGAKU HONG KONG LIMITED" });
            pdfTable.Rows.Add(new object[] { "MS-0052958", "K302NL2501001MP+502+Modify", "302NL25010", "H27AMK136726", "AU01107901 KURODA KAGAKU HONG KONG LIMITED" });
            pdfTable.Rows.Add(new object[] { "MS-0052960", "K303P70202002MP+502+Modify", "303P702021", "H27AMI136131", "AU01120004 RICH ADMIRAL INTL LTD" });
            pdfTable.Rows.Add(new object[] { "MS-0052961", "K302F72540202MP+502+New*", "302F725402", "B01014271", "AU01107019 MEIKO SANGYO CO.,(HK) LTD." });
            /*OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel Files |*.xls";

            DataTable relationTable = new DataTable();

            string filename = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                relationTable = new DataTable();

                relationTable = ImportXlsUtil.TranslateToTable(filename);

                foreach (DataRow row in relationTable.Rows)
                {
                    string chaseno = row[0].ToString();
                    string itemtext = row[1].ToString();
                    string itemcode = row[2].ToString();
                    string ringi = row[3].ToString();
                    string vendor = row[4].ToString();
                    string vendorname = row[5].ToString();

                    if (vendor.Length == 9)
                        vendor = "0" + vendor;

                    string resultVendor = vendor + " " + vendorname;

                    pdfTable.Rows.Add(new object[] { chaseno, itemtext, itemcode, ringi, resultVendor });
                }
            }*/

            ExportPdfUtil.ExportFixedAssetCode(pdfTable);
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel Files |*.xls";

            DataTable relationTable = new DataTable();

            string filename = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                relationTable = new DataTable();

                relationTable = ImportXlsUtil.TranslateToTable(filename);

                foreach (DataRow row in relationTable.Rows)
                {
                    string chaseno = row[0].ToString();
                    string qstatus = row[1].ToString();
                    string remarks = row[2].ToString();
                    string ringi = row[3].ToString();

                    string query = string.Format("update tb_betamould set tm_oemasset = '', tm_accountcode = '', tm_costcentre = '', tm_category = 'A'" +
                       ", tm_st_code = '{0}', tm_rm = '{1}', tm_ringi_code = '{2}' where tm_chaseno = '{3}'", qstatus, remarks, ringi, chaseno);

                    /*string query = string.Format("update tb_betamould set tm_oemasset = '', tm_accountcode = '5005020002', tm_costcentre = '1404000029'" +
                        ", tm_st_code = '{0}', tm_rm = '{1}' where tm_chaseno = '{2}'", qstatus, remarks, chaseno);*/

                    DataService.GetInstance().ExecuteNonQuery(query);
                }
            }
            //MessageBox.Show("Finished");
        }
    }
}
