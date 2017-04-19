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
using Mould_System.file.excel;
using System.Diagnostics;
using CustomUtil.utils.authentication;
using Mould_System.functions.file;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterMouldCode : UserControl
    {
        private DataTable table = null;

        public ucMasterMouldCode()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Mould Code");
            this.cbSearch.Items.Add("Type");
            this.cbSearch.Items.Add("Content");
            this.cbSearch.Items.Add("Item Group");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select mc_mouldcode as mouldcode, mc_type as type, mc_contentjp as contentjp" +
                ", mc_contenteng as contenteng, mc_contentchin as contentchin, mc_itemgroup as itemgroup from tbm_mouldcode";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" where mc_mouldcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" where mc_type like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" where mc_contentjp like '%{0}%' or mc_contenteng like '%{0}%' or mc_contentchin like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" where mc_itemgroup like '%{0}%'", txtSearch.Text);

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            lblTotal.Text = "ROWS COUNT: " + dgvMouldCode.Rows.Count;

            dgvMouldCode.DataSource = table;
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

        DataTable uploadtable;
        bool validData = true;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = "";

                uploadtable = new DataTable();

                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Excel Files |*.xls"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;

                    uploadtable = ImportXlsUtil.TranslateToTable(filename);

                    frmUploadConfirm form = new frmUploadConfirm(uploadtable);
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (!worker.IsBusy)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            dgvMouldCode.Cursor = Cursors.WaitCursor;
                            worker.RunWorkerAsync(uploadtable);
                        }
                        else
                            MessageBox.Show("File is using by other process");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable downloadTable = new DataTable();
            downloadTable.Columns.Add("Mould Code");
            downloadTable.Columns.Add("Type");
            downloadTable.Columns.Add("Content (Jp)");
            downloadTable.Columns.Add("Content (Eng)");
            downloadTable.Columns.Add("Content (Chin)");
            downloadTable.Columns.Add("Item Group");

            string query = "select mc_mouldcode, mc_type, mc_contentjp, mc_contenteng, mc_contentchin, mc_itemgroup from tbm_mouldcode";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string mouldcode = GlobalService.reader.GetString(0);
                string type = GlobalService.reader.GetString(1);
                string contentjp = GlobalService.reader.GetString(2);
                string contenteng = GlobalService.reader.GetString(3);
                string contentchin = GlobalService.reader.GetString(4);
                string itemgroup = GlobalService.reader.GetString(5);

                downloadTable.Rows.Add(new object[] { mouldcode, type, contentjp, contenteng, contentchin, itemgroup });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            ExportXlsUtil.XlsUtil(downloadTable);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataTable worktable = (DataTable)e.Argument;

                foreach (DataRow datarow in worktable.Rows)
                {
                    string mouldcode = datarow[0].ToString().Trim();
                    string type = datarow[1].ToString();
                    string contentjp = datarow[2].ToString();
                    string contenteng = datarow[3].ToString();
                    string contentchin = datarow[4].ToString();
                    string itemgroup = datarow[5].ToString();

                    string commandText = string.Format("if exists (select * from tbm_mouldcode where mc_mouldcode = '{0}') update tbm_mouldcode set mc_type = '{1}'" +
                        ", mc_contentjp = N'{2}', mc_contenteng = N'{3}', mc_contentchin = N'{4}', mc_itemgroup = '{5}' where mc_mouldcode = '{0}' else insert into tbm_mouldcode" +
                        " (mc_mouldcode, mc_type, mc_contentjp, mc_contenteng, mc_contentchin, mc_itemgroup) values ('{0}', '{1}', N'{2}', N'{3}', N'{4}', '{5}')", mouldcode, type, contentjp,
                        contenteng, contentchin, itemgroup);

                    DataService.GetInstance().ExecuteNonQuery(commandText);
                    //string commandText = string.Format("insert into tbm_mouldcode (mc_mouldcode, mc_type, mc_contentjp, mc_contenteng, mc_contentchin, mc_itemgroup" +
                    // " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", mouldcode, type, contentjp, contenteng, contentchin, itemgroup);
                }

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Mould Code", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), "-", "Master Uploaded");

                DataService.GetInstance().ExecuteNonQuery(logText);

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                validData = false;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            dgvMouldCode.Cursor = Cursors.Default;

            if (!validData)
                MessageBox.Show("Invalid Data Format");
            else
            {
                MessageBox.Show("Record has been saved");
                this.loadData();
            }
        }
    }
}
