using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Mould_System.services;
using Mould_System.checking;
using Mould_System.file.excel;

namespace Mould_System.forms._3.disposal
{
    public partial class frmDisposalList : Form
    {
        public frmDisposalList(List<string> chasenolist)
        {
            InitializeComponent();

            this.cbDisposalType.SelectedIndex = 0;

            this.loadData(chasenolist);
        }

        private void loadData(List<string> chasenolist)
        {
            for (int i = 0; i < chasenolist.Count; i++)
                Debug.WriteLine(chasenolist[i]);

            DataTable table = new DataTable();

            string[] headers = { "qstatus", "chaseno", "mouldno", "common", "itemcode", "rev", "type", "fa", "vendor", "vendorname", "cstatus" };

            table.Columns.Add("selected", typeof(bool));

            List<string> mouldlist = new List<string>();

            foreach (string header in headers)
                table.Columns.Add(header);

            for (int i = 0; i < chasenolist.Count; i++)
            {
                string chaseno = chasenolist[i];

                string query = string.Format("select st.st_status, t.tm_chaseno, t.tm_mouldno, t.tm_itemcode, t.tm_rev" +
                    ", t.tm_type, t.tm_fixedassetcode, t.tm_vendor_code, v.v_name, t.tm_common from tb_betamould as t, tb_betaqstatus as st" +
                    ", tb_vendor as v where t.tm_st_code = st.st_code and t.tm_vendor_code = v.v_code and t.tm_chaseno = '{0}'", chaseno);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string qstatus = GlobalService.reader.GetString(0);
                    string chase = GlobalService.reader.GetString(1);
                    string mouldno = GlobalService.reader.GetString(2);
                    string itemcode = GlobalService.reader.GetString(3);
                    string rev = GlobalService.reader.GetString(4);
                    string type = GlobalService.reader.GetString(5);
                    string fac = GlobalService.reader.GetString(6);
                    string vendor = GlobalService.reader.GetString(7);
                    string vendorname = GlobalService.reader.GetString(8);
                    string common = GlobalService.reader.GetString(9);

                    mouldlist.Add(mouldno);

                    table.Rows.Add(new object[] { false, qstatus, chase, mouldno, "-", itemcode, rev, type, fac, vendor, vendorname, common });
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                foreach (DataRow row in table.Rows)
                {
                    string commonmould = "";
                    string mould = row.ItemArray[3].ToString();

                    string text = string.Format("select sc.sc_mouldno from tb_betamould as t, tb_setcommon as sc where t.tm_mouldno = sc.sc_oldmouldno" +
                        " and (sc.sc_oldmouldno = '{0}' or sc.sc_oldmouldno = '')", mould);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                    if (GlobalService.reader.HasRows)
                    {
                        while (GlobalService.reader.Read())
                        {
                            string sourcemould = GlobalService.reader.GetString(0);

                            commonmould = sourcemould;
                        }
                    }
                    else
                    {
                        //commonmould = "-";
                        commonmould = mould;
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    row[4] = commonmould;
                }
            }

            mouldlist = mouldlist.Distinct().ToList();

            for (int k = 0; k < mouldlist.Count; k++)
            {
                string mouldno = mouldlist[k];

                if (mouldno == "-")
                    continue;

                string commandtext = string.Format("select distinct sc_mouldno, sc_itemcode, sc_type from tb_setcommon where sc_mouldno = '{0}' and sc_oldmouldno = '' group by sc_mouldno, sc_itemcode, sc_type", mouldno);

                Debug.WriteLine("COMMAND: " + commandtext);

                string vendor = "";

                try
                {
                    vendor = DataChecking.getCommonMouldVendorByMould(mouldno);
                }
                catch
                {
                    vendor = DataChecking.getVendorByMould(mouldno);
                }

                string vendorname = DataChecking.getVendorName(vendor);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(commandtext);

                while (GlobalService.reader.Read())
                {
                    string scmouldno = GlobalService.reader.GetString(0);
                    string scitemcode = GlobalService.reader.GetString(1);
                    string sctype = GlobalService.reader.GetString(2);
                    string scdiv = sctype;

                    if (sctype != "Common")
                        sctype = "Non-Common";

                    table.Rows.Add(new object[] { false, "-", "-", "-", scmouldno, scitemcode, "-", scdiv, "-", vendor, vendorname, sctype });

                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }

            dgvDisposal.DataSource = table;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (cbDisposalType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Disposal type first");
                return;
            }

            bool allInstock = true;
            bool allCommonSelected  = true;

            List<string> selectedMouldList = new List<string>();
            List<string> singleChasenoList = new List<string>();
            List<string> commonChasenoList = new List<string>();
            List<string> totalChasenoList = new List<string>();

            foreach (DataGridViewRow row in dgvDisposal.Rows)
            {
                string selected = row.Cells[0].Value.ToString();

                string qstatus = row.Cells[1].Value.ToString();

                string chaseno = row.Cells[2].Value.ToString();

                string mouldno = row.Cells[3].Value.ToString();

                string commonmouldno = row.Cells[4].Value.ToString();

                string div = row.Cells[7].Value.ToString();

                if (selected == "True")
                {
                    if (qstatus != "入庫済" && qstatus != "-")
                        allInstock = false;
                    else
                    {
                        if (div != "Set" && div != "Common")
                            singleChasenoList.Add(chaseno);
                        else
                        {
                            if (chaseno != "-")
                                commonChasenoList.Add(chaseno);
                            selectedMouldList.Add(commonmouldno);
                        }
                    }
                }
                else
                {
                    if (div != "Single")
                        if (selectedMouldList.Contains(row.Cells[4].Value.ToString()))
                            allCommonSelected = false;
                }
            }

            if (!allInstock)
            {
                MessageBox.Show("Must be In-Stock before Disposal");
                return;
            }

            if (!allCommonSelected)
            {
                MessageBox.Show("Some parts of Common Mould are not selected. Please check your selection");
                return;
            }

            //MessageBox.Show("OK");

            switch (MessageBox.Show("Data checking finished. Are you sure to dispose selected items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:

                    //SINGLE
                    singleChasenoList = singleChasenoList.Distinct().ToList();

                    for (int k = 0; k < singleChasenoList.Count; k++)
                    {
                        string selectedChaseno = singleChasenoList[k];

                        string qstatus = "";

                        string singleQuery = "";

                        if (cbDisposalType.SelectedIndex == 2)//日本生產本部提出
                            qstatus = "D3";
                        else
                            qstatus = "D1";

                        singleQuery = string.Format("update tb_betamould set tm_st_code = '{0}' where tm_chaseno = '{1}'", qstatus, selectedChaseno);

                        DataService.GetInstance().ExecuteNonQuery(singleQuery);
                    }

                    //COMMON
                    commonChasenoList = commonChasenoList.Distinct().ToList();

                    for (int i = 0; i < commonChasenoList.Count; i++)
                    {
                        string selectedChaseno = commonChasenoList[i];

                        string qstatus = "";

                        string commonQuery = "";

                        if (cbDisposalType.SelectedIndex == 2)
                            qstatus = "D3";
                        else
                            qstatus = "D1";

                        commonQuery = string.Format("update tb_betamould set tm_st_code = '{0}' where tm_chaseno = '{1}'", qstatus, selectedChaseno);

                        DataService.GetInstance().ExecuteNonQuery(commonQuery);
                    }

                    MessageBox.Show("Record has been saved");

                    totalChasenoList = totalChasenoList.Concat(singleChasenoList).Concat(commonChasenoList).ToList();
                    totalChasenoList = totalChasenoList.Distinct().ToList();

                    DataTable outputtable = new DataTable();

                    string[] headers = {"Disposal Type", "Status", "Chase No.", "Mould No.", "Part No.", "Rev", "Div", "Type", "Amount (HKD)", "FA", "Vendor", "Vendor Name",
                                   "P2003Ctrl No.", "P2003Answers", "P2003Result", "P2003Updated", "P2004Ctrl No.", "P2004Answers",
                                   "P2004Result", "P2004Updated", "KDC Ctrl No.", "KDC Issued", "KDC RPS Answers", "KDC Seisan Answers", "KDC Result",
                                   "KDC Updated", "Asset Description", "Cap.date", "Acquis.val.HKD", "Accum.dep.HKD", "Closing Month",
                                   "Book val.HKD1", "FinancialYear", "Book val.HKD2", "Disposal Ringi", "Disposal Report No.", 
                                   "Disposal Report Issued", "Disposal Report Received", "Vendor Result", "FA Disposal Date", "Disposal Remarks"};

                    foreach (string header in headers)
                        outputtable.Columns.Add(header);

                    string resultStatus = "", resultChaseno = "", resultMouldno = "", resultPartno = "", resultType = "", resultFa = "", resultVendor = "";
                    string resultVendorname = "", resultRemarks = "", resultDiv = "", resultAmountHkd = "", resultRev = "";

                    string resultKdcNo = DataChecking.getKdcReportNo();

                    for (int c = 0; c < totalChasenoList.Count; c++)
                    {
                        string chasenoFromList = totalChasenoList[c];

                        Debug.WriteLine(chasenoFromList);

                        string disposalType = cbDisposalType.SelectedItem.ToString();

                        string query = string.Format("select st.st_status, t.tm_chaseno, t.tm_mouldno, t.tm_itemcode, t.tm_rev, t.tm_status, t.tm_type, t.tm_amounthkd, t.tm_fixedassetcode" +
                            ", t.tm_vendor_code, v.v_name, t.tm_rm from tb_betamould as t, tb_vendor as v, tb_betaqstatus as st where t.tm_vendor_code = v.v_code" +
                            " and t.tm_st_code = st.st_code and t.tm_chaseno = '{0}'", chasenoFromList);

                        Debug.WriteLine("QUERY: " + query);

                        GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                        while (GlobalService.reader.Read())
                        {
                            resultStatus = GlobalService.reader.GetString(0);
                            resultChaseno = GlobalService.reader.GetString(1);
                            resultMouldno = GlobalService.reader.GetString(2);
                            resultPartno = GlobalService.reader.GetString(3);
                            resultRev = GlobalService.reader.GetString(4);
                            resultDiv = GlobalService.reader.GetString(5);
                            resultType = GlobalService.reader.GetString(6);
                            resultAmountHkd = GlobalService.reader.GetString(7);
                            resultFa = GlobalService.reader.GetString(8);
                            resultVendor = GlobalService.reader.GetString(9);
                            resultVendorname = GlobalService.reader.GetString(10);
                            resultRemarks = GlobalService.reader.GetString(11);

                            Debug.WriteLine("RESULT: " + resultStatus + "   " + resultChaseno);

                            outputtable.Rows.Add(new object[]{disposalType, resultStatus, resultChaseno, resultMouldno, resultPartno, resultRev,resultDiv,
                                resultType, resultAmountHkd, resultFa, resultVendor, resultVendorname, "", "", "", "", "", "", "", "", resultKdcNo, "", "", "", "", "", "", "", "", ""
                                , "", "", "", "", "", "", "", "", "", "", ""});
                            /*outputtable.Rows.Add(new object[]{disposalType, resultStatus, resultChaseno, resultMouldno, resultPartno, resultType,
                        resultFa, resultVendor, resultVendorname, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
                        , "", "", "", "", "", "", "", ""});*/
                        }
                        GlobalService.reader.Close();
                        GlobalService.reader.Dispose();

                        string insertText = string.Format("insert into tb_disposaldetail (dd_type, dd_chaseno,dd_kdcno) values ('{0}', '{1}', '{2}')", disposalType, chasenoFromList, resultKdcNo);
                        DataService.GetInstance().ExecuteNonQuery(insertText);
                    }

                    ExportXlsUtil.XlsUtil(outputtable);

                    GlobalService.ChaseNoList.Clear();
                    this.Hide();

                    break;

                case System.Windows.Forms.DialogResult.No:
                    break;
            }
            
        }

        private void ckbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelectAll.Checked)
            {
                foreach (DataGridViewRow row in dgvDisposal.Rows)
                {
                    row.Cells[0].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDisposal.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvDisposal.Rows.Clear();
        }
    }
}
