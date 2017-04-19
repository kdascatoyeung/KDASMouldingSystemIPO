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
using Mould_System.services;
using Mould_System.functions.ringi;
using Mould_System.file.excel;
using System.Diagnostics;
using Mould_System.functions.file;

namespace Mould_System.forms._6.data
{
    public partial class ucMasterRingiDetail : UserControl
    {
        public ucMasterRingiDetail()
        {
            InitializeComponent();

            this.cbSearch.SelectedIndex = 0;

            this.dgvRingi.SelectionChanged -= new EventHandler(dgvRingi_SelectionChanged);
            this.dgvRingi.SelectionChanged += new EventHandler(dgvRingi_SelectionChanged);
        }

        private void dgvRingi_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRingi.SelectedRows == null)
                return;

            this.loadDetails();
        }

        private void loadRingi()
        {
            DataTable table = new DataTable();

            string _commandText = "select rg_no as ringi, rg_content as content, rg_currency as currency, rg_amount as amount, rg_amounthkd as amounthkd" +
                ", rg_balance as balance, rg_r3date as r3confirmed, rg_expired as expiry from tb_ringi";

            string _commandRelationsText = "select r.rg_no as ringi, r.rg_content as content, r.rg_currency as currency, r.rg_amount as amount, r.rg_amounthkd as amounthkd" +
                ", r.rg_balance as balance, r.rg_r3date as r3confirmed, r.rg_expired as expiry from tb_ringi as r, tb_ringidetail as rd where r.rg_no = rd.rd_ringino";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)//All
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)//Ringi
                commandText = _commandText + string.Format(" where rg_no like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)//Model
                commandText = _commandRelationsText + string.Format(" and rd.rd_modelname like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)//Part No.
                commandText = _commandRelationsText + string.Format(" and rd.rd_itemcode like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)//Subject
                commandText = _commandRelationsText + string.Format(" and rd.rd_subject like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)//Remarks
                commandText = _commandRelationsText + string.Format(" and rd.rd_remarks like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new SqlDataAdapter(commandText, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvRingi.DataSource = table;

            dgvRingi.Sort(dgvRingi.Columns[7], ListSortDirection.Descending);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvRingi.SelectedRows == null)
                return;

            string ringi = dgvRingi.SelectedRows[0].Cells[0].Value.ToString();

            //string deltext = string.Format("delete from tb_ringidetail where rd_ringino = '{0}'", ringi);
            //DataService.GetInstance().ExecuteNonQuery(deltext);

            string modelname = this.txtModelName.Text;

            string subject = this.txtSubject.Text;

            for (int i = 0; i < dgvPreRingi.Rows.Count - 1; i++)
            {
                string modelcode = "", partno = "", currency = "", amount = "", vendor = "", remarks = "";

                string id = "";

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[0].Value))
                        modelcode = dgvPreRingi.Rows[i].Cells[0].Value.ToString();
                }
                catch
                {
                    modelcode = "";
                }

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[1].Value))
                        partno = (dgvPreRingi.Rows[i].Cells[1].Value).ToString();
                }
                catch
                {
                    partno = "";
                }

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[2].Value))
                        currency = (dgvPreRingi.Rows[i].Cells[2].Value).ToString();
                }
                catch
                {
                    currency = "";
                }

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[3].Value))
                        amount = (dgvPreRingi.Rows[i].Cells[3].Value).ToString();
                }
                catch
                {
                    amount = "";
                }

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[4].Value))
                        vendor = (dgvPreRingi.Rows[i].Cells[4].Value).ToString();
                }
                catch
                {
                    vendor = "";
                }

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[5].Value))
                        remarks = (dgvPreRingi.Rows[i].Cells[5].Value).ToString();
                }
                catch
                {
                    remarks = "";
                }

                try
                {
                    if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[6].Value))
                        id = (dgvPreRingi.Rows[i].Cells[6].Value).ToString();
                }
                catch
                {
                    id = "";
                }

                string query = string.Format("if not exists (select * from tb_ringidetail where rd_id = '{0}') insert into tb_ringidetail (rd_ringino" +
                    ", rd_itemcode, rd_modelcode, rd_currency, rd_amount, rd_vendor, rd_remarks, rd_subject, rd_modelname) values ('{1}'" +
                    ", '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}') else update tb_ringidetail set rd_modelname = '{9}', rd_subject = '{8}', rd_itemcode = '{2}'" +
                    ", rd_modelcode = '{3}', rd_currency = '{4}', rd_amount = '{5}', rd_vendor = '{6}', rd_remarks = '{7}' where rd_id = '{0}'", id, ringi, partno,
                    modelcode, currency, amount, vendor, remarks, subject, modelname);

                DataService.GetInstance().ExecuteNonQuery(query);

            }

            /*foreach (DataGridViewRow row in dgvPreRingi.Rows)
            {
                string modelcode = "", partno = "", currency = "", amount = "", vendor = "", remarks = "";

                string id = "";

                if (!Convert.IsDBNull(row.Cells[0].Value))
                    modelcode = row.Cells[0].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[1].Value))
                    partno = row.Cells[1].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[2].Value))
                    currency = row.Cells[2].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[3].Value))
                    amount = row.Cells[3].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[4].Value))
                    vendor = row.Cells[4].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[5].Value))
                    remarks = row.Cells[5].Value.ToString();

                try
                {
                    if (!Convert.IsDBNull(row.Cells[6].Value))
                        id = row.Cells[6].Value.ToString();
                }
                catch
                {
                    id = "";
                }
                string query = string.Format("if not exists (select * from tb_ringidetail where rd_id = '{0}') insert into tb_ringidetail (rd_ringino" +
                    ", rd_itemcode, rd_modelcode, rd_currency, rd_amount, rd_vendor, rd_remarks, rd_subject, rd_modelname) values ('{1}'" +
                    ", '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}') else update tb_ringidetail set rd_modelname = '{9}', rd_subject = '{8}', rd_itemcode = '{2}'" +
                    ", rd_modelcode = '{3}', rd_currency = '{4}', rd_amount = '{5}', rd_vendor = '{6}', rd_remarks = '{7}' where rd_id = '{0}'", id, ringi, partno,
                    modelcode, currency, amount, vendor, remarks, subject, modelname);

                DataService.GetInstance().ExecuteNonQuery(query);
            }*/

            MessageBox.Show("Record has been saved");
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                this.txtSearch.Enabled = false;
                this.loadRingi();
            }
            else
                this.txtSearch.Enabled = true;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadRingi();
        }

        private void dgvRingi_DoubleClick(object sender, EventArgs e)
        {
            if (dgvRingi.SelectedRows == null)
                return;

            string ringi = dgvRingi.SelectedRows[0].Cells[0].Value.ToString();

            frmRingiItems ringiitems = new frmRingiItems(ringi);
            ringiitems.ShowDialog();
        }

        private void loadDetails()
        {
            try
            {
                dgvPreRingi.Rows.Clear();

                string ringi = dgvRingi.SelectedRows[0].Cells[0].Value.ToString();

                lblRingi.Text = ringi;

                Debug.WriteLine(ringi);

                if (DataChecking.ringiRelationExists(ringi))
                {
                    DataTable tmptable = new DataTable();

                    txtModelName.Text = DataChecking.getRingiRelationModelName(ringi);

                    txtSubject.Text = DataChecking.getRingiRelationSubject(ringi);

                    string query = string.Format("select rd_itemcode, rd_modelcode, rd_currency, rd_amount, rd_vendor, rd_remarks, rd_id" +
                        " from tb_ringidetail where rd_ringino = '{0}'", ringi);

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    while (GlobalService.reader.Read())
                    {
                        string itemcode = GlobalService.reader.GetString(0);
                        string modelcode = GlobalService.reader.GetString(1);
                        string currency = GlobalService.reader.GetString(2);
                        string amount = GlobalService.reader.GetString(3);
                        string vendor = GlobalService.reader.GetString(4);
                        string remarks = GlobalService.reader.GetString(5);
                        int id = GlobalService.reader.GetInt32(6);

                        dgvPreRingi.Rows.Add(new object[] { modelcode, itemcode, currency, amount, vendor, remarks, id });
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    for (int i = 0; i < dgvPreRingi.Rows.Count; i++)
                    {
                        var rowToCompare = dgvPreRingi.Rows[i];

                        foreach (DataGridViewRow row in dgvPreRingi.Rows)
                        {
                            if (rowToCompare.Equals(row)) 
                                continue;

                            bool duplicateRow = true;

                            for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                            {
                                if (!rowToCompare.Cells[cellIndex].Value.Equals(row.Cells[cellIndex].Value))
                                {
                                    duplicateRow = false;
                                    break;
                                }
                            }

                            if (duplicateRow)
                                dgvPreRingi.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    dgvPreRingi.Rows.Clear();

                    txtModelName.Text = "";

                    txtSubject.Text = "";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable templatetable = new DataTable();

            string[] headers = { "Ringi No.", "Model Name", "Subject", "Model Code", "Part No.", "Currency", "Amount", "Vendor", "Remarks" };

            foreach (string header in headers)
                templatetable.Columns.Add(header);

            ExportXlsUtil.XlsUtil(templatetable);
        }

        DataTable uploadtable;
        bool validData = true;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string filename = "";

            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            uploadtable = new DataTable();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                uploadtable = ImportXlsUtil.TranslateToTable(filename);

                frmUploadConfirm form = new frmUploadConfirm(uploadtable);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    if (!worker.IsBusy)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        worker.RunWorkerAsync();
                    }
                    else
                        MessageBox.Show("File is using by other process");
                }

                
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvRingi.SelectedRows == null)
                return;

            DataTable downloadtable = new DataTable();

            string[] headers = { "Ringi", "Model Name", "Subject", "Model Code", "Part No.", "Currency", "Amount", "Vendor", "Remarks" };

            foreach (string header in headers)
                downloadtable.Columns.Add(header);

            string ringi = dgvRingi.SelectedRows[0].Cells[0].Value.ToString();

            string modelname = this.txtModelName.Text;

            string subject = this.txtSubject.Text;

            for (int i = 0; i < dgvPreRingi.Rows.Count - 1; i++)
            {
                string modelcode = "", partno = "", currency = "", amount = "", vendor = "", remarks = "";

                if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[0].Value))
                    modelcode = dgvPreRingi.Rows[i].Cells[0].Value.ToString();

                if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[1].Value))
                    partno = (dgvPreRingi.Rows[i].Cells[1].Value).ToString();

                if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[2].Value))
                    currency = (dgvPreRingi.Rows[i].Cells[2].Value).ToString();

                if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[3].Value))
                    amount = (dgvPreRingi.Rows[i].Cells[3].Value).ToString();

                if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[4].Value))
                    vendor = (dgvPreRingi.Rows[i].Cells[4].Value).ToString();

                if (!Convert.IsDBNull(dgvPreRingi.Rows[i].Cells[5].Value))
                    remarks = (dgvPreRingi.Rows[i].Cells[5].Value).ToString();

                downloadtable.Rows.Add(new object[] { ringi, modelname, subject, modelcode, partno, currency, amount, vendor, remarks });

            }

            /*foreach (DataGridViewRow row in dgvPreRingi.Rows)
            {
                string modelcode = "", partno = "", currency = "", amount = "", vendor = "", remarks = "";

                if (!Convert.IsDBNull(row.Cells[0].Value))
                    modelcode = row.Cells[0].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[1].Value))
                    partno = row.Cells[1].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[2].Value))
                    currency = row.Cells[2].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[3].Value))
                    amount = row.Cells[3].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[4].Value))
                    vendor = row.Cells[4].Value.ToString();

                if (!Convert.IsDBNull(row.Cells[5].Value))
                    remarks = row.Cells[5].Value.ToString();

                downloadtable.Rows.Add(new object[] { ringi, modelname, subject, modelcode, partno, currency, amount, vendor, remarks });
            }*/

            ExportXlsUtil.XlsUtil(downloadtable);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = dgvPreRingi.CurrentRow.Index;

            int id = Convert.ToInt32(dgvPreRingi.Rows[rowindex].Cells[6].Value);

            string deltext = string.Format("delete from tb_ringidetail where rd_id = '{0}'", id);
            DataService.GetInstance().ExecuteNonQuery(deltext);

            MessageBox.Show("Record has been deleted");

            this.loadDetails();
        }

        private void dgvPreRingi_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvPreRingi.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void dgvPreRingi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dgvPreRingi.HitTest(e.X, e.Y);
                dgvPreRingi.ClearSelection();
                dgvPreRingi.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataRow row in uploadtable.Rows)
                {
                    string ringi = row[0].ToString();
                    string modelname = row[1].ToString();
                    string subject = row[2].ToString();
                    string modelcode = row[3].ToString();
                    string partno = row[4].ToString();
                    string currency = row[5].ToString();
                    string amount = row[6].ToString();
                    string vendor = row[7].ToString();
                    string remarks = row[8].ToString();

                    lblRingi.Text = ringi;
                    txtModelName.Text = modelname;
                    txtSubject.Text = subject;

                    //dgvPreRingi.Rows.Add(new object[] { modelcode, partno, currency, amount, vendor, remarks });

                    string query = string.Format("insert into tb_ringidetail (rd_ringino, rd_itemcode, rd_modelcode, rd_currency, rd_amount" +
                        ", rd_vendor, rd_remarks, rd_subject, rd_modelname) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", ringi,
                        partno, modelcode, currency, amount, vendor, remarks, subject, modelname);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                validData = false;
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;

            if (!validData)
                MessageBox.Show("Invalid Data Format");
            else
            {
                MessageBox.Show("Record has been saved");
                this.loadDetails();
            }
        }
    }
}
