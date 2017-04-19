using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mould_System.file.excel;
using Mould_System.services;
using System.Diagnostics;
using System.Threading;

namespace Mould_System.functions.others
{
    public partial class frmProgressBar : Form
    {
        public frmProgressBar(string filename)
        {
            InitializeComponent();

            DataTable tmptable = ImportXlsUtil.TranslateToTable(filename);
            //customProgressBar1.Start();

            int count = 0;

            foreach (DataRow row in tmptable.Rows)
            {
                string rowChaseno = row.ItemArray[15].ToString();

                string rowPassremarks = row.ItemArray[20].ToString();

                string rowPassdate = row.ItemArray[21].ToString();

                string rowCollectdate = row.ItemArray[22].ToString();

                if (rowPassdate != "")
                    rowPassdate = ImportXlsUtil.ParseDateTime(rowPassdate).ToString("yyyy/MM/dd");

                string query = string.Format("update tb_betamould set tm_passdate = '{0}', tm_collectdate = '{1}', tm_passremarks = '{2}' where tm_chaseno = '{3}'",
                    rowPassdate, rowCollectdate, rowPassremarks, rowChaseno);

                //DataService.GetInstance().ExecuteNonQuery(query);

                string query2 = string.Format("update tb_betamould set tm_facremarks = tm_collectdate where tm_chaseno = '{0}' and tm_fixedAssetCode != ''", rowChaseno);

                //DataService.GetInstance().ExecuteNonQuery(query2);

                count += 1;

                System.Diagnostics.Debug.WriteLine("" + count);
            }

            Thread.Sleep(10);

            this.DialogResult = DialogResult.OK;
        }
    }
}
