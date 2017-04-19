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

namespace Mould_System.functions.quotation
{
    public partial class ucQuotationCommon : UserControl
    {
        public event EventHandler formClose;

        public ucQuotationCommon(string mouldno, string itemcode)
        {
            InitializeComponent();

            this.loadMainMould(mouldno, itemcode);

            cbSearch.SelectedIndex = 0;
        }

        private void loadMainMould(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_mouldno, tm_itemcode, tm_vendor_code, tm_mouldcode_code, tm_oemasset from tb_betamould" +
                " where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_chaseno desc", mouldno, itemcode);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                lblMouldNo.Text = GlobalService.reader.GetString(0);
                lblItemcode.Text = GlobalService.reader.GetString(1);
                lblVendor.Text = GlobalService.reader.GetString(2);
                lblMouldcode.Text = GlobalService.reader.GetString(3);
                string oemasset = GlobalService.reader.GetString(4);

                if (oemasset == "")
                    lblOemAsset.Text = "Unknown";
                else
                    lblOemAsset.Text = oemasset;
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select distinct t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_mouldcode_code as mouldcode, t.tm_vendor_code as vendor" +
                ", v.v_name as vendorname, t.tm_amount as amount, t.tm_rm as remarks from tb_betamould as t, tb_vendor as v";

            string commandText = "";

            string _whereText = string.Format(" where t.tm_vendor_code = v.v_code and t.tm_status = 'New' and t.tm_itemcode != '{0}'", lblItemcode.Text);

            string whereText = "";

            string checkedText = "";

            if (ckbAmount.Checked)
                checkedText = " and t.tm_amount != '0'";
            else
                checkedText = " and t.tm_amount = '0'";

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

            commandText = _commandText + whereText + checkedText;

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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvSource.SelectedRows)
            {
                string mouldno = row.Cells[0].Value.ToString();
                string itemcode = row.Cells[1].Value.ToString();
                string mouldcode = row.Cells[2].Value.ToString();
                string vendor = row.Cells[3].Value.ToString();
                string amount = row.Cells[5].Value.ToString();
                string remarks = row.Cells[6].Value.ToString();

                string mouldnoold= lblMouldNo.Text;

                string mouldArrow = "";

                if(amount=="0")
                    mouldArrow = mouldno + "          \u2192";
                else
                    mouldArrow = mouldno + "          +";

                this.dgvResult.Rows.Add(new object[] { mouldArrow, mouldnoold, itemcode, vendor, mouldcode, "Common", "Old", "-", remarks, mouldno });
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

            this.dgvResult.Rows.Add(new object[] { "-", mouldno, newItemCode, newVendor, mouldcode, "Common", "New", newOemAsset, newRemarks, mouldno });
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.dgvResult.Rows.Remove(dgvResult.SelectedRows[0]);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string mainMouldNo = lblMouldNo.Text;

            string mainItemCode = lblItemcode.Text;

            string mainText = string.Format("if not exists (select * from tb_relationcommon where rc_itemcode = '{1}') begin" +
                " insert into tb_relationcommon (rc_oldmouldno, rc_itemcode, rc_newmouldno) values" +
                " ('{0}', '{1}', '{2}') end", mainMouldNo, mainItemCode, mainMouldNo);
            DataService.GetInstance().ExecuteNonQuery(mainText);

            foreach (DataGridViewRow row in dgvResult.Rows)
            {
                string mouldnocommon = row.Cells[1].Value.ToString();
                string itemcode = row.Cells[2].Value.ToString();
                string vendor = row.Cells[3].Value.ToString();
                string mouldcode = row.Cells[4].Value.ToString();
                string newOld = row.Cells[6].Value.ToString();
                string oemasset = row.Cells[7].Value.ToString();
                string remarks = row.Cells[8].Value.ToString();
                string mouldnoold = row.Cells[9].Value.ToString();

                string query = string.Format("insert into tb_relationcommon (rc_oldmouldno, rc_itemcode, rc_newmouldno) values " +
                    " ('{0}', '{1}', '{2}')", mouldnoold, itemcode, mouldnocommon);
                DataService.GetInstance().ExecuteNonQuery(query);

                string commandText = string.Format("update tb_betamould set tm_common = 'Common', tm_type = 'Common', tm_modify = 'Yes', tm_moulditemviewer = 'Yes' where tm_mouldno = '{0}'", lblMouldNo.Text);
                DataService.GetInstance().ExecuteNonQuery(commandText);

                if (newOld == "New")
                {
                    string projectText = itemcode + "-01";
                    string request = itemcode + "01";
                    string itemText = mouldnoold + "MP+" + mouldcode + "+New";

                    string currency = DataChecking.getCurrency(vendor);

                    string group = DataChecking.getVendorGroup(vendor);

                    string chaseno = DataChecking.getLastChaseNo();

                    string inserttext = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_currency, tm_amount, tm_amounthkd" +
                    ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_group) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}')", chaseno, mouldnocommon, itemcode, "01", "New",
                    currency, "0", "0", "False", mouldcode, vendor, "S", "1", itemText, projectText, request, "KDTHK", "K", DateTime.Today.ToString("yyyy/MM/dd"), "Common", oemasset, remarks, AdUtil.getUsername("kmhk.local"), group);

                    DataService.GetInstance().ExecuteNonQuery(inserttext);
                }
                else
                {
                    string updateText = string.Format("update tb_betamould set tm_common = 'Common', tm_modify = 'Yes', tm_moulditemviewer = 'Yes' where tm_mouldno = '{0}' and tm_itemcode = '{1}'", mouldnoold, itemcode);
                    DataService.GetInstance().ExecuteNonQuery(updateText);
                }
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

        private void ckbAmount_CheckedChanged(object sender, EventArgs e)
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
