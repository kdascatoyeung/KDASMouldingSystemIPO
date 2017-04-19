using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.import;
using Mould_System.services;
using System.Data.SqlClient;
using CustomUtil.utils.export;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterCost : UserControl
    {
        public ucMasterCost()
        {
            InitializeComponent();

            LoadData("");
        }

        private void LoadData(string source)
        {
            DataTable table = new DataTable();

            string[] headers = { "itemcode", "rev", "curr", "cost", "remarks" };
            foreach (string header in headers)
                table.Columns.Add(header);

            string query = string.Format("select c_itemcode as itemcode, c_rev as rev, c_currency as curr, c_cost as cost, c_remarks as remarks from tb_mould_cost where c_itemcode like '%{0}%'", source);
            SqlDataAdapter sda = new SqlDataAdapter(query, DataService.GetInstance().Connection);
            sda.Fill(table);

            dgvVendor.DataSource = table;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dgvVendor.DataSource;

            ExportExcelUtil.SaveAsExcel(table, "COST");
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith(".xls") ? ImportExcel2003.TranslateToTable(ofd.FileName) : ImportExcel2007.TranslateToTable(ofd.FileName);

                string text = "delete from tb_mould_cost dbcc checkident ('tb_mould_cost', reseed, 0)";
                DataService.GetInstance().ExecuteNonQuery(text);

                foreach (DataRow row in table.Rows)
                {
                    string itemcode = row.ItemArray[0].ToString().Trim();
                    string rev = row.ItemArray[1].ToString().Trim();
                    if (rev.Length == 1)
                        rev = "0" + rev;
                    string currency = row.ItemArray[2].ToString().Trim();
                    string cost = Math.Round(Convert.ToDecimal(row.ItemArray[3]), 0).ToString();

                    string remarks = row.ItemArray[4].ToString().Trim();

                    string query = string.Format("insert into tb_mould_cost (c_itemcode, c_rev, c_currency, c_cost, c_remarks) values ('{0}', '{1}', '{2}', '{3}', N'{4}')", itemcode, rev, currency, cost, remarks);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }

                MessageBox.Show("Record has been saved.");
            }

            LoadData("");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtSearch.Text);
        }
    }
}
