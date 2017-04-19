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
using Mould_System.checking;

namespace Mould_System.functions.ringi
{
    public partial class ucToRingi : UserControl
    {
        public event EventHandler formClose;

        private DataTable table = null;

        public ucToRingi(List<string> list)
        {
            InitializeComponent();

            this.setupCombobox();

            this.loadList(list);
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Ringi No.");
            this.cbSearch.Items.Add("Content");
            this.cbSearch.Items.Add("Balance");
            //this.cbSearch.Items.Add("Item Code");
            this.cbSearch.SelectedIndex = 1;

            this.cbOperator.Items.Add("Equals to");
            this.cbOperator.Items.Add("Larger than");
            this.cbOperator.Items.Add("Smaller than");
            this.cbOperator.SelectedIndex = 0;
        }

        private void loadList(List<string> list)
        {
            try
            {
                DataTable itemTable = new DataTable();
                itemTable.Columns.Add("chaseno");
                itemTable.Columns.Add("mouldno");
                itemTable.Columns.Add("itemcode");
                itemTable.Columns.Add("rev");
                itemTable.Columns.Add("currency");
                itemTable.Columns.Add("amount");

                for (int i = 0; i < list.Count; i++)
                {
                    string listResult = list[i];

                    string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev, tm_currency as currency" +
                        ", tm_amount as amount from tb_betamould where tm_chaseno = '{0}'", listResult);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
                    while (GlobalService.reader.Read())
                    {
                        string chaseno = GlobalService.reader.GetString(0);
                        string mouldno = GlobalService.reader.GetString(1);
                        string itemcode = GlobalService.reader.GetString(2);
                        string rev = GlobalService.reader.GetString(3);
                        string currency = GlobalService.reader.GetString(4);
                        string amount = GlobalService.reader.GetString(5);

                        itemTable.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, currency, amount });
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();
                }
                dgvSelected.DataSource = itemTable;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "";
            string commandText = "";

            if (ckbSuggested.Checked)
            {

                commandText = string.Format("select r.rg_no as ringi, r.rg_content as content, r.rg_balance as balance" +
                        ", r.rg_expired as expired from tb_ringi as r, tb_ringidetail as rd where" +
                        " r.rg_no = rd.rd_ringino and rd.rd_itemcode = '{0}'", dgvSelected.Rows[0].Cells[2].Value.ToString());
            }
            else
            {
                _commandText = string.Format("select rg_no as ringi, rg_content as content, rg_balance as balance, rg_expired as expired" +
                    " from tb_ringi where convert(datetime, rg_expired) >= convert(datetime, '{0}')", DateTime.Today.AddYears(-2).ToString("yyyy/MM/dd"));

                if (cbSearch.SelectedIndex == 0)
                    commandText = _commandText;

                if (cbSearch.SelectedIndex == 1)
                    commandText = _commandText + string.Format(" and rg_no like '%{0}%'", txtSearch.Text);

                if (cbSearch.SelectedIndex == 2)
                    commandText = _commandText + string.Format(" and rg_content like '%{0}%'", txtSearch.Text);

                if (cbSearch.SelectedIndex == 3)
                {
                    if (cbOperator.SelectedIndex == 0)
                        commandText = _commandText + string.Format(" and convert(decimal, rg_balance) = convert(decimal, '{0}')", txtSearch.Text);
                    if (cbOperator.SelectedIndex == 1)
                        commandText = _commandText + string.Format(" and convert(decimal, rg_balance) > convert(decimal, '{0}')", txtSearch.Text);
                    if (cbOperator.SelectedIndex == 2)
                        commandText = _commandText + string.Format(" and convert(decimal, rg_balance) < convert(decimal, '{0}')", txtSearch.Text);
                }

                /*if (cbSearch.SelectedIndex == 4)
                    commandText = string.Format("select distinct r.rg_no as ringi, r.rg_content as content, r.rg_balance as balance" +
                        ", r.rg_expired as expired from tb_ringi as r, tb_ringirelations as re where convert(datetime, r.rg_expired) >= convert(datetime, '{0}')" +
                        " and r.rg_no = re.rr_ringi and re.rr_itemcode like '%{1}%'", DateTime.Today.AddYears(-2).ToString("yyyy/MM/dd"), txtSearch.Text);*/
            }

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvRingi.DataSource = table;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.cbOperator.Enabled = false;
                this.txtSearch.Enabled = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 3)
            {
                this.txtSearch.Enabled = true;
                this.cbOperator.Enabled = true;
            }
            else if (cbSearch.SelectedIndex == 4)
            {
                this.txtSearch.Enabled = true;
                this.cbOperator.Enabled = false;
                this.loadData();
            }
            else
            {
                this.txtSearch.Enabled = true;
                this.cbOperator.Enabled = false;
            }
        }

        private void cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formClose != null)
                formClose(this, new EventArgs());
        }

        private void dgvRingi_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvRingi.SelectedRows == null)
                    return;
                else
                {
                    this.checkBalance();

                    lblRingi.Text = dgvRingi.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        bool isValid = false;
        private void checkBalance()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvSelected.Rows)
            {
                string rowCurrency = row.Cells[4].Value.ToString();
                string rowAmount = row.Cells[5].Value.ToString();
                decimal amount = DataChecking.amountWithRate(rowCurrency, rowAmount);
                total = total + amount;

            }

            string ringi = lblRingi.Text;

            decimal balance = Convert.ToDecimal(dgvRingi.SelectedRows[0].Cells[2].Value);

            DateTime expiry = Convert.ToDateTime(dgvRingi.SelectedRows[0].Cells[3].Value);

            double result = (expiry - DateTime.Today).TotalDays;

            for (int i = 0; i < GlobalService.ToFacList.Count; i++)
            {
                string listBalance = GlobalService.ToFacList[i].Amount;
                string listRingi = GlobalService.ToFacList[i].Ringi;

                if (listRingi == ringi)
                    balance = balance - Convert.ToDecimal(listBalance);
            }

            lblBalance.Text = total + " / " + balance;
            lblExpiry.Text = expiry.ToString("yyyy/MM/dd");

            if (total > balance || result < 0)
            {
                if (total > balance && result > 0)
                {
                    lblBalance.ForeColor = Color.Red;
                    lblExpiry.ForeColor = Color.Black;
                }
                else if (result < 0 && total < balance)
                {
                    lblBalance.ForeColor = Color.Black;
                    lblExpiry.ForeColor = Color.Red;
                }
                else
                {
                    lblBalance.ForeColor = Color.Red;
                    lblExpiry.ForeColor = Color.Red;
                }
                isValid = false;
            }
            else
            {
                lblBalance.ForeColor = Color.Black;
                lblExpiry.ForeColor = Color.Black;
                isValid = true;
            }

            Debug.WriteLine("Diff: " + result);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(isValid);
            if (!isValid)
            {
                MessageBox.Show("Target ringi does not contain sufficient amount or already expired. Please apply E-Form to Control Management for Ringi Approval");
                return;
            }
            switch (MessageBox.Show("Assign " + dgvSelected.Rows.Count + " mould(s) to Ringi " + dgvRingi.SelectedRows[0].Cells[0].Value.ToString() + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    //this.save();
                    this.addToTempList();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void addToTempList()
        {
            string ringi = lblRingi.Text;

            foreach (DataGridViewRow row in dgvSelected.Rows)
            {
                string chaseno = row.Cells[0].Value.ToString();

                string query = string.Format("if not exists (select * from tb_tempringi where tmp_chaseno = '{1}') insert into tb_tempringi (tmp_ringi, tmp_chaseno) values ('{0}', '{1}')"+
                    " else update tb_tempringi set tmp_ringi = '{0}' where tmp_chaseno = '{1}'", ringi, chaseno);

                DataService.GetInstance().ExecuteNonQuery(query);
            }

            MessageBox.Show("Record added to temporary list");

            if (formClose != null)
                formClose(this, new EventArgs());
        }
    }
}
