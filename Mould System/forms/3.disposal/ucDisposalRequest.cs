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
using Mould_System.checking;
using Mould_System.file.excel;

namespace Mould_System.forms._3.disposal
{
    public partial class ucDisposalRequest : UserControl
    {
        public ucDisposalRequest()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 2;

            dgvDisposal.Visible = false;

            DataChecking.DoubleBuffered(dgvDisposal, true);

        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev as rev" +
                ", t.tm_type as type, t.tm_amounthkd as amounthkd, t.tm_fixedassetcode as fa, t.tm_ringi_code as ringi, t.tm_vendor_code as vendor" +
                ", v.v_name as vendorname from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_st_code = 'S'";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" and t.tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" and t.tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" and t.tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)
                commandText = _commandText + string.Format(" and v.v_name like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvDisposal.DataSource = table;

            GlobalService.adapter.Dispose();

            dgvDisposal.Visible = true;

            foreach (DataGridViewColumn col in dgvDisposal.Columns)
                Debug.WriteLine("DISPOSAL REQUEST: " + col.HeaderText);
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

        private void addToListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvDisposal.SelectedRows == null)
                return;

            bool isValid = true;

            List<string> mouldlist = new List<string>();
            List<string>errlist = new List<string>();

            foreach (DataGridViewRow row in dgvDisposal.SelectedRows)
            {
                string mouldno = row.Cells[1].Value.ToString();

                if (DataChecking.isMouldInStock(mouldno))
                    mouldlist.Add(mouldno);
                else
                {
                    errlist.Add(mouldno);
                    isValid = false;
                }
            }

            /*if (!isValid)
            {
                MessageBox.Show("Some data are not in IN-STOCK status yet. Please check the data before doing the disposal operation");
                return;
            }*/

            for (int i = 0; i < mouldlist.Count; i++)
            {
                string mould = mouldlist[i];

                Debug.WriteLine("SEARCH MOULD: " + mould);

                string query = string.Format("select t.tm_chaseno from tb_betamould as t, tb_setcommon as sc where t.tm_mouldno = sc.sc_oldmouldno" +
                        " and sc.sc_mouldno = '{0}'", mould);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                if (GlobalService.reader.HasRows)
                {
                    while (GlobalService.reader.Read())
                    {
                        string strChaseno = GlobalService.reader.GetString(0);

                        GlobalService.ChaseNoList.Add(strChaseno);
                    }
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                string query1 = string.Format("select tm_chaseno from tb_betamould where tm_mouldno = '{0}'", mould);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query1);

                while (GlobalService.reader.Read())
                {
                    string chase = GlobalService.reader.GetString(0);
                    GlobalService.ChaseNoList.Add(chase);
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }

            GlobalService.ChaseNoList = GlobalService.ChaseNoList.Distinct().ToList();

            MessageBox.Show("Data added to list");
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmDisposalList disposallist = new frmDisposalList(GlobalService.ChaseNoList);
            disposallist.ShowDialog();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            DataTable tmptable = new DataTable();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                tmptable = ImportXlsUtil.TranslateToTable(ofd.FileName);

                if (!worker.IsBusy)
                    worker.RunWorkerAsync(tmptable);
                else
                    MessageBox.Show("Using by other process");
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {

        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable workTable = (DataTable)e.Argument;

            foreach (DataRow row in workTable.Rows)
            {
                string chaseno = row.ItemArray[0].ToString();
                string mouldno = row.ItemArray[1].ToString();

                string p2003no = row.ItemArray[2].ToString();
                string p2003ans = row.ItemArray[3].ToString();
                string p2003result = row.ItemArray[4].ToString();
                string p2003updated = row.ItemArray[5].ToString();

                string p2004no = row.ItemArray[6].ToString();
                string p2004ans = row.ItemArray[7].ToString();
                string p2004result = row.ItemArray[8].ToString();
                string p2004updated = row.ItemArray[9].ToString();

                string kdcno = row.ItemArray[10].ToString();
                string kdcissued = row.ItemArray[11].ToString();
                string kdcrps = row.ItemArray[12].ToString();
                string kdcseisan = row.ItemArray[13].ToString();
                string kdcresult = row.ItemArray[14].ToString();
                string kdcupdated = row.ItemArray[15].ToString();

                string assetdesc = row.ItemArray[16].ToString();
                string capdate = row.ItemArray[17].ToString();
                string acquis = row.ItemArray[18].ToString();
                string accum = row.ItemArray[19].ToString();
                string cmonth = row.ItemArray[20].ToString();
                string bookhkd1 = row.ItemArray[21].ToString();
                string fy = row.ItemArray[22].ToString();
                string bookhkd2 = row.ItemArray[23].ToString();


            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
