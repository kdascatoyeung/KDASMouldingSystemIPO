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
using CustomUtil.utils.authentication;

namespace Mould_System.forms._2.transfer
{
    public partial class ucTransferVendor2 : UserControl
    {
        string generalItemCode = "";

        public ucTransferVendor2()
        {
            InitializeComponent();

            foreach (DataGridViewColumn col in dgvTransferPreview.Columns)
                Debug.WriteLine(col.HeaderText);
        }

        private string[] Split(string str)
        {
            return str.Split(new string[] { " or " }, StringSplitOptions.None);
        }

        private void getVendorInfo()
        {
            try
            {
                txtItemcode.Focus();
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

                lblVendorName.Text = DataChecking.getVendorName(txtVendor.Text);
                lblPayTerms.Text = DataChecking.getPayTerm(txtVendor.Text);
                lblPayCurrency.Text = DataChecking.getPayCurrency(txtVendor.Text);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!DataChecking.isValidVendor(txtVendor.Text))
                    MessageBox.Show("Invalid vendor code");
                else
                    this.getVendorInfo();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtItemcode.Text) && string.IsNullOrEmpty(txtMouldNo.Text))
            {
                MessageBox.Show("Part No. cannot be null");
                return;
            }

            if(string.IsNullOrEmpty(txtVendor.Text) || !DataChecking.isValidVendor(txtVendor.Text))
            {
                MessageBox.Show("Invalid Vendor Code");
                return;
            }

            string itemcode = txtItemcode.Text;

            generalItemCode = itemcode;

            if (itemcode.Length == 8)
                itemcode = itemcode.Substring(0, 7);

            else if (itemcode.Length == 10)
            {
                if (itemcode.StartsWith("3V"))
                    itemcode = itemcode.Substring(0, 9);
                else
                    itemcode = itemcode.Substring(2, 7);
            }

            else if (itemcode.Length == 12)
            {
            }

            else if (itemcode.Length == 15)
                itemcode = itemcode.Substring(0, 7);

            else
            {
                if (string.IsNullOrEmpty(txtMouldNo.Text))
                {
                    MessageBox.Show("Invalid Part No.");
                    return;
                }
                else
                    itemcode = "";
            }

            dgvTransferPreview.Rows.Clear();

            string rev = txtRev.Text;

            string searchmould = txtMouldNo.Text;

            string query = string.Format("select tm_mouldno from tb_betamould where tm_itemcode like '%{0}%' and tm_mouldno like '%{1}%' group by tm_mouldno", itemcode, searchmould);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            List<string> mouldnolist = new List<string>();

            while (GlobalService.reader.Read())
            {
                string mouldno = GlobalService.reader.GetString(0);

                mouldnolist.Add(mouldno);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            for (int i = 0; i < mouldnolist.Count; i++)
            {
                string mouldno = mouldnolist[i].ToString();

                string revision = "";
                string vendor = "";
                string mouldcode = "";
                string latestpartno = "";
                string vendorname = "";

                string text = string.Format("select top 1 t.tm_rev, t.tm_vendor_code, t.tm_mouldcode_code, t.tm_itemcode, v.v_name"+
                    " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_itemcode like '%{0}%' and tm_mouldno = '{1}' order by tm_itemcode desc, tm_rev desc", itemcode, mouldno);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                while (GlobalService.reader.Read())
                {
                    revision = GlobalService.reader.GetString(0);
                    vendor = GlobalService.reader.GetString(1);
                    mouldcode = GlobalService.reader.GetString(2);
                    latestpartno = GlobalService.reader.GetString(3);
                    vendorname = GlobalService.reader.GetString(4);
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                dgvTransferPreview.Rows.Add(new object[] { "False", mouldno, mouldcode, latestpartno, revision, rev, vendor, vendorname, txtVendor.Text, "", "1" });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTransferPreview.Rows)
            {
                string selected = row.Cells[0].FormattedValue.ToString();
                string mouldno = row.Cells[1].Value.ToString();
                string mouldcode = row.Cells[2].Value.ToString();
                string itemcode = row.Cells[3].Value.ToString();
                string latestrec = row.Cells[4].Value.ToString();
                string rev = row.Cells[5].Value.ToString();
                string vendor = row.Cells[8].Value.ToString();
                string remarks = row.Cells[9].Value.ToString();

                if (selected == "True")
                {
                    string text = string.Format("select tm_fixedassetcode from tb_betamould where tm_mouldno = '{0}' and tm_fixedassetcode != '' and tm_fixedassetcode not like '%,%' and tm_fixedassetcode not like '%VC%'", mouldno);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                    List<string> falist = new List<string>();

                    while (GlobalService.reader.Read())
                    {
                        string fa = GlobalService.reader.GetString(0);

                        falist.Add(fa);
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    string faremarks = "";

                    string category = "K";

                    if (falist.Count == 0)
                        faremarks = "";
                    else if (falist.Count == 1)
                    {
                        faremarks = falist[0].ToString();
                        category = "A";
                    }
                    else
                    {
                        faremarks = string.Join(",", falist.ToArray());
                        category = "A";
                    }

                    string chaseno = DataChecking.getLastChaseNo();

                    string transferChaseno = chaseno.Replace("MS", "TM");

                    string pgroup = DataChecking.getVendorGroup(vendor);

                    string latestStatus = DataChecking.getLastStatus(mouldno, itemcode);

                    string itemtext = mouldno + "MP+" + mouldcode + "+TM";

                    string type = "TM";

                    string ismodify = "False";

                    string projecttext = itemcode + "-" + rev;

                    string request = itemcode + rev;

                    string quantity = "1";

                    string amount = "0";

                    string currency = DataChecking.getCurrency(vendor);

                    string status = "T";

                    string owner = "KDTHK";

                    string common = "Non-Common";

                    string model = itemcode.Length == 10 ? itemcode.Substring(3, 3) : mouldno.Substring(1, 3);

                    string oldvendor = row.Cells[6].Value.ToString();//DataChecking.getVendorByMouldItem(mouldno, itemcode);

                    string pcs = row.Cells[10].Value.ToString();//DataChecking.getPcsByMouldItem(mouldno, itemcode);

                    string query = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                        ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_createdby, tm_model, tm_group, tm_po, tm_faremarks, tm_pcs, tm_ismodify, tm_fixedassetcode, tm_rm) values" +
                        " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', '{27}', '{28}', '{29}')", chaseno, mouldno, itemcode, rev, type, "Single",
                        currency, amount, amount, "False", mouldcode, vendor, status, quantity, itemtext, projecttext, request, owner, category, DateTime.Today.ToString("yyyy/MM/dd"), common, AdUtil.getUsername("kmhk.local"), model, pgroup, transferChaseno, faremarks, pcs, ismodify, faremarks, remarks);

                    DataService.GetInstance().ExecuteNonQuery(query);

                    this.saveTransferHistory(transferChaseno, mouldno, itemcode, rev, type, owner, owner, oldvendor, vendor, DateTime.Today.ToString("yyyy/MM/dd"), chaseno, faremarks, remarks);
                }
                else
                    continue;
            }
            MessageBox.Show("Record has been saved");

            dgvTransferPreview.Rows.Clear();
        }

        private void saveTransferHistory(string transferChaseno, string mouldno, string itemcode, string rev, string status, string ownerbefore, string ownerafter,
            string locationbefore, string locationafter, string date, string chaseno, string faremarks, string remarks)
        {
            string query = string.Format("insert into tb_transferhistory (his_tmchaseno, his_mouldno, his_itemcode, his_rev, his_status, his_ownerbefore, his_ownerafter" +
                ", his_locationbefore, his_locationafter, his_date, his_chaseno, his_fixedassetcode, his_remarks) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}')", transferChaseno, mouldno,
                itemcode, rev, status, ownerbefore, ownerafter, locationbefore, locationafter, date, chaseno, faremarks, remarks);

            Debug.WriteLine("Query: " + query);
            DataService.GetInstance().ExecuteNonQuery(query);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            this.getVendorInfo();
        }
    }
}
