using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;

namespace Mould_System.forms._7.setting
{
    public partial class ucJpyMonthly : UserControl
    {
        public ucJpyMonthly()
        {
            InitializeComponent();

            this.loadData();

            cbMonth.SelectedIndex = 0;

        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string query = "select jpy_year as resultYear, jpy_month as resultMonth, jpy_rate as resultRate from tb_monthjpy";
            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(query, DataService.GetInstance().Connection);
            GlobalService.adapter.Fill(table);
            dgvJpy.DataSource = table;

            GlobalService.adapter.Dispose();
        }

        private void dgvJpy_DoubleClick(object sender, EventArgs e)
        {
            if (dgvJpy.SelectedRows == null)
                return;
            else
            {
                string year = dgvJpy.SelectedRows[0].Cells[0].Value.ToString();
                string month = dgvJpy.SelectedRows[0].Cells[1].Value.ToString();
                string rate = dgvJpy.SelectedRows[0].Cells[2].Value.ToString();

                txtYear.Text = year;
                cbMonth.SelectedItem = month;
                txtRate.Text = rate;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbMonth.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a month first");
                return;
            }
            string query = string.Format("if not exists (select * from tb_monthJpy where jpy_year = '{0}' and jpy_month = '{1}')" +
                " insert into tb_monthJpy (jpy_year, jpy_month, jpy_rate) values ('{0}', '{1}', '{2}') else" +
                " update tb_monthJpy set jpy_rate = '{2}' where jpy_year = '{0}' and jpy_month = '{1}'", txtYear.Text, cbMonth.SelectedItem.ToString(), txtRate.Text);

            DataService.GetInstance().ExecuteNonQuery(query);

            MessageBox.Show("Record has been saved");

            this.loadData();
        }
    }
}
