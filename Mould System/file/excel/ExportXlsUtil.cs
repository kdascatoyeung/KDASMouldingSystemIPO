using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mould_System.file.excel
{
    public class ExportXlsUtil
    {
        public static void XlsUtil(DataTable table)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = true;

            for (int i = 0; i < table.Columns.Count; i++)
                excel.Cells[1, i + 1] = table.Columns[i].Caption;

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (table.Columns[j].ColumnName == "正味價格" || table.Columns[j].ColumnName == "納期")
                        {
                            string str = table.Rows[i][j].ToString();
                            excel.Cells[i + 2, j + 1] = str;
                        }
                        else
                        {
                            string str = "'" + table.Rows[i][j].ToString();
                            excel.Cells[i + 2, j + 1] = str;
                        }
                    }
                }
            }

            Microsoft.Office.Interop.Excel.Range oRange = excel.get_Range("A1", "A1");
            oRange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Range iRange = excel.get_Range("A1", "A1");
            iRange.AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
            excel.DisplayAlerts = false;
            excel.AlertBeforeOverwriting = false;
        }

        public static void ExportDatagridview(DataGridView dgv)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            excel.Visible = true;

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible == true)
                    excel.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }

            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible != false)
                        {
                            string str = "'" + dgv.Rows[i].Cells[j].Value.ToString();
                            excel.Cells[i + 2, j + 1] = str;
                        }
                    }
                }
            }

            Microsoft.Office.Interop.Excel.Range oRange = excel.get_Range("A1", "A1");
            oRange.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Range iRange = excel.get_Range("A1", "A1");
            iRange.AutoFilter(1, Type.Missing, Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlAnd, Type.Missing, true);
            excel.DisplayAlerts = false;
            excel.AlertBeforeOverwriting = false;
        }

        public static string ExcelMultiSheet(DataSet ds)
        {
            string filepath;
            Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
            excelApp.Application.Workbooks.Add();

            DataTable table100 = ds.Tables[0];
            DataTable table50first = ds.Tables[1];
            DataTable table50second = ds.Tables[2];
            DataTable table50full = ds.Tables[3];

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[1];
            sheet1.Name = "100% MPA";

            for (int i = 0; i < table100.Columns.Count; i++)
                sheet1.Cells[1, i + 1] = table100.Columns[i].ColumnName;

            for (int i = 0; i < table100.Rows.Count; i++)
            {
                for (int j = 0; j < table100.Columns.Count; j++)
                    sheet1.Cells[i + 2, j + 1] = table100.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[2];
            sheet2.Name = "50% MPA 1st 50%";

            for (int i = 0; i < table50first.Columns.Count; i++)
                sheet2.Cells[1, i + 1] = table50first.Columns[i].ColumnName;

            for (int i = 0; i < table50first.Rows.Count; i++)
            {
                for (int j = 0; j < table50first.Columns.Count; j++)
                    sheet2.Cells[i + 2, j + 1] = table50first.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet3 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[3];
            sheet3.Name = "50% MPA 2nd 50%";

            for (int i = 0; i < table50second.Columns.Count; i++)
                sheet3.Cells[1, i + 1] = table50second.Columns[i].ColumnName;

            for (int i = 0; i < table50second.Rows.Count; i++)
            {
                for (int j = 0; j < table50second.Columns.Count; j++)
                    sheet3.Cells[i + 2, j + 1] = table50second.Rows[i][j].ToString();
            }

            excelApp.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);

            Microsoft.Office.Interop.Excel.Worksheet sheet4 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[4];
            //Microsoft.Office.Interop.Excel.Worksheet sheet4 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets.Add(After: excelApp.Sheets[excelApp.Sheets.Count]);
            sheet4.Name = "50% MPA 100% 2pcs & 1+1 pcs";

            for (int i = 0; i < table50full.Columns.Count; i++)
                sheet4.Cells[1, i + 1] = table50full.Columns[i].ColumnName;

            for (int i = 0; i < table50full.Rows.Count; i++)
            {
                for (int j = 0; j < table50full.Columns.Count; j++)
                    sheet4.Cells[i + 2, j + 1] = table50full.Rows[i][j].ToString();
            }

            filepath = @"C:\ReceivedPO\" + DateTime.Today.ToString("yyyyMMdd") + "_ReceivedPO.xls";

            string filename = "";

            SaveFileDialog sfd = new SaveFileDialog()
            {
                DefaultExt = "xls",
                Filter = "EXCEL Files (*.xls)|*.xls",
                FilterIndex = 1,
                FileName = DateTime.Today.ToString("yyyyMMdd") + "_ReceivedPO"// + year + month + day,
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = sfd.FileName;

                    excelApp.ActiveWorkbook.SaveAs(filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                    
                    //excelApp.ActiveWorkbook.Saved = true;
                    //excelApp.AlertBeforeOverwriting = false;
                    excelApp.Quit();

                    MessageBox.Show("Record saved to " + filename);
                }
                catch (COMException ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);

                    Debug.WriteLine(ex.Message + ex.StackTrace);
                }
            }
            return filename;
        }

        public static string multiSheetExcel(DataSet ds)
        {
            DataTable table100 = ds.Tables[0];
            DataTable table50first = ds.Tables[1];
            DataTable table50second = ds.Tables[2];
            DataTable table50full = ds.Tables[3];
            DataTable table5050 = ds.Tables[4];
            DataTable tableCn = ds.Tables[5];
            DataTable tableRmb = ds.Tables[6];

            string filename = "";

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Sheets sheets = workbook.Worksheets;

            for (int i = sheets.Count; i > 1; i--)
                ((Microsoft.Office.Interop.Excel.Worksheet)sheets[i]).Delete();

            for (int i = 1; i <= 6; i++)
            {
                workbook.Sheets.Add(Type.Missing, Type.Missing, 1, Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(i);
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[1];
            sheet1.Name = "100% Normal";

            for (int i = 0; i < table100.Columns.Count; i++)
                sheet1.Cells[1, i + 1] = table100.Columns[i].ColumnName;

            for (int i = 0; i < table100.Rows.Count; i++)
            {
                for (int j = 0; j < table100.Columns.Count; j++)
                    sheet1.Cells[i + 2, j + 1] = table100.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet2 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[2];
            sheet2.Name = "50% MPA 1st 50%";

            for (int i = 0; i < table50first.Columns.Count; i++)
                sheet2.Cells[1, i + 1] = table50first.Columns[i].ColumnName;

            for (int i = 0; i < table50first.Rows.Count; i++)
            {
                for (int j = 0; j < table50first.Columns.Count; j++)
                    sheet2.Cells[i + 2, j + 1] = table50first.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet3 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[3];
            sheet3.Name = "50% MPA 2nd 50%";

            for (int i = 0; i < table50second.Columns.Count; i++)
                sheet3.Cells[1, i + 1] = table50second.Columns[i].ColumnName;

            for (int i = 0; i < table50second.Rows.Count; i++)
            {
                for (int j = 0; j < table50second.Columns.Count; j++)
                    sheet3.Cells[i + 2, j + 1] = table50second.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet4 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[4];
            //Microsoft.Office.Interop.Excel.Worksheet sheet4 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets.Add(After: excelApp.Sheets[excelApp.Sheets.Count]);
            sheet4.Name = "50% MPA 100% 2pcs";

            for (int i = 0; i < table50full.Columns.Count; i++)
                sheet4.Cells[1, i + 1] = table50full.Columns[i].ColumnName;

            for (int i = 0; i < table50full.Rows.Count; i++)
            {
                for (int j = 0; j < table50full.Columns.Count; j++)
                    sheet4.Cells[i + 2, j + 1] = table50full.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet5 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[5];
            sheet5.Name = "50% MPA 100% 1+1 pcs";

            for (int i = 0; i < table5050.Columns.Count; i++)
                sheet5.Cells[1, i + 1] = table5050.Columns[i].ColumnName;

            for (int i = 0; i < table5050.Rows.Count; i++)
            {
                for (int j = 0; j < table5050.Columns.Count; j++)
                    sheet5.Cells[i + 2, j + 1] = table5050.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet6 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[6];
            sheet6.Name = "OEM=CN";

            for (int i = 0; i < tableCn.Columns.Count; i++)
                sheet6.Cells[1, i + 1] = tableCn.Columns[i].ColumnName;

            for (int i = 0; i < tableCn.Rows.Count; i++)
            {
                for (int j = 0; j < tableCn.Columns.Count; j++)
                    sheet6.Cells[i + 2, j + 1] = tableCn.Rows[i][j].ToString();
            }

            Microsoft.Office.Interop.Excel.Worksheet sheet7 = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.Sheets[7];
            sheet7.Name = "RMB";

            for (int i = 0; i < tableRmb.Columns.Count; i++)
                sheet7.Cells[1, i + 1] = tableRmb.Columns[i].ColumnName;

            for (int i = 0; i < tableRmb.Rows.Count; i++)
            {
                for (int j = 0; j < tableRmb.Columns.Count; j++)
                    sheet7.Cells[i + 2, j + 1] = tableRmb.Rows[i][j].ToString();
            }

            SaveFileDialog sfd = new SaveFileDialog()
            {
                DefaultExt = "xls",
                Filter = "EXCEL Files (*.xls)|*.xls",
                FilterIndex = 1,
                FileName = DateTime.Today.ToString("yyyyMMdd") + "_ReceivedPO"// + year + month + day,
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = sfd.FileName;

                    excelApp.ActiveWorkbook.SaveAs(filename, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel5, null, null, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);

                    //excelApp.ActiveWorkbook.Saved = true;
                    //excelApp.AlertBeforeOverwriting = false;
                    excelApp.Quit();

                    MessageBox.Show("Record saved to " + filename);
                }
                catch (COMException ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);

                    Debug.WriteLine(ex.Message + ex.StackTrace);
                }
            }

            return filename;
        }
    }
}
