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

namespace Mould_System.forms._7.setting
{
    public partial class ucCurrency : UserControl
    {
        private DataTable table = null;

        public ucCurrency()
        {
            InitializeComponent();

            this.loadData();
        }

        private void loadData()
        {
            table = new DataTable();

            string query = "select mp_year as fy, mp_usd as usd, mp_rmb as rmb, mp_jpy as jpy from tb_mprate";

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            DataView view = table.DefaultView;
            view.Sort = "fy desc";
            dgvCurrency.DataSource = view;
        }

        private void dgvCurrency_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCurrency.SelectedRows == null)
                return;
            else
            {
                string fy = dgvCurrency.SelectedRows[0].Cells[0].Value.ToString();
                string usd = dgvCurrency.SelectedRows[0].Cells[1].Value.ToString();
                string rmb = dgvCurrency.SelectedRows[0].Cells[2].Value.ToString();

                txtYear.Text = fy;
                txtUsd.Text = usd;
                txtRmb.Text = rmb;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                MessageBox.Show("Invalid Input");
                return;
            }

            string fy = txtYear.Text;
            string usd = txtUsd.Text;
            string rmb = txtRmb.Text;

            string query = string.Format("if exists (select * from tb_mprate where mp_year = '{0}') update tb_mprate set mp_usd = '{1}'" +
                ", mp_rmb = '{2}', mp_jpy = '{3}' where mp_year = '{0}' else insert into tb_mprate (mp_year, mp_usd, mp_rmb, mp_jpy) values" +
                " ('{0}', '{1}', '{2}', '{3}')", fy, usd, rmb, "1");

            DataService.GetInstance().ExecuteNonQuery(query);

            MessageBox.Show("Record has been saved");
            this.loadData();
        }
    }
}
