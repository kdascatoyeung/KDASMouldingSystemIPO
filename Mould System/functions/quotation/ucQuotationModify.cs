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
using System.Data.SqlClient;
using System.Diagnostics;
using CustomUtil.utils.authentication;

namespace Mould_System.functions.quotation
{
    public partial class ucQuotationModify : UserControl
    {
        private DataTable table = null;

        public event EventHandler formClose;

        public ucQuotationModify(string chaseno)
        {
            InitializeComponent();

            cbOwner.SelectedIndex = 0;

            try
            {
                lblSingle.BackColor = Color.SteelBlue;
                lblSingle.ForeColor = Color.White;

                this.loadData(chaseno);

                this.loadSingleGrid();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        string gModel = "";

        private void loadData(string chaseno)
        {
            string query = string.Format("select tm_mouldno, tm_itemcode, tm_rev" +
                    ", tm_oemasset, tm_remarks, tm_vendor_code, tm_mouldcode_code, tm_status, tm_type, tm_owner, tm_model from tb_betamould where tm_chaseno = '{0}'", chaseno);

            Debug.WriteLine(query);
            string mouldno = "", itemcode = "", rev = "", oemasset = "", remarks = "", vendor = "", mouldcode = "", status = "", type = "", owner = "";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                mouldno = GlobalService.reader.GetString(0);
                itemcode = GlobalService.reader.GetString(1);
                rev = GlobalService.reader.GetString(2);
                oemasset = GlobalService.reader.GetString(3);
                remarks = GlobalService.reader.GetString(4);
                vendor = GlobalService.reader.GetString(5);
                mouldcode = GlobalService.reader.GetString(6);
                status = GlobalService.reader.GetString(7);
                type = GlobalService.reader.GetString(8);
                owner = GlobalService.reader.GetString(9);
                gModel = GlobalService.reader.GetString(10);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            //if (status == "New" || status == "Modify")
               // txtDiv.Text = "Modify";

            txtDiv.Text = "Modify";
            txtType.Text = type;

            lblChaseno.Text = chaseno.StartsWith("CM") ? DataChecking.GetLastCnChaseNo() : DataChecking.getLastChaseNo();
            txtMouldno.Text = mouldno;
            txtItemcode.Text = itemcode;
            txtOemasset.Text = oemasset;
            txtRemarks.Text = remarks;

            txtVendor.Text = vendor;
            lblVendorname.Text = DataChecking.getVendorName(vendor);
            lblGroup.Text = DataChecking.getVendorGroup(vendor);
            lblPurchaser.Text = DataChecking.getVendorPerson(vendor);
            lblCurrency.Text = DataChecking.getCurrency(vendor);

            cbOwner.SelectedItem = owner;

            try
            {
                cbGroup.Items.Clear();
                string singleGroup = DataChecking.getVendorGroup(vendor);
                string text = string.Format("select v_remarks from tb_vendor where v_code = '{0}'", vendor);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                if (GlobalService.reader.HasRows)
                {
                    while (GlobalService.reader.Read())
                    {
                        remarks = GlobalService.reader.GetString(0);
                    }
                }

                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                if (remarks != "")
                {
                    string[] remark = Split(remarks);
                    foreach (string item in remark)
                        cbGroup.Items.Add(item);
                }
                else
                    cbGroup.Items.Add(singleGroup);

                cbGroup.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }

            txtMouldCode.Text = mouldcode;
            this.loadMouldCode(mouldcode);
        }

        private string[] Split(string str)
        {
            return str.Split(new string[] { " or " }, StringSplitOptions.None);
        }

        private void loadMouldCode(string mouldcode)
        {
            string query = string.Format("select mc_mouldcode, mc_type, mc_contentjp, mc_contenteng, mc_contentchin" +
                " from tbm_mouldcode where mc_mouldcode = '{0}'", mouldcode);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            while (GlobalService.reader.Read())
            {
                lblType.Text = GlobalService.reader.GetString(0);
                string contentJp = GlobalService.reader.GetString(1);
                string contentEng = GlobalService.reader.GetString(2);
                string contentChin = GlobalService.reader.GetString(3);
                lblContent.Text = contentJp + ", " + contentEng + ", " + contentChin;
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadSingleGrid()
        {
            table = new DataTable();

            string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev" +
                " from tb_betamould where tm_itemcode = '{0}' and tm_type = 'Single' and tm_common = 'Non-Common'", txtItemcode.Text);

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvRelationship.DataSource = table;

            GlobalService.adapter.Dispose();
        }

        private void loadSetGrid()
        {
            table = new DataTable();

            string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev" +
                " from tb_betamould where tm_mouldno = '{0}' and tm_type = 'Set'", txtMouldno.Text);

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);

            dgvRelationship.DataSource = table;

            GlobalService.adapter.Dispose();
        }

        private void loadCommonGrid()
        {
            table = new DataTable();
            table.Columns.Add("chaseno");
            table.Columns.Add("mouldno");
            table.Columns.Add("itemcode");
            table.Columns.Add("rev");
            /*string query = string.Format("select t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev as rev" +
                " from tb_betamould as t, tb_relationship as r where (t.tm_itemcode = r.re_main_itemcode or t.tm_itemcode = r.re_sub_itemcode) and" +
                " t.tm_itemcode = '{0}'", txtItemCode.Text);*/

            string query = string.Format("select t.tm_chaseno, r.rc_oldmouldno, r.rc_itemcode, t.tm_rev from tb_betamould as t, tb_relationcommon as r" +
                " where t.tm_itemcode = r.rc_itemcode and t.tm_mouldno = r.rc_oldmouldno and rc_newmouldno = '{0}'", txtMouldno.Text);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string mouldno = GlobalService.reader.GetString(1);
                string itemcode = GlobalService.reader.GetString(2);
                string rev = GlobalService.reader.GetString(3);

                table.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            dgvRelationship.DataSource = table;
        }

        private void labelClick(object sender, EventArgs e)
        {
            foreach (Control control in panelMenu.Controls)
            {
                if (control is Label)
                {
                    control.BackColor = Color.Transparent;
                    control.ForeColor = Color.Black;
                }
            }

            Label label = (Label)sender;
            label.BackColor = Color.SteelBlue;
            label.ForeColor = Color.White;

            string tag = label.Tag.ToString();

            if (tag == "single")
                this.loadSingleGrid();
            if (tag == "set")
                this.loadSetGrid();
            if (tag == "common")
                this.loadCommonGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formClose != null)
                formClose(this, new EventArgs());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sourceChaseNo = lblChaseno.Text;

                string mouldno = txtMouldno.Text;
                string itemcode = txtItemcode.Text;
                string rev = txtRev.Text;
                decimal amount = Convert.ToDecimal(txtAmount.Text);
                string oemasset = txtOemasset.Text;
                string remarks = txtRemarks.Text;
                string pcs = txtPcs.Text;
                string type = txtType.Text;
                //string owner = txtOwner.Text;
                string owner = cbOwner.SelectedItem.ToString();
                string pgroup = cbGroup.SelectedItem.ToString();
                string vendor = txtVendor.Text;

                string mouldcode = txtMouldCode.Text;

                string model = gModel;

                if (rev.Length == 1)
                    rev = "0" + rev;

                string modify = "";

                if (ckbModify.Checked)
                    modify = "True";
                else
                    modify = "False";

                bool mpa;

                if (ckbMpa.Checked)
                    mpa = true;
                else
                    mpa = false;

                if (!DataChecking.isValidVendor(vendor))
                {
                    MessageBox.Show("Invalid vendor code");
                    return;
                }

                if (!DataChecking.isValidMouldCode(mouldcode))
                {
                    MessageBox.Show("Invalid mould code");
                    return;
                }

                string curr = "";

                string year = DateTime.Today.ToString("yyyy");
                string month = DateTime.Today.ToString("MM");
                string jpyrate = DataChecking.getJpyRate(year, month);

                if (lblCurrency.Text.Contains("JPY"))
                    curr = "JPY";
                else
                    curr = DataChecking.getCurrency(vendor);

                decimal calAmount = 0;

                if (lblCurrency.Text.Contains("JPY"))
                    calAmount = Convert.ToDecimal(amount) * Convert.ToDecimal(jpyrate);
                else
                    calAmount = DataChecking.amountWithRate(curr, amount.ToString());

                string itemtext = "";

                if (!mpa)
                    itemtext = mouldno + "MP+" + mouldcode + "+Modify";
                else
                    itemtext = mouldno + "MP+" + mouldcode + "+Modify*";

                string projecttext = itemcode + "-" + rev;
                string request = itemcode + rev;

                decimal tmpAmount = amount / Convert.ToInt32(pcs);

                //string currency = DataChecking.getCurrency(vendor);

                //string common = DataChecking.getCommon(mouldno, itemcode);
                string common = DataChecking.getCommonByMouldNo(mouldno);

                string quantity = "";

                calAmount = calAmount / Convert.ToInt32(pcs);

                string amounthkd = calAmount.ToString("#.##");

                quantity = Convert.ToDecimal(amounthkd) >= 10000 && mpa ? "2" : "1";

                string qstatus = "";
                string category = "A";

                decimal tax = 0;

                string chaseno = sourceChaseNo.StartsWith("CM") ? DataChecking.GetLastCnChaseNo() : DataChecking.getLastChaseNo();

                string accountcode = sourceChaseNo.StartsWith("CM") ? "" : "5005020002";
                string costcentre = sourceChaseNo.StartsWith("CM") ? "" : "1404000029";

                if (sourceChaseNo.StartsWith("CM"))
                {
                    qstatus = "U";

                    amounthkd = "-";

                    double ta = Convert.ToDouble(amount);

                    category = ta >= 5000 ? "A" : "K";

                    tax = Convert.ToDecimal(ta * 0.17);
                }
                else
                {
                    if (calAmount < 10000)
                    {
                        if (calAmount == 0)
                            qstatus = "K";
                        else
                        {
                            qstatus = "U";
                        }

                        category = "K";
                    }
                    else
                    {
                        if (mouldcode.StartsWith("8") && mouldcode != "8")
                        {
                            qstatus = "U";
                            category = "K";
                        }
                        else if (oemasset != "")
                        {
                            qstatus = "U";
                            category = "K";
                        }
                        else
                        {
                            qstatus = "F";
                            accountcode = "";
                            costcentre = "";
                            category = "A";
                        }
                    }
                }

                if (oemasset != "")
                {
                    if (oemasset.Length == 1)
                        oemasset = "0" + oemasset;

                    if (!DataChecking.validOem(oemasset))
                    {
                        MessageBox.Show("Invalid OEM");
                        return;
                    }

                    accountcode = DataChecking.getAccountCode(oemasset);
                    costcentre = DataChecking.getCostCentre(oemasset);
                }

                //string model = itemcode.Substring(2, 3);

                string insertText = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                            ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model, tm_group, tm_accountcode, tm_costcentre, tm_ismodify, tm_pcs) values" +
                            " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', N'{22}', N'{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}')", chaseno, mouldno, itemcode, rev, "Modify", type,
                            curr, amount, amounthkd, mpa, mouldcode, vendor, qstatus, quantity, itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model, pgroup, accountcode, costcentre, modify, pcs);
                DataService.GetInstance().ExecuteNonQuery(insertText);

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                        " values ('{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', '{6}')", "Quotation", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), chaseno, "Modify Item");

                DataService.GetInstance().ExecuteNonQuery(logText);

                MessageBox.Show("Record has been saved");

                if (formClose != null)
                    formClose(this, new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    SendKeys.Send("{TAB}");
                    cbGroup.Items.Clear();
                    string singleGroup = DataChecking.getVendorGroup(txtVendor.Text);
                    string text = string.Format("select v_remarks from tb_vendor where v_code = '{0}'", txtVendor.Text);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                    string remarks = "";

                    if (GlobalService.reader.HasRows)
                    {
                        while (GlobalService.reader.Read())
                        {
                            remarks = GlobalService.reader.GetString(0);
                        }
                    }

                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    if (remarks != "")
                    {
                        string[] remark = Split(remarks);
                        foreach (string item in remark)
                            cbGroup.Items.Add(item);
                    }
                    else
                    {
                        cbGroup.Items.Add(singleGroup);
                    }
                    cbGroup.SelectedIndex = 0;

                    string vendor = txtVendor.Text;
                    lblVendorname.Text = DataChecking.getVendorName(vendor);
                    lblPurchaser.Text = DataChecking.getVendorPerson(vendor);
                    lblCurrency.Text = DataChecking.getCurrency(vendor);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ex.StackTrace);
                }
            }
        }

        private void txtMouldCode_KeyDown(object sender, KeyEventArgs e)
        {
            this.loadMouldCode(txtMouldCode.Text);
        }
    }
}
