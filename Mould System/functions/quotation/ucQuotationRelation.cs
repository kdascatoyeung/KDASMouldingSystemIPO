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
using Mould_System.checking;
using Mould_System.file.csv;

namespace Mould_System.functions.quotation
{
    public partial class ucQuotationRelation : UserControl
    {
        public event EventHandler formClose;

        public ucQuotationRelation(string mouldno, string itemcode)
        {
            InitializeComponent();

            this.loadData2(mouldno);

            this.loadData(mouldno, itemcode);

            /*this.loadRelationship(mouldno);

            this.loadRelationship2(mouldno);

            this.loadRelationship3(mouldno);*/
        }

        DataTable tmptable;

        private void loadData2(string mouldno)
        {
            tmptable = new DataTable();

            string[] headers = { "mouldno", "itemcode", "type", "remarks" };

            foreach (string header in headers)
                tmptable.Columns.Add(header);

            string query = string.Format("select distinct sc_itemcode, sc_mouldno, sc_type, sc_remarks from tb_setcommon where sc_mouldno = '{0}'", mouldno);

            string mould = "";

            List<string> filterlist = new List<string>();

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string itemcode = GlobalService.reader.GetString(0);
                mould = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                filterlist.Add(itemcode);

                tmptable.Rows.Add(new object[] { mould, itemcode, type, remarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            this.loadMainData(mould, filterlist);

            this.loadCommonData(mould);

            DataView view = tmptable.DefaultView;

            tmptable = view.ToTable(true, "mouldno", "itemcode", "type", "remarks");

            dgvRelationship.DataSource = tmptable;
        }

        private void loadMainData(string mouldno, List<string> filterlist)
        {
            filterlist = filterlist.Distinct().ToList();

            for (int i = 0; i < filterlist.Count; i++)
            {
                string filter = filterlist[i];
                string query = string.Format("select tm_mouldno, tm_itemcode, tm_type, tm_rm from tb_betamould where tm_mouldno = '{0}' and tm_itemcode != '{1}'", mouldno, filter);

                GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                while (GlobalService.reader.Read())
                {
                    string mould = GlobalService.reader.GetString(0);
                    string itemcode = GlobalService.reader.GetString(1);
                    string type = GlobalService.reader.GetString(2);
                    string remarks = GlobalService.reader.GetString(3);

                    tmptable.Rows.Add(new object[] { mould, itemcode, type, remarks });

                    Debug.WriteLine("Main Row Added");
                }
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
            }
        }

        private void loadCommonData(string mouldno)
        {
            string query = string.Format("select t.tm_mouldno, t.tm_itemcode, t.tm_type, t.tm_rm from tb_betamould as t, tb_setcommon as sc" +
                " where t.tm_mouldno = sc.sc_oldmouldno and sc.sc_mouldno = '{0}' and sc.sc_type = 'Common'", mouldno);

            Debug.WriteLine("QUERY: " + query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string mould = GlobalService.reader.GetString(0);
                string itemcode = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                tmptable.Rows.Add(new object[] { mould, itemcode, type, remarks });

                Debug.WriteLine("Common Row Added");
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadData(string mouldno, string itemcode)
        {
            DataTable table = new DataTable();

            string query = string.Format("select top 1 t.tm_mouldno as mouldno, t.tm_mouldcode_code as mouldcode" +
                ", t.tm_vendor_code as vendor, v.v_name as vendorname, t.tm_group as pgroup"+
                " from tb_betamould as t, tb_vendor as v where t.tm_vendor_code = v.v_code" +
                " and t.tm_mouldno = '{0}' and t.tm_itemcode = '{1}' order by tm_id desc", mouldno, itemcode);

            GlobalService.adapter = new System.Data.SqlClient.SqlDataAdapter(query, DataService.GetInstance().Connection);

            GlobalService.adapter.Fill(table);

            dgvMouldDetail.DataSource = table;
        }

        private void loadRelationship(string mouldno)
        {
            string query = string.Format("select distinct tm_itemcode as itemcode, tm_mouldno as mouldno, tm_type as type, tm_remarks as remarks" +
                " from tb_betamould where tm_mouldno = '{0}'", mouldno);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string itemcode = GlobalService.reader.GetString(0);
                string mould = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                dgvRelationship.Rows.Add(new object[] { mould, itemcode, type, remarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadRelationship2(string mouldno)
        {
            string query = string.Format("select distinct t.tm_itemcode, t.tm_mouldno, sc.sc_type, sc.sc_remarks from tb_betamould as t, tb_setcommon as sc" +
                    " where t.tm_mouldno = sc.sc_oldmouldno and sc.sc_mouldno = sc.sc_mouldno and sc.sc_mouldno = '{0}'", mouldno);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string itemcode = GlobalService.reader.GetString(0);
                string mould = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                dgvRelationship.Rows.Add(new object[] { mould, itemcode, type, remarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void loadRelationship3(string mouldno)
        {
            string query = string.Format("select distinct sc_itemcode, sc_mouldno, sc_type, sc_remarks from tb_setcommon" +
                    " where sc_mouldno = '{0}'", mouldno);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string itemcode = GlobalService.reader.GetString(0);
                string mould = GlobalService.reader.GetString(1);
                string type = GlobalService.reader.GetString(2);
                string remarks = GlobalService.reader.GetString(3);

                dgvRelationship.Rows.Add(new object[] { mould, itemcode, type, remarks });
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (formClose != null)
                this.formClose(this, new EventArgs());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isChecked)
                MessageBox.Show("Please check data first");
            else
            {
                string mouldno = dgvMouldDetail.Rows[0].Cells[0].Value.ToString();

                for (int i = 0; i < dgvSetup.Rows.Count - 1; i++)
                {
                    string partno = dgvSetup.Rows[i].Cells[0].Value.ToString();
                    string setcommon = dgvSetup.Rows[i].Cells[1].Value.ToString();
                    string remarks = "";

                    string cellvalue = Convert.ToString(dgvSetup.Rows[i].Cells[2].Value);

                    if (!string.IsNullOrEmpty(cellvalue))
                        remarks = cellvalue;

                    Debug.WriteLine(partno + "  " + setcommon + "  " + remarks);

                    string insertText = "";

                    string updateText = "";

                    if (setcommon == "1")
                    {
                        string oldmould = "";

                        try
                        {
                            oldmould = DataChecking.getTopMouldNo(partno);
                        }
                        catch
                        {
                            oldmould = "";
                        }

                        insertText = string.Format("if not exists (select * from tb_setcommon where sc_itemcode = '{0}' and sc_mouldno = '{1}' and sc_type = 'Common')" +
                            " insert into tb_setcommon (sc_itemcode, sc_mouldno, sc_oldmouldno, sc_type, sc_remarks) values ('{0}', '{1}', '{2}', 'Common', '{3}')", partno, mouldno, oldmould, remarks);

                        if(DataChecking.isMouldExists(oldmould, partno))
                            updateText = string.Format("update tb_betamould set tm_remarks = '{0}', tm_moulditemviewer = 'Yes', tm_common = 'Common' where tm_itemcode = '{1}' and tm_mouldno = '{2}'", remarks, partno, oldmould);
                        else
                        updateText = string.Format("update tb_betamould set tm_remarks = '{0}', tm_moulditemviewer = 'Yes', tm_type = case when tm_type = 'Single' then 'Common' when tm_type = 'TM' then 'Common' when tm_type = 'Set' then 'Set & Common' else 'Common' end" +
                            " where tm_itemcode = '{1}'", remarks, partno);
                    }
                    else
                    {
                        insertText = string.Format("if not exists (select * from tb_setcommon where sc_itemcode = '{0}' and sc_mouldno = '{1}' and sc_type = 'Set')" +
                            " insert into tb_setcommon (sc_itemcode, sc_mouldno, sc_oldmouldno, sc_type, sc_remarks) values ('{0}', '{1}', '{2}', 'Set', '{3}')", partno, mouldno, mouldno, remarks);

                        updateText = string.Format("update tb_betamould set tm_mouldno = '{0}', tm_remarks = '{1}', tm_moulditemviewer = 'Yes', tm_type = case when tm_type = 'Single' then 'Set' when tm_type = 'TM' then 'Set' when tm_type = 'Common' then 'Set & Common' else 'Set' end" +
                            " where tm_itemcode = '{2}'", mouldno, remarks, partno);
                    }

                    DataService.GetInstance().ExecuteNonQuery(insertText);

                    DataService.GetInstance().ExecuteNonQuery(updateText);

                    string query = string.Format("select distinct sc_type from tb_setcommon where sc_mouldno = '{0}'", mouldno);

                    List<string> listType = new List<string>();

                    GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

                    while (GlobalService.reader.Read())
                    {
                        string result = GlobalService.reader.GetString(0);
                        listType.Add(result);
                    }
                    GlobalService.reader.Close();
                    GlobalService.reader.Dispose();

                    string updateType = "";

                    if (listType.Contains("Set") && listType.Contains("Common"))
                        updateType = "Set & Common";
                    else if (listType.Contains("Set") && !listType.Contains("Common"))
                        updateType = "Set";
                    else if (!listType.Contains("Set") && listType.Contains("Common"))
                        updateType = "Common";
                    else
                        updateType = "Single";
                    
                    string finalText = string.Format("update tb_betamould set tm_type = '{0}', tm_moulditemviewer = 'Yes' where tm_mouldno = '{1}' and tm_type = 'Single'", updateType, mouldno);

                    DataService.GetInstance().ExecuteNonQuery(finalText);
                }

                MessageBox.Show("Record has been saved");

                if (formClose != null)
                    formClose(this, new EventArgs());
            }
        }

        bool isChecked;

        private void btnCheck_Click(object sender, EventArgs e)
        {
            List<int> listIndex = new List<int>();

            bool validInput = true;

            for (int i = 0; i < dgvSetup.Rows.Count - 1; i++)
            {
                string partno = dgvSetup.Rows[i].Cells[0].Value.ToString();
                string setcommon = dgvSetup.Rows[i].Cells[1].Value.ToString();
                string remarks = "";

                string cellvalue = Convert.ToString(dgvSetup.Rows[i].Cells[2].Value);

                if (!string.IsNullOrEmpty(cellvalue))
                {
                    remarks = cellvalue;
                }

                Debug.WriteLine(partno + "  " + setcommon + "  " + remarks);

                if (partno.Length != 8 && partno.Length != 10 && partno.Length != 12 && partno.Length != 15)
                {
                    Debug.WriteLine("Error itemcode: " + partno);
                    validInput = false;
                    listIndex.Add(dgvSetup.Rows[i].Index);
                }

                if (setcommon != "1" && setcommon != "2")
                {
                    Debug.WriteLine("Error Set Common: " + setcommon);
                    validInput = false;
                    listIndex.Add(dgvSetup.Rows[i].Index);
                }
            }

            listIndex = listIndex.Distinct().ToList();

            if (!validInput)
            {
                MessageBox.Show("Contains invalid data. Please check");
                foreach (int index in listIndex)
                {
                    Debug.WriteLine("Index: " + index);
                    dgvSetup.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                    dgvSetup.Rows[index].DefaultCellStyle.ForeColor = Color.White;
                }
                isChecked = false;
            }
            else
            {
                MessageBox.Show("Data checked. You can save now");
                foreach(DataGridViewRow row in dgvSetup.Rows)
                {
                    row.DefaultCellStyle.BackColor = SystemColors.ControlLightLight;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                isChecked = true;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvRelationship.Rows.Count == 0)
                return;

            string mouldno = dgvRelationship.Rows[0].Cells[0].Value.ToString();

            DataTable dltable = (DataTable)dgvRelationship.DataSource;

            /*string[] headers = { "Mould No.", "Part No.", "Type", "Remarks" };

            foreach (string header in headers)
                dltable.Columns.Add(header);*/

            ExportCsvUtil.ExportCsv(dltable, "", mouldno);
            
        }

        private void dgvSetup_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvSetup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvSetup.SelectedRows == null)
                return;

            foreach(DataGridViewRow row in dgvSetup.SelectedRows)
                dgvSetup.Rows.Remove(row);
        }
    }
}
