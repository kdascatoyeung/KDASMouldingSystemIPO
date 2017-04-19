using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.csv;
using Mould_System.checking;
using System.Diagnostics;

namespace Mould_System.forms._5.reporting
{
    public partial class ucPaymentList : UserControl
    {
        public ucPaymentList()
        {
            InitializeComponent();

            //cbSearch.SelectedIndex = 0;

            //cbOption.SelectedIndex = 0;
        }

        private void loadData3()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Vendor", typeof(string));
            table.Columns.Add("VendorName", typeof(string));
            table.Columns.Add("pgroup", typeof(string));
            table.Columns.Add("payterm", typeof(string));
            table.Columns.Add("paycurr", typeof(string));
            table.Columns.Add("amounthkd", typeof(decimal));
            table.Columns.Add("originalamount", typeof(string));

            table.Columns.Add("instockdate50", typeof(string));
            table.Columns.Add("instockdate", typeof(string));

            string _commandText = "select t.tm_vendor_code, v.v_name, t.tm_group, v.v_payterm, v.v_paycurr" +
                ", cast(t.tm_amounthkd as decimal) as amounthkd, t.tm_amounthkd as originalamount, t.tm_instockdate50, t.tm_instockdate" +
                " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code" +
                " and (t.tm_status != 'TM' or t.tm_status != 'TM+Modify') and (t.tm_st_code = 'S' or t.tm_st_code = 'HS')";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" where t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            if(cbSearch.SelectedIndex==2)
            {
                string datetime = dpSearch.Value.ToString("yyyy.MM");
                commandText = _commandText + string.Format(" where t.tm_instockdate50 like '{0}%'", datetime);
            }

            if (cbSearch.SelectedIndex == 3)
            {
                string datetime = dpSearch.Value.ToString("yyyy.MM");
                commandText = _commandText + string.Format(" where t.tm_instockdate like '{0}%'", datetime);
            }

            if (cbSearch.SelectedIndex == 4)
            {
                string datetime = dpSearch.Value.ToString("yyyy.MM");
                commandText = _commandText + string.Format(" and t.tm_paydate like '{0}%'", datetime);
            }

            GlobalService.reader = DataService.GetInstance().ExecuteReader(commandText);

            while (GlobalService.reader.Read())
            {
                string vendor = GlobalService.reader.GetString(0);
                string vendorname = GlobalService.reader.GetString(1);
                string pgroup = GlobalService.reader.GetString(2);
                string payterm = GlobalService.reader.GetString(3);
                string paycurr = GlobalService.reader.GetString(4);
                decimal amounthkd = GlobalService.reader.GetDecimal(5);
                string originalamount = GlobalService.reader.GetString(6);
                string instockdate50 = GlobalService.reader.GetString(7);
                string instockdate = GlobalService.reader.GetString(8);

                table.Rows.Add(new object[] { vendor, vendorname, pgroup, payterm, paycurr, amounthkd, originalamount, instockdate50, instockdate });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            DataTable cloned = table.Clone();

            foreach (DataRow row in table.Rows)
            {
                string rowVendor = row.ItemArray[0].ToString();
                string rowVendorName = row.ItemArray[1].ToString();
                string rowGroup = row.ItemArray[2].ToString();
                string rowPayTerm = row.ItemArray[3].ToString();
                string rowPayCurr = row.ItemArray[4].ToString();
                decimal rowAmountHkd = Convert.ToDecimal(row.ItemArray[5]);
                string rowOriginal = row.ItemArray[6].ToString();
                string rowInStock50 = row.ItemArray[7].ToString();
                string rowInStock = row.ItemArray[8].ToString();

                if (rowInStock50.StartsWith("2") && !rowInStock.StartsWith("2"))
                    rowAmountHkd = rowAmountHkd / 2;
            }
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            /*string _commandText = "select t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_group as incharge, v.v_payterm as payterm, v.v_paycurr as currency"+
                ", case when t.tm_instockdate not like '2%' and t.tm_instockdate50 like '2%' then sum(isnull(cast(t.tm_amounthkd as decimal) / 2, 0)) else sum(isnull(cast(t.tm_amounthkd as decimal), 0)) end as amounthkd from tb_betamould as t, tb_vendor as v"+
                " where t.tm_vendor_code = v.v_code and (t.tm_status != 'TM' or t.tm_status != 'TM+Modify') and t.tm_st_code = 'S'";*/

            string _query = "select t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_group as incharge, v.v_payterm as payterm, v.v_paycurr as currency" +
                ", case when t.tm_st_code = 'HS' and t.tm_instockdate50 like '2%' then sum(isnull(cast(t.tm_amounthkd as decimal) / 2, 0))" +
                " else sum(isnull(cast(t.tm_amounthkd as decimal), 0)) end as amounthkd from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code" +
                " and (t.tm_status != 'TM' or t.tm_status != 'TM+Modify') and (t.tm_st_code = 'S' or t.tm_st_code = 'HS')";

            string query = "";

            string groupText = " group by t.tm_vendor_code, v.v_name, t.tm_group, v.v_payterm, v.v_paycurr, case when t.tm_st_code = 'HS' and t.tm_instockdate50 like '2%' then sum(isnull(cast(t.tm_amounthkd as decimal) / 2, 0))" +
                " else sum(isnull(cast(t.tm_amounthkd as decimal), 0)) end";

            if (cbSearch.SelectedIndex == 0)
                query = _query;

            if (cbSearch.SelectedIndex == 1)//Vendor Code
                query = _query + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)//Instockdate50
                query = _query + string.Format(" and t.tm_instockdate50 like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)//Instockdate
                query = _query + string.Format(" and t.tm_instockdate like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)//Paydate
                query = _query + string.Format(" and t.tm_paydate like '%{0}%'", txtSearch.Text);

            query = query + groupText;

            Debug.WriteLine("Query: " + query);
            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(query, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvPaymentList.DataSource = table;

            lblTotal.Text = "ROW COUNT : " + dgvPaymentList.Rows.Count;
        }

        private void loadData4()
        {
            try
            {
                DataTable table = new DataTable();

                string _query = "select t.tm_chaseno as chaseno, t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_group as incharge, t.tm_mpa as mpa, t.tm_instockdate50 as instock50, t.tm_instockdate as instock, v.v_payterm as payterm, v.v_paycurr as currency, t.tm_st_code as status" +
                    ", case when (t.tm_st_code = 'HS' or t.tm_st_code = 'S') and t.tm_instockdate50 like '2%' then cast(cast(convert(decimal(10, 2), t.tm_amounthkd) / 2 as decimal(10,2)) as nvarchar)  else cast(convert(decimal(10, 2), t.tm_amounthkd) as nvarchar) end as amounthkd" +
                    " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and (t.tm_st_code = 'S' or t.tm_st_code = 'HS') and t.tm_amounthkd != '0'";

                string query = "";

                string today = DateTime.Today.ToString("yyyy/MM/dd");

                DateTime selected = dpSearch.Value;

                string dateSearch = selected.ToString("yyyy/MM");

                if (string.IsNullOrEmpty(txtSearch.Text))
                    query = _query + string.Format(" and t.tm_paydate like '%{0}%'", dateSearch);

                else
                    query = _query + string.Format(" and t.tm_paydate like '%{0}%' and t.tm_vendor_code like '%{1}%'", dateSearch, txtSearch.Text);

                /*if (cbSearch.SelectedIndex == 0)
                    query = _query;

                if (cbSearch.SelectedIndex == 1)//Vendor Code
                    query = _query + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

                if (cbSearch.SelectedIndex == 2)//Instockdate50
                    query = _query + string.Format(" and t.tm_instockdate50 like '%{0}%'", txtSearch.Text);

                if (cbSearch.SelectedIndex == 3)//Instockdate
                    query = _query + string.Format(" and t.tm_instockdate like '%{0}%'", txtSearch.Text);

                if (cbSearch.SelectedIndex == 4)//Paydate
                    query = _query + string.Format(" and t.tm_paydate like '%{0}%'", txtSearch.Text);

                string groupText = " group by t.tm_vendor_code, t.tm_group, v.v_name, v.v_paycurr, v.v_payterm";

                query += groupText;*/

                Debug.WriteLine("Query: " + query);
                GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(query, DataService.GetInstance().Connection);

                GlobalService.adapter.Fill(table);

                dgvPaymentList.DataSource = table;

                lblTotal.Text = "ROW COUNT : " + dgvPaymentList.Rows.Count;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void loadData2()
        {
            List<string> vendorlist = new List<string>();

            DataTable tb = new DataTable();

            string[] headers = { "vendor", "vendorname", "amounthkd", "payterm" };

            foreach (string header in headers)
                tb.Columns.Add(header);

            string query = "select tm_vendor_code from tb_betamould where (tm_status != 'TM' or tm_status != 'TM+Modify') group by tm_vendor_code";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string tmpvendor = GlobalService.reader.GetString(0);
                vendorlist.Add(tmpvendor);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            foreach (string vendor in vendorlist)
            {
                string payterm = DataChecking.getPayTerm(vendor);

                if (payterm == "HK01")
                {

                }

                else if (payterm == "HK02")
                {

                }
            }
        }

        private void dpSearch_ValueChanged(object sender, EventArgs e)
        {
            this.loadData4();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                //txtSearch.Enabled = false;
                //txtSearch.Visible = true;
                //dpSearch.Visible = false;
                //this.loadData4();
            }
            else
            {
                txtSearch.Enabled = true;
                //txtSearch.Visible = true;
                //dpSearch.Visible = false;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable sourceTable = new DataTable();

            string[] headers = { "Chase No.", "Vendor", "Vendor Name", "I/C", "MPA", "In Stock 50%", "In Stock Date", "Pay Terms", "Pay Curr", "PO", "PO Rev", "Issued", "Amount (HKD)" };

            sourceTable = (DataTable)dgvPaymentList.DataSource;

            ExportCsvUtil.ExportCsv(sourceTable, "", "PAYMENT LIST");

            /*if (cbOption.SelectedIndex == 0)
            {
                sourceTable = (DataTable)dgvPaymentList.DataSource;

                ExportCsvUtil.ExportCsv(sourceTable, "", "PAYMENT LIST");
            }

            if (cbOption.SelectedIndex == 1)
            {
                if (dgvPaymentList.Rows.Count == 0)
                    return;

                foreach (string header in headers)
                    sourceTable.Columns.Add(header);

                foreach (DataGridViewRow row in dgvPaymentList.Rows)
                {
                    string vendor = row.Cells[0].Value.ToString();
                    string vendorname = row.Cells[1].Value.ToString();
                    string incharge = row.Cells[2].Value.ToString();
                    string payterms = row.Cells[3].Value.ToString();
                    string paycurr = row.Cells[4].Value.ToString();

                    string query = string.Format("select tm_po, tm_porev, tm_poissued, tm_amounthkd from tb_betamould where tm_vendor_code = '{0}'", vendor);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    while (GlobalService.reader.Read())
                    {
                        string po = GlobalService.reader.GetString(0);
                        string porev = GlobalService.reader.GetString(1);
                        string poissued = GlobalService.reader.GetString(2);
                        string amounthkd = GlobalService.reader.GetString(3);

                        sourceTable.Rows.Add(new object[] { vendor, vendorname, incharge, payterms, paycurr, po, porev, poissued, amounthkd });
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();
                }
                ExportCsvUtil.ExportCsv(sourceTable, "", "PAYMENT LIST WITH PO (ALL)");
            }
            if (cbOption.SelectedIndex == 2)
            {
                if (dgvPaymentList.SelectedRows == null)
                    return;

                foreach (string header in headers)
                    sourceTable.Columns.Add(header);

                foreach (DataGridViewRow row in dgvPaymentList.SelectedRows)
                {
                    string vendor = row.Cells[0].Value.ToString();
                    string vendorname = row.Cells[1].Value.ToString();
                    string incharge = row.Cells[2].Value.ToString();
                    string payterms = row.Cells[3].Value.ToString();
                    string paycurr = row.Cells[4].Value.ToString();


                    string query = string.Format("select tm_po, tm_porev, tm_poissued, tm_amounthkd from tb_betamould where tm_vendor_code = '{0}'", vendor);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    while (GlobalService.reader.Read())
                    {
                        string po = GlobalService.reader.GetString(0);
                        string porev = GlobalService.reader.GetString(1);
                        string poissued = GlobalService.reader.GetString(2);
                        string amounthkd = GlobalService.reader.GetString(3);

                        sourceTable.Rows.Add(new object[] { vendor, vendorname, incharge, payterms, paycurr, po, porev, poissued, amounthkd });
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();
                }
                ExportCsvUtil.ExportCsv(sourceTable, "", "PAYMENT LIST WITH PO");
            }*/
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData4();
        }
    }
}
