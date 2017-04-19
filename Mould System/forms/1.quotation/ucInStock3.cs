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
using Mould_System.functions.instock;
using Mould_System.file.csv;
using Mould_System.file.excel;
using System.Diagnostics;
using System.Globalization;
using Mould_System.functions.file;

namespace Mould_System.forms._1.quotation
{
    public partial class ucInStock3 : UserControl
    {
        private string instockdate50 = "", instockdate = "";

        private string tmpPo = "";

        private bool inputRequired = true;

        public ucInStock3()
        {
            InitializeComponent();
        }

        private void getDataByPo(string po)
        {
            string query = string.Format("select tm_checkdate, tm_cav, tm_weight, tm_accessory, tm_camera, tm_vertical, tm_horizontal, tm_height from tb_betamould where tm_po = '{0}'", po);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string checkdate = GlobalService.reader.GetString(0);
                string cav = GlobalService.reader.GetString(1);
                string weight = GlobalService.reader.GetString(2);
                string equipment = GlobalService.reader.GetString(3);
                string shot = GlobalService.reader.GetString(4);
                string length = GlobalService.reader.GetString(5);
                string width = GlobalService.reader.GetString(6);
                string height = GlobalService.reader.GetString(7);

                if (checkdate != "")
                {
                    //dpCheckDate.Value = Convert.ToDateTime(checkdate);
                    txtCheckdate.Text = checkdate;
                }

                if (cav != "")
                    txtCav.Text = cav;

                if (weight != "")
                    txtWeight.Text = weight;

                if (equipment != "")
                    txtEquipment.Text = equipment;

                if (shot != "")
                    txtShot.Text = shot;

                if (length != "")
                    txtLength.Text = length;

                if (width != "")
                    txtWidth.Text = width;

                if (height != "")
                    txtHeight.Text = height;
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void search()
        {
            this.txtCheckdate.Clear();
            this.txtCav.Clear();
            this.txtWeight.Clear();
            this.txtEquipment.Clear();
            this.txtShot.Clear();
            this.txtLength.Clear();
            this.txtWidth.Clear();
            this.txtHeight.Clear();
            this.txtInstockRemarks.Clear();

            this.dgvResult.Rows.Clear();
            this.dgvPreview.Rows.Clear();

            string po = txtPo.Text;

            if (!DataChecking.isValidPo(po))
            {
                if (po.StartsWith("12") && po.EndsWith("10"))
                {
                    string tmpo = po.Substring(0, po.Length - 2);
                    tmpo = tmpo + "20";

                    if (DataChecking.isValidPo(tmpo))
                    {
                        switch (MessageBox.Show("Temporary receive PO: " + po + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:

                                string poText = string.Format("insert into tb_temppo (tp_po) values ('{0}')", po);
                                DataService.GetInstance().ExecuteNonQuery(poText);

                                MessageBox.Show("Record has been saved.");
                                break;

                            case DialogResult.No:
                                break;
                        }

                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid PO No.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid PO No.");
                    return;
                }
            }

            if (DataChecking.IsPoRmb(po))
            {
                foreach (CheckBox checkbox in tbCheckbox.Controls)
                {
                    checkbox.Enabled = false;
                    checkbox.Checked = false;
                }

                this.getDataByPo(po);

                tmpPo = po;

                if (checkPoIsMpa(po))
                {
                    pictureBox1.BackgroundImage = Properties.Resources.tick;

                    ckbNormal.Enabled = false;
                    ckbTransfer.Enabled = false;

                    string is50 = DataChecking.getInstock50ByPo(po);

                    if (is50 == "Yes")
                    {
                        ckbFirst50.Enabled = true;
                        ckbSecond50.Enabled = false;
                        ckbPo1.Enabled = true;
                        ckbPo2.Enabled = true;

                    }
                    else
                    {
                        ckbFirst50.Enabled = false;
                        ckbSecond50.Enabled = true;
                        ckbPo1.Enabled = false;
                        ckbPo2.Enabled = false;
                    }
                }
                else
                {
                    pictureBox1.BackgroundImage = Properties.Resources.cross;

                    string type = DataChecking.getTypeByPo(po);

                    if (type == "New" || type == "Modify")
                    {
                        ckbNormal.Enabled = true;
                        ckbTransfer.Enabled = false;
                    }
                    else
                    {
                        ckbNormal.Enabled = false;
                        ckbTransfer.Enabled = true;
                    }

                    ckbFirst50.Enabled = false;
                    ckbSecond50.Enabled = false;
                    ckbPo1.Enabled = false;
                    ckbPo2.Enabled = false;
                }

                btnPreview.Enabled = true;
            }
            else
            {
                string currentInStockdate = DataChecking.getInStockDateByPo(po);

                if (currentInStockdate == "Received")
                {
                    switch (MessageBox.Show("PO: " + po + " data already received. Do you want to modify it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            break;
                        case DialogResult.No:
                            foreach (CheckBox checkbox in tbCheckbox.Controls)
                            {
                                checkbox.Enabled = true;
                                checkbox.Checked = false;
                            }
                            pictureBox1.BackgroundImage = null;
                            return;
                    }
                }

                this.getDataByPo(po);

                tmpPo = po;

                if (checkPoIsMpa(po))
                {
                    pictureBox1.BackgroundImage = Properties.Resources.tick;

                    ckbNormal.Enabled = false;
                    ckbTransfer.Enabled = false;

                    string is50 = DataChecking.getInstock50ByPo(po);

                    if (is50 == "Yes")
                    {
                        ckbFirst50.Enabled = true;
                        ckbSecond50.Enabled = false;
                        ckbPo1.Enabled = true;
                        ckbPo2.Enabled = true;

                    }
                    else
                    {
                        ckbFirst50.Enabled = false;
                        ckbSecond50.Enabled = true;
                        ckbPo1.Enabled = false;
                        ckbPo2.Enabled = false;
                    }
                }
                else
                {
                    pictureBox1.BackgroundImage = Properties.Resources.cross;

                    string type = DataChecking.getTypeByPo(po);

                    if (type == "New" || type == "Modify")
                    {
                        ckbNormal.Enabled = true;
                        ckbTransfer.Enabled = false;
                    }
                    else
                    {
                        ckbNormal.Enabled = false;
                        ckbTransfer.Enabled = true;
                    }

                    ckbFirst50.Enabled = false;
                    ckbSecond50.Enabled = false;
                    ckbPo1.Enabled = false;
                    ckbPo2.Enabled = false;
                }

                btnPreview.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.search();
        }

        private void loadOriginalData(string po)
        {
            DataTable originalTable = new DataTable();

            string[] headers = {"chaseno", "po", "itemcode", "rev", "mouldno", "mouldcode", "vendor", "vendorname", "tmpfac", "fac", "currency",
                                   "amount", "poissued", "instock50", "instockdate"};

            foreach (string header in headers)
                originalTable.Columns.Add(header);

            string query = string.Format("select t.tm_chaseno, t.tm_po, t.tm_itemcode, t.tm_rev, t.tm_mouldno, t.tm_mouldcode_code, t.tm_vendor_code" +
                ", v.v_name, t.tm_tmpfixedassetcode, t.tm_fixedassetcode, t.tm_currency, t.tm_amount, t.tm_poissued, t.tm_mpa, t.tm_instockdate50, t.tm_instockdate" +
                " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_po = '{0}'", po);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            string chaseno = "", pono = "", itemcode = "", rev = "", mouldno = "", mouldcode = "", vendor = "", vendorname = "";
            string tmpfac = "", fac = "", currency = "", amount = "", poissued = "", mpa = "", tmpInstock50 = "", tmpInstock = "";

            while (GlobalService.reader.Read())
            {
                chaseno = GlobalService.reader.GetString(0);
                pono = GlobalService.reader.GetString(1);
                itemcode = GlobalService.reader.GetString(2);
                rev = GlobalService.reader.GetString(3);
                mouldno = GlobalService.reader.GetString(4);
                mouldcode = GlobalService.reader.GetString(5);
                vendor = GlobalService.reader.GetString(6);
                vendorname = GlobalService.reader.GetString(7);
                tmpfac = GlobalService.reader.GetString(8);
                if (tmpfac == "")
                    tmpfac = "-";
                fac = GlobalService.reader.GetString(9);
                if (fac == "")
                    fac = "-";
                currency = GlobalService.reader.GetString(10);
                amount = GlobalService.reader.GetString(11);
                //double tmpIssued = Double.Parse(GlobalService.reader.GetString(12));
                //poissued = DateTime.FromOADate(tmpIssued).ToString("yyyy/MM/dd");
                poissued = GlobalService.reader.GetString(12);
                mpa = GlobalService.reader.GetString(13);
                tmpInstock50 = GlobalService.reader.GetString(14);
                tmpInstock = GlobalService.reader.GetString(15);

                if (mpa == "True")
                    dgvResult.Rows.Add(new object[] { chaseno, pono, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, "-", currency, amount, poissued, tmpInstock50, tmpInstock });

                dgvResult.Rows.Add(new object[] { chaseno, pono, itemcode, rev, mouldno, mouldcode, vendor, vendorname, "-", fac, currency, amount, poissued, tmpInstock50, tmpInstock });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            this.loadPreviewData(chaseno, pono, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, fac, currency, amount, poissued);
        }

        private void loadPreviewData(string chaseno, string po, string itemcode, string rev, string mouldno, string mouldcode, string vendor, string vendorname,
            string tmpfac, string fac, string currency, string amount, string issued)
        {
            dgvPreview.Rows.Clear();

            if (fac == "")
                fac = "-";

            if (ckbNormal.Checked)
            {
                instockdate50 = "-----";
                instockdate = "Received";

                inputRequired = true;

                dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, fac, currency, amount, issued, "-----", "Received" });
            }

            else if (ckbFirst50.Checked)
            {
                instockdate50 = "Received";
                instockdate = "#N/A";

                inputRequired = false;

                dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, fac, currency, amount, issued, "Received", "#N/A" });
            }

            else if (ckbSecond50.Checked)
            {
                instockdate = "Received";

                inputRequired = true;

                string tmpinstock50 = DataChecking.getInstock50ByPo(po);
                instockdate50 = tmpinstock50;

                dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, fac, currency, amount, issued, tmpinstock50, "Received" });
            }

            else if (ckbPo1.Checked)
            {
                instockdate50 = "一回合格入庫";
                instockdate = "Received";

                inputRequired = true;

                if (tmpfac != "")
                    dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, "-", currency, amount, issued, "一回合格入庫", "Received" });

                    dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, "-", fac, currency, amount, issued, "一回合格入庫", "Received" });
            }

            else if (ckbPo2.Checked)
            {
                instockdate50 = "已拆單、以合格同時入庫";
                instockdate = "Received";

                inputRequired = true;

                if (tmpfac != "")
                    dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, "-", currency, amount, issued, "已拆單、以合格同時入庫", "Received" });

                dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, "-", fac, currency, amount, issued, "已拆單、以合格同時入庫", "Received" });
            }

            else
            {
                instockdate50 = "-----";
                instockdate = DateTime.Today.ToString("yyyy/MM/dd");

                inputRequired = false;

                if (tmpfac == "")
                    tmpfac = "-";
                dgvPreview.Rows.Add(new object[] { chaseno, po, itemcode, rev, mouldno, mouldcode, vendor, vendorname, tmpfac, fac, currency, amount, issued, "-----", DateTime.Today.ToString("yyyy/MM/dd") });
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            List<int> count = new List<int>();

            foreach (Control control in tbCheckbox.Controls)
            {
                CheckBox ckb = (CheckBox)control;
                if (ckb.Checked == true)
                    count.Add(1);
            }

            bool isRmb = DataChecking.IsPoRmb(txtPo.Text.Trim());

            if (count.Count == 0 && !isRmb)
            {
                MessageBox.Show("Nothing selected. Please click Modify Spec if you want to update Mould Spec only");
                return;
            }

            string checkdate = "", cav = "", weight = "", accessory = "", camera = "", length = "", width = "", height = "", instockremarks = "";

            checkdate = txtCheckdate.Text;

            if (!string.IsNullOrEmpty(txtCav.Text))
                cav = txtCav.Text;

            if (!string.IsNullOrEmpty(txtWeight.Text))
                weight = txtWeight.Text;

            if (!string.IsNullOrEmpty(txtEquipment.Text))
                accessory = txtEquipment.Text;

            if (!string.IsNullOrEmpty(txtShot.Text))
                camera = txtShot.Text;

            if (!string.IsNullOrEmpty(txtLength.Text))
                length = txtLength.Text;

            if (!string.IsNullOrEmpty(txtWidth.Text))
                width = txtWidth.Text;

            if (!string.IsNullOrEmpty(txtHeight.Text))
                height = txtHeight.Text;

            if (!string.IsNullOrEmpty(txtInstockRemarks.Text))
                instockremarks = txtInstockRemarks.Text;

            string calpo = txtPo.Text;

            int thismonth = DateTime.Today.Month;
            int selectedmonth = dpCheckDate.Value.Month;

            /*checkdate = dpCheckDate.Value.ToString("yyyy/MM/dd");

            int result = thismonth - selectedmonth;

            if (result > 3 || result < -3)
            {
                switch (MessageBox.Show("Checkdate selection out of range (+ / - 3 months). Keep modifying?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        
                        break;

                    case DialogResult.No:
                        return;
                }
            }*/

            if (isRmb)
            {
                string query = string.Format("update tb_betamould set tm_instockdate50 = '{0}', tm_instockdate = '{1}', tm_checkdate = '{2}', tm_cav = '{3}'" +
                            ", tm_weight = '{4}', tm_accessory = '{5}', tm_camera = '{6}', tm_vertical = '{7}', tm_horizontal = '{8}', tm_height = '{9}', tm_moulditemviewer = 'Yes', tm_st_code = 'PR', tm_instockremarks = '{10}'" +
                            " where tm_po = '{11}'", instockdate50, instockdate, checkdate, cav, weight, accessory, camera, length, width, height, instockremarks, tmpPo);

                //Debug.WriteLine(query);
                DataService.GetInstance().ExecuteNonQuery(query);
            }
            else
            {
                if (inputRequired)
                {
                    if (string.IsNullOrEmpty(checkdate))
                    {
                        MessageBox.Show("檢查合格日 cannot be null");
                        return;
                    }

                    string query = string.Format("update tb_betamould set tm_instockdate50 = '{0}', tm_instockdate = '{1}', tm_checkdate = '{2}', tm_cav = '{3}'" +
                        ", tm_weight = '{4}', tm_accessory = '{5}', tm_camera = '{6}', tm_vertical = '{7}', tm_horizontal = '{8}', tm_height = '{9}', tm_moulditemviewer = 'Yes', tm_st_code = 'PR', tm_instockremarks = '{10}'" +
                        " where tm_po = '{11}'", instockdate50, instockdate, checkdate, cav, weight, accessory, camera, length, width, height, instockremarks, tmpPo);

                    DataService.GetInstance().ExecuteNonQuery(query);

                    //MessageBox.Show("Record has been saved");
                }
                else
                {
                    string type = DataChecking.getTypeByPo(calpo);

                    if (type == "New" || type == "Modify")
                    {
                        string query = string.Format("update tb_betamould set tm_instockdate50 = '{0}', tm_instockdate = '{1}', tm_checkdate = '{2}', tm_cav = '{3}'" +
                            ", tm_weight = '{4}', tm_accessory = '{5}', tm_camera = '{6}', tm_vertical = '{7}', tm_horizontal = '{8}', tm_height = '{9}', tm_moulditemviewer = 'Yes', tm_st_code = 'PR', tm_instockremarks = '{10}'" +
                            " where tm_po = '{11}'", instockdate50, instockdate, checkdate, cav, weight, accessory, camera, length, width, height, instockremarks, tmpPo);

                        DataService.GetInstance().ExecuteNonQuery(query);
                    }
                    else
                    {
                        List<string> polist = new List<string>();

                        string text = string.Format("select tm_po from tb_betamould where tm_po like '{0}%'", calpo);

                        GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

                        while (GlobalService.reader.Read())
                        {
                            string po = GlobalService.reader.GetString(0);
                            polist.Add(po);
                        }
                        GlobalService.reader.Close();
                        GlobalService.reader.Dispose();

                        for (int i = 0; i < polist.Count; i++)
                        {
                            string targetpo = polist[i];

                            string query = string.Format("update tb_betamould set tm_instockdate50 = '{0}', tm_instockdate = '{1}', tm_checkdate = '{2}', tm_cav = '{3}'" +
                            ", tm_weight = '{4}', tm_accessory = '{5}', tm_camera = '{6}', tm_vertical = '{7}', tm_horizontal = '{8}', tm_height = '{9}', tm_instockremarks = '{10}', tm_moulditemviewer = 'Yes', tm_st_code = 'S'" +
                            " where tm_po = '{11}'", instockdate50, instockdate, checkdate, cav, weight, accessory, camera, length, width, height, instockremarks, targetpo);

                            DataService.GetInstance().ExecuteNonQuery(query);
                        }
                    }
                    
                }
            }
            MessageBox.Show("Record has been saved");
            //dpCheckDate.Value = DateTime.Today;
            this.cancel();
        }

        private void cancel()
        {
            dgvPreview.Rows.Clear();

            dgvResult.Rows.Clear();

            txtPo.Clear();
            txtCheckdate.Clear();
            txtCav.Clear();
            txtWeight.Clear();
            txtEquipment.Clear();
            txtShot.Clear();
            txtLength.Clear();
            txtWidth.Clear();
            txtHeight.Clear();
            txtInstockRemarks.Clear();

            pictureBox1.BackgroundImage = null;

            ckbFirst50.Checked = false;
            ckbNormal.Checked = false;
            ckbSecond50.Checked = false;
            ckbPo1.Checked = false;
            ckbPo2.Checked = false;
            ckbTransfer.Checked = false;

            ckbFirst50.Enabled = true;
            ckbSecond50.Enabled = true;
            ckbNormal.Enabled = true;
            ckbPo1.Enabled = true;
            ckbPo2.Enabled = true;
            ckbTransfer.Enabled = true;

            btnPreview.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.cancel();
        }

        private bool checkPoIsMpa(string po)
        {
            bool valid = false;

            string query = string.Format("select tm_mpa from tb_betamould where tm_po = '{0}'", po);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string mpa = GlobalService.reader.GetString(0);

                if (mpa == "True")
                    valid = true;
                else
                    valid = false;
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            dgvPreview.Rows.Clear();

            dgvResult.Rows.Clear();

            string po = txtPo.Text;

            string currentStatus = DataChecking.getStatusCodeByPo(po);

            if (currentStatus == "S")
            {
                MessageBox.Show("Current Status : 入庫濟. No need to do in-stock operation");

                this.btnReceive.Enabled = false;
                return;
            }

            List<int> count = new List<int>();

            foreach (Control control in tbCheckbox.Controls)
            {
                CheckBox ckb = (CheckBox)control;
                if (ckb.Checked == true)
                    count.Add(1);
            }

            if (count.Count == 0)
            {
                MessageBox.Show("Please choose one of the option");
                return;
            }

            this.loadOriginalData(po);
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            frmReceivedPo received = new frmReceivedPo();
            received.ShowDialog();
        }

        private void btnWaiting_Click(object sender, EventArgs e)
        {
            DataTable waitingTable = new DataTable();

            string[] headers = { "Chase No.", "Vendor", "Vendor Name", "Part No.", "Rev", "Mould No.", "Status", "Mould Code", "Currency", "Amount", 
                                   "MPA", "FA (Temp)", "FA", "PO", "Issued", "OEM Asset", "Remarks" };

            foreach (string header in headers)
                waitingTable.Columns.Add(header);

            string query = "select t.tm_chaseno, t.tm_vendor_code, v.v_name, t.tm_itemcode, t.tm_rev, t.tm_mouldno, t.tm_status, t.tm_mouldcode_code" +
                ", t.tm_currency, t.tm_amount, t.tm_mpa, t.tm_tmpfixedassetcode, t.tm_fixedassetcode, t.tm_po, t.tm_poissued, t.tm_oemasset, t.tm_rm" +
                " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and (t.tm_st_code = 'P' or t.tm_st_code = 'K' or t.tm_st_code = 'HS')";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string vendor = GlobalService.reader.GetString(1);
                string vendorname = GlobalService.reader.GetString(2);
                string itemcode = GlobalService.reader.GetString(3);
                string rev = GlobalService.reader.GetString(4);
                string mouldno = GlobalService.reader.GetString(5);
                string status = GlobalService.reader.GetString(6);
                string mouldcode = GlobalService.reader.GetString(7);
                string currency = GlobalService.reader.GetString(8);
                string amount = GlobalService.reader.GetString(9);
                string mpa = GlobalService.reader.GetString(10);
                string tmpfac = GlobalService.reader.GetString(11);
                string fac = GlobalService.reader.GetString(12);
                string po = GlobalService.reader.GetString(13);
                string poissued = GlobalService.reader.GetString(14);
                string oemasset = GlobalService.reader.GetString(15);
                string remarks = GlobalService.reader.GetString(16);

                waitingTable.Rows.Add(new object[]{chaseno, vendor, vendorname, itemcode, rev, mouldno, status, mouldcode, currency, amount,
                    mpa, tmpfac, fac, po, poissued, oemasset, remarks});
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            if (waitingTable.Rows.Count == 0)
                MessageBox.Show("No record can be downloaded");
            else
                ExportCsvUtil.ExportCsv(waitingTable, "", "WAITING LIST");
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmInStockRecord instockrecord = new frmInStockRecord();
            instockrecord.ShowDialog();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable templateTable = new DataTable();

            string[] headers = { "Chase No.", "Vendor", "Vendor Name", "Part No.", "Rev", "Mould No.", "Status", "Mould Code", "Currency", "Amount", 
                                   "MPA", "FA (Temp)", "FA", "PO", "Issued", "In Stock 50%", "In Stock Date", "OEM Asset", "Remarks" };

            foreach (string header in headers)
                templateTable.Columns.Add(header);

            string query = "select t.tm_chaseno, t.tm_vendor_code, v.v_name, t.tm_itemcode, t.tm_rev, t.tm_mouldno, t.tm_status, t.tm_mouldcode_code, t.tm_currency, t.tm_amount" +
                ", t.tm_mpa, t.tm_tmpfixedassetcode, t.tm_fixedassetcode, t.tm_po, t.tm_poissued, t.tm_instockdate50, t.tm_oemasset, t.tm_rm, t.tm_instockdate from" +
                " tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code and (t.tm_instockdate = 'Received' or t.tm_instockdate50 = 'Received') and tm_st_code != 'C'";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string chaseno = GlobalService.reader.GetString(0);
                string vendor = GlobalService.reader.GetString(1);
                string vendorname = GlobalService.reader.GetString(2);
                string itemcode = GlobalService.reader.GetString(3);
                string rev = GlobalService.reader.GetString(4);
                string mouldno = GlobalService.reader.GetString(5);
                string status = GlobalService.reader.GetString(6);
                string mouldcode = GlobalService.reader.GetString(7);
                string currency = GlobalService.reader.GetString(8);
                string amount = GlobalService.reader.GetString(9);
                string mpa = GlobalService.reader.GetString(10);
                string tmpfac = GlobalService.reader.GetString(11);
                string fac = GlobalService.reader.GetString(12);
                string po = GlobalService.reader.GetString(13);
                string poissued = GlobalService.reader.GetString(14);
                string is50 = GlobalService.reader.GetString(15);
                string oemasset = GlobalService.reader.GetString(16);
                string remarks = GlobalService.reader.GetString(17);
                string instock = GlobalService.reader.GetString(18);

                templateTable.Rows.Add(new object[]{chaseno, vendor, vendorname, itemcode, rev, mouldno, status, mouldcode, currency,
                    amount, mpa, tmpfac, fac, po, poissued, is50, instock, oemasset, remarks});
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            if (templateTable.Rows.Count == 0)
                MessageBox.Show("No record can be downloaded");
            else
                ExportCsvUtil.ExportCsv(templateTable, "", "TEMPLATE");
        }

        string filename = "";

        DataTable uploadTable;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                uploadTable = new DataTable();

                uploadTable = ImportXlsUtil.TranslateToTable(filename);

                for (int i = 0; i < uploadTable.Rows.Count; i++)
                {
                    string issued = uploadTable.Rows[i][14].ToString();
                    string instock50 = uploadTable.Rows[i][15].ToString();
                    string instock = uploadTable.Rows[i][16].ToString();

                    issued = ImportXlsUtil.ParseDateTime(issued).ToString("yyyy/MM/dd");

                    if (instock50 != "-----" && instock50 != "" && instock50!= "一回合格入庫" && instock50 != "Received" && instock50 != "已拆單、以合格同時入庫")
                        instock50 = ImportXlsUtil.ParseDateTime(instock50).ToString("yyyy/MM/dd");

                    if (instock != "" && instock != "Received" && instock != "#N/A")
                        instock = ImportXlsUtil.ParseDateTime(instock).ToString("yyyy/MM/dd");

                    uploadTable.Rows[i][14] = issued;
                    uploadTable.Rows[i][15] = instock50;
                    uploadTable.Rows[i][16] = instock;
                }

                frmUploadConfirm form = new frmUploadConfirm(uploadTable);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    if (!worker.IsBusy)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        dgvPreview.Cursor = Cursors.WaitCursor;
                        dgvResult.Cursor = Cursors.WaitCursor;
                        worker.RunWorkerAsync();
                    }
                    else
                        MessageBox.Show("Using by other process");
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataRow row in uploadTable.Rows)
                {
                    string chaseno = row.ItemArray[0].ToString();
                    string ulInStock = row.ItemArray[16].ToString();

                    string ulInStock50 = row.ItemArray[15].ToString();

                    if (ulInStock50 != "" && !ulInStock50.Contains("---") && ulInStock50 != "Received" && ulInStock50 != "一回合格入庫" && ulInStock50 != "已拆單、以合格同時入庫")
                    {
                        string vendorcode = DataChecking.getVendorCodeByChaseNo(chaseno);

                        string payterm = DataChecking.getPayTerm(vendorcode);

                        ulInStock50 = ImportXlsUtil.ParseDateTime(ulInStock50).ToString("yyyy/MM/dd");

                        string paymonth = "";

                        if (payterm == "HK01")
                            paymonth = ImportXlsUtil.ParseDateTime(ulInStock50).AddMonths(1).ToString("yyyy/MM/dd");
                        else if (payterm == "HK02")
                            paymonth = ImportXlsUtil.ParseDateTime(ulInStock50).AddMonths(2).ToString("yyyy/MM/dd");

                        string query = string.Format("update tb_betamould set tm_st_code = 'HS', tm_instockdate50 = '{0}', tm_moulditemviewer = 'Yes', tm_paydate = '{1}' where tm_chaseno = '{2}'", ulInStock50, paymonth, chaseno);

                        DataService.GetInstance().ExecuteNonQuery(query);
                    }

                    if (ulInStock != "" && ulInStock != "Received" && ulInStock!="#N/A")
                    {
                        string vendorcode = DataChecking.getVendorCodeByChaseNo(chaseno);

                        string payterm = DataChecking.getPayTerm(vendorcode);

                        string paymonth = "";

                        if (payterm == "HK01")
                            paymonth = ImportXlsUtil.ParseDateTime(ulInStock).AddMonths(1).ToString("yyyy/MM/dd");

                        else if (payterm == "HK02")
                            paymonth = ImportXlsUtil.ParseDateTime(ulInStock).AddMonths(2).ToString("yyyy/MM/dd");

                        ulInStock = ImportXlsUtil.ParseDateTime(ulInStock).ToString("yyyy/MM/dd");

                        if (ulInStock == "0001/03/02")
                            ulInStock = "";

                        string query = string.Format("update tb_betamould set tm_st_code = 'S', tm_instockdate = '{0}', tm_paydate = '{1}', tm_nofac = 'False', tm_moulditemviewer = 'Yes' where tm_chaseno = '{2}'", ulInStock, paymonth, chaseno);

                        DataService.GetInstance().ExecuteNonQuery(query);

                        string expenseText = string.Format("update tb_expensetransfer set et_poinstock = '{0}' where et_chaseno = '{1}'", ulInStock, chaseno);

                        DataService.GetInstance().ExecuteNonQuery(expenseText);

                        string query2 = string.Format("update TB_FA_APPROVAL set f_remarks = N'已入庫' where f_mould = '{0}'", chaseno);
                        DataServiceNew.GetInstance().ExecuteNonQuery(query2);
                    }
                }

                MessageBox.Show("Data uploaded");
            }
            catch
            {
                MessageBox.Show("Invalid Data Format");
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            dgvPreview.Cursor = Cursors.Default;
            dgvResult.Cursor = Cursors.Default;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;

            foreach (Control control in tbCheckbox.Controls)
            {
                CheckBox ckb = (CheckBox)control;
                if (ckb != checkbox && ckb.Checked)
                    ckb.Checked = false;
            }
        }

        private void txtCheckdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                this.SelectNextControl(this.ActiveControl, true, true, true, true);

            if (e.KeyCode == Keys.Left)
                this.SelectNextControl(this.ActiveControl, false, true, true, true);
        }

        public string Calculation(string strValor, int intNumDecimales)
        {
            string strAux = null;
            string strComas = null;
            string strPuntos = null;
            int intX = 0;
            bool bolMenos = false;

            strComas = "";
            if (strValor.Length == 0) return "";
            strValor = strValor.Replace(Application.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            if (strValor.Contains(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                strAux = strValor.Substring(0, strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                strComas = strValor.Substring(strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1);
            }
            else
            {
                strAux = strValor;
            }

            if (strAux.Substring(0, 1) == Application.CurrentCulture.NumberFormat.NegativeSign)
            {
                bolMenos = true;
                strAux = strAux.Substring(1);
            }

            strPuntos = strAux;
            strAux = "";
            while (strPuntos.Length > 3)
            {
                strAux = Application.CurrentCulture.NumberFormat.NumberGroupSeparator + strPuntos.Substring(strPuntos.Length - 3, 3) + strAux;
                strPuntos = strPuntos.Substring(0, strPuntos.Length - 3);
            }
            if (intNumDecimales > 0)
            {
                if (strValor.Contains(Application.CurrentCulture.NumberFormat.PercentDecimalSeparator))
                {
                    strComas = Application.CurrentCulture.NumberFormat.PercentDecimalSeparator + strValor.Substring(strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.PercentDecimalSeparator) + 1);
                    if (strComas.Length > intNumDecimales)
                    {
                        strComas = strComas.Substring(0, intNumDecimales + 1);
                    }
                }
            }
            strAux = strPuntos + strAux + strComas;
            return strAux;

        }

        private void textboxKeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Calculation(tb.Text, 50);
            tb.Select(tb.TextLength, 0);
        }

        private void txtPo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.search();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string po = txtPo.Text;

            //int thismonth = DateTime.Today.Month;
            //int selectedmonth = dpCheckDate.Value.Month;

            string checkdate = txtCheckdate.Text;
            string cav = txtCav.Text;
            string weight = txtWeight.Text;
            string equipment = txtEquipment.Text;
            string shot = txtShot.Text;
            string length = txtLength.Text;
            string width = txtWidth.Text;
            string height = txtHeight.Text;
            string remarks = txtInstockRemarks.Text;

            string query = string.Format("update tb_betamould set tm_checkdate = '{0}', tm_cav = '{1}', tm_weight = '{2}', tm_accessory = '{3}'" +
                            ", tm_camera = '{4}', tm_vertical = '{5}', tm_horizontal = '{6}', tm_height = '{7}', tm_instockremarks = '{8}' where tm_po = '{9}'", checkdate,
                            cav, weight, equipment, shot, length, width, height, remarks, po);

            Debug.WriteLine(query);
            DataService.GetInstance().ExecuteNonQuery(query);

            MessageBox.Show("Record has been saved");

            /*string checkdate  = dpCheckDate.Value.ToString("yyyy/MM/dd");

            int result = thismonth - selectedmonth;

            if (result > 3 || result < -3)
            {
                switch (MessageBox.Show("Checkdate selection out of range. Keep modifying?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        string query = string.Format("update tb_betamould set tm_checkdate = '{0}', tm_cav = '{1}', tm_weight = '{2}', tm_accessory = '{3}'" +
                            ", tm_camera = '{4}', tm_vertical = '{5}', tm_horizontal = '{6}', tm_height = '{7}', tm_instockremarks = '{8}' where tm_po = '{9}'", checkdate,
                            cav, weight, equipment, shot, length, width, height, remarks, po);

                        Debug.WriteLine(query);
                        DataService.GetInstance().ExecuteNonQuery(query);

                        MessageBox.Show("Record has been saved");
                        break;

                    case DialogResult.No:
                        break;
                }
            }*/
        }

        private void btnUploadTM_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls;*.xlsx"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                uploadTable = new DataTable();

                uploadTable = ofd.FileName.EndsWith(".xls") ? ImportXlsUtil.TranslateToTable(ofd.FileName) : ImportXls2007Util.TranslateToTable(ofd.FileName);

                DataTable tmptable = new DataTable();

                tmptable.Columns.Add("Chase No.");
                tmptable.Columns.Add("Check Date");
                tmptable.Columns.Add("In Stock Remarks");
                tmptable.Columns.Add("In Stock Date");

                foreach (DataRow row in uploadTable.Rows)
                {
                    string chaseno = row.ItemArray[0].ToString();

                    if (chaseno.StartsWith("CM"))
                    {
                        string instockdate = ImportXls2007Util.ParseDateTime(row.ItemArray[3].ToString()).ToString("yyyy/MM/dd");

                        tmptable.Rows.Add(new object[] { chaseno, "", "", instockdate });
                    }
                    else
                    {
                        string checkdate = ImportXlsUtil.ParseDateTime(row.ItemArray[1].ToString()).ToString("yyyy/MM/dd");
                        if (checkdate == "0001/01/01") checkdate = "";

                        string instockremarks = row.ItemArray[2].ToString();

                        string instockdate = ImportXlsUtil.ParseDateTime(row.ItemArray[3].ToString()).ToString("yyyy/MM/dd");

                        tmptable.Rows.Add(new object[] { chaseno, checkdate, instockremarks, instockdate });
                    }
                }

                frmUploadConfirm form = new frmUploadConfirm(tmptable);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    if (!workerTM.IsBusy)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        dgvPreview.Cursor = Cursors.WaitCursor;
                        dgvResult.Cursor = Cursors.WaitCursor;
                        workerTM.RunWorkerAsync();
                    }
                    else
                        MessageBox.Show("Using by other process");
                }
            }
        }

        private void workerTM_DoWork(object sender, DoWorkEventArgs e)
        {
            foreach (DataRow row in uploadTable.Rows)
            {
                string chaseno = row.ItemArray[0].ToString();

                if (chaseno.StartsWith("CM"))
                {
                    string instockdate = ImportXls2007Util.ParseDateTime(row.ItemArray[3].ToString()).ToString("yyyy/MM/dd");

                    string query = string.Format("update tb_betamould set tm_instockdate = '{0}', tm_st_code = 'S' where tm_chaseno = '{1}'", instockdate, chaseno);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }
                else
                {
                    string checkdate = row.ItemArray[1].ToString();
                    string instockremarks = row.ItemArray[2].ToString();
                    string instockdate = row.ItemArray[3].ToString();

                    string datetime = DateTime.Today.ToString("yyyy/MM/dd");

                    checkdate = ImportXlsUtil.ParseDateTime(checkdate).ToString("yyyy/MM/dd");
                    if (checkdate == "0001/01/01") checkdate = "";

                    instockdate = ImportXlsUtil.ParseDateTime(instockdate).ToString("yyyy/MM/dd");
                    if (instockdate == "0001/01/01") instockdate = "";

                    string query = string.Format("update tb_betamould set tm_instockdate = '{0}', tm_st_code = 'S', tm_checkdate = '{1}', tm_instockremarks = '{2}', tm_moulditemviewer = 'Yes' where tm_chaseno = '{3}'", instockdate, checkdate, instockremarks, chaseno);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }
            }
        }

        private void workerTM_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            dgvPreview.Cursor = Cursors.Default;
            dgvResult.Cursor = Cursors.Default;
        }

        private void btnTemplateTM_Click(object sender, EventArgs e)
        {
            DataTable templateTable = new DataTable();

            string[] headers = { "Chase No.", "Check Date", "In Stock Remarks", "In Stock Date" };

            foreach (string header in headers)
                templateTable.Columns.Add(header);

            ExportXlsUtil.XlsUtil(templateTable);
        }

        private void btnRollBack_Click(object sender, EventArgs e)
        {
            frmInStockRollBack form = new frmInStockRollBack();
            form.ShowDialog();
        }
    }
}
