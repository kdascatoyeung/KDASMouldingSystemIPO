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
using System.Diagnostics;

namespace Mould_System.forms._1.quotation
{
    public partial class ucFac : UserControl
    {
        private DataTable table = null;

        public ucFac()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Chase No.");
            this.cbSearch.Items.Add("Mould No.");
            this.cbSearch.Items.Add("Part No.");
            this.cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            dgvFa.Rows.Clear();

            string _commandText = "select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode" +
                ", tm_currency as currency, tm_amount as amount, tm_pdfid as refid from tb_betamould where tm_st_code = 'A'";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" and tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" and tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" and tm_itemcode like '%{0}%'", txtSearch.Text);

            List<FaList> list = new List<FaList>();

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(commandText))
            {
                while (reader.Read())
                {
                    string chaseno = reader.GetString(0);
                    string mouldno = reader.GetString(1);
                    string itemcode = reader.GetString(2);
                    string currency = reader.GetString(3);
                    string amount = reader.GetString(4);
                    string pdfid = reader.GetString(5);

                    list.Add(new FaList { ChaseNo = chaseno, MouldNo = mouldno, PartNo = itemcode, Currency = currency, Amount = amount, RefId = pdfid });
                }
            }

            foreach (FaList item in list)
            {
                try
                {
                    string query = string.Format("select f_status from TB_FA_APPROVAL where f_chaseno = '{0}'", item.ChaseNo);
                    Debug.WriteLine(query);
                    string result = DataServiceNew.GetInstance().ExecuteScalar(query).ToString();

                    string status = result.StartsWith("IPO 1st") ? "採購1st承認中"
                        : result.StartsWith("IPO 2nd") ? "採購2nd承認中"
                        : result.StartsWith("Ringi") ? "稟議審批中"
                        : result.StartsWith("Review") ? "會計查核中"
                        : result.StartsWith("Final") ? "會計審批中"
                        : "會計輸入中";

                    dgvFa.Rows.Add(status, item.ChaseNo, item.MouldNo, item.PartNo, item.Currency, item.Amount, item.RefId);
                }
                catch
                {
                    continue;
                }
            }

            dgvFa.Sort(dgvFa.Columns[1], ListSortDirection.Ascending);

            lblTotal.Text = "ROWS COUNT: " + dgvFa.Rows.Count;

        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 3)
            {
                this.txtSearch.Enabled = true;
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
    }

    public class FaList
    {
        public string ChaseNo { get; set; }
        public string MouldNo { get; set; }
        public string PartNo { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string RefId { get; set; }
    }
}
