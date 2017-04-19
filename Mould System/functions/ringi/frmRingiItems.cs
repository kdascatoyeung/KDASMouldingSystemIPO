using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mould_System.services;

namespace Mould_System.functions.ringi
{
    public partial class frmRingiItems : Form
    {
        private DataTable table = null;

        public frmRingiItems(string ringi)
        {
            InitializeComponent();

            this.loadData(ringi);

            this.Text = "Ringi: " + ringi;
        }

        private void loadData(string ringi)
        {
            table = new DataTable();

            /*string query = string.Format("select t.tm_chaseno as chaseno, t.tm_mouldno as mouldno, t.tm_itemcode as itemcode, t.tm_rev as rev" +
                ", t.tm_vendor_code as vendor, t.tm_currency as currency, t.tm_amount as amount from tb_betamould as t, tb_ringirelations as re where t.tm_itemcode = re.rr_itemcode and t.tm_rev = re.rr_rev" +
                " and re.rr_ringi = '{0}'", ringi);*/

            string query = string.Format("select tm_chaseno as chaseno, tm_mouldno as mouldno, tm_itemcode as itemcode, tm_rev as rev" +
                ", tm_vendor_code as vendor, tm_currency as currency, tm_amount as amount from tb_betamould where tm_ringi_code = '{0}'", ringi);

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(table);

            dgvRingiItems.DataSource = table;

            GlobalService.adapter.Dispose();
        }
    }
}
