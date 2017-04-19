using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Mould_System.file.csv
{
    public static class ExportCsvUtil
    {
        public static void ExportCsvWithPath(DataTable table, string fileHeader, string directory)
        {
            string datetime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filename = directory + @"\" + fileHeader + datetime + ".csv";

            FileStream fs = new FileStream(filename, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            int icolcount = table.Columns.Count;

            //sw.WriteLine(title);

            for (int i = 0; i < icolcount; i++)
            {
                sw.Write(table.Columns[i]);
                if (i < icolcount - 1)
                    sw.Write(",");
            }
            sw.Write('\n');
            //sw.WriteLine(sw.NewLine);

            foreach (DataRow dr in table.Rows)
            {
                for (int i = 0; i < icolcount; i++)
                {
                    if (table.Columns[i].ColumnName == "REVISION" || table.Columns[i].ColumnName == "Rev" || table.Columns[i].ColumnName == "明細")
                    {
                        if (!Convert.IsDBNull(dr[i]))
                            //sw.Write(dr[i].ToString());
                            sw.Write("=" + Escape(dr[i].ToString()) + "");
                    }
                    else
                    {
                        if (!Convert.IsDBNull(dr[i]))
                            //sw.Write(dr[i].ToString());
                            sw.Write(Escape(dr[i].ToString()));
                    }
                    if (i < icolcount - 1)
                        sw.Write(",");
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public static void ExportCsv(DataTable table, string title, string fileHeader)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            string filename;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                DefaultExt = "csv",
                Filter = "CSV Files (*.csv)|*.csv",
                FilterIndex = 1,
                FileName = fileHeader,// + year + month + day,
                Title = title
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = sfd.FileName;
                    FileStream fs = new FileStream(filename, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                    int icolcount = table.Columns.Count;

                    //sw.WriteLine(title);

                    for (int i = 0; i < icolcount; i++)
                    {
                        sw.Write(table.Columns[i]);
                        if (i < icolcount - 1)
                            sw.Write(",");
                    }
                    sw.Write('\n');
                    //sw.WriteLine(sw.NewLine);

                    foreach (DataRow dr in table.Rows)
                    {
                        for (int i = 0; i < icolcount; i++)
                        {
                            if (table.Columns[i].ColumnName == "Rev" || table.Columns[i].ColumnName == "rev" || table.Columns[i].ColumnName == "REV." || table.Columns[i].ColumnName == "REV" || table.Columns[i].ColumnName == "pono" || table.Columns[i].ColumnName == "PO" || table.Columns[i].ColumnName == "po" || table.Columns[i].ColumnName == "訂單號碼"
                            || table.Columns[i].ColumnName == "Vendor Code" || table.Columns[i].ColumnName == "Vendor" || table.Columns[i].ColumnName == "CD計算月" || table.Columns[i].ColumnName == "P/O" || table.Columns[i].ColumnName == "P/O no." || table.Columns[i].ColumnName == "Pono" || table.Columns[i].ColumnName == "MouldCode" || table.Columns[i].ColumnName == "Oem")
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                    //sw.Write(dr[i].ToString());
                                    sw.Write("=" + Escape(dr[i].ToString()) + "");
                            }
                            else if (table.Columns[i].ColumnName == "Fac" || table.Columns[i].ColumnName == "固定資産番号")
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                {
                                    if (((string)dr[i]).Contains(","))
                                    {
                                        string[] line = ((string)dr[i]).Split(',');
                                        string text = string.Join("&", line);

                                        sw.Write(text);
                                    }
                                    else
                                        sw.Write(Escape(dr[i].ToString()));
                                }
                            }
                            else
                            {
                                if (!Convert.IsDBNull(dr[i]))
                                    //sw.Write(dr[i].ToString());
                                    sw.Write(Escape(dr[i].ToString()));
                            }
                            if (i < icolcount - 1)
                                sw.Write(",");
                        }
                        sw.Write(sw.NewLine);
                    }
                    sw.Close();

                    MessageBox.Show("Record downloaded");
                }
                catch
                {
                    MessageBox.Show("File is using by other process");
                }
            }
        }

        public static void ExportCsvGrid(DataGridView dgv, string title, string fileHeader)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            string filename;

            SaveFileDialog sfd = new SaveFileDialog()
            {
                DefaultExt = "csv",
                Filter = "CSV Files (*.csv)|*.csv",
                FilterIndex = 1,
                FileName = fileHeader,// + year + month + day,
                Title = title
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = sfd.FileName;
                    FileStream fs = new FileStream(filename, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                    int icolcount = dgv.Columns.Count;

                    //sw.WriteLine(title);

                    for (int i = 0; i < icolcount; i++)
                    {
                        sw.Write(dgv.Columns[i].HeaderText);
                        if (i < icolcount - 1)
                            sw.Write(",");
                    }
                    sw.Write('\n');
                    //sw.WriteLine(sw.NewLine);

                    foreach (DataGridViewRow dr in dgv.Rows)
                    {
                        for (int i = 0; i < icolcount; i++)
                        {
                            if (dgv.Columns[i].HeaderText == "Rev" || dgv.Columns[i].HeaderText == "rev" || dgv.Columns[i].HeaderText == "REV." || dgv.Columns[i].HeaderText == "REV" || dgv.Columns[i].HeaderText == "pono" || dgv.Columns[i].HeaderText == "PO" || dgv.Columns[i].HeaderText == "po" || dgv.Columns[i].HeaderText == "訂單號碼"
                            || dgv.Columns[i].HeaderText == "Vendor Code" || dgv.Columns[i].HeaderText == "Vendor" || dgv.Columns[i].HeaderText == "CD計算月" || dgv.Columns[i].HeaderText == "P/O" || dgv.Columns[i].HeaderText == "P/O no.")
                            {
                                if (!Convert.IsDBNull(dr.Cells[i].Value))
                                    //sw.Write(dr[i].ToString());
                                    sw.Write("=" + Escape(dr.Cells[i].Value.ToString()) + "");
                            }
                            else
                            {
                                if (!Convert.IsDBNull(dr.Cells[i].Value))
                                    //sw.Write(dr[i].ToString());
                                    sw.Write(Escape(dr.Cells[i].Value.ToString()));
                            }
                            if (i < icolcount - 1)
                                sw.Write(",");
                        }
                        sw.Write(sw.NewLine);
                    }
                    sw.Close();

                    MessageBox.Show("Record downloaded");
                }
                catch
                {
                    MessageBox.Show("File is using by other process");
                }
            }
        }

        public static string Escape(this string str)
        {
            return "\"" + str.Replace("\"", "\"\"") + "\"";
        }
    }
}
