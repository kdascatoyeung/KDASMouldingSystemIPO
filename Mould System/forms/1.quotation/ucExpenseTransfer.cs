using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using Mould_System.file.excel;
using Mould_System.file.csv;
using System.Diagnostics;
using Mould_System.functions.file;

namespace Mould_System.forms._1.quotation
{
    public partial class ucExpenseTransfer : UserControl
    {
        DataTable table;

        public ucExpenseTransfer()
        {
            InitializeComponent();

            cbSearch.SelectedIndex = 0;
        }

        private void loadData()
        {
            table = new DataTable();

            string _commandText = "select et_id as etid, et_date as etdate, et_incharge as etincharge, et_asset as etasset, et_partno as etitemcode, et_rev as etrev" +
                ", et_mouldno as etmouldno, et_type as ettype, et_mouldcode as etmouldcode, et_cur as etcurrency, et_amount as etamount" +
                ", et_vendorcode as etvendor, et_vendor as etvendorname, et_chaseno as etchaseno, et_remarks as etremarks, et_pono as etpo" +
                ", et_poissued as etissued, et_poinstock as etinstock, et_debit as etdebit, et_fasales as etsales, et_ringino as etringi, et_finish as etfinish, et_epsonno as etepsonno" +
                " from tb_expensetransfer";

            string commandText = "";

            if (cbSearch.SelectedIndex == 0)
                commandText = _commandText;

            if (cbSearch.SelectedIndex == 1)
                commandText = _commandText + string.Format(" where et_incharge like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 2)
                commandText = _commandText + string.Format(" where et_asset like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 3)
                commandText = _commandText + string.Format(" where et_chaseno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 4)
                commandText = _commandText + string.Format(" where et_partno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 5)
                commandText = _commandText + string.Format(" where et_mouldno like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 6)
                commandText = _commandText + string.Format(" where et_vendor like '%{0}%'", txtSearch.Text);

            if (cbSearch.SelectedIndex == 7)
                commandText = _commandText + string.Format(" where et_pono like '%{0}%'", txtSearch.Text);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(commandText, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvExpenseTransfer.DataSource = table;

            lblTotal.Text = "ROWS COUNT: " + dgvExpenseTransfer.Rows.Count;
        }
        
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvExpenseTransfer.Rows.Count == 0)
            {
                MessageBox.Show("No record can be downloaded");
                return;
            }

            DataTable dlTable = table.Copy();

            string[] headers = {"Date", "担當", "資產", "Parts no.", "Rev", "Mould no.", "Type", "Mould Code", "Cur", "Amount", "Vendor Code", "Vendor",
                                   "追跡番号", "Remarks", "P/O no.", "P/O Issue Date", "P/O Instock Date", "Debit Note Apply Date", "Fixed Asset Sales Apply Date", 
                                   "Ringi no.","Epson管理no."};

            dlTable.Columns.Remove("etid");
            dlTable.Columns["etdate"].ColumnName = "Date";
            dlTable.Columns["etincharge"].ColumnName = "担當";
            dlTable.Columns["etasset"].ColumnName = "資產";
            dlTable.Columns["etitemcode"].ColumnName = "Parts no.";
            dlTable.Columns["etrev"].ColumnName = "Rev";
            dlTable.Columns["etmouldno"].ColumnName = "Mould no.";
            dlTable.Columns["ettype"].ColumnName = "Type";
            dlTable.Columns["etmouldcode"].ColumnName = "Mould Code";
            dlTable.Columns["etcurrency"].ColumnName = "Cur";
            dlTable.Columns["etamount"].ColumnName = "Amount";
            dlTable.Columns["etvendor"].ColumnName = "Vendor Code";
            dlTable.Columns["etvendorname"].ColumnName = "Vendor Name";
            dlTable.Columns["etchaseno"].ColumnName = "追跡番号";
            dlTable.Columns["etremarks"].ColumnName = "Remarks";
            dlTable.Columns["etpo"].ColumnName = "P/O no.";
            dlTable.Columns["etissued"].ColumnName = "P/O Issue Date";
            dlTable.Columns["etinstock"].ColumnName = "P/O Instock Date";
            dlTable.Columns["etdebit"].ColumnName = "Debit Note Apply Date";
            dlTable.Columns["etsales"].ColumnName = "Fixed Asset Sales Apply Date";
            dlTable.Columns["etringi"].ColumnName = "Ringi no.";
            dlTable.Columns["etfinish"].ColumnName = "Finish";
            dlTable.Columns["etepsonno"].ColumnName = "Epson管理no.";


            ExportCsvUtil.ExportCsv(dlTable, "", "經費轉移");
        }

        string filename = "";

        DataTable ulTable;
        bool validData = true;

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Excel Files |*.xls"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filename = ofd.FileName;

                ulTable = new DataTable();

                ulTable = ImportXlsUtil.TranslateToTable(filename);

                for (int i = 0; i < ulTable.Rows.Count; i++)
                {
                    string date = ulTable.Rows[i][0].ToString();
                    string issued = ulTable.Rows[i][15].ToString();
                    string instock = ulTable.Rows[i][16].ToString();
                    string debit = ulTable.Rows[i][17].ToString();
                    string sales = ulTable.Rows[i][18].ToString();

                    date = ImportXlsUtil.ParseDateTime(date).ToString("yyyy/MM/dd");
                    if (issued != "")
                        issued = ImportXlsUtil.ParseDateTime(issued).ToString("yyyy/MM/dd");
                    if (instock != "")
                        instock = ImportXlsUtil.ParseDateTime(instock).ToString("yyyy/MM/dd");
                    if (debit != "no need" && debit != "")
                        debit = ImportXlsUtil.ParseDateTime(debit).ToString("yyyy/MM/dd");
                    if (sales != "no need" && sales != "")
                        sales = ImportXlsUtil.ParseDateTime(sales).ToString("yyyy/MM/dd");

                    ulTable.Rows[i][0] = date;
                    ulTable.Rows[i][15] = issued;
                    ulTable.Rows[i][16] = instock;
                    ulTable.Rows[i][17] = debit;
                    ulTable.Rows[i][18] = sales;
                }

                frmUploadConfirm form = new frmUploadConfirm(ulTable);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    if (!worker.IsBusy)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        dgvExpenseTransfer.Cursor = Cursors.WaitCursor;
                        worker.RunWorkerAsync();
                    }
                    else
                        MessageBox.Show("File is using by other process");
                }
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (DataRow row in ulTable.Rows)
                {
                    string date = row.ItemArray[0].ToString();
                    string incharge = row.ItemArray[1].ToString();
                    string asset = row.ItemArray[2].ToString();
                    string partno = row.ItemArray[3].ToString();
                    string rev = row.ItemArray[4].ToString();
                    string mouldno = row.ItemArray[5].ToString();
                    string type = row.ItemArray[6].ToString();
                    string mouldcode = row.ItemArray[7].ToString();
                    string currency = row.ItemArray[8].ToString();
                    string amount = row.ItemArray[9].ToString();
                    string vendorcode = row.ItemArray[10].ToString();
                    string vendorname = row.ItemArray[11].ToString();
                    string chaseno = row.ItemArray[12].ToString();
                    string remarks = row.ItemArray[13].ToString();
                    string po = row.ItemArray[14].ToString();
                    string poissued = row.ItemArray[15].ToString();
                    string poinstock = row.ItemArray[16].ToString();
                    string debit = row.ItemArray[17].ToString();
                    string sales = row.ItemArray[18].ToString();
                    string ringi = row.ItemArray[19].ToString();
                    string finish = row.ItemArray[20].ToString();
                    string epsonno = row.ItemArray[21].ToString();

                    if (rev.Length == 1)
                        rev = "0" + rev;

                    date = ImportXlsUtil.ParseDateTime(date).ToString("yyyy/MM/dd");
                    poissued = ImportXlsUtil.ParseDateTime(poissued).ToString("yyyy/MM/dd");
                    poinstock = ImportXlsUtil.ParseDateTime(poinstock).ToString("yyyy/MM/dd");
                    debit = ImportXlsUtil.ParseDateTime(debit).ToString("yyyy/MM/dd");

                    string query = string.Format("if exists (select * from tb_expensetransfer where et_partno = '{0}' and et_rev = '{1}' and et_mouldno = '{2}') update tb_expensetransfer set et_date = '{3}', et_incharge = '{4}'" +
                        ", et_asset = '{5}', et_type = '{6}', et_mouldcode = '{7}', et_cur = '{8}', et_amount = '{9}', et_vendorcode = '{10}', et_vendor = '{11}'" +
                        ", et_chaseno = '{12}', et_remarks = '{13}', et_pono = '{14}', et_poissued = '{15}', et_poinstock = '{16}', et_debit = '{17}', et_fasales = '{18}', et_ringino = '{19}', et_finish = '{20}'" +
                        ", et_epsonno = '{21}' else insert into tb_expensetransfer (et_date, et_incharge, et_asset, et_partno, et_rev, et_mouldno, et_type, et_mouldcode, et_cur, et_amount" +
                        ", et_vendorcode, et_vendor, et_chaseno, et_remarks, et_pono, et_poissued, et_poinstock, et_debit, et_fasales, et_ringino, et_finish, et_epsonno) values" +
                        " ('{3}', '{4}', '{5}', '{0}', '{1}', '{2}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}')", partno, rev, mouldno, date, incharge, asset,
                         type, mouldcode, currency, amount, vendorcode, vendorname, chaseno, remarks, po, poissued, poinstock, debit, sales, ringi, finish, epsonno);

                    /*string query = string.Format("if exists (select * from tb_expensetransfer where et_ = '{0}') update tb_expensetransfer set et_date = '{1}', et_incharge = '{2}'" +
                        ", et_asset = '{3}', et_mouldno = '{4}', et_type = '{5}', et_mouldcode = '{6}', et_currency = '{7}', et_amount = '{8}', et_vendorcode = '{9}', et_vendorname = '{10}'" +
                        ", et_chaseno = '{0}', et_remarks = '{11}', et_po = '{12}', et_poissued = '{13}', et_poinstock = '{14}', et_debit = '{15}', et_sales = '{16}', et_ringi = '{17}', et_finish = '{18}'" +
                        ", et_epsonno = '{19}' else insert into tb_expensetransfer (et_date, et_incharge, et_asset, et_mouldno, et_type, et_mouldcode, et_currency, et_amount" +
                        ", et_vendorcode, et_vendorname, et_chaseno, et_remarks, et_po, et_poissued, et_poinstock, et_debit, et_sales, et_ringi, et_finish, et_epsonno) values" +
                        " ('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{0}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}')", chaseno, date, incharge, asset,
                        mouldno, type, mouldcode, currency, amount, vendorcode, vendorname, chaseno, remarks, po, poissued, poinstock, debit, sales, ringi, finish, epsonno);*/

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
            dgvExpenseTransfer.Cursor = Cursors.Default;

            if (!validData)
                MessageBox.Show("Invalid Data Format");
            else
            {
                MessageBox.Show("Record has been saved");
                this.loadData();
            }
        }

        private void btnNonFinish_Click(object sender, EventArgs e)
        {

        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex == 0)
            {
                txtSearch.Enabled = false;
                this.loadData();
            }
            else
                txtSearch.Enabled = true;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.loadData();
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable tbTemplate = new DataTable();

            string[] headers = {"Date", "担當", "資產", "Parts no.", "Rev", "Mould no.", "Type", "Mould Code", "Cur", "Amount", "Vendor Code", "Vendor",
                                   "追跡番号", "Remarks", "P/O no.", "P/O Issue Date", "P/O Instock Date", "Debit Note Apply Date", "Fixed Asset Sales Apply Date", 
                                   "Ringi no.", "Finish", "Epson管理no."};

            foreach (string header in headers)
                tbTemplate.Columns.Add(header);

            ExportXlsUtil.XlsUtil(tbTemplate);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Delete selected record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvExpenseTransfer.SelectedRows)
                    {
                        string id = row.Cells[0].Value.ToString();

                        string query = string.Format("delete from tb_expensetransfer where et_id = '{0}'", id);

                        DataService.GetInstance().ExecuteNonQuery(query);
                    }
                    MessageBox.Show("Record deleted");

                    this.loadData();
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (DataGridViewRow row in dgvExpenseTransfer.Rows)
            {
                string id = row.Cells[0].Value.ToString();
                string date = row.Cells[1].Value.ToString();
                string ic = row.Cells[2].Value.ToString();
                string asset = row.Cells[3].Value.ToString();
                string partno = row.Cells[4].Value.ToString();
                string rev = row.Cells[5].Value.ToString();
                string mouldno = row.Cells[6].Value.ToString();
                string type = row.Cells[7].Value.ToString();
                string mouldcode = row.Cells[8].Value.ToString();
                string currency = row.Cells[9].Value.ToString();
                string amount = row.Cells[10].Value.ToString();
                string vendor = row.Cells[11].Value.ToString();
                string vendorname = row.Cells[12].Value.ToString();
                string chaseno = row.Cells[13].Value.ToString();
                string remarks = row.Cells[14].Value.ToString();
                string po = row.Cells[15].Value.ToString();
                string issued = row.Cells[16].Value.ToString();
                string instock = row.Cells[17].Value.ToString();
                string debitnote = row.Cells[18].Value.ToString();
                string fasales = row.Cells[19].Value.ToString();
                string ringi = row.Cells[20].Value.ToString();
                string finished = row.Cells[21].Value.ToString();
                string epsonno = row.Cells[22].Value.ToString();

                string query = string.Format("update tb_expensetransfer set et_date = '{0}', et_incharge = '{1}', et_asset = '{2}', et_partno = '{3}', et_rev = '{4}'" +
                    ", et_mouldno = '{5}', et_type = '{6}', et_mouldcode = '{7}', et_cur = '{8}', et_amount = '{9}', et_vendorcode = '{10}', et_vendor = '{11}'" +
                    ", et_chaseno = '{12}', et_remarks = '{13}', et_pono = '{14}', et_poissued = '{15}', et_poinstock = '{16}', et_debit = '{17}'" +
                    ", et_fasales = '{18}', et_ringino = '{19}', et_finish = '{20}', et_epsonno = '{21}' where et_id = '{22}'", date, ic, asset, partno, rev, mouldno,
                    type, mouldcode, currency, amount, vendor, vendorname, chaseno, remarks, po, issued, instock, debitnote, fasales, ringi, finished, epsonno, id);

                DataService.GetInstance().ExecuteNonQuery(query);

            }

            this.Cursor = Cursors.Default;

            MessageBox.Show("Record has been saved");
            this.loadData();
        }

        private void dgvExpenseTransfer_MouseDown(object sender, MouseEventArgs e)
        {
            /*try
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hti = dgvExpenseTransfer.HitTest(e.X, e.Y);
                    dgvExpenseTransfer.ClearSelection();
                    dgvExpenseTransfer.Rows[hti.RowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }*/
        }
    }
}
