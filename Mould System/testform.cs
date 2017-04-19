using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.services;
using System.Diagnostics;

namespace Mould_System
{
    public partial class testform : Form
    {
        public testform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<DisposalData> list = new List<DisposalData>();

            string query = "select dd_mould, dd_partno from tb_disposaldetail where dd_status = N'廢棄完了'";
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(new DisposalData { Mould = reader.GetString(0).Trim(), PartNo = reader.GetString(1).Trim() });
            }

            list = list.Distinct().ToList();

            List<string> chaseNoList = new List<string>();

            foreach (DisposalData item in list)
            {
                string text = string.Format("select tm_chaseno from tb_betamould where tm_mouldno = '{0}' and tm_itemcode = '{1}'", item.Mould, item.PartNo);
                using (IDataReader reader = DataService.GetInstance().ExecuteReader(text))
                {
                    while (reader.Read())
                        chaseNoList.Add(reader.GetString(0).Trim());
                }
            }

            foreach (string item in chaseNoList)
            {
                string text = string.Format("update tb_betamould set tm_st_code = 'L' where tm_chaseno = '{0}'", item);
                DataService.GetInstance().ExecuteNonQuery(text);

                string text2 = string.Format("update TB_FA_APPROVAL set f_remarks = N'已廢棄' where f_chaseno = '{0}'", item);
                DataServiceNew.GetInstance().ExecuteNonQuery(text2);
            }
        }
    }

    public class DisposalData
    {
        public string Mould{get;set;}
        public string PartNo{get;set;}
    }
}
