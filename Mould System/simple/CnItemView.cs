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

namespace Mould_System.simple
{
    public partial class CnItemView : UserControl
    {
        DataTable table = null;

        public CnItemView()
        {
            InitializeComponent();

            DataChecking.DoubleBuffered(dgvCustomview, true);

            dgvCustomview.Visible = false;

            cbSearch.SelectedIndex = 3;

            LoadStatus();
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
                " where t.tm_vendor_code = v.v_code and t.tm_st_code = st.st_code and t.tm_currency = 'RMB'";

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

            if (cbSearch.SelectedIndex == 5)//Vendor Name
                commandText = _commandText + string.Format(" and v.v_name like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 6)//In Stock Date
                commandText = _commandText + string.Format(" and t.tm_instockdate like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 7)//Oem
                commandText = _commandText + string.Format(" and t.tm_oemasset like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 8)//Quotation Status
            {
                string stname = cbStatus.SelectedItem.ToString();
                commandText = _commandText + string.Format(" and st.st_status = '{0}'", stname);
            }

            SqlDataAdapter sda = new SqlDataAdapter(commandText, DataService.GetInstance().Connection);
            sda.Fill(table);

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
            else if (cbSearch.SelectedIndex == 8)
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
    }
}
