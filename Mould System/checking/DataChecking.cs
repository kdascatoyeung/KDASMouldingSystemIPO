using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mould_System.services;
using System.Diagnostics;

namespace Mould_System.checking
{
    public class DataChecking
    {
        /********************************************************************************************************************
         * Id
         * ******************************************************************************************************************/
        public static int getFirstId(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_id from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_id asc", mouldno, itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }

        public static int getLastId(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_id from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_id desc", mouldno, itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }

        public static int getId(string chaseno)
        {
            string query = string.Format("select tm_id from tb_betamould where tm_chaseno = '{0}'", chaseno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            int id = Convert.ToInt32(command.ExecuteScalar());

            return id;
        }
        /********************************************************************************************************************
         * Chase No
         * ******************************************************************************************************************/
        public static string getChaseNo()
        {
            string chaseno = "";

            int lastId = 0;

            string text = "select top 1 tm_id from tb_betamould order by tm_id desc";
            //SqlDataReader reader = DataService.GetInstance().ExecuteReader(text);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(text);

            if (GlobalService.reader.HasRows)
            {
                while (GlobalService.reader.Read())
                    lastId = GlobalService.reader.GetInt32(0);
            }
            GlobalService.reader.Close();

            lastId = lastId + 1;

            chaseno = "MS-" + lastId.ToString("D6");

            GlobalService.reader.Dispose();
            return chaseno;
        }

        public static string getChaseNoById(int id)
        {
            string query = string.Format("select tm_chaseno from tb_betamould where tm_id = '{0}'", id);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string chaseno = command.ExecuteScalar().ToString();

            command.Dispose();

            return chaseno;
        }

        public static string getChaseNoByItem(string itemcode, string rev, string mouldno)
        {
            string query = string.Format("select top 1 tm_chaseno from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_mouldno = '{2}' order by tm_chaseno desc", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string chaseno = command.ExecuteScalar().ToString();

            command.Dispose();

            return chaseno;
        }
        /********************************************************************************************************************
         * Item Code
         * ******************************************************************************************************************/
        public static bool isItemCodeExists(string itemcode)
        {
            bool isExists = false;

            string query = string.Format("select tm_itemcode from tb_betamould where tm_itemcode = '{0}'", itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            object ckItemCode = command.ExecuteScalar();
            if (ckItemCode != null)
                isExists = true;

            command.Dispose();

            return isExists;
        }

        public static bool isItemCodeExists2(string itemcode)
        {
            bool isExists = false;

            itemcode = itemcode.Remove(itemcode.Length-1);
            
            string query = string.Format("select tm_itemcode from tb_betamould where left(tm_itemcode, len(tm_itemcode) -1 ) = '{0}' and tm_st_code != 'C'", itemcode);

            Debug.WriteLine("Query: " + query);

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            object ckItemCode = command.ExecuteScalar();
            if (ckItemCode != null)
                isExists = true;

            command.Dispose();

            Debug.WriteLine(isExists);
            return isExists;
        }

        public static string getLastRev(string itemcode)
        {
            string rev = "";

            string query = string.Format("select top 1 tm_rev from tb_betamould where tm_itemcode = '{0}' order by tm_rev desc", itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            rev = command.ExecuteScalar().ToString();

            command.Dispose();

            return rev;
        }

        public static string getLastRevByMould(string itemcode, string mouldno)
        {
            string rev = "";

            string query = string.Format("select top 1 tm_rev from tb_betamould where tm_itemcode = '{0}' and tm_mouldno = '{1}' order by tm_rev desc", itemcode, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            rev = command.ExecuteScalar().ToString();

            command.Dispose();

            return rev;
        }

        public static string getItemCode(int id)
        {
            string itemcode = "";

            string query = string.Format("select tm_itemcode from tb_betamould where tm_id = '{0}'", id);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            itemcode = command.ExecuteScalar().ToString();

            command.Dispose();
            return itemcode;
        }

        public static bool validItemCode(string itemcode, string rev, string mouldno)
        {
            bool valid = false;

            string query = string.Format("select tm_itemcode from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_mouldno = '{2}'", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            object objItemCode = command.ExecuteScalar();
            if (objItemCode != null)
                valid = true;

            command.Dispose();
            return valid;
        }
        /********************************************************************************************************************
         * Mould No
         * ******************************************************************************************************************/
        public static string getFirstMouldNo(string itemcode)
        {
            string result = "";

            string query = string.Format("select top 1 tm_mouldno from tb_betamould where tm_itemcode = '{0}' and tm_type != 'Set' order by tm_mouldno asc", itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            object objResult = command.ExecuteScalar();

            if (objResult != null)
                result = objResult.ToString();

            return result;
        }

        public static string getLastThree2(string itemcode)
        {
            string result = "";

            itemcode = itemcode.Remove(itemcode.Length - 1);

            string query = string.Format("select top 1 tm_mouldno from tb_betamould where tm_type != 'Set' and left(tm_itemcode, len(tm_itemcode) - 1) = '{0}' order by tm_mouldno desc", itemcode);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
            {
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
                string tmp = DataService.GetInstance().ExecuteScalar(query).ToString();
                int mId = Convert.ToInt32(tmp.Substring(tmp.Length - 2));
                int cMid = mId + 1;
                result = cMid.ToString("00");
                Debug.WriteLine(result);
            }
            else
            {
                result = "01";
            }
            GlobalService.reader.Close();

            GlobalService.reader.Dispose();
            return result;
            return result;
        }

        public static string getLastThree(string itemcode)
        {
            string result = "";

            string query = string.Format("select top 1 tm_mouldno from tb_betamould where tm_itemcode = '{0}' and tm_type != 'Set' order by tm_mouldno desc", itemcode);
            //SqlDataReader reader = DataService.GetInstance().ExecuteReader(query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
            {
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
                string tmp = DataService.GetInstance().ExecuteScalar(query).ToString();
                int mId = Convert.ToInt32(tmp.Substring(tmp.Length - 2));
                int cMid = mId + 1;
                result = cMid.ToString("00");
                Debug.WriteLine(result);
            }
            else
            {
                result = "01";
            }
            GlobalService.reader.Close();

            GlobalService.reader.Dispose();
            return result;
        }

        public static string getLastMouldNo(string itemcode)
        {
            string result = "";
            string query = string.Format("select top 1 tm_mouldno from tb_betamould where tm_itemcode = '{0}' and tm_type != 'Set' order by tm_mouldno desc", itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            result = command.ExecuteScalar().ToString();

            return result;
        }

        public static string getMouldNo(int id)
        {
            string mouldno = "";

            string query = string.Format("select tm_mouldno from tb_betamould where tm_id = '{0}'", id);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            mouldno = command.ExecuteScalar().ToString();

            return mouldno;
        }

        public static string getMouldNoByItem(string itemcode, string rev)
        {
            string mouldno = "";

            string query = string.Format("select tm_mouldno from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}'", itemcode, rev);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            mouldno = command.ExecuteScalar().ToString();

            return mouldno;
        }

        public static string getTopMouldNo(string itemcode)
        {
            string result = "";
            string query = string.Format("select top 1 tm_mouldno from tb_betamould where tm_itemcode = '{0}' order by tm_mouldno desc", itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            result = command.ExecuteScalar().ToString();

            return result;
        }
        /********************************************************************************************************************
         * Rev
         * ******************************************************************************************************************/
        public static string getRev(int id)
        {
            string rev = "";

            string query = string.Format("select tm_rev from tb_betamould where tm_id = '{0}'", id);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            rev = command.ExecuteScalar().ToString();

            return rev;
        }
        /********************************************************************************************************************
         * Amount
         * ******************************************************************************************************************/
        public static decimal amountWithRate(string currency, string amount)
        {
            decimal calAmount = 0;

            int year;
            int month = Convert.ToInt32(DateTime.Today.Month);

            if (month >= 4)
                year = Convert.ToInt32(DateTime.Today.AddYears(1).Year);
            else
                year = Convert.ToInt32(DateTime.Today.Year);

            double usdRate = 0, jpyRate = 0, rmbRate = 0, eurRate = 0;

            string query = string.Format("select mp_usd, mp_jpy, mp_rmb, mp_eur from tb_mprate where mp_year = '{0}'", year);
            //SqlDataReader reader = DataService.GetInstance().ExecuteReader(query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            while (GlobalService.reader.Read())
            {
                usdRate = Convert.ToDouble(GlobalService.reader.GetString(0));
                jpyRate = Convert.ToDouble(GlobalService.reader.GetString(1));
                rmbRate = Convert.ToDouble(GlobalService.reader.GetString(2));
                eurRate = Convert.ToDouble(GlobalService.reader.GetString(3));
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            decimal tmpAmount = 0;
            try
            {
                tmpAmount = Convert.ToDecimal(amount);
            }
            catch
            {
                tmpAmount = 0;
            }

            if (currency == "HKD")
                calAmount = tmpAmount;
            if (currency == "USD")
                calAmount = tmpAmount * (decimal)usdRate;
            if (currency == "JPY")
                calAmount = tmpAmount * (decimal)jpyRate;
            if (currency == "RMB")
                calAmount = tmpAmount * (decimal)rmbRate;
            if (currency == "EUR")
                calAmount = tmpAmount * (decimal)eurRate;
            return calAmount;
        }

        public static decimal getTotalAmountByItem(string itemcode, string rev, string vendor)
        {
            decimal amount = 0;

            //string query = string.Format("select sum(convert(decimal,tm_amount)) from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_vendor_code = '{2}'" +
               // " and (tm_st_code = 'P' or tm_st_code = 'K' or tm_st_code = 'S') and (tm_transfer != 'Waiting for Disposal' or tm_transfer != 'Disposal') group by tm_itemcode, tm_rev, tm_vendor_code", itemcode, rev, vendor);
            string query = string.Format("select sum(convert(decimal,tm_amount)) from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_vendor_code = '{2}'" +
               " and (tm_transfer != 'Waiting for Disposal' or tm_transfer != 'Disposal') group by tm_itemcode, tm_rev, tm_vendor_code", itemcode, rev, vendor);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            Debug.WriteLine(query);
            try
            {
                amount = (decimal)command.ExecuteScalar();
            }
            catch
            {
                amount = 0;
            }
            return amount;
        }
        /********************************************************************************************************************
         * Vendor
         * ******************************************************************************************************************/
        public static bool isValidVendor(string vendor)
        {
            bool valid = false;

            string query = string.Format("select * from tb_vendor where v_code = '{0}'", vendor);
            //SqlDataReader reader = DataService.GetInstance().ExecuteReader(query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
                valid = true;
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
            return valid;
        }

        public static string getVendorName(string vendor)
        {
            string name = "";

            string query = string.Format("select v_name from tb_vendor where v_code = '{0}'", vendor);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            name = (string)command.ExecuteScalar();

            return name;
        }

        public static string getCurrency(string vendor)
        {
            string currency = "";

            string query = string.Format("select v_paycurr from tb_vendor where v_code = '{0}'", vendor);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            currency = command.ExecuteScalar().ToString();

            return currency;
        }

        public static string getVendorPerson(string vendor)
        {
            string person = "";

            try
            {
                string query = string.Format("select p.tm_name from tb_vendor as v, tb_purchaser as p where v.v_group = p.tm_group and v.v_code = '{0}'", vendor);
                SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
                person = command.ExecuteScalar().ToString();
            }
            catch
            {
                person = "Cannot get purchaser. Please check Purchaser master";
            }

            return person;
        }

        public static string getVendorGroup(string vendor)
        {
            string group = "";

            string query = string.Format("select v_group from tb_vendor where v_code = '{0}'", vendor);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            group = command.ExecuteScalar().ToString();

            return group;
        }

        public static string getVendorByItem(string itemcode, string rev, string mouldno)
        {
            string vendor = "";

            string query = string.Format("select tm_vendor_code from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_mouldno = '{2}'", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);

            Debug.WriteLine(query);
            vendor = command.ExecuteScalar().ToString();

            return vendor;
        }

        public static string getVendorByMould(string mouldno)
        {
            string vendor = "";

            string query = string.Format("select tm_vendor_code from tb_betamould where tm_mouldno = '{0}'", mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            vendor = command.ExecuteScalar().ToString();

            command.Dispose();

            return vendor;
        }

        public static string getTopVendorByMould(string mouldno)
        {
            string query = string.Format("select top 1 tm_vendor_code from tb_betamould where tm_mouldno = '{0}' order by tm_chaseno desc", mouldno);

            string vendor = DataService.GetInstance().ExecuteScalar(query).ToString();

            return vendor;
        }
        /********************************************************************************************************************
         * Ringi
         * ******************************************************************************************************************/
        public static bool isValidRingi(string ringi)
        {
            bool valid = false;

            string query = string.Format("select * from tb_ringi where rg_no = '{0}'", ringi);
            //SqlDataReader reader = DataService.GetInstance().ExecuteReader(query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
                valid = true;
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }

        public static decimal getBalance(string ringi)
        {
            decimal balance = 0;

            string query = string.Format("select rg_balance from tb_ringi where rg_no = '{0}'", ringi);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            balance = Convert.ToDecimal(command.ExecuteScalar());

            return balance;
        }

        public static int getRingiCount(string itemcode, string rev, string mouldno)
        {
            int count = 0;

            string query = string.Format("select count(*) from tb_ringirelations" +
                " where rr_itemcode = '{0}' and rr_rev = '{1}' and rr_mouldno = '{2}'", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            try
            {
                count = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                count = 0;
            }
            command.Dispose();
            return count;
        }

        public static string getRingiByItem(string itemcode, string rev, string mouldno)
        {
            string ringi = "";

            string query = string.Format("select r.rr_ringi from tb_ringirelations as r, tb_betamould as t" +
                " where t.tm_itemcode = r.rr_itemcode and t.tm_rev = r.rr_rev and r.rr_itemcode = '{0}' and r.rr_rev = '{1}' and t.tm_mouldno = '{2}'", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            try
            {
                ringi = command.ExecuteScalar().ToString();
            }
            catch
            {
                ringi = "Unknown";
            }
            command.Dispose();
            return ringi;
        }

        public static bool containRingiByChaseNo(string chaseno)
        {
            bool valid = false;
            string query = string.Format("select r.rr_ringi from tb_ringirelations as r, tb_betamould as t" +
                " where t.tm_chaseno = r.rr_chaseno and t.tm_chaseno = '{0}'", chaseno);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
                valid = true;
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }
        /********************************************************************************************************************
         * Mould Code
         * ******************************************************************************************************************/
        public static bool isValidMouldCode(string mouldcode)
        {
            bool valid = false;

            string query = string.Format("select * from tbm_mouldcode where mc_mouldcode = '{0}'", mouldcode);
            //SqlDataReader reader = DataService.GetInstance().ExecuteReader(query);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
                valid = true;
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }

        public static string getMouldCodeByItem(string itemcode, string rev, string mouldno)
        {
            string mouldcode = "";

            string query = string.Format("select tm_mouldcode_code from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_mouldno = '{2}'", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            mouldcode = command.ExecuteScalar().ToString();

            return mouldcode;
        }

        public static string getMouldCodeByMould(string mouldno)
        {
            string mouldcode = "";

            string query = string.Format("select tm_mouldcode_code from tb_betamould where tm_mouldno = '{0}'", mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            mouldcode = command.ExecuteScalar().ToString();

            command.Dispose();

            return mouldcode;
        }

        public static string getMouldCode(string chaseno)
        {
            string mouldcode = "";

            string query = string.Format("select tm_mouldcode_code from tb_betamould where tm_chaseno = '{0}'", chaseno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            mouldcode = command.ExecuteScalar().ToString();

            return mouldcode;
        }

        public static string getTopMouldCodeByMould(string mouldno)
        {
            string query = string.Format("select top 1 tm_mouldcode_code from tb_betamould where tm_mouldno = '{0}' order by tm_chaseno desc", mouldno);

            string mouldcode = DataService.GetInstance().ExecuteScalar(query).ToString();

            return mouldcode;
        }
        /********************************************************************************************************************
         * Status
         * ******************************************************************************************************************/
        public static string getLastStatus(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_status from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_id desc", mouldno, itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string status = Convert.ToString(command.ExecuteScalar());

            command.Dispose();

            return status;
        }

        public static string getKdcStatus(string source)
        {
            string query = string.Format("select st_kdcstatus from tb_betaqstatus where st_code = '{0}'", source);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string kdcstatus = Convert.ToString(command.ExecuteScalar());

            command.Dispose();

            return kdcstatus;
        }

        public static string getKdcStatusByItem(string itemcode, string rev, string mouldno)
        {
            string query = string.Format("select st.st_kdcstatus from tb_betamould as t, tb_betaqstatus as st where t.tm_st_code = st.st_code and t.tm_itemcode = '{0}' and t.tm_rev = '{1}' and t.tm_mouldno = '{2}'", itemcode, rev, mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string kdcstatus = command.ExecuteScalar().ToString();

            command.Dispose();

            return kdcstatus;
        }

        public static string getKdcStatusByMould(string mouldno)
        {
            string query = string.Format("select st.st_kdcstatus from tb_betamould as t, tb_betaqstatus as st where t.tm_st_code = st.st_code and t.tm_mouldno = '{0}'", mouldno);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string kdcstatus = command.ExecuteScalar().ToString();

            command.Dispose();

            return kdcstatus;
        }

        public static string getCurrentStatus(string qstatus)
        {
            string query = string.Format("select st_status from tb_betaqstatus where st_code = '{0}'", qstatus);
            string status = DataService.GetInstance().ExecuteScalar(query).ToString();

            return status;
        }
        /********************************************************************************************************************
         * User
         * ******************************************************************************************************************/
        public static bool isValidUser(string username)
        {
            bool valid = false;


            return valid;
        }

        public static bool isValidPassword(string password)
        {
            bool valid = false;


            return valid;
        }

        /********************************************************************************************************************
         * Directory
         * ******************************************************************************************************************/
        public static string getDirectory()
        {
            string query = "select set_directory from tb_setting";
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string directory = command.ExecuteScalar().ToString();

            command.Dispose();

            return directory;
        }

        /********************************************************************************************************************
         * 50% MPA
         * ******************************************************************************************************************/
        public static string getMpa(int id)
        {
            string query = string.Format("select tm_mpa from tb_betamould where tm_id = '{0}'", id);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string mpa = command.ExecuteScalar().ToString();

            command.Dispose();

            return mpa;
        }

        public static string isMpa(string chaseno)
        {
            string query = string.Format("select tm_mpa from tb_betamould where tm_chaseno = '{0}'", chaseno);
            string result = DataService.GetInstance().ExecuteScalar(query).ToString();

            return result;
        }
        /********************************************************************************************************************
        * Mould
        * ******************************************************************************************************************/
        public static string getCommon(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_common from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_id desc", mouldno, itemcode);
            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string common = command.ExecuteScalar().ToString();

            command.Dispose();

            return common;
        }

        public static string getCommonByMouldNo(string mouldno)
        {
            string query = string.Format("select top 1 tm_common from tb_betamould where tm_mouldno = '{0}' order by tm_id desc", mouldno);

            SqlCommand command = new SqlCommand(query, DataService.GetInstance().Connection);
            string common = command.ExecuteScalar().ToString();

            command.Dispose();

            return common;
        }
        /********************************************************************************************************************
        * Fixed Asset Code
        * ******************************************************************************************************************/
        public static bool isFixedAssetExists(string chaseno)
        {
            bool isExists = false;

            string query = string.Format("select tm_fixedassetcode from tb_betamould where tm_chaseno = '{0}'", chaseno);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (GlobalService.reader.HasRows)
                isExists = true;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return isExists;
        }

        public static string getFixedAssetCode(string chaseno)
        {
            string query = string.Format("select tm_fixedassetcode from tb_betamould where tm_chaseno = '{0}'", chaseno);
            string fac = DataService.GetInstance().ExecuteScalar(query).ToString();

            return fac;
        }

        public static string getTmpFixedAssetCode(string chaseno)
        {
            string query = string.Format("select tm_tmpfixedassetcode from tb_betamould where tm_chaseno = '{0}'", chaseno);
            string tmpfac = DataService.GetInstance().ExecuteScalar(query).ToString();

            return tmpfac;
        }
        /********************************************************************************************************************
        * Others
        * ******************************************************************************************************************/
        public static string getJpyRate(string year, string month)
        {
            string query = string.Format("select jpy_rate from tb_monthjpy where jpy_year = '{0}' and jpy_month = '{1}'", year, month);
            string rate = DataService.GetInstance().ExecuteScalar(query).ToString();

            return rate;
        }

        public static bool isItemExist(string itemcode, string rev, string vendorcode)
        {
            string query = string.Format("select * from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}' and tm_vendor_code = '{2}'", itemcode, rev, vendorcode);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
            {
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
                return true;
            }
            else
            {
                GlobalService.reader.Close();
                GlobalService.reader.Dispose();
                return false;
            }
        }

        public static string getPO(string chaseno)
        {
            string result = "";

            string query = string.Format("select tm_po from tb_betamould where tm_chaseno = '{0}'", chaseno);
            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);
            if (GlobalService.reader.HasRows)
            {
                while (GlobalService.reader.Read())
                {
                    string po = GlobalService.reader.GetString(0);
                    result = po;
                }
            }
            else
                result = "-";

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return result;
        }

        public static string getCreated(string chaseno)
        {
            string created = "";

            string query = string.Format("select tm_indate from tb_betamould where tm_chaseno = '{0}'", chaseno);
            created = DataService.GetInstance().ExecuteScalar(query).ToString();

            return created;
        }

        public static string getLastModifiedBy(string chaseno)
        {
            string lastmodifiedby = "";

            string query = string.Format("select tm_lastmodifiedby from tb_betamould where tm_chaseno = '{0}'", chaseno);
            lastmodifiedby = DataService.GetInstance().ExecuteScalar(query).ToString();

            return lastmodifiedby;
        }

        public static string getLastModifiedOn(string chaseno)
        {
            string lastmodifiedon = "";

            string query = string.Format("select tm_lastmodifiedon from tb_betamould where tm_chaseno = '{0}'", chaseno);
            lastmodifiedon = DataService.GetInstance().ExecuteScalar(query).ToString();

            return lastmodifiedon;
        }

        public static void DoubleBuffered(DataGridView dgv, bool setting)
        {
            System.Type dgvType = dgv.GetType();
            System.Reflection.PropertyInfo info = dgvType.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            info.SetValue(dgv, setting, null);
        }

        public static bool validOem(string oemcode)
        {
            bool valid;

            string query = string.Format("select * from tb_oem where oem_code = '{0}'", oemcode);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (GlobalService.reader.HasRows)
                valid = true;

            else
                valid = false;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }

        public static string GetLastCnChaseNo()
        {
            string query = "select top 1 tm_chaseno from tb_betamould where tm_chaseno like 'CM%' order by tm_chaseno desc";

            string result ="";
            string chaseno = "";

            try
            {
                result = DataService.GetInstance().ExecuteScalar(query).ToString();

                result = result.Substring(3);

                int number = Convert.ToInt32(result) + 1;

                chaseno = "CM-" + number.ToString("D7");
            }
            catch
            {
                chaseno = "CM-1000001";
            }

            return chaseno;
        }

        public static string getLastChaseNo()
        {
            string query = "select top 1 tm_chaseno from tb_betamould where tm_chaseno like 'MS%' order by tm_chaseno desc";

            string result = DataService.GetInstance().ExecuteScalar(query).ToString();

            result = result.Substring(3);

            int number = Convert.ToInt32(result) + 1;

            string chaseno = "MS-" + number.ToString("D7");

            return chaseno;
        }

        public static string getLastTransferNo()
        {
            string query = "select top 1 his_tmchaseno from tb_transferhistory order by his_tmchaseno desc";

            string result = DataService.GetInstance().ExecuteScalar(query).ToString();

            Debug.WriteLine("Latest Transfer No."+ result);

            result = result.Substring(3);

            int number = Convert.ToInt32(result) + 1;

            string chaseno = "TM-" + number.ToString("D7");

            return chaseno;
        }

        //Instock Info
        public static string getCheckDate(string chaseno)
        {
            string query = string.Format("select tm_checkdate from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string checkdate = "";

            try
            {
                checkdate = DataService.GetInstance().ExecuteScalar(query).ToString();

                return checkdate;
            }
            catch
            {
                return checkdate;
            }
        }

        public static string getCav(string chaseno)
        {
            string query = string.Format("select tm_cav from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string cav = "";

            try
            {
                cav = DataService.GetInstance().ExecuteScalar(query).ToString();

                return cav;
            }
            catch
            {
                return cav;
            }
        }

        public static string getWeight(string chaseno)
        {
            string query = string.Format("select tm_weight from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string weight = "";

            try
            {
                weight = DataService.GetInstance().ExecuteScalar(query).ToString();

                return weight;
            }
            catch
            {
                return weight;
            }
        }

        public static string getAccessory(string chaseno)
        {
            string query = string.Format("select tm_accessory from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string accessory = "";

            try
            {
                accessory = DataService.GetInstance().ExecuteScalar(query).ToString();

                return accessory;
            }
            catch
            {
                return accessory;
            }
        }

        public static string getCamera(string chaseno)
        {
            string query = string.Format("select tm_camera from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string camera = "";

            try
            {
                camera = DataService.GetInstance().ExecuteScalar(query).ToString();

                return camera;
            }
            catch
            {
                return camera;
            }
        }

        public static string getVertical(string chaseno)
        {
            string query = string.Format("select tm_vertical from tb_betamould where tm_vertical = '{0}'", chaseno);

            string vertical = "";

            try
            {
                vertical = DataService.GetInstance().ExecuteScalar(query).ToString();

                return vertical;
            }
            catch
            {
                return vertical;
            }
        }

        public static string getHorizontal(string chaseno)
        {
            string query = string.Format("select tm_horizontal from tb_betamould where tm_horizontal = '{0}'", chaseno);

            string horizontal = "";

            try
            {
                horizontal = DataService.GetInstance().ExecuteScalar(query).ToString();

                return horizontal;
            }
            catch
            {
                return horizontal;
            }
        }

        public static string getHeight(string chaseno)
        {
            string query = string.Format("select tm_height from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string height = "";

            try
            {
                height = DataService.GetInstance().ExecuteScalar(query).ToString();

                return height;
            }
            catch
            {
                return height;
            }
        }

        public static string getAmount(string chaseno)
        {
            string query = string.Format("select tm_amount from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string amount = DataService.GetInstance().ExecuteScalar(query).ToString();

            return amount;
        }

        public static string getIssuedDate(string chaseno)
        {
            string query = string.Format("select tm_poissued from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string issued = "";

            try
            {
                issued = DataService.GetInstance().ExecuteScalar(query).ToString();

                return issued;
            }
            catch
            {
                return issued;
            }
        }

        public static string getInStock50(string chaseno)
        {
            string query = string.Format("select tm_instockdate50 from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string instock50 = DataService.GetInstance().ExecuteScalar(query).ToString();

            return instock50;
        }

        public static string getAccountCode(string oem)
        {
            string query = string.Format("select oem_accountcode from tb_oem where oem_code = '{0}'", oem);
            string accountcode = DataService.GetInstance().ExecuteScalar(query).ToString() ;

            return accountcode;
        }

        public static string getCostCentre(string oem)
        {
            string query = string.Format("select oem_costcentre from tb_oem where oem_code = '{0}'", oem);
            string costcentre = DataService.GetInstance().ExecuteScalar(query).ToString();

            return costcentre;
        }

        public static bool isValidInput(string mouldno, string itemcode, string rev)
        {
            bool valid = false;

            string query = string.Format("select * from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' and tm_rev = '{2}'", mouldno, itemcode, rev);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (GlobalService.reader.HasRows)
                valid = true;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }

        public static bool isValidPo(string po)
        {
            bool valid = false;

            string query = string.Format("select * from tb_betamould where tm_po = '{0}'", po);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (GlobalService.reader.HasRows)
                valid = true;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();
            return valid;
        }

        public static bool IsPoRmb(string po)
        {
            string query = string.Format("select tm_currency from tb_betamould where tm_po = '{0}'", po);

            string result = DataService.GetInstance().ExecuteScalar(query).ToString();

            if (result == "RMB")
                return true;
            else
                return false;
        }

        public static bool isPoWaitInStock(string po)
        {
            bool valid = false;

            string query = string.Format("select tm_st_code from tb_betamould where tm_po = '{0}'", po);

            string status = DataService.GetInstance().ExecuteScalar(query).ToString();

            if (status == "K")
                valid = true;

            return valid;
        }

        public static string getStatusByPo(string po)
        {
            string query = string.Format("select st.st_status from tb_betamould as t, tb_betaqstatus as st where t.tm_st_code = st.st_code and tm_po = '{0}'", po);
            string status = DataService.GetInstance().ExecuteScalar(query).ToString();

            return status;
        }

        public static string getStatusCodeByPo(string po)
        {
            string query = string.Format("select tm_st_code from tb_betamould where tm_po = '{0}'", po);
            string stcode = DataService.GetInstance().ExecuteScalar(query).ToString();

            return stcode;
        }

        public static string getOemContent(string oem)
        {
            string query = string.Format("select oem_content from tb_oem where oem_code = '{0}'", oem);
            string content = DataService.GetInstance().ExecuteScalar(query).ToString();

            return content;
        }

        public static string getTypeByPo(string po)
        {
            string query = string.Format("select distinct tm_status from tb_betamould where tm_po = '{0}'", po);
            string type = DataService.GetInstance().ExecuteScalar(query).ToString();

            return type;
        }

        public static string getInstock50ByPo(string po)
        {
            string query = string.Format("select distinct tm_instockdate50 from tb_betamould where tm_po = '{0}'", po);
            string instockdate50 = DataService.GetInstance().ExecuteScalar(query).ToString();

            return instockdate50;
        }

        public static string getInStockDateByPo(string po)
        {
            string query = string.Format("select tm_instockdate from tb_betamould where tm_po = '{0}'", po);
            string instockdate = DataService.GetInstance().ExecuteScalar(query).ToString();

            return instockdate;
        }

        public static string getAmountByItemcodeRev(string itemcode, string rev)
        {
            decimal amount = 0;

            string query = string.Format("select tm_amount from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}'", itemcode, rev);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string stramount = GlobalService.reader.GetString(0);
                decimal tmpamount = Convert.ToDecimal(stramount);

                amount = amount + tmpamount;
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return amount.ToString();
        }

        public static string getAmountHkdByItemcodeRev(string itemcode, string rev)
        {
            decimal amount = 0;

            string query = string.Format("select tm_amounthkd from tb_betamould where tm_itemcode = '{0}' and tm_rev = '{1}'", itemcode, rev);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            while (GlobalService.reader.Read())
            {
                string stramount = GlobalService.reader.GetString(0);
                decimal tmpamount = Convert.ToDecimal(stramount);

                amount = amount + tmpamount;
            }
            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return amount.ToString();
        }

        public static string getInstockdateByItemCodeRev(string itemcode, string rev)
        {
            string query = string.Format("select distinct tm_instockdate from tb_betamould where tm_itemcode = '{0}' and tm_rev =  '{1}'", itemcode, rev);

            string instockdate = DataService.GetInstance().ExecuteScalar(query).ToString();

            return instockdate;
        }

        public static string getPayTerm(string vendor)
        {
            string query = string.Format("select v_payterm from tb_vendor where v_code = '{0}'", vendor);

            string payterm = DataService.GetInstance().ExecuteScalar(query).ToString();

            return payterm;
        }

        public static string getPayCurrency(string vendor)
        {
            string query = string.Format("select v_paycurr from tb_vendor where v_code = '{0}'", vendor);

            string paycurr = DataService.GetInstance().ExecuteScalar(query).ToString();

            return paycurr;
        }

        public static string getTotalAmountHkdByVendor(string vendor)
        {
            string query = string.Format("select sum(isnull(cast(tm_amounthkd as decimal), 0)) from tb_betamould" +
                " where (t.tm_status != 'TM' or t.tm_status != 'TM+Modify') and t.tm_st_code = 'S' and tm_vendor_code = '{0}' group by tm_vendor_code", vendor);

            string amount = DataService.GetInstance().ExecuteScalar(query).ToString();

            return amount;
        }

        public static string getVendorCodeByChaseNo(string chaseno)
        {
            string query = string.Format("select tm_vendor_code from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string vendorcode = DataService.GetInstance().ExecuteScalar(query).ToString();

            return vendorcode;
        }

        public static string getModelByMouldItem(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_model from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_chaseno desc", mouldno, itemcode);

            string model = DataService.GetInstance().ExecuteScalar(query).ToString();

            return model;
        }

        public static string getVendorByMouldItem(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_vendor_code from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_chaseno desc", mouldno, itemcode);

            string vendor = DataService.GetInstance().ExecuteScalar(query).ToString();

            return vendor;
        }

        public static string getPcsByMouldItem(string mouldno, string itemcode)
        {
            string query = string.Format("select top 1 tm_pcs from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}' order by tm_chaseno desc", mouldno, itemcode);

            string pcs = DataService.GetInstance().ExecuteScalar(query).ToString();

            return pcs;
        }

        public static string getTopRemarksByMould(string mouldno)
        {
            string query = string.Format("select top 1 tm_rm from tb_betamould where tm_mouldno = '{0}' order by tm_chaseno desc", mouldno);

            string remarks = DataService.GetInstance().ExecuteScalar(query).ToString();

            return remarks;
        }

        public static string getTopInStockDateByMould(string mouldno)
        {
            string query = string.Format("select top 1 tm_instockdate from tb_betamould where tm_mouldno = '{0}' and tm_st_code = 'S' order by tm_chaseno desc", mouldno);

            string instockdate = DataService.GetInstance().ExecuteScalar(query).ToString();

            return instockdate;
        }

        public static string getTopOwner(string mouldno)
        {
            string query = string.Format("select top 1 tm_owner from tb_betamould where tm_mouldno = '{0}'", mouldno);

            string owner = DataService.GetInstance().ExecuteScalar(query).ToString();

            return owner;
        }

        public static string getTransferNo(string chaseno)
        {
            string query = string.Format("select tm_po from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string transferno = DataService.GetInstance().ExecuteScalar(query).ToString();

            return transferno;
        }

        public static bool isMouldExists(string mouldno, string itemcode)
        {
            bool isValid = false;

            string query = string.Format("select * from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}'", mouldno, itemcode);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (GlobalService.reader.HasRows)
                isValid = true;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return isValid;
        }

        public static string getModelByChaseno(string chaseno)
        {
            string query = string.Format("select tm_model from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string model = DataService.GetInstance().ExecuteScalar(query).ToString();

            return model;
        }

        public static bool ringiRelationExists(string ringi)
        {
            string query = string.Format("select * from tb_ringidetail where rd_ringino = '{0}'", ringi);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            bool valid = false;

            if (GlobalService.reader.HasRows)
                valid = true;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return valid;
        }

        public static string getRingiRelationModelName(string ringi)
        {
            string query = string.Format("select top 1 rd_modelname from tb_ringidetail where rd_ringino = '{0}' order by rd_ringino desc", ringi);

            string modelname = DataService.GetInstance().ExecuteScalar(query).ToString();

            return modelname;
        }

        public static string getRingiRelationSubject(string ringi)
        {
            string query = string.Format("select top 1 rd_subject from tb_ringidetail where rd_ringino = '{0}' order by rd_ringino desc", ringi);

            string subject = DataService.GetInstance().ExecuteScalar(query).ToString();

            return subject;
        }

        public static bool isMouldInStock(string mouldno)
        {
            bool isInStock = false;

            string query = string.Format("select t.tm_mouldno from tb_betamould as t, tb_setcommon as sc where t.tm_mouldno = sc.sc_oldmouldno" +
                " and t.tm_st_code != 'S' and t.tm_mouldno = '{0}'", mouldno);

            GlobalService.reader = DataService.GetInstance().ExecuteReader(query);

            if (!GlobalService.reader.HasRows)
                isInStock = true;

            GlobalService.reader.Close();
            GlobalService.reader.Dispose();

            return isInStock;
        }

        public static string getStatusByChaseno(string chaseno)
        {
            string query = string.Format("select tm_st_code from tb_betamould where tm_chaseno = '{0}'", chaseno);

            string status = DataService.GetInstance().ExecuteScalar(query).ToString();

            return status;
        }

        public static string getCommonMouldVendorByMould(string mouldno)
        {
            string query = string.Format("select top 1 tm_vendor_code  from tb_betamould where tm_mouldno = '{0}' and tm_type = 'Common' order by tm_id desc", mouldno);

            Debug.WriteLine("QUERY: " + query);

            string vendor = DataService.GetInstance().ExecuteScalar(query).ToString();

            return vendor;
        }

        public static string getKdcReportNo()
        {
            int year = DateTime.Today.Year;

            int month = DateTime.Today.Month;

            if (month >= 4)
                year++;

            string query = "";
            int number;

            if (!fyRecordExists(year.ToString()))
                query = string.Format("insert into tb_reportno (report_no, report_fy) values ('{0}', '{1}')", 1, year.ToString());

            else
                query = string.Format("update tb_reportno set report_no = report_no + 1 where report_fy = '{0}'", year.ToString());

            DataService.GetInstance().ExecuteNonQuery(query);

            string text = string.Format("select report_no from tb_reportno where report_fy = '{0}'", year.ToString());

            number = Convert.ToInt32(DataService.GetInstance().ExecuteScalar(text));

            Debug.WriteLine("NO: " + number);

            string strNum = number.ToString("D2");

            string strYr = year.ToString().Substring(2);

            return "MD-" + strYr + "-" + strNum;

        }

        public static bool fyRecordExists(string year)
        {
            string query = string.Format("select count(*) from tb_reportno where report_fy = '{0}'", year);
            object result = DataService.GetInstance().ExecuteScalar(query);

            if (result is DBNull || (int)result == 0)
                return false;

            return true;
        }

        public static string GetChaseNoByPO(string po)
        {
            string query = string.Format("select top 1 tm_chaseno from tb_betamould where tm_po = '{0}' order by tm_chaseno desc", po);

            string chaseno = DataService.GetInstance().ExecuteScalar(query).ToString();

            return chaseno;
        }
    }
}
