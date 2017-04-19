using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.checking;
using System.Data.SqlClient;
using System.Diagnostics;
using Mould_System.services;
using CustomUtil.utils.authentication;
using Mould_System.file.excel;
using CustomUtil.utils.export;
using CustomUtil.utils.import;

namespace Mould_System.forms._1.quotation
{
    public partial class ucQuotation : UserControl
    {
        public event EventHandler buttonClick;
        public event EventHandler modifyClick;
        public event EventHandler menuClick;
        public event EventHandler setClick;
        public event EventHandler commonClick;

        private DataTable table = null;

        public ucQuotation()
        {
            InitializeComponent();

            this.setupCombobox();

            dgvQuotation.Visible = false;
            lblTotal.Visible = false;

            DataChecking.DoubleBuffered(dgvQuotation, true);
        }

        private void setupCombobox()
        {
            this.cbSearch.Items.Add("All");
            this.cbSearch.Items.Add("Chase No.");
            this.cbSearch.Items.Add("Mould No.");
            this.cbSearch.Items.Add("Part No.");
            this.cbSearch.Items.Add("Vendor Code");
            this.cbSearch.Items.Add("Mould Code");
            this.cbSearch.Items.Add("Mould No. (Common)");
            this.cbSearch.Items.Add("Currency");
            this.cbSearch.SelectedIndex = 3;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (buttonClick != null)
                buttonClick(this, new EventArgs());
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

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select t.tm_id as id, q.st_status as quostatus, t.tm_chaseno as chaseno, t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_group as pgroup, t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_mouldno as mouldno" +
            ", t.tm_status as status, t.tm_type as type, t.tm_mouldcode_code as mouldcode, t.tm_currency as currency, t.tm_amount as amount, t.tm_amounthkd as amounthkd, t.tm_mpa as mpa" +
            ", t.tm_st_code as qstatus, q.st_kdcstatus as kdcstatus, t.tm_oemasset as oemasset, t.tm_rm as remarks,  t.tm_common as common, t.tm_createdby as createdby, t.tm_indate as created" +
            " from tb_betamould as t, tb_betaqstatus as q, tb_vendor as v where t.tm_vendor_code = v.v_code and t.tm_st_code = q.st_code and (t.tm_transfer = '' or t.tm_transfer = 'Transfer') and t.tm_disposalno = ''";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)//All
                commandText = _commandText;
            if (cbSearch.SelectedIndex == 1)//Chase No
                commandText = _commandText + string.Format(" and tm_chaseno like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 2)//Mould No
                commandText = _commandText + string.Format(" and tm_mouldno like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 3)//Item Code
                commandText = _commandText + string.Format(" and tm_itemcode like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 4)//Vendor Code
                commandText = _commandText + string.Format(" and tm_vendor_code like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 5)//Mould Code
                commandText = _commandText + string.Format(" and tm_mouldcode_code like '%{0}%'", txtSearch.Text);
            if (cbSearch.SelectedIndex == 6)//Mould No (Common)
            {
                commandText = string.Format("select t.tm_id as id, q.st_status as quostatus, t.tm_chaseno as chaseno, t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_group as pgroup, t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_mouldno as mouldno" +
            ", t.tm_status as status, t.tm_type as type, t.tm_mouldcode_code as mouldcode, t.tm_currency as currency, t.tm_amount as amount, t.tm_amounthkd as amounthkd, t.tm_mpa as mpa" +
            ", t.tm_st_code as qstatus, q.st_kdcstatus as kdcstatus, t.tm_oemasset as oemasset, t.tm_rm as remarks,  t.tm_common as common, t.tm_createdby as createdby, t.tm_indate as created" +
            " from tb_betamould as t, tb_betaqstatus as q, tb_vendor as v, tb_setcommon as sc where t.tm_vendor_code = v.v_code and t.tm_mouldno = sc.sc_oldmouldno and t.tm_st_code = q.st_code and (t.tm_transfer = '' or t.tm_transfer = 'Transfer') and t.tm_disposalno = '' and sc.sc_mouldno like '%{0}%'", txtSearch.Text);
            }
            if (cbSearch.SelectedIndex == 7)
                commandText = _commandText + string.Format(" and tm_currency = '{0}'", txtSearch.Text);

            SqlDataAdapter sda = new SqlDataAdapter(commandText, DataService.GetInstance().Connection);
            sda.Fill(table);

            this.SortByMultiColumns();

            dgvQuotation.Sort(dgvQuotation.Columns[2], ListSortDirection.Ascending);

            dgvQuotation.Visible = true;
            lblTotal.Visible = true;

            lblTotal.Text = "ROWS COUNT: " + dgvQuotation.Rows.Count;

            for (int i = 0; i < table.Columns.Count; i++)
                Debug.WriteLine(table.Columns[i].ColumnName);
        }

        private void dgvQuotation_DoubleClick(object sender, EventArgs e)
        {
            if (dgvQuotation.SelectedRows == null)
                return;
            else
            {
                GlobalService.selectedId = Convert.ToInt32(dgvQuotation.SelectedRows[0].Cells[0].Value);

                if (menuClick != null)
                    menuClick(this, new EventArgs());
            }
        }

        private void menuDetail_Click(object sender, EventArgs e)
        {
            if (dgvQuotation.SelectedRows == null)
                return;
            else
            {
                GlobalService.selectedId = Convert.ToInt32(dgvQuotation.SelectedRows[0].Cells[0].Value);

                if (menuClick != null)
                    menuClick(this, new EventArgs());
            }
        }

        private void dgvQuotation_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (((dgvQuotation.Rows[0].Height * dgvQuotation.Rows.Count) + dgvQuotation.ColumnHeadersHeight) < e.Location.Y)
                {
                    dgvQuotation.ClearSelection();
                }
                else
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        if (dgvQuotation.SelectedRows.Count == 1)
                        {
                            var hti = dgvQuotation.HitTest(e.X, e.Y);
                            dgvQuotation.ClearSelection();
                            if (((dgvQuotation.Rows[0].Height * dgvQuotation.Rows.Count) + dgvQuotation.ColumnHeadersHeight) >= e.Location.Y)
                                dgvQuotation.Rows[hti.RowIndex].Selected = true;
                        }
                        else
                        {
                            var hti = dgvQuotation.HitTest(e.X, e.Y);
                            if (((dgvQuotation.Rows[0].Height * dgvQuotation.Rows.Count) + dgvQuotation.ColumnHeadersHeight) >= e.Location.Y)
                                dgvQuotation.Rows[hti.RowIndex].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void menuModify_Click(object sender, EventArgs e)
        {
            string selectedMould = dgvQuotation.SelectedRows[0].Cells[8].Value.ToString();
            string selectedItemCode = dgvQuotation.SelectedRows[0].Cells[6].Value.ToString();
            string selectedRev = dgvQuotation.SelectedRows[0].Cells[7].Value.ToString();

            switch (MessageBox.Show("Are you sure to MODIFY target Mould No: " + selectedMould + ",\nItem Code: " + selectedItemCode + ", Rev: " + selectedRev + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    //this.modify();
                    GlobalService.selectedChaseno = dgvQuotation.SelectedRows[0].Cells[2].Value.ToString();

                    if (modifyClick != null)
                        modifyClick(this, new EventArgs());
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void modify()
        {
            //table.Rows.Add();

            int lastId = 0;

            string text = "select top 1 tm_id from tb_betamould order by tm_id desc";
            GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

            while (GlobalService.reader.Read())
                lastId = GlobalService.reader.GetInt32(0);

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            lastId = lastId + 1;

            string strChaseNo = DataChecking.getLastChaseNo();

            string itemcode = dgvQuotation.SelectedRows[0].Cells[6].Value.ToString();

            string rev = (Convert.ToInt32(DataChecking.getLastRev(itemcode)) + 1).ToString();
            if (Convert.ToInt32(rev) < 10)
                rev = "0" + rev;

            string mouldno = dgvQuotation.SelectedRows[0].Cells[8].Value.ToString();
            string status = "Modify";
            string type = dgvQuotation.SelectedRows[0].Cells[10].Value.ToString();
            string currency = DataChecking.getCurrency(dgvQuotation.SelectedRows[0].Cells[3].Value.ToString());
            string amount = dgvQuotation.SelectedRows[0].Cells[13].Value.ToString();
            string mpa = dgvQuotation.SelectedRows[0].Cells[15].FormattedValue.ToString();
            string vendor = dgvQuotation.SelectedRows[0].Cells[3].Value.ToString();
            string vendorname = dgvQuotation.SelectedRows[0].Cells[4].Value.ToString();
            string mouldcode = dgvQuotation.SelectedRows[0].Cells[11].Value.ToString();
            string qstatus = "";
            //string owner = dgvQuotation.SelectedRows[0].Cells[13].Value.ToString();

            string oemasset = dgvQuotation.SelectedRows[0].Cells[18].Value.ToString();
            string remarks = dgvQuotation.SelectedRows[0].Cells[19].Value.ToString();
            string category = "";
            string commonstatus = dgvQuotation.SelectedRows[0].Cells[20].Value.ToString();
            string purchasegroup = dgvQuotation.SelectedRows[0].Cells[5].Value.ToString();

            if (DataChecking.amountWithRate(currency, amount) < 10000)
            {
                category = "K";

                if (vendor != "" && mouldcode != "" && mouldno != "" && itemcode != "" && rev != "" && amount != "")
                    qstatus = "U";

                else
                    qstatus = "Q";
            }
            else
            {
                category = "A";

                if (vendor != "" && mouldcode != "" && mouldno != "" && itemcode != "" && rev != "" && amount != "" && oemasset == "")
                    qstatus = "F";

                else if (vendor != "" && mouldcode != "" && mouldno != "" && itemcode != "" && rev != "" && amount != "" && oemasset != "")
                {
                    qstatus = "U";
                    category = "K";
                }
                else
                    qstatus = "Q";
            }

            string amounthkd = DataChecking.amountWithRate(currency, amount).ToString("#.##");
            string kdcstatus = DataChecking.getKdcStatus(qstatus);
            string currentstatus = DataChecking.getCurrentStatus(qstatus);

            string createdperson = AdUtil.getUsername("kmhk.local");
            string createddatetime = DateTime.Today.ToString("yyyy/MM/dd");

            string accountcode = "";
            string costcentre = "";

            if (oemasset != "")
            {
                accountcode = DataChecking.getAccountCode(oemasset);
                costcentre = DataChecking.getCostCentre(oemasset);
            }
            else
            {

            }
            table.Rows.Add(new object[]{lastId, currentstatus, strChaseNo, vendor, vendorname, purchasegroup, itemcode, rev, mouldno,
                status, type, mouldcode, currency, amount, amounthkd, mpa, qstatus, kdcstatus, oemasset, remarks, commonstatus, createdperson, createddatetime});

            string itemtext = mouldno + "MP+" + mouldcode + "+" + status;
            string projecttext = itemcode + "-" + rev;
            string request = itemcode + rev;

            string quantity = "";

            if (mpa == "True")
                quantity = "2";
            else
                quantity = "1";

            string model = itemcode.Substring(2, 3);
            string common = DataChecking.getCommon(mouldno, itemcode);

            string insertText = string.Format("insert into tb_betamould (tm_chaseno, tm_mouldno, tm_itemcode, tm_rev, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd" +
                    ", tm_mpa, tm_mouldcode_code, tm_vendor_code, tm_st_code, tm_qty, tm_itemtext, tm_projecttext, tm_request, tm_owner, tm_category, tm_indate, tm_common, tm_oemasset, tm_rm, tm_createdby, tm_model) values" +
                    " ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}')", strChaseNo, mouldno, itemcode, rev, status, type,
                    currency, amount, amounthkd, mpa, mouldcode, vendor, qstatus, quantity, itemtext, projecttext, request, "KDTHK", category, DateTime.Today.ToString("yyyy/MM/dd"), common, oemasset, remarks, AdUtil.getUsername("kmhk.local"), model);

            DataService.GetInstance().ExecuteNonQuery(insertText);

            lblTotal.Text = "ROWS COUNT: " + dgvQuotation.Rows.Count;
        }

        private void menuSet_Click(object sender, EventArgs e)
        {
            GlobalService.gMouldNo = dgvQuotation.SelectedRows[0].Cells[8].Value.ToString();
            GlobalService.gItemCode = dgvQuotation.SelectedRows[0].Cells[6].Value.ToString();

            if (setClick != null)
                setClick(this, new EventArgs());
        }

        private void menuCommon_Click(object sender, EventArgs e)
        {
            GlobalService.gMouldNo = dgvQuotation.SelectedRows[0].Cells[8].Value.ToString();
            GlobalService.gItemCode = dgvQuotation.SelectedRows[0].Cells[6].Value.ToString();

            if (commonClick != null)
                commonClick(this, new EventArgs());
        }

        private void SortByMultiColumns()
        {
            DataView view = table.DefaultView;
            view.Sort = "itemcode asc, mouldno asc, rev asc";
            dgvQuotation.DataSource = view;
        }

        private void dELETEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> chasenolist = new List<string>();

            foreach (DataGridViewRow row in dgvQuotation.SelectedRows)
            {
                string chaseno = row.Cells[2].Value.ToString();
                chasenolist.Add(chaseno);
            }

            chasenolist = chasenolist.Distinct().ToList();

            switch (MessageBox.Show("Are you sure to delete selected items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    foreach (string chaseno in chasenolist)
                    {
                        string text = string.Format("update TB_FA_APPROVAL set f_remarks = N'已刪除' where f_chaseno = '{0}'", chaseno);
                        DataServiceNew.GetInstance().ExecuteNonQuery(text);

                        string query = string.Format("delete from tb_betamould where tm_chaseno = '{0}'", chaseno);
                        DataService.GetInstance().ExecuteNonQuery(query);
                    }

                    this.loadData();
                    break;

                case DialogResult.No:
                    break;
            }
            
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (dgvQuotation.SelectedRows.Count == 0)
            {
                contextMenuStrip.Enabled = false;
            }
            else
            {
                contextMenuStrip.Enabled = true;
            }
        }

        private void cbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            string[] headers = {"chaseno", "partno", "rev", "mould", "div", "type", "currency", "amount", "amounthkd", "mpa", "fa", "tmpfa", "qty", "common",
                                   "itemtext", "request", "indate", "deliverydate", "projecttext", "model", "po", "porev", "issued", "category", "ringi", "vendor",
                                   "mouldcode", "status", "owner", "oem", "remarks", "instockdate", "instockdate50", "pgroup", "accountcode", "costcentre",
                                   "checkdate", "checkdate2", "cav", "weight", "equipment", "shot", "vertical", "horizontal", "height", "ismodify", "instockremarks",
                                   "collectdate", "pass", "pcs", "cnis50", "cntax", "cndate", "cnsenddate"};

            foreach (string header in headers)
                table.Columns.Add(header);

            foreach (DataGridViewRow row in dgvQuotation.Rows)
            {
                string _chaseno = row.Cells[2].Value.ToString().Trim();

                string query = string.Format("select tm_chaseno, tm_itemcode, tm_rev, tm_mouldno, tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd, tm_mpa" +
                    ", tm_fixedassetcode, tm_tmpfixedassetcode, tm_qty, tm_common, tm_itemtext, tm_request, tm_indate, tm_deliverydate, tm_projecttext, tm_model" +
                    ", tm_po, tm_porev, tm_poissued, tm_category, tm_ringi_code, tm_vendor_code, tm_mouldcode_code, tm_st_code, tm_owner, tm_oemasset, tm_rm" +
                    ", tm_instockdate, tm_instockdate50, tm_group, tm_accountcode, tm_costcentre, tm_checkdate, tm_checkdate2, tm_cav, tm_weight, tm_accessory" +
                    ", tm_camera, tm_vertical, tm_horizontal, tm_height, tm_ismodify, tm_instockremarks, tm_collectdate, tm_passremarks, tm_pcs, tm_is50, tm_tax, tm_cndatetime" +
                    ", tm_cnsendtime from tb_betamould where tm_chaseno = '{0}'", _chaseno);

                using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        string chaseno = reader.GetString(0).Trim();
                        string partno = reader.GetString(1).Trim();
                        string rev = reader.GetString(2).Trim();
                        string mould = reader.GetString(3).Trim();
                        string div = reader.GetString(4).Trim();
                        string type = reader.GetString(5).Trim();
                        string curr = reader.GetString(6).Trim();
                        string amt = reader.GetString(7).Trim();
                        string amthkd = reader.GetString(8).Trim();
                        string mpa = reader.GetString(9).Trim();
                        string fa = reader.GetString(10).Trim();
                        string tmpfa = reader.GetString(11).Trim();
                        string qty = reader.GetString(12).Trim();
                        string common = reader.GetString(13).Trim();
                        string itemtext = reader.GetString(14).Trim();
                        string request = reader.GetString(15).Trim();
                        string indate = reader.GetString(16).Trim();
                        string deliverydate = reader.GetString(17).Trim();
                        string projecttext = reader.GetString(18).Trim();
                        string model = reader.GetString(19).Trim();
                        string po = reader.GetString(20).Trim();
                        string porev = reader.GetString(21).Trim();
                        string issued = reader.GetString(22).Trim();
                        string category = reader.GetString(23).Trim();
                        string ringi = reader.GetString(24).Trim();
                        string vendor = reader.GetString(25).Trim();
                        string mouldcode = reader.GetString(26).Trim();
                        string status = reader.GetString(27).Trim();
                        string owner = reader.GetString(28).Trim();
                        string oem = reader.GetString(29).Trim();
                        string remarks = reader.GetString(30).Trim();
                        string instock = reader.GetString(31).Trim(); 
                        string instock50 = reader.GetString(32).Trim(); 
                        string group = reader.GetString(33).Trim(); 
                        string ac = reader.GetString(34).Trim(); 
                        string cc = reader.GetString(35).Trim();
                        string checkdate = reader.GetString(36).Trim();
                        string checkdate2 = reader.GetString(37).Trim();
                        string cav = reader.GetString(38).Trim();
                        string weight = reader.GetString(39).Trim();
                        string equipment = reader.GetString(40).Trim();
                        string shot = reader.GetString(41).Trim();
                        string vertical = reader.GetString(42).Trim();
                        string horizontal = reader.GetString(43).Trim();
                        string height = reader.GetString(44).Trim();
                        string ismodify = reader.GetString(45).Trim();
                        string instockremarks = reader.GetString(46).Trim();
                        string collectdate = reader.GetString(47).Trim();
                        string pass = reader.GetString(48).Trim();
                        string pcs = reader.GetString(49).Trim();
                        string is50 = reader.GetString(50).Trim();
                        string tax = reader.GetString(51).Trim();
                        string cndate = reader.GetString(52).Trim();
                        string cnsenddate = reader.GetString(53).Trim();

                        table.Rows.Add(chaseno, partno, rev, mould, div, type, curr, amt, amthkd, mpa, fa, tmpfa, qty, common, itemtext, request, indate, deliverydate,
                            projecttext, model, po, porev, issued, category, ringi, vendor, mouldcode, status, owner, oem, remarks, instock, instock50, group,
                            ac, cc, checkdate, checkdate2, cav, weight, equipment, shot, vertical, horizontal, height, ismodify, instockremarks, collectdate, pass,
                            pcs, is50, tax, cndate, cnsenddate);

                    }
                }
            }
            ExportXlsUtil.XlsUtil(table);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            DataUtil.UpdateData();
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith(".xls") ? ImportExcel2003.TranslateToTable(ofd.FileName) : ImportExcel2007.TranslateToTable(ofd.FileName);

                foreach (DataRow row in table.Rows)
                {
                    string chaseno = row.ItemArray[0].ToString().Trim();
                    string partno = row.ItemArray[1].ToString().Trim();
                    string rev = row.ItemArray[2].ToString().Trim();
                    if (rev.Length == 1) rev = "0" + rev;
                    string mouldno = row.ItemArray[3].ToString().Trim();
                    string div = row.ItemArray[4].ToString().Trim();
                    string curr = row.ItemArray[5].ToString().Trim();
                    string amt = row.ItemArray[6].ToString().Trim();
                    string amthkd = row.ItemArray[7].ToString().Trim();
                    string mpa = row.ItemArray[8].ToString().Trim();
                    string fa = row.ItemArray[9].ToString().Trim();
                    string tmpfa = row.ItemArray[10].ToString().Trim();
                    string qty = row.ItemArray[11].ToString().Trim();
                    string model = row.ItemArray[12].ToString().Trim();
                    string po = row.ItemArray[13].ToString().Trim();
                    string porev = row.ItemArray[14].ToString().Trim();
                    string issued = ImportExcel2003.ParseDateTime(row.ItemArray[15].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (issued == "0001/01/01") issued = row.ItemArray[15].ToString().Trim();
                    string category = row.ItemArray[16].ToString().Trim();
                    string ringi = row.ItemArray[17].ToString().Trim();
                    string vendor = row.ItemArray[18].ToString().Trim();
                    if(vendor.Length==9) vendor = "0"+vendor;
                    string mouldcode = row.ItemArray[19].ToString().Trim();
                    string status = row.ItemArray[20].ToString().Trim();
                    string oem = row.ItemArray[21].ToString().Trim();
                    string remarks = row.ItemArray[22].ToString().Trim();
                    string instock = ImportExcel2003.ParseDateTime(row.ItemArray[23].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (instock == "0001/01/01") instock = row.ItemArray[23].ToString().Trim();
                    string instock50 = ImportExcel2003.ParseDateTime(row.ItemArray[24].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (instock50 == "0001/01/01") instock50 = row.ItemArray[24].ToString().Trim();
                    string pgroup = row.ItemArray[25].ToString().Trim();
                    string ac = row.ItemArray[26].ToString().Trim();
                    string cc = row.ItemArray[27].ToString().Trim();
                    string checkdate = ImportExcel2003.ParseDateTime(row.ItemArray[28].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (checkdate == "0001/01/01") checkdate = row.ItemArray[28].ToString().Trim();
                    string cav = row.ItemArray[29].ToString().Trim();
                    string weight = row.ItemArray[30].ToString().Trim();
                    string equipment = row.ItemArray[31].ToString().Trim();
                    string shot = row.ItemArray[32].ToString().Trim();
                    string vertical = row.ItemArray[33].ToString().Trim();
                    string horizontal = row.ItemArray[34].ToString().Trim();
                    string height = row.ItemArray[35].ToString().Trim();
                    string collectdate = ImportExcel2003.ParseDateTime(row.ItemArray[36].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (collectdate == "0001/01/01") collectdate = row.ItemArray[36].ToString().Trim();

                    string itemtext = mouldno + "MP+" + mouldcode + "+" + div;
                    string projecttext = partno + "-" + rev;
                    string type = "Single";
                    string owner = "KDTHK";
                    string indate = DateTime.Today.ToString("yyyy/MM/dd");
                    string request = partno + rev;

                    if (chaseno == "") continue;

                    string st = status == "入庫濟" ? "S" : "K";
                    string query = string.Format("if not exists (select * from tb_betamould where tm_chaseno = '{0}') insert into tb_betamould (tm_chaseno, tm_itemcode, tm_rev, tm_mouldno" +
                        ", tm_status, tm_type, tm_currency, tm_amount, tm_amounthkd, tm_mpa, tm_fixedassetcode, tm_tmpfixedassetcode, tm_qty, tm_itemtext, tm_request, tm_indate, tm_projecttext" +
                        ", tm_model, tm_po, tm_porev, tm_poissued, tm_category, tm_ringi_code, tm_vendor_code, tm_mouldcode_code, tm_st_code, tm_owner, tm_rm, tm_instockdate" +
                        ", tm_instockdate50, tm_group, tm_accountcode, tm_costcentre, tm_checkdate, tm_cav, tm_weight, tm_accessory, tm_camera, tm_vertical, tm_horizontal, tm_height, tm_collectdate)" +
                        " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', '{24}', '{25}', '{26}', N'{27}'" +
                        ", '{28}', '{29}', '{30}', '{31}', '{32}', '{33}', '{34}', '{35}', '{36}', '{37}', '{38}', '{39}', '{40}', '{41}')", chaseno, partno, rev, mouldno, div, type, curr, amt, amthkd, mpa, fa, tmpfa,
                        qty, itemtext, request, indate, projecttext, model, po, porev, issued, category, ringi, vendor, mouldcode, st, owner, remarks, instock, instock50, pgroup, ac, cc, checkdate,
                        cav, weight, equipment, shot, vertical, horizontal, height, collectdate);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }

                MessageBox.Show("Record has been saved.");
            }
        }
    }
}
