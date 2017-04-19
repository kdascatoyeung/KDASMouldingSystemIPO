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
using CustomUtil.utils.export;
using CustomUtil.utils.import;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterModelDetail : UserControl
    {
        public ucMasterModelDetail()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            txtSearch.Enabled = cbSearch.SelectedIndex == 0 ? false : true;
        }

        private void SearchData(string source)
        {
            DataTable table = new DataTable();
            table.Columns.Add("model");
            table.Columns.Add("code");

            string _query = "select m_model as model, m_code as code from tb_model";

            string query = cbSearch.SelectedIndex == 0 ? _query
                : cbSearch.SelectedIndex == 1 ? _query + string.Format(" where m_model like '%{0}%'", source) : _query + string.Format(" where m_code like '%{0}%'", source);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataService.GetInstance().Connection);
            sda.Fill(table);

            dgvMouldDetail.DataSource = table;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
                SearchData("");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData(txtSearch.Text.Trim());
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dgvMouldDetail.DataSource;
            //ExportCsvUtil.ExportCsv(table, "", "Model Detail");
            if (table.Rows.Count > 0)
                ExportExcelUtil.ExportExcel(table);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith("xlsx") ? ImportExcel2007.TranslateToTable(ofd.FileName) : ImportExcel2003.TranslateToTable(ofd.FileName);

                foreach (DataRow row in table.Rows)
                {
                    string model = row.ItemArray[0].ToString().Trim();
                    string code = row.ItemArray[1].ToString().Trim();

                    string query = string.Format("if not exists (select * from tb_model where m_model = '{0}' and m_code = '{1}') insert into tb_model (m_model, m_code) values ('{0}', '{1}')", model, code);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }
                MessageBox.Show("Record has been uploaded.");
            }

            if (cbSearch.SelectedIndex == 0)
                SearchData("");
            else
                SearchData(txtSearch.Text.Trim());
        }

        private void dgvMouldDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                switch (MessageBox.Show("Are you sure to delete " + dgvMouldDetail.SelectedRows.Count + " records?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:

                        foreach (DataGridViewRow row in dgvMouldDetail.SelectedRows)
                        {
                            string model = row.Cells[0].Value.ToString().Trim();
                            string code = row.Cells[1].Value.ToString().Trim();

                            string query = string.Format("delete from tb_model where m_model = '{0}' and m_code = '{1}'", model, code);
                            DataService.GetInstance().ExecuteNonQuery(query);
                        }

                        if (cbSearch.SelectedIndex == 0)
                            SearchData("");
                        else
                            SearchData(txtSearch.Text.Trim());

                        break;

                    case DialogResult.No:
                        break;
                }
                
            }
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
