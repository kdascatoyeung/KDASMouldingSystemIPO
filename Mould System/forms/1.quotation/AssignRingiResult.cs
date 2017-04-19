using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using System.Data.SqlClient;

namespace Mould_System.forms._1.quotation
{
    public partial class AssignRingiResult : Form
    {
        public AssignRingiResult()
        {
            InitializeComponent();

            SearchData("");
        }

        private void dgvResult_DoubleClick(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows == null)
                return;

            GlobalService.SelectedRingiNo = dgvResult.SelectedRows[0].Cells[0].Value.ToString();
            GlobalService.SelectedRingiContent = dgvResult.SelectedRows[0].Cells[1].Value.ToString();
            GlobalService.SelectedRingiBalance = dgvResult.SelectedRows[0].Cells[2].Value.ToString();

            DialogResult = DialogResult.OK;
        }

        private void SearchData(string source)
        {
            DataTable table = new DataTable();
            string query = string.Format("select rg_no as ringi, rg_content as content, rg_balance as balance from tb_ringi where rg_no like '%{0}%'", source);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataService.GetInstance().Connection);
            sda.Fill(table);

            dgvResult.DataSource = table;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData(txtSearch.Text);
        }
    }
}
