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
using CustomUtil.utils.authentication;

namespace Mould_System.simple
{
    public partial class ApprovalView : UserControl
    {
        public ApprovalView()
        {
            InitializeComponent();

            LoadData();

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            btnApproveAll.Enabled = btnReject.Enabled = btnSave.Enabled = dgvApproval.Rows.Count > 0 ? true : false;
        }

        private void LoadData()
        {
            dgvApproval.Rows.Clear();

            string status = GlobalService.Owner == GlobalService.IPO1st ? "IPO 1st Approval" : GlobalService.Owner == GlobalService.IPO2nd ? "IPO 2nd Approval" : "";

            string query = string.Format("select f_request, f_applicant, f_pdfid, f_attachment from TB_FA_APPROVAL where f_status = '{0}' group by f_request, f_applicant, f_pdfid, f_attachment", status);

            using (IDataReader reader = DataServiceNew.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string request = reader.GetString(0);
                    string applicant = reader.GetString(1);
                    string pdfid = reader.GetString(2);
                    string attachment = reader.GetString(3);

                    dgvApproval.Rows.Add("---", request, applicant, pdfid, attachment);
                }
            }
        }

        private void btnApproveAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvApproval.Rows)
                row.Cells[0].Value = "Approve";
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvApproval.Rows)
                row.Cells[0].Value = "Reject";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvApproval.EndEdit();

            foreach (DataGridViewRow row in dgvApproval.Rows)
            {
                string approval = row.Cells[0].Value.ToString().Trim();

                if (approval == "---")
                    continue;

                string pdfid = row.Cells[3].Value.ToString().Trim();

                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                string query = "";

                string applicant = row.Cells[2].Value.ToString().Trim();

                string email = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(applicant, "kmhk.local"), "kmhk.local");

                if (GlobalService.Owner == GlobalService.IPO1st)
                {
                    if (approval == "Approve")
                    {
                        query = string.Format("update TB_FA_APPROVAL set f_status = '{0}', f_ipo1stapp = '{1}', f_ipo1stdate = '{2}'" +
                       " where f_pdfid = '{3}'", "IPO 2nd Approval", "Approve", now, pdfid);

                        EmailUtil.SendEmail(email, "chongwah.cheng@dthk.kyocera.com", "SpApp_Fixed Asset Application Approval Required");
                    }
                    else
                    {
                        query = string.Format("delete from TB_FA_APPROVAL where f_pdfid = '{0}'", pdfid);

                        RejectStatus(pdfid);
                    }
                }
                else
                {
                    if (approval == "Approve")
                    {
                        query = string.Format("update TB_FA_APPROVAL set f_status = '{0}', f_ipo2ndapp = '{1}', f_ipo2nddate = '{2}', f_ringi1st = N'{3}', f_cm1st = N'{4}', f_cm2nd = N'{5}', f_cm3rd = N'{6}'" +
                       " where f_pdfid = '{7}'", "Ringi Approval", "Approve", now, "Lai King Ho(黎景豪,Ken)", "Lee Suk Ha(李淑霞,Zoe)", "Li Yuen Yan(李婉茵,Sharon)", "Leung Wai Yip(梁偉業,Philip)", pdfid);

                        try
                        {
                            EmailUtil.NotificationEmail(email, "ken.lai@dthk.kyocera.com", "Fixed Asset Application Approval Required");
                        }
                        catch
                        {
                            Debug.WriteLine("aaa");
                        }
                    }
                    else
                    {
                        query = string.Format("delete from TB_FA_APPROVAL where f_pdfid = '{0}'", pdfid);

                        RejectStatus(pdfid);
                    }
                }

                DataServiceNew.GetInstance().ExecuteNonQuery(query);
            }

            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RejectStatus(string pdfid)
        {
            string backText = string.Format("update tb_betamould set tm_st_code = 'F' where tm_pdfid = '{0}'", pdfid);
            DataService.GetInstance().ExecuteNonQuery(backText);
        }

        private void dgvApproval_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string path = dgvApproval.CurrentRow.Cells[4].Value.ToString();
                Process.Start(path);
            }
        }
    }
}
