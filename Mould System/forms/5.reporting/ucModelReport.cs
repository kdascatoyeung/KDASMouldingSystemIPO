using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using CustomUtil.utils.export;

namespace Mould_System.forms._5.reporting
{
    public partial class ucModelReport : UserControl
    {
        public ucModelReport()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //txtSearch.Enabled = cbSearch.SelectedIndex == 0 ? false : true;
        }

        private void SearchData(string model, string month)
        {
            DataTable table = new DataTable();
            table.Columns.Add("model");
            table.Columns.Add("amount");

            string query = string.Format("select m_model, tm_model, sum(isnull(cast(tm_amounthkd as decimal), 0)) from tb_betamould, tb_model where tm_st_code != 'C' and tm_po != '' and tm_oemasset = ''"+
                " and m_code = tm_model and tm_amounthkd != '' and tm_amounthkd != '-' and m_model like '%{0}%' and tm_poissued like '%{1}%' group by tm_model, m_model", model, month);

            List<ModelList> modelList = new List<ModelList>();

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    modelList.Add(new ModelList { Model = reader.GetString(0).Trim(), ModelCode = reader.GetString(1).Trim(), Amount = reader.GetDecimal(2) });
            }

            var list = from l in modelList
                       group l by new
                       {
                           l.Model,
                       } into gcs
                       select new
                       {
                           Model = gcs.Key.Model,
                           Value = gcs.Sum(x => Convert.ToDouble(x.Amount))
                       };

            foreach (var item in list)
                table.Rows.Add(item.Model, item.Value);

            dgvModelReport.DataSource = table;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
                SearchData(txtModel.Text.Trim(), txtSearch.Text.Trim());
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DataTable table = (DataTable)dgvModelReport.DataSource;

            ExportCsvUtil.ExportCsv(table, "", "Model Report");
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData(txtModel.Text.Trim(), txtSearch.Text.Trim());
        }
    }

    public class ModelList
    {
        public string Model { get; set; }
        public string ModelCode { get; set; }
        public decimal Amount { get; set; }
    }
}
