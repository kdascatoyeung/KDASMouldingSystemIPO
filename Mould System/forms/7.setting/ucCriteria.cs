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

namespace Mould_System.forms._7.setting
{
    public partial class ucCriteria : UserControl
    {
        public ucCriteria()
        {
            InitializeComponent();

            this.loadData();
        }

        private void loadData()
        {
            lbRecord.Items.Clear();

            string query = "select cr_criteria from tb_criteria group by cr_criteria";

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string item = GlobalService.reader.GetString(0);
                lbRecord.Items.Add(item);
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCriteria.Text))
            {
                MessageBox.Show("Invalid criteria");
                return;
            }

            groupBox2.Enabled = true;

            lblCriteria.Text = txtCriteria.Text;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox ckb = (CheckBox)control;

                    string tag = ckb.Tag.ToString();

                    string query = string.Format("select cr_column from tb_criteria where cr_criteria = '{0}' and cr_column = '{1}'", lblCriteria.Text, tag);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    if (GlobalService.reader.HasRows)
                        ckb.Checked = true;
                    else
                        ckb.Checked = false;

                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string criteria = lblCriteria.Text;

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox ckb = (CheckBox)control;

                    string query = "";

                    string tag = ckb.Tag.ToString();

                    if (ckb.Checked)
                        query = string.Format("if not exists (select * from tb_criteria where cr_criteria = '{0}' and cr_column = '{1}') insert into tb_criteria (cr_criteria, cr_column)" +
                            " values ('{0}', '{1}')", criteria, tag);

                    else
                        query = string.Format("if exists (select * from tb_criteria where cr_criteria = '{0}' and cr_column = '{1}') delete from tb_criteria where cr_criteria = '{0}' and cr_column = '{1}'", criteria, tag);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }
            }
            MessageBox.Show("Record has been saved");
        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAll.Checked)
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    CheckBox ckb = (CheckBox)control;
                    ckb.Checked = true;
                }
                ckbAll.Text = "Deselect All";
            }
            else
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    CheckBox ckb = (CheckBox)control;
                    ckb.Checked = false;
                }
                ckbAll.Text = "Select All";
            }
        }

        private void lbRecord_DoubleClick(object sender, EventArgs e)
        {
            if (lbRecord.SelectedItem == null)
                return;
            else
            {
                txtCriteria.Text = lbRecord.SelectedItem.ToString();
            }
        }
    }
}
