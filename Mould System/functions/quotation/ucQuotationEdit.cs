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
    public partial class ucQuotationEdit : UserControl
    {
        private DataTable table = null;

        public event EventHandler formClose;

        private string oMouldno = "", oItemCode = "", oRev = "", oStatus = "", oType = "", oAmount = "";
        private string oMpa = "", oItemText = "", oProjectText = "", oRequest = "", oOemAsset = "", oRemarks = "";
        private string oVendor = "", oMouldCode = "";

        private string globalStatus = "", globalCategory = "";

        bool modifyInStock = false;

        public ucQuotationEdit(int id)
        {
            InitializeComponent();

            this.loadData(id);

            lblSingle.BackColor = Color.SteelBlue;
            lblSingle.ForeColor = Color.White;

            //this.loadSingleGrid();

            this.loadData2(oMouldno);
        }

        private void loadData(int id)
        {
            try
            {
                string currentStatus = "";
                string mouldcurr = "";
                string calFa = "";

                string query = string.Format("select tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_amount, tm_itemtext, tm_mpa" +
                    ", tm_oemasset, tm_rm, tm_fixedassetcode, tm_ringi_code, tm_vendor_code, tm_mouldcode_code, tm_st_code, tm_pcs, tm_model, tm_ismodify, tm_currency, tm_category, tm_vnonly, tm_cnvnonly from tb_betamould where tm_id = '{0}'", id);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    lblChaseno.Text = GlobalService.reader.GetString(0);
                    txtMouldno.Text = GlobalService.reader.GetString(1);
                    oMouldno = txtMouldno.Text;

                    txtItemcode.Text = GlobalService.reader.GetString(2);
                    oItemCode = txtItemcode.Text;

                    txtRev.Text = GlobalService.reader.GetString(3);
                    oRev = txtRev.Text;

                    cbDiv.SelectedItem = GlobalService.reader.GetString(4);
                    oStatus = cbDiv.SelectedItem.ToString();

                    txtAmount.Text = GlobalService.reader.GetString(5);
                    oAmount = txtAmount.Text;

                    txtItemText.Text = GlobalService.reader.GetString(6);
                    oItemText = txtItemText.Text;

                    string mpa = GlobalService.reader.GetString(7);
                    if (mpa == "True")
                        ckbMpa.Checked = true;
                    else
                        ckbMpa.Checked = false;
                    oMpa = mpa;

                    txtOemasset.Text = GlobalService.reader.GetString(8);
                    oOemAsset = txtOemasset.Text;

                    txtRemarks.Text = GlobalService.reader.GetString(9);
                    oRemarks = txtRemarks.Text;

                    string fa = GlobalService.reader.GetString(10);
                    calFa = fa;

                    if (fa == "")
                        lblFa.Text = "N/A";
                    else
                        lblFa.Text = fa;

                    string rin = GlobalService.reader.GetString(11);
                    if (rin == "")
                        lblRingi.Text = "N/A";
                    else
                        lblRingi.Text = rin;

                    txtVendor.Text = GlobalService.reader.GetString(12);
                    oVendor = txtVendor.Text;

                    txtMouldCode.Text = GlobalService.reader.GetString(13);
                    oMouldCode = txtMouldCode.Text;

                    currentStatus = GlobalService.reader.GetString(14);

                    txtPcs.Text = GlobalService.reader.GetString(15);

                    txtModel.Text = GlobalService.reader.GetString(16);

                    string ismodify = GlobalService.reader.GetString(17);

                    mouldcurr = GlobalService.reader.GetString(18);

                    globalCategory = GlobalService.reader.GetString(19);

                    string vnonly = GlobalService.reader.GetString(20);

                    string cnvnonly = GlobalService.reader.GetString(21);

                    if (vnonly == "True")
                        cbProductionBase.SelectedIndex = 2;
                    else if (cnvnonly == "True")
                        cbProductionBase.SelectedIndex = 1;
                    else
                        cbProductionBase.SelectedIndex = 0;

                    if (ismodify == "True")
                        ckbModify.Checked = true;
                    else
                        ckbModify.Checked = false;
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                Debug.WriteLine(currentStatus);

                modifyInStock = false;

                globalStatus = currentStatus;

                if (currentStatus == "Q" || currentStatus == "U" || currentStatus == "F" || currentStatus == "T")
                {
                    this.btnSave.Enabled = true;
                    pbEdit.Image = Properties.Resources.tick_icon;
                }
                else if (currentStatus == "P" || currentStatus == "D")
                {
                    if (calFa == "")
                    {
                        this.btnSave.Enabled = true;
                        pbEdit.Image = Properties.Resources.tick_icon;
                    }
                    else
                    {
                        this.btnSave.Enabled = false;
                        pbEdit.Image = Properties.Resources.cross_icon;
                    }
                }
                else if (currentStatus == "K")
                {
                    foreach (Control control in groupBox1.Controls)
                        control.Enabled = false;

                    modifyInStock = true;

                    txtRemarks.Enabled = true;
                    txtModel.Enabled = true;
                    ckbModify.Enabled = true;
                    cbGroup.Enabled = true;

                    lblOem.Enabled = true;
                    txtOemasset.Enabled = true;

                    lblIsModify.Enabled = true;
                    lblModel.Enabled = true;
                    lblVendorGroup.Enabled = true;
                    lblRemarks.Enabled = true;

                    lblVnOnly.Enabled = true;
                    ckbVn.Enabled = true;
                    cbProductionBase.Enabled = true;

                    this.btnSave.Enabled = true;
                    pbEdit.Image = Properties.Resources.tick_icon;
                }
                else if (currentStatus == "S")
                {
                    foreach (Control control in groupBox1.Controls)
                        control.Enabled = false;

                    modifyInStock = true;

                    txtRemarks.Enabled = true;
                    ckbModify.Enabled = true;
                    txtModel.Enabled = true;
                    cbGroup.Enabled = true;

                    lblOem.Enabled = true;
                    txtOemasset.Enabled = true;

                    lblIsModify.Enabled = true;
                    lblModel.Enabled = true;
                    lblVendorGroup.Enabled = true;
                    lblRemarks.Enabled = true;

                    lblVnOnly.Enabled = true;
                    ckbVn.Enabled = true;
                    cbProductionBase.Enabled = true;

                    this.btnSave.Enabled = true;
                    pbEdit.Image = Properties.Resources.tick_icon;
                }
                else
                {
                    this.btnSave.Enabled = false;
                    pbEdit.Image = Properties.Resources.cross_icon;
                }

                lblStatus.Text = DataChecking.getCurrentStatus(currentStatus);

                lblVendorname.Text = DataChecking.getVendorName(txtVendor.Text);
                lblGroup.Text = DataChecking.getVendorGroup(txtVendor.Text);
                lblPurchaser.Text = DataChecking.getVendorPerson(txtVendor.Text);
                lblCurrency.Text = DataChecking.getCurrency(txtVendor.Text);

                if (mouldcurr == "JPY")
                    lblCurrency.Text = lblCurrency.Text + "(Transfer Curr: JPY)";

                this.loadMouldCode(txtMouldCode.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formClose != null)
                formClose(this, new EventArgs());
        }

        private void loadSingleGrid()
        {
            table = new DataTable();

            string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev" +
                " from tb_betamould where tm_itemcode = '{0}' and tm_type = 'Single'", txtItemcode.Text);

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
                " from tb_betamould, tb_setcommon where tm_mouldno = '{0}' and tm_type = 'Set'", txtMouldno.Text, lblChaseno.Text);

            Debug.WriteLine(query);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string _chaseno = lblChaseno.Text.Trim();

            if (_chaseno.StartsWith("CM"))
            {
                string mouldno = txtMouldno.Text.Trim();
                string partno = txtItemcode.Text.Trim();
                string rev = txtRev.Text.Trim();
                string div = cbDiv.SelectedItem.ToString();
                string model = txtModel.Text.Trim();
                string amount = txtAmount.Text.Trim();
                string itemtext = txtItemText.Text.Trim();
                string mpa = ckbMpa.Checked ? "True" : "False";
                string remarks = txtRemarks.Text.Trim();
                string pcs = txtPcs.Text.Trim();
                string vendor = txtVendor.Text.Trim();
                string group = cbGroup.SelectedItem.ToString();
                string mouldcode = txtMouldCode.Text.Trim();
                string quantity = mpa=="True"?"2":"1";
                double camount = Convert.ToDouble(amount);
                string category = camount >= 5000 ? "A" : "K";

                string query = string.Format("update tb_betamould set tm_mouldno = '{0}', tm_itemcode = '{1}', tm_rev = '{2}', tm_status = '{3}', tm_model = '{4}', tm_amount = '{5}'" +
                    ", tm_itemtext = '{6}', tm_mpa = '{7}', tm_rm = N'{8}', tm_pcs = '{9}', tm_vendor_code = '{10}', tm_group = '{11}', tm_mouldcode_code = '{12}', tm_qty = '{13}', tm_category = '{14}'" +
                    " where tm_chaseno = '{15}'", mouldno, partno, rev, div, model, amount, itemtext, mpa, remarks, pcs, vendor, group, mouldcode, quantity, category, _chaseno);
                DataService.GetInstance().ExecuteNonQuery(query);
            }
            else
            {
                if (!modifyInStock)
                {
                    string currentStatus = "";

                    string chaseno = lblChaseno.Text;
                    string mouldno = txtMouldno.Text;
                    string itemcode = txtItemcode.Text;
                    string rev = txtRev.Text;
                    string status = cbDiv.SelectedItem.ToString();
                    string amount = txtAmount.Text;
                    string mpa = "False";
                    if (ckbMpa.Checked)
                        mpa = "True";

                    string itemtext = "";

                    string projecttext = itemcode + "-" + rev;
                    string request = itemcode + rev;
                    string vendor = txtVendor.Text;
                    string mouldcode = txtMouldCode.Text;

                    string category = "";
                    string quantity = "1";

                    string currency = "";

                    string pcs = txtPcs.Text;

                    string oemasset = txtOemasset.Text;
                    string remarks = txtRemarks.Text;

                    string group = cbGroup.SelectedItem.ToString();

                    string instockdate50 = "";

                    string ismodify = "";

                    if (ckbModify.Checked)
                        ismodify = "True";
                    else
                        ismodify = "False";

                    string vnonly = cbProductionBase.SelectedIndex == 2 ? "True" : "False";

                    string cnvnonly = cbProductionBase.SelectedIndex == 1 ? "True" : "False";

                    string model = txtModel.Text;

                    bool validMouldCode = true;

                    if (mouldcode != "")
                    {
                        if (!DataChecking.isValidMouldCode(mouldcode))
                            validMouldCode = false;
                        else
                        {
                            if (mpa == "False")
                            {
                                itemtext = mouldno + "MP+" + mouldcode + "+" + status;
                                instockdate50 = "#N/A";
                            }
                            else
                            {
                                itemtext = mouldno + "MP+" + mouldcode + "+" + status + "*";
                                instockdate50 = "Yes";
                            }
                        }
                    }

                    bool validVendor = true;

                    if (vendor != "")
                    {
                        if (!DataChecking.isValidVendor(vendor))
                            validVendor = false;
                        else
                        {
                            if (lblCurrency.Text.Contains("JPY"))
                                currency = "JPY";
                            else
                                currency = DataChecking.getCurrency(vendor);
                        }
                    }

                    string accountcode = currency == "RMB" ? "" : "5005020002";
                    string costcentre = currency == "RMB" ? "" : "1404000029";

                    decimal calAmount = 0;

                    string year = DateTime.Today.ToString("yyyy");
                    string month = DateTime.Today.ToString("MM");
                    string jpyrate = DataChecking.getJpyRate(year, month);

                    if (lblCurrency.Text.Contains("JPY"))
                        calAmount = Convert.ToDecimal(amount) * Convert.ToDecimal(jpyrate);
                    else
                        calAmount = DataChecking.amountWithRate(currency, amount);

                    string amounthkd = currency == "RMB" ? "-" : calAmount.ToString("#.##");

                    if (calAmount >= 10000 & mpa == "True")
                        quantity = "2";
                    else
                        quantity = "1";

                    int piece = Convert.ToInt32(pcs);

                    calAmount = calAmount / piece;

                    if (!validMouldCode)
                    {
                        MessageBox.Show("Invalid Mould Code Found. Please check your data");
                        return;
                    }

                    if (!validVendor)
                    {
                        MessageBox.Show("Invalid Vendor Code Found. Please check your data");
                        return;
                    }

                    if (globalStatus != "T")
                    {
                        if (calAmount < 10000)
                        {
                            if (globalStatus == "K")
                                currentStatus = "K";
                            else if (globalStatus == "S")
                                currentStatus = "S";
                            else
                            {
                                if (calAmount == 0)
                                    currentStatus = "K";
                                else
                                {
                                    currentStatus = "U";
                                }
                            }

                            category = "K";
                        }
                        else
                        {
                            if (globalStatus == "K")
                            {
                                currentStatus = "K";
                                category = globalCategory;
                            }
                            else if (globalStatus == "S")
                            {
                                currentStatus = "S";
                                category = globalCategory;
                            }
                            else
                            {
                                if (mouldcode.StartsWith("8") && mouldcode != "8")
                                {
                                    currentStatus = "U";
                                    category = "K";
                                }
                                else if (oemasset != "")
                                {
                                    currentStatus = "U";
                                    category = "K";
                                }
                                else
                                {
                                    currentStatus = "F";
                                    accountcode = "";
                                    costcentre = "";
                                    category = "A";
                                }
                            }
                        }
                    }
                    else
                    {
                        currentStatus = "T";
                        category = "K";
                    }

                    if (oemasset != "")
                    {
                        //Debug.WriteLine("OEM: " + oemasset);

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

                    //string amounthkd = DataChecking.amountWithRate(currency, amount).ToString();

                    string updateText = string.Format("update tb_betamould set tm_mouldno = '{0}', tm_itemcode = '{1}', tm_rev = '{2}'" +
                        ", tm_status = '{3}', tm_currency = '{4}', tm_amount = '{5}', tm_mpa = '{6}', tm_mouldcode_code = '{7}'" +
                        ", tm_vendor_code = '{8}', tm_qty = '{9}', tm_itemtext = '{10}', tm_projecttext = '{11}', tm_request = '{12}'" +
                        ", tm_st_code = '{13}', tm_oemasset = '{14}', tm_rm = N'{15}', tm_modify = 'Yes', tm_amounthkd = '{16}', tm_group = '{17}', tm_accountcode = '{18}', tm_costcentre = '{19}', tm_category = '{20}', tm_ismodify = '{21}', tm_model = '{22}', tm_instockdate50 = '{23}', tm_vnonly = '{24}', tm_cnvnonly = '{25}' where tm_chaseno = '{26}'", mouldno, itemcode, rev, status, currency, amount, mpa, mouldcode,
                        vendor, quantity, itemtext, projecttext, request, currentStatus, oemasset, remarks, amounthkd, group, accountcode, costcentre, category, ismodify, model, instockdate50, vnonly, cnvnonly, chaseno);

                    DataService.GetInstance().ExecuteNonQuery(updateText);

                    this.saveLogRecord();
                }
                else
                {
                    string ismodify = "";

                    if (ckbModify.Checked)
                        ismodify = "True";
                    else
                        ismodify = "False";

                    string vnonly = cbProductionBase.SelectedIndex == 2 ? "True" : "False";

                    string cnvnonly = cbProductionBase.SelectedIndex == 1 ? "True" : "False";

                    string model = txtModel.Text;

                    string remarks = txtRemarks.Text;

                    string chaseno = lblChaseno.Text;

                    string oemasset = txtOemasset.Text;

                    string accountcode = "";

                    string costcentre = "";

                    if (oemasset != "")
                    {
                        //Debug.WriteLine("OEM: " + oemasset);

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

                    string text = string.Format("update tb_betamould set tm_model = '{0}', tm_ismodify = '{1}', tm_rm = '{2}', tm_group = '{3}'" +
                        ", tm_moulditemviewer = 'Yes', tm_vnonly = '{4}', tm_cnvnonly = '{5}', tm_oemasset = '{6}', tm_accountcode = '{7}'" +
                        ", tm_costcentre = '{8}' where tm_chaseno = '{9}'", model, ismodify, remarks, cbGroup.SelectedItem.ToString(), vnonly, cnvnonly, oemasset, accountcode, costcentre, chaseno);

                    DataService.GetInstance().ExecuteNonQuery(text);
                }
                MessageBox.Show("Record has been saved");

                if (formClose != null)
                    formClose(this, new EventArgs());
            }
        }

        private void saveLogRecord()
        {
            string logText = "";

            if (oMouldno != txtMouldno.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oMouldno, txtMouldno.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oItemCode != txtItemcode.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oItemCode, txtItemcode.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oRev != txtRev.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oRev, txtRev.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oStatus != cbDiv.SelectedItem.ToString())
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oStatus, cbDiv.SelectedItem.ToString(), AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oAmount != txtAmount.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oAmount, txtAmount.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            string mpa = "";
            if (ckbMpa.Checked)
                mpa = "True";
            else
                mpa = "False";

            if (oMpa != mpa)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oMpa, mpa, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oOemAsset != txtOemasset.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oOemAsset, txtOemasset.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oRemarks != txtRemarks.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oRemarks, txtRemarks.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oVendor != txtVendor.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oVendor, txtVendor.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
            }

            if (oMouldCode != txtMouldCode.Text)
            {
                logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "Quotation", oMouldCode, txtMouldCode.Text, AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    lblChaseno.Text, "Edit Data");
                DataService.GetInstance().ExecuteNonQuery(logText);
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

        DataTable tmptable;

        private void loadData2(string mouldno)
        {
            tmptable = new DataTable();

            string[] headers = { "mouldno", "itemcode", "type", "remarks" };

            foreach (string header in headers)
                tmptable.Columns.Add(header);

            string query = string.Format("select distinct sc_itemcode, sc_mouldno, sc_type, sc_remarks from tb_setcommon where sc_mouldno = '{0}'", mouldno);

            string mould = "";

            List<string> filterlist = new List<string>();

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string itemcode = GlobalService.reader.GetString(0);
                mould = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                filterlist.Add(itemcode);

                tmptable.Rows.Add(new object[] { mould, itemcode, type, remarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            this.loadMainData(mould, filterlist);

            this.loadCommonData(mould);

            DataView view = tmptable.DefaultView;

            tmptable = view.ToTable(true, "mouldno", "itemcode", "type", "remarks");

            customDatagrid1.DataSource = tmptable;
        }

        private void loadMainData(string mouldno, List<string> filterlist)
        {
            filterlist = filterlist.Distinct().ToList();

            for (int i = 0; i < filterlist.Count; i++)
            {
                string filter = filterlist[i];
                string query = string.Format("select tm_mouldno, tm_itemcode, tm_type, tm_rm from tb_betamould where tm_mouldno = '{0}' and tm_itemcode != '{1}'", mouldno, filter);

                Debug.WriteLine("MAIN QUERY: " + query);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string mould = GlobalService.reader.GetString(0);
                    string itemcode = GlobalService.reader.GetString(1);
                    string type = GlobalService.reader.GetString(2);
                    string remarks = GlobalService.reader.GetString(3);

                    tmptable.Rows.Add(new object[] { mould, itemcode, type, remarks });

                    Debug.WriteLine("Main Row Added");
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }
        }

        private void loadCommonData(string mouldno)
        {
            string query = string.Format("select t.tm_mouldno, t.tm_itemcode, t.tm_type, t.tm_rm from tb_betamould as t, tb_setcommon as sc" +
                " where t.tm_mouldno = sc.sc_oldmouldno and sc.sc_mouldno = '{0}' and sc.sc_type = 'Common'", mouldno);

            Debug.WriteLine("QUERY: " + query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string mould = GlobalService.reader.GetString(0);
                string itemcode = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                tmptable.Rows.Add(new object[] { mould, itemcode, type, remarks });

                Debug.WriteLine("Common Row Added");
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }
    }
}
