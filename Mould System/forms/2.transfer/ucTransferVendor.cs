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
using Mould_System.functions.transfer;

namespace Mould_System.forms._2.transfer
{
    public partial class ucTransferVendor : UserControl
    {
        private List<RingiContent> ringiList;

        public ucTransferVendor()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtItemcode.Text) || string.IsNullOrEmpty(txtRev.Text))
            {
                MessageBox.Show("Please enter Part No. and Rev");
                return;
            }

            this.cbMouldno.Items.Clear();

            string query = string.Format("select distinct tm_mouldno from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}'", txtItemcode.Text, txtRev.Text);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (!GlobalService.reader.HasRows)
            {
                MessageBox.Show("Cannot find record with Part No. : " + txtItemcode.Text + " & Rev: " + txtRev.Text);
            }
            else
            {
                while (GlobalService.reader.Read())
                {
                    string mouldno = GlobalService.reader.GetString(0);
                    cbMouldno.Items.Add(mouldno);
                }
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            this.cbMouldno.SelectedIndex = 0;
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            string itemcode = txtItemcode.Text;
            string rev = txtRev.Text;
            string mouldno = cbMouldno.SelectedItem.ToString();

            if (DataChecking.isValidInput(mouldno, itemcode, rev))
            {
                frmTransferDetail detail = new frmTransferDetail(mouldno, itemcode, rev);
                detail.ShowDialog();
            }
        }

        bool availableRingi = true;

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!DataChecking.isValidVendor(txtVendorAfter.Text))
            {
                MessageBox.Show("Invalid vendor code");
                return;
            }

            string itemcode = txtItemcode.Text;
            string rev = txtRev.Text;
            string mouldno = cbMouldno.SelectedItem.ToString();

            string chaseno = DataChecking.getChaseNoByItem(itemcode, rev, mouldno);
            string fee = txtFee.Text;
            string vendorbefore = DataChecking.getVendorByItem(itemcode, rev, mouldno);
            string vendorafter = txtVendorAfter.Text;

            string ringi = "", fa = "";

            try
            {
                ringi = DataChecking.getRingiByItem(itemcode, rev, mouldno);
                fa = DataChecking.getFixedAssetCode(chaseno);
            }
            catch
            {
                ringi = "";
                fa = "";
            }

            if (string.IsNullOrEmpty(txtFee.Text) || txtFee.Text == "0")
            {
                dgvTransferPreview.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, "0", vendorbefore, vendorafter, ringi, fa });
            }
            else
            {
                if (ringiList.Count != 0)
                {
                    for (int i = 0; i < ringiList.Count; i++)
                    {
                        string ringiInList = ringiList[i].Ringi;

                        decimal balance = Convert.ToDecimal(ringiList[i].Balance);

                        decimal dFee = Convert.ToDecimal(fee);
                        if (dFee > balance)
                            availableRingi = false;

                        dgvTransferPreview.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, fee, vendorbefore, vendorafter, ringi, fa });
                    }
                }
                else
                {
                    dgvTransferPreview.Rows.Add(new object[] { chaseno, mouldno, itemcode, rev, fee, vendorbefore, vendorafter, ringi, fa });
                }
            }

            dgvTransferPreview.Sort(dgvTransferPreview.Columns[0], ListSortDirection.Ascending);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<TransferNoFeeList> noFeeList = new List<TransferNoFeeList>();
            List<TransferFeeList> feeList = new List<TransferFeeList>();

            foreach (DataGridViewRow row in dgvTransferPreview.Rows)
            {
                string chaseno = row.Cells[0].Value.ToString();
                string mouldno = row.Cells[1].Value.ToString();
                string itemcode = row.Cells[2].Value.ToString();
                decimal fee = Convert.ToDecimal(row.Cells[4].Value);
                string ringi = row.Cells[7].Value.ToString();
                string fa = row.Cells[8].Value.ToString();

                if (fee == 0)
                    noFeeList.Add(new TransferNoFeeList { ChaseNo = chaseno, MouldNo = mouldno, ItemCode = itemcode });
                else
                    feeList.Add(new TransferFeeList { ChaseNo = chaseno, MouldNo = mouldno, ItemCode = itemcode, Fee = fee, Ringi = ringi, FixedAssetCode = fa });

                this.transferWithoutFee(noFeeList);
                this.transferWithFee(feeList);

                MessageBox.Show("Record has been saved");
            }
        }

        private void transferWithoutFee(List<TransferNoFeeList> list)
        {
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string listChaseno = list[i].ChaseNo;
                    string listMouldno = list[i].MouldNo;
                    string listItemcode = list[i].ItemCode;

                    string query = string.Format("select tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_mpa, tm_fixedassetcode, tm_tmpfixedassetcode" +
                        ", tm_qty, tm_common, tm_request, tm_projecttext, tm_category, tm_mouldcode_code, tm_owner, tm_vendor_code, tm_pcs" +
                        " from tb_betamould where tm_chaseno = '{0}'", listChaseno);

                    string mouldno = "", itemcode = "", rev = "", status = "", type = "", currency = "", mpa = "";
                    string fac = "", tmpfac = "", qty = "", common = "", request = "", indate = DateTime.Today.ToString("yyyy/MM/dd");
                    string projecttext = "", category = "", vendor = "", mouldcode = "", owner = "", fromVendor = "", pcs = "";

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
                    while (GlobalService.reader.Read())
                    {
                        mouldno = GlobalService.reader.GetString(0);
                        itemcode = GlobalService.reader.GetString(1);
                        rev = GlobalService.reader.GetString(2);
                        status = GlobalService.reader.GetString(3);
                        type = GlobalService.reader.GetString(4);
                        mpa = GlobalService.reader.GetString(5);
                        fac = GlobalService.reader.GetString(6);
                        tmpfac = GlobalService.reader.GetString(7);
                        qty = GlobalService.reader.GetString(8);
                        common = GlobalService.reader.GetString(9);
                        request = GlobalService.reader.GetString(10);
                        projecttext = GlobalService.reader.GetString(11);
                        category = GlobalService.reader.GetString(12);
                        mouldcode = GlobalService.reader.GetString(13);
                        owner = GlobalService.reader.GetString(14);
                        fromVendor = GlobalService.reader.GetString(15);
                        pcs = GlobalService.reader.GetString(16);
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    string tStatus = "";

                    if (status == "New")
                        tStatus = "TM";
                    else
                        tStatus = "TM+Modify";

                    string itemtext = mouldno + "MP+" + mouldcode + "+" + tStatus;
                    string chaseno = DataChecking.getLastChaseNo();
                    string tmpPo = chaseno.Replace("MS", "TM");

                    string transferChaseNo = DataChecking.getLastTransferNo();
                    vendor = txtVendorAfter.Text;
                    currency = DataChecking.getCurrency(vendor);

                    string text = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency" +
                        ", tm_amount, tm_amounthkd, tm_mpa, tm_fixedassetcode, tm_tmpfixedassetcode, tm_common, tm_itemtext, tm_request, tm_indate" +
                        ", tm_projecttext, tm_po, tm_category, tm_vendor_code, tm_mouldcode_code, tm_st_code, tm_transfer, tm_owner, tm_qty" +
                        ", tm_createdby) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}'",
                        chaseno, mouldno, itemcode, rev, tStatus, type, currency, "0", "0", mpa, fac, tmpfac, common, itemtext, request, indate, projecttext, tmpPo,
                        category, vendor, mouldcode, "P", transferChaseNo, owner, qty, AdUtil.getUsername("kmhk.local"));

                    DataService.GetInstance().ExecuteNonQuery(text);
                }
            }
        }

        private void transferWithFee(List<TransferFeeList> list)
        {
            if (list.Count != 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string listChaseno = list[i].ChaseNo;
                    decimal listFee = Convert.ToDecimal(list[i].Fee);

                    string query = string.Format("select tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_mpa, tm_fixedassetcode, tm_tmpfixedassetcode" +
                        ", tm_qty, tm_common, tm_request, tm_indate, tm_projecttext, tm_category, tm_mouldcode_code, tm_owner, tm_vendor_code" +
                        " from tb_betamould where tm_chaseno = '{0}'", listChaseno);

                    string mouldno = "", itemcode = "", rev = "", status = "", type = "", currency = "", mpa = "";
                    string fac = "", tmpfac = "", qty = "", common = "", request = "", indate = DateTime.Today.ToString("yyyy/MM/dd");
                    string projecttext = "", category = "", vendor = "", mouldcode = "", owner = "", fromVendor = "";

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
                    while (GlobalService.reader.Read())
                    {
                        mouldno = GlobalService.reader.GetString(0);
                        itemcode = GlobalService.reader.GetString(1);
                        rev = GlobalService.reader.GetString(2);
                        status = GlobalService.reader.GetString(3);
                        type = GlobalService.reader.GetString(4);
                        mpa = GlobalService.reader.GetString(5);
                        fac = GlobalService.reader.GetString(6);
                        tmpfac = GlobalService.reader.GetString(7);
                        qty = GlobalService.reader.GetString(8);
                        common = GlobalService.reader.GetString(9);
                        request = GlobalService.reader.GetString(10);
                        projecttext = GlobalService.reader.GetString(12);
                        category = GlobalService.reader.GetString(13);
                        mouldcode = GlobalService.reader.GetString(14);
                        owner = GlobalService.reader.GetString(15);
                        fromVendor = GlobalService.reader.GetString(16);
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();
                }
            }
        }

        private void saveHistory(string tChaseno, string tMouldno, string tItemcode, string tRev, string tStatus, string tFromVendor, string tToVendor, decimal tFee, string tOwner)
        {
            string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string chaseno = tChaseno.Replace("TM", "MS");
            string fac = DataChecking.getFixedAssetCode(chaseno);
            string tmpfac = DataChecking.getTmpFixedAssetCode(chaseno);

            string query = string.Format("insert into tb_transferhistory (his_tmchaseno, his_mouldno, his_itemcode, his_rev, his_status, his_ownerbefore" +
                ", his_ownerafter, his_locationbefore, his_locationafter, his_date, his_fee, his_fixedassetcode, his_tmpfixedassetcode) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')",
                tChaseno, tMouldno, tItemcode, tRev, tStatus, tOwner, tOwner, tFromVendor, tToVendor, datetime, tFee, fac, tmpfac);

            DataService.GetInstance().ExecuteNonQuery(query);
        }
    }
}
