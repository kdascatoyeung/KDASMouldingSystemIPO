using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mould_System.services;
using System.Windows.Forms;
using System.Data;
using CustomUtil.utils.import;

namespace Mould_System
{
    public class DataUtil
    {
        public static string GetLatestPdfId()
        {
            string thisMonth = DateTime.Today.ToString("yy/MM");

            string query = string.Format("select top 1 dr_seqid from tb_downloadRecord where dr_yymm = '{0}' order by dr_id desc", thisMonth);

            int id = 0;

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                {
                    while (GlobalService.Reader.Read())
                        id = GlobalService.Reader.GetInt32(0);
                }
                else
                    id = 0;
            }

            string year = string.Format("{0:yy}", DateTime.Today);
            string month = string.Format("{0:MM}", DateTime.Today);
            int newId = id + 1;

            string strId = newId.ToString("D3");

            string path = @"\\kdthk-dm1\MOSS$\CM\FixedAssets\FA" + year + month + "_" + strId + ".pdf";

            string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string filename = "FA" + year + month + "_" + strId + ".pdf";

            string insertText = string.Format("insert into tb_downloadRecord (dr_filename, dr_datetime, dr_yymm, dr_seqId) values ('{0}', '{1}', '{2}', '{3}')", filename, datetime, thisMonth, newId);
            DataService.GetInstance().ExecuteNonQuery(insertText);

            return "FA" + year + month + "_" + strId;
        }

        public static string GetMpa(string chaseNo)
        {
            string query = string.Format("select tm_mpa from tb_betamould where tm_chaseno = '{0}'", chaseNo);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetVendor(string chaseNo)
        {
            string query = string.Format("select tm_vendor_code from tb_betamould where tm_chaseno = '{0}'", chaseNo);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetModel(string chaseno)
        {
            string query = string.Format("select tm_model from tb_betamould where tm_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetCurrency(string chaseno)
        {
            string query = string.Format("select tm_currency from tb_betamould where tm_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetAmount(string chaseno)
        {
            string query = string.Format("select tm_amounthkd from tb_betamould where tm_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static void UpdateData()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel Files |*.xlsx";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ImportExcel2007.TranslateToTable(ofd.FileName);

                foreach (DataRow row in table.Rows)
                {
                    string chaseno = row.ItemArray[0].ToString().Trim();
                    string partno = row.ItemArray[1].ToString().Trim();
                    string rev = row.ItemArray[2].ToString().Trim();
                    if (rev.Length == 1) rev = "0" + rev;
                    string mould = row.ItemArray[3].ToString().Trim();
                    string div = row.ItemArray[4].ToString().Trim();
                    string type = row.ItemArray[5].ToString().Trim();
                    string currency = row.ItemArray[6].ToString().Trim();
                    string amount = row.ItemArray[7].ToString().Trim();
                    string amounthkd = row.ItemArray[8].ToString().Trim();
                    string mpa = row.ItemArray[9].ToString().Trim();
                    string fa = row.ItemArray[10].ToString().Trim();
                    string tmpfa = row.ItemArray[11].ToString().Trim();
                    string qty = row.ItemArray[12].ToString().Trim();
                    string common = row.ItemArray[13].ToString().Trim();
                    string itemtext = row.ItemArray[14].ToString().Trim();
                    string request = row.ItemArray[15].ToString().Trim();
                    string indate = ImportExcel2007.ParseDateTime(row.ItemArray[16].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (indate == "0001/01/01") indate = row.ItemArray[16].ToString().Trim();
                    string deliverydate = ImportExcel2007.ParseDateTime(row.ItemArray[17].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (deliverydate == "0001/01/01") deliverydate = row.ItemArray[17].ToString().Trim();
                    string projecttext = row.ItemArray[18].ToString().Trim();
                    string model = row.ItemArray[19].ToString().Trim();
                    string po = row.ItemArray[20].ToString().Trim();
                    string porev = row.ItemArray[21].ToString().Trim();
                    string issued = ImportExcel2007.ParseDateTime(row.ItemArray[22].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (issued == "0001/01/01") issued = row.ItemArray[22].ToString().Trim();
                    string category = row.ItemArray[23].ToString().Trim();
                    string ringi = row.ItemArray[24].ToString().Trim();
                    string vendor = row.ItemArray[25].ToString().Trim();
                    if (vendor.Length == 9) vendor = "0" + vendor;
                    string mouldcode = row.ItemArray[26].ToString().Trim();
                    string status = row.ItemArray[27].ToString().Trim();
                    string owner = row.ItemArray[28].ToString().Trim();
                    string oem = row.ItemArray[29].ToString().Trim();
                    string remarks = row.ItemArray[30].ToString().Trim();
                    string instockdate = ImportExcel2007.ParseDateTime(row.ItemArray[31].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (instockdate == "0001/01/01") instockdate = row.ItemArray[31].ToString().Trim();
                    string instockdate50 = ImportExcel2007.ParseDateTime(row.ItemArray[32].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (instockdate50 == "0001/01/01") instockdate50 = row.ItemArray[32].ToString().Trim();
                    string pgroup = row.ItemArray[33].ToString().Trim();
                    string ac = row.ItemArray[34].ToString().Trim();
                    string cc = row.ItemArray[35].ToString().Trim();
                    string checkdate = ImportExcel2007.ParseDateTime(row.ItemArray[36].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (checkdate == "0001/01/01") checkdate = row.ItemArray[36].ToString().Trim();
                    string checkdate2 = ImportExcel2007.ParseDateTime(row.ItemArray[37].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (checkdate2 == "0001/01/01") checkdate2 = row.ItemArray[37].ToString().Trim();
                    string cav = row.ItemArray[38].ToString().Trim();
                    string weight = row.ItemArray[39].ToString().Trim();
                    string equipment = row.ItemArray[40].ToString().Trim();
                    string shot = row.ItemArray[41].ToString().Trim();
                    string vertical = row.ItemArray[42].ToString().Trim();
                    string horizontal = row.ItemArray[43].ToString().Trim();
                    string height = row.ItemArray[44].ToString().Trim();
                    string ismodifiy = row.ItemArray[45].ToString().Trim();
                    string instockremarks = row.ItemArray[46].ToString().Trim();
                    string collectdate = ImportExcel2007.ParseDateTime(row.ItemArray[47].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (collectdate == "0001/01/01") collectdate = row.ItemArray[47].ToString().Trim();
                    string pass = row.ItemArray[48].ToString().Trim();
                    string pcs = row.ItemArray[49].ToString().Trim();
                    string rmb50 = row.ItemArray[50].ToString().Trim();
                    string rmbtax = row.ItemArray[51].ToString().Trim();
                    string cndate = ImportExcel2007.ParseDateTime(row.ItemArray[52].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (cndate == "0001/01/01") cndate = row.ItemArray[52].ToString().Trim();
                    string cnsenddate = ImportExcel2007.ParseDateTime(row.ItemArray[53].ToString().Trim()).ToString("yyyy/MM/dd");
                    if (cnsenddate == "0001/01/01") cnsenddate = row.ItemArray[53].ToString().Trim();

                    string query = string.Format("update tb_betamould set tm_itemcode = '{0}', tm_rev = '{1}', tm_mouldno = '{2}', tm_status = '{3}', tm_type = '{4}', tm_currency = '{5}', tm_amount = '{6}', tm_amounthkd = '{7}'" +
                        ", tm_mpa = '{8}', tm_fixedassetcode = '{9}', tm_tmpfixedassetcode = '{10}', tm_qty = '{11}', tm_common = '{12}', tm_itemtext = '{13}', tm_request = '{14}', tm_indate = '{15}', tm_deliverydate = '{16}'" +
                        ", tm_projecttext = '{17}', tm_model = '{18}', tm_po = '{19}', tm_porev = '{20}', tm_poissued = '{21}', tm_category = '{22}', tm_ringi_code = '{23}', tm_vendor_code = '{24}', tm_mouldcode_code = '{25}'" +
                        ", tm_st_code = '{26}', tm_owner = '{27}', tm_oemasset = '{28}', tm_rm = N'{29}', tm_instockdate = '{30}', tm_instockdate50 = '{31}', tm_group = '{32}', tm_accountcode = '{33}', tm_costcentre = '{34}'" +
                        ", tm_checkdate = '{35}', tm_checkdate2 = '{36}', tm_cav = '{37}', tm_weight = '{38}', tm_accessory = '{39}', tm_camera = '{40}', tm_vertical = '{41}', tm_horizontal = '{42}', tm_height = '{43}', tm_ismodify = '{44}'" +
                        ", tm_instockremarks = N'{45}', tm_collectdate = '{46}', tm_passremarks = N'{47}', tm_pcs = '{48}', tm_is50 = '{49}', tm_tax = '{50}', tm_cndatetime = '{51}', tm_cnsendtime = '{52}' where tm_chaseno = '{53}'",
                        partno, rev, mould, div, type, currency, amount, amounthkd, mpa, fa, tmpfa, qty, common, itemtext, request, indate, deliverydate, projecttext, model, po, porev, issued, category, ringi, vendor,
                        mouldcode, status, owner, oem, remarks, instockdate, instockdate50, pgroup, ac, cc, checkdate, checkdate2, cav, weight, equipment, shot, vertical, horizontal, height, ismodifiy, instockremarks,
                        collectdate, pass, pcs, rmb50, rmbtax, cndate, cnsenddate, chaseno);

                    DataService.GetInstance().ExecuteNonQuery(query);
                }

                MessageBox.Show("Record has been saved.");
            }
        }
    }
}
