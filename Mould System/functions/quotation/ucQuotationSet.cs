using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.checking;
using CustomUtil.utils.authentication;
using System.Diagnostics;

namespace Mould_System.functions.quotation
{
    public partial class ucQuotationSet : UserControl
    {
        public event EventHandler formClose;

        private string mode = "New";

        public ucQuotationSet(string mouldno, string itemcode)
        {
            InitializeComponent();
            
            this.loadMainMould(mouldno, itemcode);

            cbSearch.SelectedIndex = 0;
        }

        private void loadMainMould(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_mouldno, tm_itemcode, tm_vendor_code, tm_mouldcode_code from tb_betamould" +
                " where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_chaseno desc", mouldno, itemcode);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                lblMouldNo.Text = GlobalService.reader.GetString(0);
                lblItemcode.Text = GlobalService.reader.GetString(1);
                lblVendor.Text = GlobalService.reader.GetString(2);
                lblMouldcode.Text = GlobalService.reader.GetString(3);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select distinct t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_mouldcode_code as mouldcode, t.tm_vendor_code as vendor" +
                ", v.v_name as vendorname from tb_betamould as t, tb_vendor as v";

            string _whereText = string.Format(" where t.tm_vendor_code = v.v_code and t.tm_amount = '0'" +
                " and t.tm_mouldno != '{0}' and t.tm_itemcode != '{1}'", lblMouldNo.Text, lblItemcode.Text);

            string commandText = "";

            string whereText = "";

            if (cbSearch.SelectedIndex == 0)
                whereText = _whereText;

            if (cbSearch.SelectedIndex == 1)
                whereText = _whereText + string.Format(" and t.tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                whereText = _whereText + string.Format(" and t.tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                whereText = _whereText + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                whereText = _whereText + string.Format(" and t.tm_mouldcode_code like '%{0}%'", txtSearch.Text);

            commandText = _commandText + whereText;

            Debug.WriteLine("Command Text: " + commandText);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter.Fill(table);

            dgvSource.DataSource = table;

            GlobalService.adapter.Dispose();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSource.SelectedRows)
            {
                string mouldno = row.Cells[0].Value.ToString();
                string mouldnoArrow = row.Cells[0].Value.ToString() + "          \u2192";
                string itemcode = row.Cells[1].Value.ToString();
                string mouldcode = row.Cells[2].Value.ToString();
                string vendor = row.Cells[3].Value.ToString();
                string type = "Set";

                string mouldnoset = lblMouldNo.Text;

                this.dgvResult.Rows.Add(new object[] { mouldnoArrow, mouldnoset, itemcode, vendor, mouldcode, type, "Old", "", "", mouldno });
            }
        }

        private void btnAdd2_Click(object sender, EventArgs e)
        {
            string newItemCode = txtItemCode.Text;
            string newVendor = txtVendor.Text;
            string newRemarks = txtRemarks.Text;
            string newOemAsset = txtOemAsset.Text;

            if (string.IsNullOrEmpty(newItemCode) || string.IsNullOrEmpty(newVendor))
            {
                MessageBox.Show("Part No. or Vendor code cannot be null");
                return;
            }

            if (DataChecking.isItemCodeExists(newItemCode))
            {
                MessageBox.Show("Already contains same SINGLE data with Part No.: " + newItemCode);
                return;
            }

            if (!DataChecking.isValidVendor(newVendor))
            {
                MessageBox.Show("Invalid Vendor Code");
                return;
            }

            string mouldno = lblMouldNo.Text;
            string mouldcode = lblMouldcode.Text;

            this.dgvResult.Rows.Add(new object[] { "-", mouldno, newItemCode, newVendor, mouldcode, "Set", "New", newOemAsset, newRemarks, mouldno });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.dgvResult.Rows.Remove(dgvResult.SelectedRows[0]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                string rowMouldNoSet = row.Cells[1].Value.ToString();
                string rowItemCode = row.Cells[2].Value.ToString();
                string rowVendor = row.Cells[3].Value.ToString();
                string rowMouldCode = row.Cells[4].Value.ToString();
                string rowOemAsset = row.Cells[7].Value.ToString();
                string rowRemarks = row.Cells[8].Value.ToString();
                string rowMouldNo = row.Cells[9].Value.ToString();

                string newOld = row.Cells[6].Value.ToString();

                string currency = DataChecking.getCurrency(rowVendor);

                string query = string.Format("insert into tb_relationset (set_oldmouldno, set_itemcode, set_mouldno) values ('{0}', '{1}', '{2}')", rowMouldNo, rowItemCode, rowMouldNoSet);
                DataService.GetInstance().ExecuteNonQuery(query);

                if (newOld == "New")
                {
                    string projectText = rowItemCode + "-01";
                    string request = rowItemCode + "01";
                    string itemText = rowMouldNoSet + "MP+" + rowMouldCode + "+New";

                    string chaseno = DataChecking.getLastChaseNo();

                    string group = DataChecking.getVendorGroup(rowVendor);

                    string inserttext = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                    ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_group) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}')", chaseno, rowMouldNoSet, rowItemCode, "01", "New", "Set",
                    currency, "0", "0", "False", rowMouldCode, rowVendor, "S", "1", itemText, projectText, request, "KDTHK", "K", DateTime.Today.ToString("yyyy/MM/dd"), "Non-Common", rowOemAsset, rowRemarks, AdUtil.getUsername("kmhk.local"), group);

                    DataService.GetInstance().ExecuteNonQuery(inserttext);
                }
                else
                {
                    string updateText = string.Format("update tb_betamould set tm_mouldno = '{0}', tm_type = 'Set', tm_modify = 'Yes', tm_moulditemviewer = 'Yes' where tm_mouldno = '{1}' and tm_itemcode = '{2}'", rowMouldNoSet, rowMouldNo, rowItemCode);
                    DataService.GetInstance().ExecuteNonQuery(updateText);
                }

                string generalText = string.Format("update tb_betamould set tm_type = 'Set', tm_moulditemviewer = 'Yes' where tm_mouldno = '{0}' and tm_itemcode = '{1}'", lblMouldNo.Text, lblItemcode.Text);
                DataService.GetInstance().ExecuteNonQuery(generalText);
            }

            MessageBox.Show("Record has been saved");

            if (formClose != null)
                formClose(this, new EventArgs());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formClose != null)
                formClose(this, new EventArgs());
        }
    }
}
