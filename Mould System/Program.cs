using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mould_System.services;
using CustomUtil.utils.authentication;
using Mould_System.forms._1.quotation;
using System.Data;
using CustomUtil.utils.import;

namespace Mould_System
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ImportExcel2007.TranslateToTable(ofd.FileName);

                foreach (DataRow row in table.Rows)
                {
                    string id = row.ItemArray[0].ToString().Trim();
                    string group = row.ItemArray[1].ToString().Trim();

                    string query = string.Format("update tb_vendor set v_group = '{0}' where v_id = '{1}'", group, id);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }
            }*/

            GlobalService.Owner = AdUtil.getUsername("kmhk.local");
            //GlobalService.Owner = "Cato Yeung Pui Kwan (楊沛昆)";

            //GlobalService.IPO1st = "Ho Kin Hang(何健恒,Ken)";
            //GlobalService.IPO2nd = "Ho Kin Hang(何健恒,Ken)";
            GlobalService.IPO1st = "Poon Nga Wai(潘雅慧,Anna)";
            GlobalService.IPO2nd = "Cheng Chong Wah(鄭創華)";


            //Application.Run(new testform());
            if (GlobalService.Owner == "Cheng Chong Wah(鄭創華)")
                Application.Run(new MainSimple());
            else
                Application.Run(new frmMain());
        }
    }
}
