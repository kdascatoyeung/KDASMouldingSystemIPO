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
using Mould_System.file.excel;
using Mould_System.checking;

namespace Mould_System.forms._3.disposal
{
    public partial class ucDisposal : UserControl
    {
        public ucDisposal()
        {
            InitializeComponent();

            this.cbDisposalStatus.SelectedIndex = 0;
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select dd_type as disposaltype, st.st_status as qstatus, t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_status as div, t.tm_type as type" +
                ", t.tm_amounthkd as amounthkd, t.tm_fixedassetcode as facode, t.tm_vendor_code as vendor, v.v_name as vendorname" +
                ", d.dd_2003no as p2003no, d.dd_2003answer as p2003ans, d.dd_2003result as p2003result" +
                ", d.dd_2003updated as p2003updated, d.dd_2004no as p2004no, d.dd_2004answer as p2004ans, d.dd_2004result as p2004result" +
                ", d.dd_2004updated as p2004updated, d.dd_kdcno as kdcno, d.dd_kdcissued as kdcissued, d.dd_kdcrps as kdcrps, d.dd_kdcseisan as kdcseisan, d.dd_kdcresult as kdcresult" +
                ", d.dd_kdcupdated as kdcupdated, d.dd_assetdesc as assetdesc, d.dd_capdate as capdate, d.dd_acquishkd as acquis" +
                ", d.dd_accumhkd as accum, d.dd_closing as cmonth, d.dd_bookhkd as bookhkd, d.dd_fy as fy, d.dd_bookhkd2 as bookhkd2" +
                ", d.dd_disposalringi as disposalringi, d.dd_reportno as reportno, d.dd_reportissued as reportissued, d.dd_reportreceived as reportreceived" +
                ", d.dd_vendorresult as vendorresult, d.dd_fadisposaldate as fadisposal, d.dd_disposalremarks as remarks from tb_betamould as t, tb_vendor as v" +
                ", tb_disposaldetail as d, tb_betaqstatus as st where t.tm_st_code = st.st_code and t.tm_chaseno = d.dd_chaseno and t.tm_vendor_code = v.v_code";

            string commandText = "";

            if (cbDisposalStatus.SelectedIndex == 0)//廢棄對象
                commandText = _commandText;

            if (cbDisposalStatus.SelectedIndex == 1)//調整依賴中
                commandText = _commandText + " and t.tm_st_code = 'D1'";

            if (cbDisposalStatus.SelectedIndex == 2)//日本生產本部確認中
                commandText = _commandText + " and t.tm_st_code = 'D2'";

            if (cbDisposalStatus.SelectedIndex == 3)//日本生產本部確認完了
                commandText = _commandText + " and t.tm_st_code = 'D3'";

            if (cbDisposalStatus.SelectedIndex == 4)//固定資產申請
                commandText = _commandText + " and t.tm_st_code = 'D4'";

            if (cbDisposalStatus.SelectedIndex == 5)//廢棄稟議書申請
                commandText = _commandText + " and t.tm_st_code = 'D5'";

            if (cbDisposalStatus.SelectedIndex == 6)//廢棄報告書發行濟
                commandText = _commandText + " and t.tm_st_code = 'D6'";

            if (cbDisposalStatus.SelectedIndex == 7)//廢棄報告書回收濟
                commandText = _commandText + " and t.tm_st_code = 'D7'";

            if (cbDisposalStatus.SelectedIndex == 8)//固定資產廢棄申請濟
                commandText = _commandText + " and t.tm_st_code = 'D8'";

            if (cbDisposalStatus.SelectedIndex == 9)
                commandText = _commandText + "and t.tm_st_code = 'D'";

            //GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);

            //GlobalService.adapter.Fill(table);

            //dgvDisposalDetail.DataSource = table;
        }

        private void cbDisposalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable dltable = (DataTable)dgvDisposalDetail.DataSource;

            if (dltable.Rows.Count > 50)
            {
                frmDownloadType downloadtype = new frmDownloadType(dltable);
                downloadtype.ShowDialog();
            }
            else
                ExportXlsUtil.XlsUtil(dltable);
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

                if (!bgworker.IsBusy)
                    bgworker.RunWorkerAsync();
                else
                    MessageBox.Show("Using by other process");
            }
        }

        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable tmptable = new DataTable();

                tmptable = ImportXlsUtil.TranslateToTable(filename);

                int errorcount = 1;

                List<int> indexlist = new List<int>();

                foreach (DataRow row in tmptable.Rows)
                {
                    errorcount += 1;

                    string chaseno = row.ItemArray[2].ToString();

                    Debug.WriteLine("CHASE NO" + chaseno + "ROW: " + errorcount);
                    string status = DataChecking.getStatusByChaseno(chaseno);

                    Debug.WriteLine("STATUS: " + status);

                    string p2003no = row.ItemArray[12].ToString();
                    string p2003ans = row.ItemArray[13].ToString();
                    string p2003result = row.ItemArray[14].ToString();
                    string p2003updated = row.ItemArray[15].ToString();

                    string p2004no = row.ItemArray[16].ToString();
                    string p2004ans = row.ItemArray[17].ToString();
                    string p2004result = row.ItemArray[18].ToString();
                    string p2004updated = row.ItemArray[19].ToString();

                    string kdcno = row.ItemArray[20].ToString();
                    string kdcissued = row.ItemArray[21].ToString();
                    string kdcrps = row.ItemArray[22].ToString();
                    string kdcseisan = row.ItemArray[23].ToString();
                    string kdcresult = row.ItemArray[24].ToString();
                    string kdcupdated = row.ItemArray[25].ToString();

                    string assetdesc = row.ItemArray[26].ToString();
                    string capdate = row.ItemArray[27].ToString();
                    string acquishkd = row.ItemArray[28].ToString();
                    string accumhkd = row.ItemArray[29].ToString();
                    string closingmonth = row.ItemArray[30].ToString();
                    string bookhkd1 = row.ItemArray[31].ToString();
                    string fy = row.ItemArray[32].ToString();
                    string bookhkd2 = row.ItemArray[33].ToString();
                    //string nav = row.ItemArray[33].ToString();

                    string disposalringi = row.ItemArray[34].ToString();
                    string disposalreportno = row.ItemArray[35].ToString();
                    string disposalreportissued = row.ItemArray[36].ToString();
                    string disposalreportrecieved = row.ItemArray[37].ToString();
                    string vendorresult = row.ItemArray[38].ToString();
                    string fadisposal = row.ItemArray[39].ToString();
                    string disposalremarks = row.ItemArray[40].ToString();

                    string query = "";

                    string disposalText = "";

                    if (status == "D1")//待廃棄 - 調整依賴中
                    {
                        if ((p2003result == "OK" || p2003result == "可") && (p2004result == "OK" || p2004result == "可"))
                        {
                            if (check2003IsValid(p2003no, p2003ans, p2003updated) && check2004IsValid(p2004no, p2004ans, p2004updated))
                            {
                                p2003updated = ImportXlsUtil.ParseDateTime(p2003updated).ToString("yyyy/MM/dd");
                                p2004updated = ImportXlsUtil.ParseDateTime(p2004updated).ToString("yyyy/MM/dd");

                                query = string.Format("update tb_betamould set tm_st_code = 'D2' where tm_chaseno = '{0}'", chaseno);

                                disposalText = string.Format("update tb_disposaldetail set dd_2003no = '{0}', dd_2003answer = '{1}', dd_2003result = '{2}'" +
                                    ", dd_2003updated = '{3}', dd_2004no = '{4}', dd_2004answer = '{5}', dd_2004result = '{6}', dd_2004updated = '{7}', dd_disposalremarks = '{8}'  where" +
                                    " dd_chaseno = '{9}'", p2003no, p2003ans, p2003result, p2003updated, p2004no, p2004ans, p2004result, p2004updated, disposalremarks,
                                    chaseno);
                            }
                            else
                                indexlist.Add(errorcount);
                        }

                        if (p2003result == "不可" || p2004result == "不可")
                        {
                            query = RollBackQuery(chaseno);

                            disposalText = DeleteQuery(chaseno);
                        }
                    }

                    else if (status == "D2")//待廃棄 - 日本生産本部確認中
                    {
                        if (kdcresult == "OK" || kdcresult == "可")
                        {
                            if (checkKdcIsValid(kdcno, kdcrps, kdcseisan, kdcupdated))
                            {
                                kdcupdated = ImportXlsUtil.ParseDateTime(kdcupdated).ToString("yyyy/MM/dd");

                                string fac = DataChecking.isFixedAssetExists(chaseno) ? DataChecking.getFixedAssetCode(chaseno) : "";

                                if (fac != "")
                                    query = string.Format("update tb_betamould set tm_st_code = 'D4' where tm_chaseno = '{0}'", chaseno);
                                else
                                    query = string.Format("update tb_betamould set tm_st_code = 'D3' where tm_chaseno = '{0}'", chaseno);

                                /*disposalText = string.Format("update tb_disposaldetail set dd_kdcno = '{0}', dd_kdcrps = '{1}', dd_kdcseisan = '{2}'" +
                                        ", dd_kdcupdated = '{3}', dd_kdcresult = '{4}', dd_kdcissued = '{6}', dd_disposalremarks = '{7}' where dd_chaseno = '{5}'", kdcno, kdcrps, kdcseisan, kdcupdated, kdcresult, chaseno, kdcissued, disposalremarks);*/

                                disposalText = string.Format("update tb_disposaldetail set dd_kdcrps = '{0}', dd_kdcseisan = '{1}'" +
                                        ", dd_kdcupdated = '{2}', dd_kdcresult = '{3}', dd_kdcissued = '{5}', dd_disposalremarks = '{6}' where dd_chaseno = '{4}'", kdcrps, kdcseisan, kdcupdated, kdcresult, chaseno, kdcissued, disposalremarks);
                            }
                            else
                                indexlist.Add(errorcount);
                        }

                        if (kdcresult == "不可")
                        {
                            query = RollBackQuery(chaseno);

                            disposalText = DeleteQuery(chaseno);
                        }
                    }

                    else if (status == "D3")//待廃棄 - 日本生産本部確認完了
                    {
                        disposalreportissued = ImportXlsUtil.ParseDateTime(disposalreportissued).ToString("yyyy/MM/dd");

                        //disposalreportrecieved = ImportXlsUtil.ParseDateTime(disposalreportrecieved).ToString("yyyy/MM/dd");

                        if (checkDisposalReportValid(disposalreportno, disposalreportissued))
                        {
                            query = string.Format("update tb_betamould set tm_st_code = 'D6' where tm_chaseno = '{0}'", chaseno);

                            disposalText = string.Format("update tb_disposaldetail set dd_reportno = '{0}', dd_reportissued = '{1}', dd_disposalremarks = '{3}'" +
                                " where dd_chaseno = '{2}'", disposalreportno, disposalreportissued, chaseno, disposalremarks);
                        }
                        else
                            indexlist.Add(errorcount);
                    }

                    else if (status == "D4")//待廃棄 - 固定資産確認
                    {
                        if (checkFaValid(assetdesc, capdate, acquishkd, accumhkd, closingmonth, bookhkd1, fy, bookhkd2))
                        {
                            capdate = ImportXlsUtil.ParseDateTime(capdate).ToString("yyyy/MM/dd");
                            closingmonth = ImportXlsUtil.ParseDateTime(closingmonth).ToString("yyyy/MM/dd");
                            fy = ImportXlsUtil.ParseDateTime(fy).ToString("yyyy/MM/dd");

                            if (bookhkd1 != "0" && bookhkd1 != "")
                            {
                                query = string.Format("update tb_betamould set tm_st_code = 'D5' where tm_chaseno = '{0}'", chaseno);

                                disposalText = string.Format("update tb_disposaldetail set dd_assetdesc = '{0}', dd_capdate = '{1}', dd_acquishkd = '{2}'" +
                                            ", dd_accumhkd = '{3}', dd_closing = '{4}', dd_bookhkd = '{5}', dd_fy = '{6}', dd_bookhkd2 = '{7}', dd_disposalremarks = '{9}' where dd_chaseno = '{8}'",
                                            assetdesc, capdate, acquishkd, accumhkd, closingmonth, bookhkd1, fy, bookhkd2, chaseno, disposalremarks);
                            }
                            else
                            {
                                if (checkDisposalReportValid(disposalreportno, disposalreportissued))
                                {
                                    disposalreportissued = ImportXlsUtil.ParseDateTime(disposalreportissued).ToString("yyyy/MM/dd");

                                    //disposalreportrecieved = ImportXlsUtil.ParseDateTime(disposalreportrecieved).ToString("yyyy/MM/dd");

                                    query = string.Format("update tb_betamould set tm_st_code = 'D6' where tm_chaseno = '{0}'", chaseno);

                                    disposalText = string.Format("update tb_disposaldetail set dd_reportno = '{0}', dd_reportissued = '{1}', dd_disposalremarks = '{3}'" +
                                        " where dd_chaseno = '{2}'", disposalreportno, disposalreportissued,
                                         chaseno, disposalremarks);
                                }
                                else
                                    indexlist.Add(errorcount);
                            }
                        }
                        else
                            indexlist.Add(errorcount);
                    }

                    else if (status == "D5")//待廃棄 - 廃棄稟議書申請
                    {
                        if (disposalringi != "")
                        {
                            if (checkRingiValid(disposalringi))
                            {
                                //disposalreportrecieved = ImportXlsUtil.ParseDateTime(disposalreportrecieved).ToString("yyyy/MM/dd");

                                //query = string.Format("update tb_betamould set tm_st_code = 'D6' where tm_chaseno = '{0}'", chaseno);

                                disposalText = string.Format("update tb_disposaldetail set dd_disposalringi = '{0}' where dd_chaseno = '{1}'", disposalringi, chaseno);

                                Debug.WriteLine("Disposal Text: " + disposalText);

                                if (checkDisposalReportValid(disposalreportno, disposalreportissued))
                                {
                                    query = string.Format("update tb_betamould set tm_st_code = 'D6' where tm_chaseno = '{0}'", chaseno);

                                    disposalText = string.Format("update tb_disposaldetail set dd_reportno = '{0}', dd_reportissued = '{1}'" +
                                        ", dd_disposalringi = '{2}', dd_disposalremarks = '{4}' where dd_chaseno = '{3}'", disposalreportno, disposalreportissued,
                                         disposalringi, chaseno, disposalremarks);
                                }
                            }
                            else
                                indexlist.Add(errorcount);
                        }
                        else
                        {
                            query = RollBackQuery(chaseno);

                            disposalText = DeleteQuery(chaseno);
                        }
                    }

                    else if (status == "D6")//待廃棄 - 廃棄報告書発行済
                    {
                        if (vendorresult == "OK" || vendorresult == "可")
                        {
                            disposalreportissued = ImportXlsUtil.ParseDateTime(disposalreportissued).ToString("yyyy/MM/dd");

                            disposalreportrecieved = ImportXlsUtil.ParseDateTime(disposalreportrecieved).ToString("yyyy/MM/dd");

                            query = string.Format("update tb_betamould set tm_st_code = 'D7' where tm_chaseno = '{0}'", chaseno);

                            disposalText = string.Format("update tb_disposaldetail set dd_reportreceived = '{0}', dd_vendorresult = '{1}', dd_disposalremarks = '{3}' where dd_chaseno = '{2}'", disposalreportrecieved, vendorresult, chaseno, disposalremarks);
                        }
                        else
                        {
                            query = RollBackQuery(chaseno);

                            disposalText = DeleteQuery(chaseno);
                        }
                    }

                    else if (status == "D7")//待廃棄 - 廃棄報告書回収済
                    {
                        string fac = DataChecking.isFixedAssetExists(chaseno) ? DataChecking.getFixedAssetCode(chaseno) : "";

                        if (fac != "")
                        {
                            if (checkFaDisposalValid(fadisposal))
                            {
                                fadisposal = ImportXlsUtil.ParseDateTime(fadisposal).ToString("yyyy/MM/dd");

                                query = string.Format("update tb_betamould set tm_st_code = 'D8' where tm_chaseno = '{0}'", chaseno);

                                disposalText = string.Format("update tb_disposaldetail set dd_fadisposaldate = '{0}', dd_disposalremarks = '{1}'" +
                                    " where dd_chaseno = '{2}'", fadisposal, disposalremarks, chaseno);
                            }
                            else
                                indexlist.Add(errorcount);
                        }
                    }

                    else if (status == "D8")//待廃棄 - 固定資産廃棄申請済
                    {
                        
                    }

                    else
                    {
                        indexlist.Add(errorcount);
                    }

                    if (query != "")
                        DataService.GetInstance().ExecuteNonQuery(query);

                    if (disposalText != "")
                        DataService.GetInstance().ExecuteNonQuery(disposalText);
                }

                if (indexlist.Count != 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.AppendLine("Following rows contain invalid data");

                    for (int i = 0; i < indexlist.Count; i++)
                    {
                        int rowindex = indexlist[i];

                        builder.Append("Row: " + rowindex).AppendLine();
                    }

                    MessageBox.Show(builder + "");
                }

                else
                    MessageBox.Show("Record has been saved");
                //this.loadData();

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                MessageBox.Show("Invalid data format in upload file");
            }
        }

        private string RollBackQuery(string chaseno)
        {
            string query = string.Format("update tb_betamould set tm_st_code = 'S' where tm_chaseno = '{0}'", chaseno);
    
            return query;
        }

        private string DeleteQuery(string chaseno)
        {
            string query = string.Format("delete from tb_disposaldetail where dd_chaseno = '{0}'", chaseno);

            return query;
        }

        private bool check2003IsValid(string p2003no, string p2003ans, string p2003updated)
        {
            if (!string.IsNullOrEmpty(p2003no) && !string.IsNullOrEmpty(p2003ans) && !string.IsNullOrEmpty(p2003updated))
                return true;

            return false;
        }

        private bool check2004IsValid(string p2004no, string p2004ans, string p2004updated)
        {
            if (!string.IsNullOrEmpty(p2004no) && !string.IsNullOrEmpty(p2004ans) && !string.IsNullOrEmpty(p2004updated))
                return true;

            return false;
        }

        private bool checkKdcIsValid(string kdcno, string kdcrps, string kdcseisan, string kdcupdated)
        {
            if (!string.IsNullOrEmpty(kdcno) && !string.IsNullOrEmpty(kdcrps) && !string.IsNullOrEmpty(kdcseisan) && !string.IsNullOrEmpty(kdcupdated))
                return true;

            return false;
        }

        private bool checkDisposalReportValid(string reportno, string issued)
        {
            if (!string.IsNullOrEmpty(reportno) && !string.IsNullOrEmpty(issued))
                return true;

            return false;
        }

        private bool checkFaValid(string assetdesc, string capdate, string acquishkd, string accumhkd, string closing, string bookhkd,
            string fy, string bookhkd2)
        {
            if (!string.IsNullOrEmpty(assetdesc) && !string.IsNullOrEmpty(capdate) && !string.IsNullOrEmpty(acquishkd)
                && !string.IsNullOrEmpty(accumhkd) && !string.IsNullOrEmpty(closing) && !string.IsNullOrEmpty(fy)
                && !string.IsNullOrEmpty(bookhkd2))
                return true;

            return false;
        }

        private bool checkFaDisposalValid(string disposaldate)
        {
            if (!string.IsNullOrEmpty(disposaldate))
                return true;

            return false;
        }

        private bool checkRingiValid(string disposalringi)
        {
            if (!string.IsNullOrEmpty(disposalringi) && DataChecking.isValidRingi(disposalringi))
                return true;

            return false;
        }
    }
}
