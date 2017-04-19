using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;

namespace Mould_System.functions.transfer
{
    public partial class frmTransferDetail : Form
    {
        public frmTransferDetail(string mouldno, string itemcode, string rev)
        {
            InitializeComponent();

            this.loadData(mouldno, itemcode, rev);
        }

        private void loadData(string mouldno, string itemcode, string rev)
        {
            string query = string.Format("select t.tm_chaseno, t.tm_mouldno, t.tm_itemcode, t.tm_rev, t.tm_status, t.tm_ringi_code" +
                ", t.tm_fixedassetcode, t.tm_vendor_code, st.st_status from tb_betamould as t, tb_betaqstatus as st where t.tm_st_code = st.st_code" +
                " and t.tm_mouldno = '{0}' and t.tm_itemcode = '{1}' and t.tm_rev = '{2}'", mouldno, itemcode, rev);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                lblChaseno.Text = GlobalService.reader.GetString(0);
                lblMouldno.Text = GlobalService.reader.GetString(1);
                lblItemcode.Text = GlobalService.reader.GetString(2);
                lblRev.Text = GlobalService.reader.GetString(3);
                lblDiv.Text = GlobalService.reader.GetString(4);
                lblRingi.Text = GlobalService.reader.GetString(5);
                lblFaCode.Text = GlobalService.reader.GetString(6);
                lblVendor.Text = GlobalService.reader.GetString(7);
                lblStatus.Text = GlobalService.reader.GetString(8);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
