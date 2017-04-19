using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using System.Diagnostics;

namespace Mould_System.forms._3.disposal
{
    public partial class ucDisposalConfirm : UserControl
    {
        public ucDisposalConfirm()
        {
            InitializeComponent();

            this.loadData();
        }

        private void loadData()
        {
            DataTable table = new DataTable();

            string _commandText = "select dd_type as disposaltype, st.st_status as qstatus, t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev as rev, t.tm_type as type" +
                ", t.tm_amounthkd as amounthkd, t.tm_fixedassetcode as facode, t.tm_ringi_code as ringi, t.tm_vendor_code as vendor, v.v_name as vendorname" +
                ", d.dd_status as disposalstatus, d.dd_2003no as p2003no, d.dd_2003answer as p2003ans, d.dd_2003result as p2003result" +
                ", d.dd_2003updated as p2003updated, d.dd_2004no as p2004no, d.dd_2004answer as p2004ans, d.dd_2004result as p2004result" +
                ", d.dd_2004updated as p2004updated, d.dd_kdcno as kdcno, d.dd_kdcrps as kdcrps, d.dd_kdcseisan as kdcseisan, d.dd_kdcresult as kdcresult" +
                ", d.dd_kdcupdated as kdcupdated, d.dd_final as finalresult, d.dd_assetdesc as assetdesc, d.dd_capdate as capdate, d.dd_acquishkd as acquis" +
                ", d.dd_accumhkd as accum, d.dd_closing as cmonth, d.dd_bookhkd as bookhkd, d.dd_fy as fy, d.dd_bookhkd2 as bookhkd2" +
                ", d.dd_nav as nav, d.dd_disposalringi as disposalringi, d.dd_reportno as reportno, d.dd_reportissued as reportissued, d.dd_reportreceived as reportreceived" +
                ", d.dd_vendorresult as vendorresult, d.dd_fadisposaldate as fadisposal, d.dd_disposalremarks as remarks from tb_betamould as t, tb_vendor as v" +
                ", tb_disposaldetail as d, tb_betaqstatus as st where t.tm_st_code = st.st_code and t.tm_chaseno = d.dd_chaseno and t.tm_vendor_code = v.v_code and (t.tm_st_code = 'D7' or t.tm_st_code = 'D8')";

            //GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(_commandText, DataService.GetInstance().Connection);
            //GlobalService.adapter.Fill(table);

            //dgvDisposalConfirm.DataSource = table;
        }

        private void dgvDisposalConfirm_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDisposalConfirm.SelectedRows == null)
                return;

            lblCount.Text = dgvDisposalConfirm.SelectedRows.Count.ToString();
        }

        private void disposeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure to dispose selected " + dgvDisposalConfirm.SelectedRows.Count + " item(s) ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvDisposalConfirm.SelectedRows)
                    {
                        string chaseno = row.Cells[2].Value.ToString();
                        string reportno = row.Cells[37].Value.ToString();

                        
                        Debug.WriteLine("Reportno: " + reportno);
                        string query = string.Format("update tb_betamould set tm_st_code = 'D', tm_disposalno = '{0}' where tm_chaseno = '{1}'", reportno, chaseno);

                        DataService.GetInstance().ExecuteNonQuery(query);
                    }

                    this.loadData();
                    break;

                case DialogResult.No:
                    break;
            }
        }
    }
}
