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
    public partial class ucSystemLog : UserControl
    {
        private DataTable table = null;

        public ucSystemLog()
        {
            InitializeComponent();

            this.setupCombobox();
        }

        private void setupCombobox()
        {
            string[] items = { "All", "Chase No.", "Module", "From Value", "To Value", "User", "Datetime" };

            foreach (string item in items)
                this.cbSearch.Items.Add(item);

            this.cbSearch.SelectedIndex = 0;

            this.cbOperator.Items.Clear();
            this.cbOperator.Items.Add("Equals");
            this.cbOperator.Items.Add("After");
            this.cbOperator.Items.Add("Before");
            this.cbOperator.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select log_datetime as dt, log_module as module, log_chaseno as chaseno, log_fromvalue as fromvalue" +
                ", log_tovalue as tovalue, log_message as msg, log_user as modifiedby from tb_log";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" and log_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" and log_module like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" and log_fromvalue like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" and log_tovalue like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)
                commandText = _commandText + string.Format(" and log_user like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 6)
            {
                if (cbOperator.SelectedIndex == 0)
                    commandText = _commandText + string.Format(" and convert(datetime, log_datetime) = convert(datetime, '{0}')", dpDate.Value);
                if (cbOperator.SelectedIndex == 1)
                    commandText = _commandText + string.Format(" and convert(datetime, log_datetime) > convert(datetime, '{0}')", dpDate.Value);
                if (cbOperator.SelectedIndex == 2)
                    commandText = _commandText + string.Format(" and convert(datetime, log_datetime) < convert(datetime, '{0}')", dpDate.Value);
            }

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvLog.DataSource = table;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
                this.txtSearch.Visible = true;
                this.cbOperator.Enabled = false;
                this.dpDate.Visible = false;
                this.loadData();
            }
            else if (cbSearch.SelectedIndex == 6)
            {
                this.txtSearch.Visible = false;
                this.cbOperator.Enabled = true;
                this.dpDate.Visible = true;
            }
            else
            {
                this.txtSearch.Enabled = true;
                this.txtSearch.Visible = true;
                this.cbOperator.Enabled = false;
                this.dpDate.Visible = false;
            }
        }

        private void cbOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void dpDate_ValueChanged(object sender, EventArgs e)
        {
            this.loadData();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }
    }
}
