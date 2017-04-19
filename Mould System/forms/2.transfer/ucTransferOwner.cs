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

namespace Mould_System.forms._2.transfer
{
    public partial class ucTransferOwner : UserControl
    {
        public ucTransferOwner()
        {
            InitializeComponent();

            cbFromOwner.SelectedIndex = 0;

            cbToOwner.SelectedIndex = 2;
        }

        private void loadData()
        {
            Debug.WriteLine("Loading.....");

            DataTable table = new DataTable();

            List<string> mouldlist = new List<string>();

            string _mouldText = string.Format("select distinct tm_mouldno from tb_betamould where tm_st_code = 'S' and tm_itemcode like '%{0}%'", txtSearch.Text);

            Debug.WriteLine("Query: " + _mouldText);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(_mouldText);

            while (GlobalService.reader.Read())
            {
                string mouldno = GlobalService.reader.GetString(0);

                mouldlist.Add(mouldno);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            if (mouldlist.Count == 0)
            {
                MessageBox.Show("No record found. Please note that only IN STOCK data can be searched");
            }
            else
            {
                foreach (string mould in mouldlist)
                {
                    string text = string.Format("select tm_fixedassetcode from tb_betamould where tm_mouldno = '{0}' and tm_fixedassetcode != '' and tm_fixedassetcode not like '%,%'", mould);

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

                    if (falist.Count == 0)
                        faremarks = "";
                    else if (falist.Count == 1)
                        faremarks = falist[0].ToString();
                    else
                        faremarks = string.Join(",", falist.ToArray());

                    Debug.WriteLine("1");
                    string mouldcode = DataChecking.getVendorByMould(mould);
                    Debug.WriteLine("2");
                    string vendor = DataChecking.getTopVendorByMould(mould);
                    Debug.WriteLine("3");
                    string vendorname = DataChecking.getVendorName(vendor);
                    Debug.WriteLine("4");
                    string remarks = DataChecking.getTopRemarksByMould(mould);
                    Debug.WriteLine("5");
                    string instockdate = DataChecking.getTopInStockDateByMould(mould);
                    Debug.WriteLine("6");
                    string owner = DataChecking.getTopOwner(mould);

                    dgvTransferPreview.Rows.Add(new object[] { mould, mouldcode, vendor, vendorname, faremarks, remarks, instockdate, owner });
                }

                Debug.WriteLine("Loading Finished");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                    return;
                this.loadData();
            }
        }

        string globalFromOwner = "";

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string fromowner = cbFromOwner.SelectedItem.ToString();
            globalFromOwner = fromowner;

            string toowner = cbToOwner.SelectedItem.ToString();

            foreach (DataGridViewRow row in dgvTransferPreview.SelectedRows)
            {
                string mould = row.Cells[0].Value.ToString();
                string mouldcode = row.Cells[1].Value.ToString();
                string vendor = row.Cells[2].Value.ToString();
                string vendorname = row.Cells[3].Value.ToString();
                string fac = row.Cells[4].Value.ToString();

                dgvPreview.Rows.Add(new object[] { mould, mouldcode, vendor, vendorname, fac, fromowner + "            \u2192", toowner, "" });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreview.Rows)
            {
                string mouldno = row.Cells[0].Value.ToString();
                string vendor = row.Cells[2].Value.ToString();
                string fac = row.Cells[4].Value.ToString();
                string toowner = row.Cells[6].Value.ToString();

                string transferremarks = row.Cells[6].Value.ToString();

                string query = string.Format("update tb_betamould set tm_owner = '{0}', tm_moulditemviewer = 'Yes' where tm_mouldno = '{1}'", toowner, mouldno);

                DataService.GetInstance().ExecuteNonQuery(query);

                this.saveTransferHistory(mouldno, globalFromOwner, toowner, vendor, vendor, transferremarks, fac);
            }
        }

        private void saveTransferHistory(string mouldno, string ownerbefore, string ownerafter, string locationbefore, string locationafter,
            string remarks, string fac)
        {
            string query = string.Format("insert into tb_transferhistory (his_mouldno, his_itemcode, his_rev, his_status, his_ownerbefore" +
                ", his_ownerafter, his_locationbefore, his_locationafter, his_date, his_fee, his_tmchaseno, his_remarks, his_fixedassetcode" +
                ", his_tmpfixedassetcode, his_chaseno) values ('{0}', '-', '-', '-', '{1}', '{2}', '{3}', '{4}', '{5}', '0', '-', '{6}', '{7}', '-', '-')", mouldno, ownerbefore,
                ownerafter, locationbefore, locationafter, DateTime.Today.ToString("yyyy/MM/dd"), remarks, fac);

            DataService.GetInstance().ExecuteNonQuery(query);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                return;
            this.loadData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPreview.SelectedRows)
            {
                dgvPreview.Rows.Remove(row);
            }
        }
    }
}
