using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mould_System.services;
using Mould_System.file.excel;
using Mould_System.checking;
using System.Diagnostics;
using Mould_System.functions.file;

namespace Mould_System.forms._1.quotation
{
    public partial class ucFacOnHold : UserControl
    {
        public ucFacOnHold()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Fixed Asset Code");
            this.cbSearch.Items.Add("Chase No.");
            this.cbSearch.Items.Add("Mould No.");
            this.cbSearch.Items.Add("Part No.");
            this.cbSearch.Items.Add("Vendor");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _query = "select t.tm_fixedassetcode as fac, t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_vendor_code as vendor,"+
                " st.st_name as quostatus, t.tm_poissued as issueddate, t.tm_instockdate as instockdate, t.tm_facremarks as facremarks" +
                " from tb_betamould as t, tb_betaqstatus as st where t.tm_fixedassetcode != '' and t.tm_st_code != 'S' and t.tm_st_code != 'T' and t.tm_st_code != 'L' and t.tm_st_code not like 'D%' and t.tm_amount != '0' and t.tm_st_code = st.st_code and t.tm_currency != 'RMB'";

            string query = "";

            if (cbSearch.SelectedIndex == 0)
                query = _query + string.Format(" and t.tm_fixedassetcode like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 1)
                query = _query + string.Format(" and t.tm_chaseno like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 2)
                query = _query + string.Format(" and t.tm_mouldno like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 3)
                query = _query + string.Format(" and t.tm_itemcode like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 4)
                query = _query + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvFacOnHold.DataSource = table;

            dgvFacOnHold.Sort(dgvFacOnHold.Columns[1], ListSortDirection.Ascending);

            lblTotal.Text = "ROWS COUNT: " + dgvFacOnHold.Rows.Count;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 4)
            {
                this.txtSearch.Enabled = true;
                this.loadData();
            }
            else
                this.loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "update tb_betamould set tm_marks = 'No'";
            DataService.GetInstance().ExecuteNonQuery(query);

            foreach (DataGridViewRow row in dgvFacOnHold.Rows)
            {
                string chaseno = row.Cells[1].Value.ToString();
                string remarks = row.Cells[5].Value.ToString();

                string commandText = "";

                commandText = string.Format("update tb_betamould set tm_facremarks = '{0}', tm_marks = case when tm_facremarks = '' then 'No' else 'Yes' end where tm_chaseno = '{1}'", remarks, chaseno);

                DataService.GetInstance().ExecuteNonQuery(commandText);
            }

            MessageBox.Show("Record has been saved");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable tmptable = (DataTable)dgvFacOnHold.DataSource;

            ExportXlsUtil.ExportDatagridview(dgvFacOnHold);
        }

        DataTable onholdtable;
        bool validData = true;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = "";
            
            onholdtable = new DataTable();

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                onholdtable = ImportXlsUtil.TranslateToTable(filename);

                frmUploadConfirm form = new frmUploadConfirm(onholdtable);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    if (!worker.IsBusy)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        dgvFacOnHold.Cursor = Cursors.WaitCursor;
                        worker.RunWorkerAsync();
                    }
                    else
                        MessageBox.Show("File is using by other process");
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataRow datarow in onholdtable.Rows)
                {
                    string chaseno = datarow[1].ToString();
                    string facremarks = datarow[5].ToString();
                    /*string modifiedby = datarow[8].ToString();
                    string modifiedon = datarow[9].ToString();*/

                    /*string query = string.Format("update tb_betamould set tm_facremarks = '{0}', tm_lastmodifiedby = '{1}', tm_lastmodifiedon = '{2}', tm_marks = case when tm_facremarks = '' then 'No' else 'Yes' end" +
                        " where tm_chaseno = '{3}'", facremarks, modifiedby, modifiedon, chaseno);*/

                    string query = string.Format("update tb_betamould set tm_facremarks = '{0}', tm_marks = case when tm_facremarks = '' then 'No' else 'Yes' end" +
                        " where tm_chaseno = '{1}'", facremarks, chaseno);

                    DataService.GetInstance().ExecuteNonQuery(query);
                    Debug.WriteLine(query);

                    string markText = "update tb_betamould set tm_marks = case when tm_facremarks = '' then 'No' else 'Yes' end";
                    DataService.GetInstance().ExecuteNonQuery(markText);
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
            dgvFacOnHold.Cursor = Cursors.Default;

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
