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
using System.Diagnostics;
using Mould_System.functions.file;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterOem : UserControl
    {
        public ucMasterOem()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _query = "select oem_code as oemcode, oem_content as oemcontent, oem_remarks as oemremarks, oem_accountcode as accountcode, oem_costcentre as costcentre from tb_oem";
            string query = "";

            if (cbSearch.SelectedIndex == 0)
                query = _query;

            else if (cbSearch.SelectedIndex == 1)
                query = _query + string.Format(" where oem_code like '%{0}%'", txtSearch.Text);

            else if (cbSearch.SelectedIndex == 2)
                query = _query + string.Format(" where oem_content like '%{0}%'", txtSearch.Text);

            else if (cbSearch.SelectedIndex == 3)
                query = _query + string.Format(" where oem_remarks like '%{0}%'", txtSearch.Text);

            else if (cbSearch.SelectedIndex == 4)
                query = _query + string.Format(" where oem_accountcode like '%{0}%'", txtSearch.Text);

            else
                query = _query + string.Format(" where oem_costcentre like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(query, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvOem.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvOem.Rows.Count;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.loadData();
                this.txtSearch.Enabled = false;
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
            ExportXlsUtil.ExportDatagridview(dgvOem);
        }

        DataTable uploadTable;
        bool validData = true;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                uploadTable = new DataTable();

                string filename = "";

                OpenFileDialog ofd = new OpenFileDialog()
                {
                    Filter = "Excel Files |*.xls"
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filename = ofd.FileName;

                    uploadTable = ImportXlsUtil.TranslateToTable(filename);

                    frmUploadConfirm form = new frmUploadConfirm(uploadTable);
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                    {
                        if (!worker.IsBusy)
                        {
                            this.Cursor = Cursors.WaitCursor;
                            dgvOem.Cursor = Cursors.WaitCursor;
                            worker.RunWorkerAsync();
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

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataRow row in uploadTable.Rows)
                {
                    string code = row.ItemArray[0].ToString();
                    string content = row.ItemArray[1].ToString();
                    string remarks = row.ItemArray[2].ToString();
                    string accountcode = row.ItemArray[3].ToString();
                    string costcentre = row.ItemArray[4].ToString();

                    string query = string.Format("if exists (select * from tb_oem where oem_code = '{0}') update tb_oem set oem_content = '{1}'" +
                        ", oem_remarks = '{2}', oem_accountcode = '{3}', oem_costcentre = '{4}' where oem_code = '{0}' else insert into tb_oem (oem_code, oem_content, oem_remarks, oem_accountcode, oem_costcentre) values ('{0}', '{1}', '{2}', '{3}', '{4}')", code, content, remarks, accountcode, costcentre);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }
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
            dgvOem.Cursor = Cursors.Default;

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
