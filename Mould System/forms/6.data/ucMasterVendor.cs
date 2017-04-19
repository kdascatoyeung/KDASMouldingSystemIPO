using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using System.Data.SqlClient;
using Mould_System.file.csv;
using System.Diagnostics;
using Mould_System.file.excel;
using CustomUtil.utils.authentication;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterVendor : UserControl
    {
        private DataTable table = null;

        public ucMasterVendor()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Vendor Code");
            this.cbSearch.Items.Add("Vendor Name");
            this.cbSearch.Items.Add("Group");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select v_code as vendorcode, v_name as vendorname, v_group as pgroup" +
                ", v_paycurr as paycurr, v_payterm as payterms, v_request as request, v_edi as edi, v_remarks as remarks  from tb_vendor";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" where v_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" where v_name like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" where v_group like '%{0}%'", txtSearch.Text);

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvVendor.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvVendor.Rows.Count;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable sourceTable = new DataTable();

            string[] headers = { "Vendor Code", "Vendor Name", "Group", "Detail", "PayCurr", "PayTerms", "Request", "EDI", "Remarks" };

            foreach (string header in headers)
                sourceTable.Columns.Add(header);

            string query = "select v_code, v_name, v_group, v_detail, v_paycurr, v_payterm, v_request, v_edi, v_remarks from tb_vendor";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string vcode = GlobalService.reader.GetString(0);
                string vname = GlobalService.reader.GetString(1);
                string vgroup = GlobalService.reader.GetString(2);
                string vdetail = GlobalService.reader.GetString(3);
                string vpaycurr = GlobalService.reader.GetString(4);
                string vpayterm = GlobalService.reader.GetString(5);
                string vrequest = GlobalService.reader.GetString(6);
                string vedi = GlobalService.reader.GetString(7);
                string vremarks = GlobalService.reader.GetString(8);

                sourceTable.Rows.Add(new object[] { vcode, vname, vgroup, vdetail, vpaycurr, vpayterm, vrequest, vedi, vremarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            ExportCsvUtil.ExportCsv(sourceTable, "", "VENDOR");
        }

        string filename = "";
        
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Excel Files |*.xls"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;

                    try
                    {
                        if (!worker.IsBusy)
                            worker.RunWorkerAsync();
                        else
                            MessageBox.Show("File is using by other process");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid data format");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable vendorTable = new DataTable();

            vendorTable = ImportXlsUtil.TranslateToTable(filename);

            foreach (DataRow row in vendorTable.Rows)
            {
                string vendorcode = row.ItemArray[0].ToString();
                string vendorname = row.ItemArray[1].ToString();
                string pgroup = row.ItemArray[2].ToString();
                string detail = row.ItemArray[3].ToString();
                string paycurr = row.ItemArray[4].ToString();
                string payterm = row.ItemArray[5].ToString();
                string request = row.ItemArray[6].ToString();
                string edi = row.ItemArray[7].ToString();
                string remarks = row.ItemArray[8].ToString();

                if (vendorcode.Length == 9)
                    vendorcode = "0" + vendorcode;

                vendorname = vendorname.Replace("'", "");

                string query = string.Format("if exists (select * from tb_vendor where v_code = '{0}') update tb_vendor set v_name = '{1}', v_group = '{2}'" +
                    ", v_detail = '{3}', v_paycurr = '{4}', v_payterm = '{5}', v_request = '{6}', v_edi = '{7}', v_remarks = '{8}' where v_code = '{0}'" +
                    " else insert into tb_vendor (v_code, v_name, v_group, v_detail, v_paycurr, v_payterm, v_request, v_edi, v_remarks) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", vendorcode, vendorname, pgroup, detail, paycurr, payterm, request, edi, remarks);

                DataService.GetInstance().ExecuteNonQuery(query);
            }

            string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Vendor", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "-", "Master Uploaded");

            DataService.GetInstance().ExecuteNonQuery(logText);

            MessageBox.Show("Data uploaded");
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.loadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("staffid");
            tb.Columns.Add("name");
            tb.Columns.Add("pgroup");

            string query = "select STAFF_ID, NAME_E, PUR_G from R3_O_ORGANIZATION where PUR_G is not null";
            GlobalService.reader = MesService.GetInstance().ExecuteReader(query);
            while (GlobalService.reader.Read())
            {
                string staffid = GlobalService.reader.GetString(0);
                string name = GlobalService.reader.GetString(1);
                string pgroup = GlobalService.reader.GetString(2);

                tb.Rows.Add(new object[] { staffid, name, pgroup });
            }
            GlobalService.reader.Close();

            string deltext = "delete from tb_purchaser";
            DataService.GetInstance().ExecuteNonQuery(deltext);

            foreach (DataRow row in tb.Rows)
            {
                string text = string.Format("insert into tb_purchaser (tm_staffno, tm_name, tm_group)" +
                    " values ('{0}', '{1}', '{2}')", row.ItemArray[0].ToString(), row.ItemArray[1].ToString(),
                    row.ItemArray[2].ToString());

                DataService.GetInstance().ExecuteNonQuery(text);
            }

            MessageBox.Show("Data updated");
        }
    }
}
