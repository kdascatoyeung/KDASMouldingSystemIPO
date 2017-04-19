using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.import;
using Mould_System.services;
using System.Data.SqlClient;
using System.Diagnostics;
using CustomUtil.utils.buffer;
using CustomUtil.utils.export;

namespace Mould_System.forms._3.disposal
{
    public partial class ucDisposalView : UserControl
    {
        public ucDisposalView()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;

            BufferUtil.DoubleBuffered(dgvDisposalDetail, true);

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            txtSearch.Enabled = cbSearch.SelectedIndex == 0 ? false : true;

            btnDelete.Enabled = dgvDisposalDetail.SelectedRows.Count > 0 ? true : false;
        }

        private void SearchData(string source)
        {
            DataTable table = new DataTable();

            string _query = "select dd_id as id, dd_type as disposaltype, dd_status as qstatus, dd_mould as mouldno, dd_partno as itemcode, dd_rev as rev, dd_asset as facode" +
                ", dd_vendor as vendor, dd_vendorname as vendorname, dd_2003no as p2003no, dd_2003answer as p2003ans, dd_2003result as p2003result, dd_2003updated as p2003updated" +
                ", dd_2004no as p2004no, dd_2004answer as p2004ans, dd_2004result as p2004result, dd_2004updated as p2004updated, dd_kdcno as kdcno, dd_kdcissued as kdcissued" +
                ", dd_kdcrps as kdcrps, dd_kdcanswer as kdcseisan, dd_kdcresult as kdcresult, dd_kdcupdated as kdcupdated, dd_assetdesc as assetdesc, dd_capdate as capdate" +
                ", dd_acquishkd as acquis, dd_accumhkd as accum, dd_closing as cmonth, dd_bookhkd as bookhkd, dd_fy as fy, dd_bookhkd2 as bookhkd2, dd_disposalringi as disposalringi" +
                ", dd_reportno as reportno, dd_reportissued as reportissued, dd_reportreceived as reportreceived, dd_vendorresult as vendorresult, dd_fadisposaldate as fadisposal" +
                ", dd_disposalremarks as remarks from tb_disposaldetail";

            string query = cbSearch.SelectedIndex == 0 ? _query
                : cbSearch.SelectedIndex == 1 ? _query + string.Format(" where dd_mould like '%{0}%'", source)
                : cbSearch.SelectedIndex == 2 ? _query + string.Format(" where dd_partno like '%{0}%'", source)
                : cbSearch.SelectedIndex == 3 ? _query + string.Format(" where dd_asset like '%{0}%'", source)
                : cbSearch.SelectedIndex == 4 ? _query + string.Format(" where dd_vendor like '%{0}%'", source)
                : cbSearch.SelectedIndex == 5 ? _query + string.Format(" where dd_vendorname like '%{0}%'", source) : _query + string.Format(" where dd_reportno like '%{0}%'", source);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataService.GetInstance().Connection);
            sda.Fill(table);

            dgvDisposalDetail.DataSource = table;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith("xlsx") ? ImportExcel2007.TranslateToTable(ofd.FileName) : ImportExcel2003.TranslateToTable(ofd.FileName);

                foreach (DataRow row in table.Rows)
                {
                    string type = row.ItemArray[0].ToString().Trim();
                    string mould = row.ItemArray[1].ToString().Trim();
                    string partno = row.ItemArray[2].ToString().Trim();
                    string rev = row.ItemArray[3].ToString().Trim();
                    string asset = row.ItemArray[4].ToString().Trim();
                    string vendor = row.ItemArray[5].ToString().Trim();
                    if (vendor.Length == 9) vendor = "0" + vendor;

                    string vendorname = row.ItemArray[6].ToString().Trim();
                    if (vendorname.Contains("'")) vendorname = vendorname.Replace("'", "''");

                    string p2003no = row.ItemArray[7].ToString().Trim();
                    if (p2003no.Contains("'")) p2003no = p2003no.Replace("'", "''");

                    string p2003ans = row.ItemArray[8].ToString().Trim();
                    
                    try
                    {
                        p2003ans = ImportExcel2007.ParseDateTime(p2003ans).ToString("yyyy/MM/dd");
                        if (p2003ans.StartsWith("00")) p2003ans = row.ItemArray[8].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (p2003ans.Contains("'")) p2003ans = p2003ans.Replace("'", "''");

                    string p2003result = row.ItemArray[9].ToString().Trim();
                    try
                    {
                        p2003result = ImportExcel2007.ParseDateTime(p2003result).ToString("yyyy/MM/dd");
                        if (p2003result.StartsWith("00")) p2003result = row.ItemArray[9].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (p2003result.Contains("'")) p2003result = p2003result.Replace("'", "''");

                    string p2003date = row.ItemArray[10].ToString().Trim();
                    try
                    {
                        p2003date = ImportExcel2007.ParseDateTime(p2003date).ToString("yyyy/MM/dd");
                        if (p2003date.StartsWith("00")) p2003date = row.ItemArray[10].ToString().Trim();
                    }
                    catch
                    {
                        
                    }
                    string p2004no = row.ItemArray[11].ToString().Trim();
                    if (p2004no.Contains("'")) p2004no = p2004no.Replace("'", "''");
                    string p2004ans = row.ItemArray[12].ToString().Trim();
                    try
                    {
                        p2004ans = ImportExcel2007.ParseDateTime(p2004ans).ToString("yyyy/MM/dd");
                        if (p2004ans.StartsWith("00")) p2004ans = row.ItemArray[12].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (p2004ans.Contains("'")) p2004ans = p2004ans.Replace("'", "''");

                    string p2004result = row.ItemArray[13].ToString().Trim();
                    try
                    {
                        p2004result = ImportExcel2007.ParseDateTime(p2004result).ToString("yyyy/MM/dd");
                        if (p2004result.StartsWith("00")) p2004result = row.ItemArray[13].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (p2004result.Contains("'")) p2004result = p2004result.Replace("'", "''");

                    string p2004date = row.ItemArray[14].ToString().Trim();
                    try
                    {
                        p2004date = ImportExcel2007.ParseDateTime(p2004date).ToString("yyyy/MM/dd");
                        if (p2004date.StartsWith("00")) p2004date = row.ItemArray[14].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string kdcno = row.ItemArray[15].ToString().Trim();
                    if (kdcno.Contains("'")) kdcno = kdcno.Replace("'", "''");

                    string kdcdate = row.ItemArray[16].ToString().Trim();
                    try
                    {
                        kdcdate = ImportExcel2007.ParseDateTime(kdcdate).ToString("yyyy/MM/dd");
                        if (kdcdate.StartsWith("00")) kdcdate = row.ItemArray[16].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string kdcrps = row.ItemArray[17].ToString().Trim();
                    try
                    {
                        kdcrps = ImportExcel2007.ParseDateTime(kdcrps).ToString("yyyy/MM/dd");
                        if (kdcrps.StartsWith("00")) kdcrps = row.ItemArray[17].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (kdcrps.Contains("'")) kdcrps = kdcrps.Replace("'", "''");

                    string kdcans = row.ItemArray[18].ToString().Trim();
                    try
                    {
                        kdcans = ImportExcel2007.ParseDateTime(kdcans).ToString("yyyy/MM/dd");
                        if (kdcans.StartsWith("00")) kdcans = row.ItemArray[18].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (kdcans.Contains("'")) kdcans = kdcans.Replace("'", "''");

                    string kdcresult = row.ItemArray[19].ToString().Trim();
                    try
                    {
                        kdcresult = ImportExcel2007.ParseDateTime(kdcresult).ToString("yyyy/MM/dd");
                        if (kdcresult.StartsWith("00")) kdcresult = row.ItemArray[19].ToString().Trim();
                    }
                    catch
                    {

                    }
                    if (kdcresult.Contains("'")) kdcresult.Replace("'", "''");

                    string kdcupdate = row.ItemArray[20].ToString().Trim();
                    try
                    {
                        kdcupdate = ImportExcel2007.ParseDateTime(kdcupdate).ToString("yyyy/MM/dd");
                        if (kdcupdate.StartsWith("00")) kdcupdate = row.ItemArray[20].ToString().Trim();
                    }
                    catch
                    {

                    }

                    string assetdesc = row.ItemArray[21].ToString().Trim();
                    if (assetdesc.Contains("'")) assetdesc = assetdesc.Replace("'", "''");

                    string capdate = row.ItemArray[22].ToString().Trim();
                    try
                    {
                        capdate = ImportExcel2007.ParseDateTime(capdate).ToString("yyyy/MM/dd");
                        if (capdate.StartsWith("00")) capdate = row.ItemArray[22].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string acquis = row.ItemArray[23].ToString().Trim();
                    string accum = row.ItemArray[24].ToString().Trim();
                    string closing = row.ItemArray[25].ToString().Trim();
                    try
                    {
                        closing = ImportExcel2007.ParseDateTime(closing).ToString("yyyy/MM/dd");
                        if (closing.StartsWith("00")) closing = row.ItemArray[25].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string bookval = row.ItemArray[26].ToString().Trim();
                    string year = row.ItemArray[27].ToString().Trim();
                    try
                    {
                        year = ImportExcel2007.ParseDateTime(year).ToString("yyyy/MM/dd");
                        if (year.StartsWith("00")) year = row.ItemArray[27].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string bookval2 = row.ItemArray[28].ToString().Trim();
                    string ringi = row.ItemArray[29].ToString().Trim();
                    string reportno = row.ItemArray[30].ToString().Trim();
                    if(reportno.Contains("''")) reportno = reportno.Replace("'", "''");
                    string reportissued = row.ItemArray[31].ToString().Trim();
                    try
                    {
                        reportissued = ImportExcel2007.ParseDateTime(reportissued).ToString("yyyy/MM/dd");
                        if (reportissued.StartsWith("00")) reportissued = row.ItemArray[31].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string reportdate = row.ItemArray[32].ToString().Trim();
                    try
                    {
                        reportdate = ImportExcel2007.ParseDateTime(reportdate).ToString("yyyy/MM/dd");
                        if (reportdate.StartsWith("00")) reportdate = row.ItemArray[32].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string vendorans = row.ItemArray[33].ToString().Trim();
                    string assetdisposal = row.ItemArray[34].ToString().Trim();
                    try
                    {
                        assetdisposal = ImportExcel2007.ParseDateTime(assetdisposal).ToString("yyyy/MM/dd");
                        if (assetdisposal.StartsWith("00")) assetdisposal = row.ItemArray[34].ToString().Trim();
                    }
                    catch
                    {

                    }
                    string remarks = row.ItemArray[35].ToString().Trim();
                    string status = row.ItemArray[36].ToString().Trim();

                    if (closing.Contains("'")) closing = closing.Replace("'", "''");
                    if (year.Contains("'")) year = year.Replace("'", "''");

                    string query = string.Format("if not exists (select * from tb_disposaldetail where dd_mould = '{2}' and dd_partno = '{3}' and dd_asset = '{5}')" +
                        " insert into tb_disposaldetail (dd_type, dd_status, dd_mould, dd_partno, dd_rev, dd_asset, dd_vendor, dd_vendorname" +
                        ", dd_2003no, dd_2003answer, dd_2003result, dd_2003updated, dd_2004no, dd_2004answer, dd_2004result, dd_2004updated" +
                        ", dd_kdcno, dd_kdcissued, dd_kdcrps, dd_kdcanswer, dd_kdcresult, dd_kdcupdated, dd_assetdesc, dd_capdate, dd_acquishkd" +
                        ", dd_accumhkd, dd_closing, dd_bookhkd, dd_fy, dd_bookhkd2, dd_disposalringi, dd_reportno, dd_reportissued, dd_reportreceived" +
                        ", dd_vendorresult, dd_fadisposaldate, dd_disposalremarks) values (N'{0}', N'{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}'" +
                        ", '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}'" +
                        ", N'{31}', '{32}', '{33}', '{34}', '{35}', N'{36}') else update tb_disposaldetail set dd_type = N'{0}', dd_rev = '{4}', dd_asset = '{5}', dd_vendor = '{6}'"+
                        ", dd_vendorname = N'{7}', dd_2003no = '{8}', dd_2003answer = '{9}', dd_2003result = '{10}', dd_2003updated = '{11}', dd_2004no = '{12}'"+
                        ", dd_2004answer = '{13}', dd_2004result = '{14}', dd_2004updated = '{15}', dd_kdcno = '{16}', dd_kdcissued = '{17}', dd_kdcrps = '{18}'"+
                        ", dd_kdcanswer = '{19}', dd_kdcresult = '{20}', dd_kdcupdated = '{21}', dd_assetdesc = '{22}', dd_capdate = '{23}', dd_acquishkd = '{24}'"+
                        ", dd_accumhkd = '{25}', dd_closing = '{26}', dd_bookhkd = '{27}', dd_fy = '{28}', dd_bookhkd2 = '{29}', dd_disposalringi = '{30}', dd_reportno = N'{31}'"+
                        ", dd_reportissued = '{32}', dd_reportreceived = '{33}', dd_vendorresult = '{34}', dd_fadisposaldate = '{35}', dd_disposalremarks = N'{36}', dd_status = N'{1}' where dd_mould = '{2}' and dd_partno = '{3}'"
                        , type, status, mould, partno, rev, asset, vendor, vendorname, p2003no, p2003ans,
                        p2003result, p2003date, p2004no, p2004ans, p2004result, p2004date, kdcno, kdcdate, kdcrps, kdcans, kdcresult, kdcupdate, assetdesc,
                        capdate, acquis, accum, closing, bookval, year, bookval2, ringi, reportno, reportissued, reportdate, vendorans, assetdisposal, remarks);

                    DataService.GetInstance().ExecuteNonQuery(query);

                    UpdateMouldData(mould, partno, reportno, status);

                }

                SearchData("");

                MessageBox.Show("Record has been uploaded.");
            }
        }

        private void UpdateMouldData(string mould, string partno, string reportno, string status)
        {
            string code = status == "廢棄處理中" ? "W" : status == "廢棄完了" ? "L" : "";

            if (code != "")
            {
                string text = string.Format("update tb_betamould set tm_st_code = '{0}', tm_disposalno = '{1}' where tm_mouldno = '{2}'", code, reportno, mould);
                DataService.GetInstance().ExecuteNonQuery(text);

                List<string> list = new List<string>();

                string query2 = string.Format("select tm_chaseno from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}'", mould, partno);
                using (IDataReader reader = DataService.GetInstance().ExecuteReader(query2))
                {
                    while (reader.Read())
                        list.Add(reader.GetString(0).Trim());
                }

                foreach (string chaseno in list)
                {
                    try
                    {
                        string query3 = string.Format("update TB_FA_APPROVAL set f_remarks = N'{0}' where f_mould = '{1}'", status, chaseno);
                        DataServiceNew.GetInstance().ExecuteNonQuery(query3);
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData(txtSearch.Text.Trim());
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
                SearchData("");
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dgvDisposalDetail.DataSource;

            table.Columns.RemoveAt(0);

            ExportCsvUtil.ExportCsv(table, "", "Disposal Record");
        }

        private void dgvDisposalDetail_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void dgvDisposalDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dgvDisposalDetail.CurrentRow.Cells[0].Value.ToString();

                string data = dgvDisposalDetail.CurrentCell.Value.ToString().Trim();

                int index = dgvDisposalDetail.CurrentCell.ColumnIndex;

                string col = index == 1 ? "dd_type"
                    : index == 2 ? "dd_status"
                    : index == 3 ? "dd_mould"
                    : index == 4 ? "dd_partno"
                    : index == 5 ? "dd_rev"
                    : index == 6 ? "dd_asset"
                    : index == 7 ? "dd_vendor"
                    : index == 8 ? "dd_vendorname"
                    : index == 9 ? "dd_2003no"
                    : index == 10 ? "dd_2003answer"
                    : index == 11 ? "dd_2003result"
                    : index == 12 ? "dd_2003updated"
                    : index == 13 ? "dd_2004no"
                    : index == 14 ? "dd_2004answer"
                    : index == 15 ? "dd_2004result"
                    : index == 16 ? "dd_2004updated"
                    : index == 17 ? "dd_kdcno"
                    : index == 18 ? "dd_kdcissued"
                    : index == 19 ? "dd_kdcrps"
                    : index == 20 ? "dd_kdcanswer"
                    : index == 21 ? "dd_kdcresult"
                    : index == 22 ? "dd_kdcupdated"
                    : index == 23 ? "dd_assetdesc"
                    : index == 24 ? "dd_capdate"
                    : index == 25 ? "dd_acquishkd"
                    : index == 26 ? "dd_accumhkd"
                    : index == 27 ? "dd_closing"
                    : index == 28 ? "dd_bookhkd"
                    : index == 29 ? "dd_fy"
                    : index == 30 ? "dd_bookhkd2"
                    : index == 31 ? "dd_disposalringi"
                    : index == 32 ? "dd_reportno"
                    : index == 33 ? "dd_reportissued"
                    : index == 34 ? "dd_reportreceived"
                    : index == 35 ? "dd_vendorresult"
                    : index == 36 ? "dd_fadisposaldate"
                    : "dd_disposalremarks";

                string query = "update tb_disposaldetail set " + col + string.Format(" = N'{0}' where dd_id = '{1}'", data, id);
                DataService.GetInstance().ExecuteNonQuery(query);

                if (index == 32)
                {
                    if (data != "")
                    {
                        string mould = dgvDisposalDetail.CurrentRow.Cells[3].Value.ToString().Trim();
                        string partno = dgvDisposalDetail.CurrentRow.Cells[4].Value.ToString().Trim();

                        string text = string.Format("update tb_betamould set tm_disposalno = '{0}' where tm_mouldno = '{1}' and tm_itemcode = '{2}'", data, mould, partno);
                        DataService.GetInstance().ExecuteNonQuery(text);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void dgvDisposalDetail_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MessageBox.Show("Are you sure to delete selected records?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        foreach (DataGridViewRow row in dgvDisposalDetail.SelectedRows)
                        {
                            string id = row.Cells[0].Value.ToString();

                            string query = string.Format("delete from tb_disposaldetail where dd_id = '{0}'", id);
                            DataService.GetInstance().ExecuteNonQuery(query);
                        }
                        SearchData(txtSearch.Text.Trim());

                        break;

                    case DialogResult.No:
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtSearch_MouseDown(object sender, MouseEventArgs e)
        {

        }

    }
}
