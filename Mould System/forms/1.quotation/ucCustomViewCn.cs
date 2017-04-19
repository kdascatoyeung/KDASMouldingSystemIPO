using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.checking;
using Mould_System.services;
using System.Data.SqlClient;
using Mould_System.file.csv;
using System.Diagnostics;
using System.IO;

namespace Mould_System.forms._1.quotation
{
    public partial class ucCustomViewCn : UserControl
    {
        private DataTable table = null;

        private List<string> colList;

        public ucCustomViewCn()
        {
            InitializeComponent();

            LoadCriteria();

            DataChecking.DoubleBuffered(dgvCustomview, true);

            dgvCustomview.Visible = false;

            cbSearch.SelectedIndex = 3;

            LoadStatus();
        }

        private void LoadCriteria()
        {
            cbCriteria.Items.Clear();

            cbCriteria.Items.Add("All");

            string query = "select cr_criteria from tb_criteria group by cr_criteria";

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    cbCriteria.Items.Add(reader.GetString(0).Trim());
            }

            cbCriteria.SelectedIndex = 0;
        }

        private void LoadStatus()
        {
            cbStatus.Items.Clear();

            cbStatus.Items.Add("Please select....");

            string query = "select st_status from tb_betaqstatus";

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    cbStatus.Items.Add(reader.GetString(0).Trim());
            }

            cbStatus.SelectedIndex = 0;
        }

        private void LoadData()
        {
            table = new DataTable();

            string _commandText = "select st.st_status as status, t.tm_oemasset as OemAsset, t.tm_category as Category, t.tm_itemtext as ItemText, t.tm_accountcode as AccountCode, t.tm_costcentre as CostCentre" +
                ", t.tm_tmpfixedassetcode as TmpFac, t.tm_fixedassetcode as Fac, t.tm_ringi_code as Ringi, t.tm_chaseno as ChaseNo, t.tm_projecttext as ProjectText, t.tm_vendor_code as Vendor, v.v_name as VendorName" +
                ", t.tm_group as pgroup, t.tm_model as Model, t.tm_itemcode as ItemCode, t.tm_rev as Rev, t.tm_mouldno as MouldNo, t.tm_status as div, t.tm_type as type, t.tm_mouldcode_code as MouldCode" +
                ", t.tm_currency as Currency, t.tm_amount as Amount, t.tm_amounthkd as AmountHkd, t.tm_pcs as Pcs, t.tm_rm as Remarks, t.tm_purchaserequest as purchaserequest, t.tm_po as Pono, t.tm_porev as PoRev, t.tm_poissued as Issued" +
                ", t.tm_mpa as MPA, t.tm_instockdate50 as InStock50, t.tm_instockdate as InStockDate, t.tm_checkdate as CheckDate, t.tm_cav as Cav, t.tm_weight as Weight, t.tm_accessory as Equipment" +
                ", t.tm_camera as Shot, t.tm_vertical as Length, t.tm_horizontal as Width, t.tm_height as Height, t.tm_instockremarks as instockremarks, t.tm_createdby as CreatedBy, t.tm_indate as Created, t.tm_ismodify as ismodify, t.tm_vnonly as vnonly, (cast(t.tm_amount as float)+cast(t.tm_tax as float)) as total, t.tm_cndatetime as cnsend, t.tm_cnsendtime as cnreturn from tb_betamould as t, tb_vendor as v, tb_betaqstatus as st" +
                " where t.tm_vendor_code = v.v_code and t.tm_st_code = st.st_code and (t.tm_currency = 'RMB' or t.tm_vendor_code like '022%')";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)//All
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)//Chase No.
                commandText = _commandText + string.Format(" and t.tm_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)//Mould No.
                commandText = _commandText + string.Format(" and t.tm_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)//Part No.
                commandText = _commandText + string.Format(" and t.tm_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)//Vendor Code
                commandText = _commandText + string.Format(" and t.tm_vendor_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)//Fixed Asset Code
                commandText = _commandText + string.Format(" and t.tm_fixedassetcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 6)//Ringi
                commandText = _commandText + string.Format(" and t.tm_ringi_code like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 7)//PO
                commandText = _commandText + string.Format(" and t.tm_po like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 8)//PO Issued
                commandText = _commandText + string.Format(" and t.tm_poissued like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 9)//In Stock Date 50%
                commandText = _commandText + string.Format(" and t.tm_instockdate50 like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 10)//In Stock Date
                commandText = _commandText + string.Format(" and t.tm_instockdate like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 11)//Quotation Status
            {
                string stname = cbStatus.SelectedItem.ToString();
                commandText = _commandText + string.Format(" and st.st_status = '{0}'", stname);
            }

            if (cbSearch.SelectedIndex == 12)//Oem Asset
                commandText = _commandText + string.Format(" and t.tm_oemasset like '%{0}%'", txtSearch.Text);

            /*if (cbSearch.SelectedIndex == 13)//Mould No. (Common)
            {
                commandText = string.Format("select st.st_status as status, t.tm_oemasset as OemAsset, t.tm_category as Category, t.tm_itemtext as ItemText, t.tm_accountcode as AccountCode, t.tm_costcentre as CostCentre" +
                ", t.tm_tmpfixedassetcode as TmpFac, t.tm_fixedassetcode as Fac, t.tm_ringi_code as Ringi, t.tm_chaseno as ChaseNo, t.tm_projecttext as ProjectText, t.tm_vendor_code as Vendor, v.v_name as VendorName" +
                ", t.tm_group as pgroup, t.tm_model as Model, t.tm_itemcode as ItemCode, t.tm_rev as Rev, t.tm_mouldno as MouldNo, t.tm_status as div, t.tm_type as type, t.tm_mouldcode_code as MouldCode" +
                ", t.tm_currency as Currency, t.tm_amount as Amount, t.tm_amounthkd as AmountHkd, t.tm_pcs as Pcs, t.tm_rm as Remarks, t.tm_purchaserequest as purchaserequest, t.tm_po as Pono, t.tm_porev as PoRev, t.tm_poissued as Issued" +
                ", t.tm_mpa as MPA, t.tm_instockdate50 as InStock50, t.tm_instockdate as InStockDate, t.tm_checkdate as CheckDate, t.tm_cav as Cav, t.tm_weight as Weight, t.tm_accessory as Equipment" +
                ", t.tm_camera as Shot, t.tm_vertical as Length, t.tm_horizontal as Width, t.tm_height as Height, t.tm_instockremarks as instockremarks, t.tm_createdby as CreatedBy, t.tm_indate as Created, t.tm_ismodify as ismodify, t.tm_vnonly as vnonly from tb_betamould as t, tb_vendor as v, tb_betaqstatus as st, tb_setcommon as sc" +
                " where t.tm_vendor_code = v.v_code and t.tm_st_code = st.st_code and t.tm_mouldno = sc.sc_oldmouldno and sc.sc_mouldno like '%{0}%'", txtSearch.Text);
            }*/

            SqlCommand command = new SqlCommand(commandText, DataService.GetInstance().Connection);
            GlobalService.adapter = new SqlDataAdapter(command);
            GlobalService.adapter.Fill(table);


            dgvCustomview.DataSource = table;

            dgvCustomview.Sort(dgvCustomview.Columns[9], ListSortDirection.Ascending);

            dgvCustomview.Visible = true;
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                txtSearch.Enabled = false;
                txtSearch.Visible = true;
                cbStatus.Visible = false;

                this.LoadData();
            }
            else if (cbSearch.SelectedIndex == 11)
            {
                txtSearch.Visible = false;
                cbStatus.Visible = true;
                cbStatus.SelectedIndex = 0;
            }
            else
            {
                txtSearch.Enabled = true;
                txtSearch.Visible = true;
                cbStatus.Visible = false;
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCriteria();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvCustomview.Visible == false)
            {
                MessageBox.Show("Please get the search result first");
                return;
            }

             try
            {
                DataTable dgvTable = (DataTable)(dgvCustomview.DataSource);

                this.Cursor = Cursors.WaitCursor;
                DataTable tmptable = new DataTable();

                if (cbCriteria.SelectedIndex != 0)
                    tmptable = new DataView(dgvTable).ToTable(false, colList.ToArray());
                else
                    tmptable = dgvTable;

                if (dgvTable.Rows.Count > 0)
                    ExportCsvUtil.ExportCsv(tmptable, "", "CUSTOM" + DateTime.Today.ToString("yyyyMMdd"));
                else
                    MessageBox.Show("No Record can be downloaded");

                this.Cursor = Cursors.Default;
            }
             catch (Exception ex)
             {
                 Debug.WriteLine(ex.Message + ex.StackTrace);
                 WriteText(ex.Message + ex.StackTrace);
                 MessageBox.Show("Log file downloaded");
             }
        }

        public void WriteText(string message)
        {
            File.WriteAllText(@"C:\Scan\Error.txt", message);
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex == 0)
                return;
            else
            {
                this.LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbCriteria.SelectedIndex == 0)
            {
                foreach (DataGridViewColumn column in dgvCustomview.Columns)
                    column.Visible = true;
            }
            else
            {
                foreach (DataGridViewColumn column in dgvCustomview.Columns)
                {
                    if (column.HeaderText != "TOTAL" && column.HeaderText != "CN SEND" && column.HeaderText != "CN RETURN")
                        column.Visible = false;
                }

                List<string> list = new List<string>();

                string query = string.Format("select cr_column from tb_criteria where cr_criteria = '{0}' group by cr_criteria, cr_column", cbCriteria.SelectedItem.ToString());

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string col = GlobalService.reader.GetString(0);
                    list.Add(col);
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();

                colList = new List<string>();

                foreach (DataGridViewColumn column in dgvCustomview.Columns)
                {
                    if (list.Contains(column.DataPropertyName.ToString()))
                    {
                        column.Visible = true;
                        colList.Add(column.DataPropertyName.ToString());
                    }
                }
            }
        }
    }
}
