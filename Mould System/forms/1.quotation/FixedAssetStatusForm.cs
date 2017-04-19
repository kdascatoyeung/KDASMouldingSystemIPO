using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mould_System.services;
using System.Diagnostics;

namespace Mould_System.forms._1.quotation
{
    public partial class FixedAssetStatusForm : Form
    {
        public FixedAssetStatusForm()
        {
            InitializeComponent();

            LoadData("");
        }

        private void LoadData(string source)
        {
            DataTable table = new DataTable();

            string query = string.Format("select f_status as st, f_apptype as apptype, f_chaseno as chaseno, f_request as request, f_desc as itemtext" +
                ", f_pdfid as pdfid, f_attachment as attachment from TB_FA_APPROVAL where f_status != 'Finished' and (f_pdfid like '%{0}%' or f_desc like '%{0}%') order by f_pdfid", source);
            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceNew.GetInstance().Connection);
            sda.Fill(table);

            dgvFa.DataSource = table;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void dgvFa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string path = dgvFa.CurrentRow.Cells[6].Value.ToString().Trim();
                Process.Start(path);
            }
        }
    }
}
