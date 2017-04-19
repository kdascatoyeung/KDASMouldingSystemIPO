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
using System.Diagnostics;
using System.Text.RegularExpressions;
using CustomUtil.utils.authentication;
using System.Data.SqlClient;

namespace Mould_System.functions.quotation
{
    public partial class ucQuotationInput : UserControl
    {
        public event EventHandler formClose;

        public ucQuotationInput()
        {
            InitializeComponent();

            this.cbFromOwner.SelectedIndex = 0;
            this.cbOwner.SelectedIndex = 0;

            this.ActiveControl = txtVendor;

            //foreach (DataGridViewColumn col in dgvQuotationDetail.Columns)
               // Debug.WriteLine(col.HeaderText);

            this.cbProductionBase.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formClose != null)
                formClose(this, new EventArgs());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            errInput.Clear();

            if (string.IsNullOrEmpty(txtNew.Text))
            {
                errInput.SetError(txtNew, "Please enter the number of items");
                return;
            }

            if (string.IsNullOrEmpty(txtModify.Text))
            {
                errInput.SetError(txtModify, "Please enter the number of items");
                return;
            }

            int number = Convert.ToInt32(txtNew.Text);
            int modifynumber = Convert.ToInt32(txtModify.Text);

            string itemcode = txtPartno.Text;
            string rev = txtRev.Text;
            string vendor = txtVendor.Text;
            string mouldno = "";
            string oemasset = txtOemAsset.Text;
            string remarks = txtRemarks.Text;
            string pcs = txtPcs.Text;

            string model = "";

            string accountcode = "";

            string costcentre = "";

            if (itemcode.Length == 12 || itemcode.Length == 15)
            {
                if (string.IsNullOrEmpty(txtModel.Text))
                {
                    MessageBox.Show("Please input Model");
                    return;
                }
                model = txtModel.Text;
            }
            else if (itemcode.Length == 8)
                model = itemcode.Substring(0, 3);

            else
            {
                if (itemcode.StartsWith("1"))
                    model = itemcode.Substring(3, 3);
                else
                    model = itemcode.Substring(2, 3);
            }

            if (!DataChecking.isValidVendor(vendor))
            {
                errInput.SetError(txtVendor, "Invalid Vendor Code");
                return;
            }

            if (cbGroup.SelectedItem == null)
            {
                errInput.SetError(cbGroup, "Please select a group first");
                return;
            }

            if (itemcode.Length != 8 && itemcode.Length != 10 && itemcode.Length != 12 && itemcode.Length != 15)
            {
                errInput.SetError(txtPartno, "Item Code length must be 8 / 10 / 12 / 15 digits");
                return;
            }

            string owner = rbtnKDTHK.Checked ? "KDTHK" : "KDTCN";

            if (oemasset != "")
            {
                if (oemasset.Length == 1)
                    oemasset = "0" + oemasset;

                if (!DataChecking.validOem(oemasset))
                {
                    errInput.SetError(txtOemAsset, "Invalid OEM");
                    return;
                }

                accountcode = DataChecking.getAccountCode(oemasset);

                costcentre = DataChecking.getCostCentre(oemasset);
            }

            string setitemcode = "N/A";

            if (!string.IsNullOrEmpty(txtItemcodeSet.Text))
                setitemcode = txtItemcodeSet.Text;

            if (rev.Length == 1)
                rev = "0" + rev;

            string fromOwner = "";
            if (cbFromOwner.SelectedIndex == 0)
                fromOwner = "From Vendor";
            else if (cbFromOwner.SelectedIndex == 1)
                fromOwner = "From KDC";
            else if (cbFromOwner.SelectedIndex == 2)
                fromOwner = "From KDTCN";
            else if (cbFromOwner.SelectedIndex == 3)
                fromOwner = "From KDTVN";

            transferMode = fromOwner;

            string currency = "";

            string tmpMould = "";

            if (fromOwner == "From KDC")
                currency = "JPY";
            else
                currency = DataChecking.getCurrency(vendor);

            string ismodify = "False";

            if (ckbIsModify.Checked)
                ismodify = "True";

            string vnonly = cbProductionBase.SelectedIndex == 2 ? "True" : "False";

            string cnvnonly = cbProductionBase.SelectedIndex == 1 ? "True" : "False";

            

            if (number != 0)
            {
                if (!DataChecking.isItemCodeExists2(itemcode))
                    tmpMould = "K" + itemcode + "01";
                else
                    tmpMould = "K" + itemcode + DataChecking.getLastThree2(itemcode);

                if(transferMode=="From Vendor")
                    dgvQuotationDetail.Rows.Add(new object[] { tmpMould, itemcode, rev, model, "New", "", currency, "0", "False", vendor, oemasset, remarks, accountcode, costcentre, pcs, ismodify, setitemcode, vnonly, cnvnonly, owner, "No" });
                else
                    dgvQuotationDetail.Rows.Add(new object[] { tmpMould, itemcode, rev, model, "TM", "", currency, "0", "False", vendor, oemasset, remarks, accountcode, costcentre, pcs, ismodify, setitemcode, vnonly, cnvnonly, owner, "No" });

                if (number > 1)
                {
                    for (int i = 1; i < number; i++)
                    {
                        int rowindex = dgvQuotationDetail.Rows.Count - 1;
                        string rowMould = dgvQuotationDetail.Rows[rowindex].Cells[0].Value.ToString();
                        int mId = Convert.ToInt32(rowMould.Substring(rowMould.Length - 2));
                        int cMid = mId + 1;
                        string result = cMid.ToString("00");
                        mouldno = "K" + itemcode + result;

                        if(transferMode=="From Vendor")
                            dgvQuotationDetail.Rows.Add(new object[] { mouldno, itemcode, rev, model, "New", "", currency, "0", "False", vendor, oemasset, remarks, accountcode, costcentre, pcs, ismodify, setitemcode, vnonly, cnvnonly, owner, "No" });
                        else
                            dgvQuotationDetail.Rows.Add(new object[] { mouldno, itemcode, rev, model, "TM", "", currency, "0", "False", vendor, oemasset, remarks, accountcode, costcentre, pcs, ismodify, setitemcode, vnonly, cnvnonly, owner, "No" });
                    }
                }

                if (modifynumber != 0)
                {
                    if (!DataChecking.isItemCodeExists(txtPartno.Text))
                    {
                        MessageBox.Show("Item Code: " + txtPartno.Text + " does not exist");
                        return;
                    }
                    if (modifynumber == 1)
                        dgvQuotationDetail.Rows.Add(new object[] { "", itemcode, rev, model, "Modify", "", currency, "0", "False", vendor, oemasset, remarks, accountcode, costcentre, pcs, ismodify, setitemcode, vnonly, cnvnonly, owner, "No" });
                    else
                    {
                        for (int i = 0; i < modifynumber; i++)
                            dgvQuotationDetail.Rows.Add(new object[] { "", itemcode, rev, model, "Modify", "", currency, "0", "False", vendor, oemasset, remarks, accountcode, costcentre, pcs, ismodify, setitemcode, vnonly, cnvnonly, owner, "No" });
                    }
                }
                dgvQuotationDetail.CurrentCell = dgvQuotationDetail.Rows[0].Cells[5];
                dgvQuotationDetail.BeginEdit(true);

                lblMsg.Text = dgvQuotationDetail.Rows.Count.ToString();

                this.btnCheckTotal.Enabled = true;
                this.btnValidate.Enabled = true;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            decimal amount = 0;
            decimal totalAmount = 0;
            decimal usdAmount = 0;
            decimal usdTotal = 0;
            decimal jpyAmount = 0;
            decimal jpyTotal = 0;
            decimal rmbAmount = 0;
            decimal rmbTotal = 0;

            string year = DateTime.Today.ToString("yyyy");
            string month = DateTime.Today.ToString("MM");

            string jpyrate = DataChecking.getJpyRate(year, month);

            bool isAmountOver = false;

            List<OverCostData> overList = new List<OverCostData>();

            List<QuotationData> quoList = new List<QuotationData>();

            foreach (DataGridViewRow row in dgvQuotationDetail.Rows)
            {
                string partno = row.Cells[1].Value.ToString();
                string rev = row.Cells[2].Value.ToString();
                string currency = row.Cells[6].Value.ToString();
                string camount = row.Cells[7].Value.ToString();

                if (currency == "USD")
                {
                    usdAmount = Convert.ToDecimal(row.Cells[7].Value);
                    usdTotal = usdTotal + usdAmount;

                    amount = DataChecking.amountWithRate(row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString());
                    totalAmount = totalAmount + amount;
                }
                else if (currency == "JPY")
                {
                    jpyAmount = Convert.ToDecimal(row.Cells[7].Value);
                    jpyTotal = jpyTotal + jpyAmount;

                    amount = Convert.ToDecimal(row.Cells[7].Value) * Convert.ToDecimal(jpyrate);
                    totalAmount = totalAmount + amount;
                }
                else if (currency == "HKD")
                {
                    amount = DataChecking.amountWithRate(row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString());
                    totalAmount = totalAmount + amount;
                }

                else if (currency == "RMB")
                {
                    rmbAmount = Convert.ToDecimal(row.Cells[7].Value);
                    rmbTotal = rmbTotal + rmbAmount;
                }

                string mouldcode = row.Cells[5].Value.ToString();

                string oem = row.Cells[10].Value.ToString();

                string pcs = row.Cells[14].Value.ToString();

                amount = amount / Convert.ToInt32(pcs);

                
                if (oem != "")
                {
                    row.Cells[12].Value = DataChecking.getAccountCode(oem);
                    row.Cells[13].Value = DataChecking.getCostCentre(oem);
                }
                else
                {
                    if (currency != "RMB")
                    {
                        if (amount < 10000 || mouldcode.StartsWith("8") && mouldcode != "8")
                        {
                            row.Cells[12].Value = "5005020002";
                            row.Cells[13].Value = "1404000029";
                        }
                    }
                }

                quoList.Add(new QuotationData { PartNo = partno, Rev = rev, Currency = currency, Amount = Convert.ToDouble(camount) });

                
            }

            var sumList = from l in quoList
                          group l by new
                          {
                              l.PartNo,
                              l.Rev,
                              l.Currency,
                          } into g
                          select new QuotationData()
                          {
                              PartNo = g.Key.PartNo,
                              Rev = g.Key.Rev,
                              Currency = g.Key.Currency,
                              Amount = g.Sum(x => Convert.ToDouble(x.Amount))
                          };

            foreach (var item in sumList)
            {
                if (IsPriceOverCost(item.PartNo, item.Rev, item.Currency, item.Amount.ToString()))
                {
                    overList.Add(new OverCostData { PartNo = item.PartNo, Amount = item.Amount.ToString() });
                    isAmountOver = true;
                }
            }

            if (isAmountOver)
            {
                string items = "";

                foreach (OverCostData item in overList)
                {
                    items = items + item.PartNo + "  Amount: " + item.Amount + "\n";
                    foreach (DataGridViewRow row in dgvQuotationDetail.Rows)
                    {
                        if (row.Cells[1].Value.ToString() == item.PartNo)
                        {
                            row.DefaultCellStyle.BackColor = Color.Red;
                            row.DefaultCellStyle.ForeColor = Color.White;
                        }
                    }
                }

                MessageBox.Show("Below items over cost.\n\n" + items);
            }

            lblJpy.Text = jpyTotal.ToString("#.##");
            lblHkd.Text = totalAmount.ToString("#.##");
            lblUsd.Text = usdTotal.ToString("#.##");
            lblRmb.Text = rmbTotal.ToString("#.##") + " (" + ((double)rmbTotal * 0.17).ToString("#.##") + ")";
        }

        private bool IsPriceOverCost(string partno, string rev, string currency, string amount)
        {
            string query = string.Format("select c_cost from tb_mould_cost where c_itemcode = '{0}' and c_rev = '{1}' and c_currency = '{2}'", partno, rev, currency);

            using (SqlDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (!reader.HasRows)
                    return false;
                else
                {
                    while (reader.Read())
                    {
                        double cost = Convert.ToDouble(reader.GetString(0));
                        if (Convert.ToDouble(amount) > cost)
                            return true;
                    }
                }
            }

            return false;
        }

        bool canSave = false;

        private void btnValidate_Click(object sender, EventArgs e)
        {
            bool validInput = true;
            bool validAmount = true;
            bool validMouldCode = true;

            bool isSetMould = false;

            List<int> indexList = new List<int>();
            List<int> setList = new List<int>();

            Regex amountEx = new Regex(@"^[0-9]*(\.[0-9]{1,2})?$");

            foreach (DataGridViewRow row in dgvQuotationDetail.Rows)
            {
                row.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
                row.DefaultCellStyle.ForeColor = Color.Black;

                string mouldno = row.Cells[0].Value.ToString();
                string itemcode = row.Cells[1].Value.ToString();
                string rev = row.Cells[2].Value.ToString();
                string currency = row.Cells[6].Value.ToString();
                string amount = row.Cells[7].Value.ToString();
                string mpa = row.Cells[8].FormattedValue.ToString();
                string vendor = row.Cells[9].Value.ToString();
                string mouldcode = "";

                //string setmould = row.Cells[11].FormattedValue.ToString();

                string accountcode = row.Cells[12].Value.ToString();
                string costcentre = row.Cells[13].Value.ToString();

                if (!validPrice(amount))
                {
                    validAmount = false;
                    indexList.Add(row.Index);
                }
                if (row.Cells[5].Value == null)
                    mouldcode = "";
                else
                    mouldcode = row.Cells[5].Value.ToString();

                if (!DataChecking.isValidMouldCode(mouldcode))
                {
                    validMouldCode = false;
                    indexList.Add(row.Index);
                }

                /*if (setmould == "True")
                {
                    setList.Add(row.Index);
                    isSetMould = true;
                }*/
            }
            indexList = indexList.Distinct().ToList();

            if (!validAmount)
                MessageBox.Show("Invalid Amount Format found. Please check.");

            if (!validMouldCode)
                MessageBox.Show("Invalid Mould Code found. Please check.");

            for (int i = 0; i < indexList.Count; i++)
            {
                int rowIndex = indexList[i];

                dgvQuotationDetail.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Red;
                dgvQuotationDetail.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
            }

            for (int k = 0; k < setList.Count; k++)
            {
                int rowIndex = setList[k];
                dgvQuotationDetail.Rows[rowIndex].Cells[0].Style.BackColor = Color.Yellow;
                dgvQuotationDetail.Rows[rowIndex].Cells[0].Style.ForeColor = Color.Black;
            }

            if (isSetMould)
            {
                MessageBox.Show("Please check and make sure the Set Mould No. is correct.");
            }

            if (validAmount && validMouldCode)
                validInput = true;
            else
                validInput = false;

            lblMsg.Visible = true;

            if (validInput)
            {
                lblMsg.Text = "PASSED";
                lblMsg.ForeColor = Color.Green;
                btnSave.Enabled = true;
            }
            else
            {
                lblMsg.Text = "WARNING";
                lblMsg.ForeColor = Color.Red;
                btnSave.Enabled = false;
            }

            canSave = validInput;
        }

        string transferMode = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvQuotationDetail.Rows)
            {
                string mouldno = row.Cells[0].Value.ToString();
                string itemcode = row.Cells[1].Value.ToString();
                string rev = row.Cells[2].Value.ToString();
                string model = row.Cells[3].Value.ToString();
                string status = row.Cells[4].Value.ToString();
                string currency = row.Cells[6].Value.ToString();
                string amount = row.Cells[7].Value.ToString();
                string mpa = row.Cells[8].FormattedValue.ToString();
                string vendor = row.Cells[9].Value.ToString();
                string mouldcode = row.Cells[5].Value.ToString();
                string oemasset = row.Cells[10].Value.ToString();
                string remarks = row.Cells[11].Value.ToString();
                //string setmould = row.Cells[11].Value.ToString();
                string accountcode = row.Cells[12].Value.ToString();
                string costcentre = row.Cells[13].Value.ToString();
                string pcs = row.Cells[14].Value.ToString();

                string pgroup = cbGroup.SelectedItem.ToString();
                string modify = row.Cells[15].FormattedValue.ToString();

                string setitemcode = row.Cells[16].Value.ToString();

                string vnonly = row.Cells[17].Value.ToString();
                string cnvnonly = row.Cells[18].Value.ToString();

                string owner = row.Cells[19].Value.ToString().Trim();
                string is50 = row.Cells[20].Value.ToString().Trim();

                string projecttext = itemcode + "-" + rev;
                string request = itemcode + rev;

                string chaseno = owner == "KDTCN" ? DataChecking.GetLastCnChaseNo() : DataChecking.getLastChaseNo();

                string itemtext = "";
                string type = "Single";

                if (!string.IsNullOrEmpty(setitemcode) && setitemcode != "" && setitemcode != "N/A")
                    type = "Set";

                string instockdate50 = "";

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

                string quantity = "";

                string qstatus = "";
                string category = "A";

                decimal calAmount = 0;
                string year = DateTime.Today.ToString("yyyy");
                string month = DateTime.Today.ToString("MM");
                string jpyrate = DataChecking.getJpyRate(year, month);

                if (transferMode == "From KDC")
                    calAmount = Convert.ToDecimal(amount) * Convert.ToDecimal(jpyrate);
                else
                    calAmount = DataChecking.amountWithRate(currency, amount);

                string amounthkd = calAmount.ToString("#.##");

                quantity = Convert.ToDecimal(amounthkd) >= 10000 && mpa == "True" ? "2" : "1";

                int piece = Convert.ToInt32(pcs);

                calAmount = calAmount / piece;

                string po = "";

                decimal tax = 0;

                if (owner == "KDTCN")
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
                        if (calAmount == 0) qstatus = "K";
                        else qstatus = "U";

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
                            qstatus = "F";
                    }

                    
                    if (status == "TM")
                    {
                        qstatus = "T";
                        if (calAmount < 10000)
                            category = "K";

                        else
                        {
                            category = "A";
                            qstatus = "F";
                        }

                        po = chaseno.Replace("MS", "TM");
                    }
                }

                string common = "Non-Common";

                string insertText = "";

                if (accountcode == "N/A")
                    accountcode = "";

                if (costcentre == "N/A")
                    costcentre = "";

                if ((mpa == "True" || is50 == "Yes") && owner == "KDTCN")
                {
                    //double tmAmount = Convert.ToDouble(amount) / 2;
                    //double tmTax = Convert.ToDouble(tax) / 2;

                    if (!itemtext.EndsWith("*"))
                        itemtext = itemtext + "*";

                    insertText = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                        ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model, tm_group, tm_accountcode, tm_costcentre, tm_ismodify, tm_instockdate50, tm_pcs, tm_po, tm_vnonly, tm_cnvnonly, tm_is50, tm_tax, tm_checkdate2) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', N'{22}', N'{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}')", chaseno, mouldno, itemcode, rev, status, type,
                        currency, amount, amounthkd, mpa, mouldcode, vendor, qstatus, "1", itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model, pgroup, accountcode, costcentre, modify, instockdate50, pcs, po, vnonly, cnvnonly, is50, tax, pgroup);
                    DataService.GetInstance().ExecuteNonQuery(insertText);

                    /*string is50ChaseNo = DataChecking.GetLastCnChaseNo();

                    string insertText2 = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                        ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model, tm_group, tm_accountcode, tm_costcentre, tm_ismodify, tm_instockdate50, tm_pcs, tm_po, tm_vnonly, tm_cnvnonly, tm_is50, tm_tax, tm_checkdate2) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', N'{22}', N'{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}')", is50ChaseNo, mouldno, itemcode, rev, status, type,
                        currency, tmAmount, amounthkd, mpa, mouldcode, vendor, qstatus, "1", itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model, pgroup, accountcode, costcentre, modify, instockdate50, pcs, po, vnonly, cnvnonly, is50, tmTax, pgroup);
                    DataService.GetInstance().ExecuteNonQuery(insertText2);*/
                }
                else
                {
                    insertText = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                        ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model, tm_group, tm_accountcode, tm_costcentre, tm_ismodify, tm_instockdate50, tm_pcs, tm_po, tm_vnonly, tm_cnvnonly, tm_is50, tm_tax, tm_checkdate2) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', N'{22}', N'{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}')", chaseno, mouldno, itemcode, rev, status, type,
                        currency, amount, amounthkd, mpa, mouldcode, vendor, qstatus, quantity, itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model, pgroup, accountcode, costcentre, modify, instockdate50, pcs, po, vnonly, cnvnonly, is50, tax, pgroup);
                    DataService.GetInstance().ExecuteNonQuery(insertText);
                }

                if (!string.IsNullOrEmpty(setitemcode) && setitemcode != "" && setitemcode != "N/A")
                {
                    string setText = string.Format("if not exists (select * from tb_setcommon where sc_itemcode = '{0}' and sc_mouldno = '{1}') begin"+
                        " insert into tb_setcommon (sc_itemcode, sc_mouldno, sc_oldmouldno, sc_type) values ('{0}', '{1}', '{1}', 'Set') end", setitemcode, mouldno, mouldno);

                    DataService.GetInstance().ExecuteNonQuery(setText);
                }

                if (oemasset != "")
                {
                    string oemcontent = DataChecking.getOemContent(oemasset);
                    string vendorname = DataChecking.getVendorName(vendor);

                    string query = String.Format("insert into tb_expensetransfer(et_date, et_asset, et_partno, et_rev, et_mouldno, et_type, et_mouldcode, et_cur, et_amount" +
                        ", et_vendorcode, et_vendor, et_chaseno, et_remarks) values ('{0}', '{1}', '{2}', '{3}'" +
                        ", '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", DateTime.Today.ToString("yyyy/MM/dd"), oemcontent, itemcode,
                        rev, mouldno, status, mouldcode, currency, amount, vendor, vendorname, chaseno, remarks);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }
                /*if (setmould == "False")
                {
                    insertText = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                        ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model, tm_group, tm_accountcode, tm_costcentre) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}')", chaseno, mouldno, itemcode, rev, status, type,
                        currency, amount, amounthkd, mpa, mouldcode, vendor, qstatus, quantity, itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model, pgroup, accountcode, costcentre);
                    DataService.GetInstance().ExecuteNonQuery(insertText);
                }
                else
                {
                    insertText = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                        ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model, tm_group, tm_accountcode, tm_costcentre) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}')", chaseno, mouldno, itemcode, rev, status, "Set",
                        currency, amount, amounthkd, mpa, mouldcode, vendor, qstatus, quantity, itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model, pgroup, accountcode, costcentre);
                    DataService.GetInstance().ExecuteNonQuery(insertText);

                    string updateText = string.Format("update tb_betamould set tm_status = 'Set' where tm_mouldno = '{0}'", mouldno);
                    DataService.GetInstance().ExecuteNonQuery(updateText);

                }*/

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                    " values ('{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', '{6}')", "Quotation", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd"), chaseno, "New Item");

                DataService.GetInstance().ExecuteNonQuery(logText);

                if (transferMode != "From Vendor")
                {
                    string tmchaseno = chaseno.Replace("MS", "TM");
                    string ownerbefore = cbFromOwner.SelectedItem.ToString();

                    this.saveTransferHistory(mouldno, itemcode, rev, status, ownerbefore, "KDTHK", vendor, vendor, amount, tmchaseno);
                }
            }

            MessageBox.Show("Record has been saved");

            if (formClose != null)
                formClose(this, new EventArgs());
        }

        private void getIC()
        {
            string vendor = txtVendor.Text;

            try
            {
                lblVendorname.Text = DataChecking.getVendorName(vendor);

                cbGroup.Items.Clear();

                string singleGroup = getVendorGroup(vendor);

                string remarks = "";

                string query = string.Format("select v_remarks from tb_vendor where v_code = '{0}'", vendor);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

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
                    cbGroup.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                lblVendorname.Text = "Unknown";
            }
        }

        private string[] Split(string str)
        {
            return str.Split(new string[] { " or " }, StringSplitOptions.None);
        }

        private string getVendorGroup(string vendor)
        {
            string query = string.Format("select v_group from tb_vendor where v_code = '{0}'", vendor);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            string group = "";

            while (GlobalService.reader.Read())
            {
                group = GlobalService.reader.GetString(0);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return group;
        }

        private void txtVendorKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                if (DataChecking.isValidVendor(txtVendor.Text))
                {
                    lblVendorname.Text = DataChecking.getVendorName(txtVendor.Text);
                    this.getIC();
                }
                else
                    lblVendorname.Text = "No Such Data";
            }
        }

        private void enterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private bool validPrice(string price)//Validate Price Format
        {
            if (price.Length == 0)
            {
                return false;
            }

            //string expression = @"^-?((\d+\.\d{1,2})|(\d+))$";
            string expression = @"^[0-9]*(\.[0-9]{1,2})?$";
            Regex regex = new Regex(expression);

            if (regex.IsMatch(price))
                return true;

            return false;
        }

        private void saveTransferHistory(string mouldno, string itemcode, string rev, string status, string ownerbefore, string ownerafter,
            string vendorbefore, string vendorafter, string amount, string chaseno)
        {
            string transferText = string.Format("insert into tb_transferhistory (his_mouldno, his_itemcode, his_rev, his_status, his_ownerbefore" +
                ", his_ownerafter, his_locationbefore, his_locationafter, his_date, his_fee, his_tmchaseno) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}'" +
                ", '{7}', '{8}', '{9}', '{10}')", mouldno, itemcode, rev, status, ownerbefore, ownerafter, vendorbefore, vendorafter, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                amount, chaseno);

            DataService.GetInstance().ExecuteNonQuery(transferText);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (DataChecking.isValidVendor(txtVendor.Text))
            {
                lblVendorname.Text = DataChecking.getVendorName(txtVendor.Text);
                this.getIC();
                cbGroup.Focus();
            }
            else
                lblVendorname.Text = "No Such Data";
        }

        bool cellEdited;
        int currentRow;
        int currentColumn;

        private void dgvQuotationDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            cellEdited = true;
            currentColumn = e.ColumnIndex;
            currentRow = e.RowIndex;
            /*try
            {
                string result = dgvQuotationDetail.CurrentRow.Cells[7].Value.ToString();
                Debug.WriteLine("Result: " + result);

                dgvQuotationDetail.CurrentRow.Cells[7].Value = string.Format("{0:#, ##0.00}", double.Parse(result));

                //Debug.WriteLine(dgvQuotationDetail.Columns[7].HeaderText.ToString());
                dgvQuotationDetail.Columns[7].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }*/
        }

        private void dgvQuotationDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //dgvQuotationDetail.Columns[7].DefaultCellStyle.Format = "N2";
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }

    public class QuotationData
    {
        public string PartNo { get; set; }
        public string Rev { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
    }

    public class OverCostData
    {
        public string PartNo { get; set; }
        public string Amount { get; set; }
    }
}
