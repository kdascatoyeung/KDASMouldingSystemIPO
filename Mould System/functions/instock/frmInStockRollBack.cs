using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using CustomUtil.utils.authentication;
using Mould_System.checking;

namespace Mould_System.functions.instock
{
    public partial class frmInStockRollBack : Form
    {
        public frmInStockRollBack()
        {
            InitializeComponent();
        }

        private void btnRollBack_Click(object sender, EventArgs e)
        {
            this.RollBack2();
        }

        private void RollBack2()
        {
            string po = txtPO.Text;

            if (!IsPOExist(po))
            {
                MessageBox.Show("PO does not exist.");
                return;
            }

            if (!IsPOInStock(po))
            {
                MessageBox.Show("PO : " + po + " does not in In-Stock status.");
                return;
            }

            string query = "";

            if (rbtnK.Checked)
            {
                query = string.Format("update tb_betamould set tm_st_code = 'K', tm_instockdate = '#N/A', tm_instockdate50 = case when tm_mpa = 'True' then 'Yes' else '#N/A' end where tm_po = '{0}'", po);
                DataService.GetInstance().ExecuteNonQuery(query);

                string chaseno = DataChecking.GetChaseNoByPO(po);

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                        " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "In Stock", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd"), chaseno, "Roll Back");

                DataService.GetInstance().ExecuteNonQuery(logText);

                MessageBox.Show("Record has been saved");
            }

            else if (rbtnPRpass.Checked)
            {
                query = string.Format("update tb_betamould set tm_st_code = 'PR', tm_instockdate = 'Received', tm_instockdate50 = N'一回合格入庫' where tm_po = '{0}'", po);
                DataService.GetInstance().ExecuteNonQuery(query);

                string chaseno = DataChecking.GetChaseNoByPO(po);

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                        " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "In Stock", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd"), chaseno, "Roll Back");

                DataService.GetInstance().ExecuteNonQuery(logText);

                MessageBox.Show("Record has been saved");
            }

            else if (rbtnPRfail.Checked)
            {
                query = string.Format("update tb_betamould set tm_st_code = 'PR', tm_instockdate = '#N/A', tm_instockdate50 = 'Received' where tm_po = '{0}'", po);
                DataService.GetInstance().ExecuteNonQuery(query);

                string chaseno = DataChecking.GetChaseNoByPO(po);

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                        " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "In Stock", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd"), chaseno, "Roll Back");

                DataService.GetInstance().ExecuteNonQuery(logText);

                MessageBox.Show("Record has been saved");
            }

            else if (rbtnHS.Checked)
            {
                query = string.Format("update tb_betamould set tm_st_code = 'HS', tm_instockdate = '#N/A' where tm_po = '{0}'", po);
                DataService.GetInstance().ExecuteNonQuery(query);

                string chaseno = DataChecking.GetChaseNoByPO(po);

                string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                        " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "In Stock", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd"), chaseno, "Roll Back");

                DataService.GetInstance().ExecuteNonQuery(logText);

                MessageBox.Show("Record has been saved");
            }

            else
            {
                MessageBox.Show("Please select one of the option");
                return;
            }
        }

        private void RollBack()
        {
            string po = this.txtPO.Text;

            if (!IsPOExist(po))
            {
                MessageBox.Show("PO does not exist.");
                return;
            }

            if (!IsPOInStock(po))
            {
                MessageBox.Show("PO : " + po + " does not in In-Stock status.");
                return;
            }

            switch (MessageBox.Show("You are trying to roll back PO : " + po + " from In-Stock status. Are you sure to do it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case System.Windows.Forms.DialogResult.Yes:
                    string query = string.Format("update tb_betamould set tm_st_code = 'K', tm_instockdate = '#N/A', tm_instockdate50 = case when tm_mpa = 'True' then 'Yes' else '#N/A' end where tm_po = '{0}'", po);
                    DataService.GetInstance().ExecuteNonQuery(query);

                    string chaseno = DataChecking.GetChaseNoByPO(po);

                    string logText = string.Format("insert into tb_log (log_module, log_fromvalue, log_tovalue, log_user, log_datetime, log_chaseno, log_message)" +
                            " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", "In Stock", "-", "-", AdUtil.getUsername("kmhk.local"), DateTime.Now.ToString("yyyy/MM/dd"), chaseno, "Roll Back");

                    DataService.GetInstance().ExecuteNonQuery(logText);

                    MessageBox.Show("Record has been saved");

                    this.DialogResult = DialogResult.OK;
                    break;
                case System.Windows.Forms.DialogResult.No:
                    break;
            }
        }

        private bool IsPOExist(string po)
        {
            string query = string.Format("select count(*) from tb_betamould where tm_po = '{0}'", po);

            object result = DataService.GetInstance().ExecuteScalar(query);

            if (result is DBNull || (int)result == 0)
                return false;

            return true;
        }

        private bool IsPOInStock(string po)
        {
            string query = string.Format("select tm_st_code from tb_betamould where tm_po = '{0}'", po);

            object result = DataService.GetInstance().ExecuteScalar(query);

            if ((string)result == "S" || (string)result == "HS" || (string)result == "PR")
                return true;

            return false;
        }

        private void txtPO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.RollBack();
        }
    }
}
