using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Net.SourceForge.Koogra.Excel;

namespace Mould_System.file.excel
{
    public class ImportXlsUtil
    {
        private Workbook excel;

        public ImportXlsUtil(string filePath)
        {
            this.excel = new Workbook(filePath);
        }

        public ImportXlsUtil(Stream stream)
        {
            this.excel = new Workbook(stream);
        }

        protected DataTable SaveToDataTable(Worksheet sheet)
        {
            DataTable table = new DataTable();

            uint minRow = sheet.Rows.MinRow;
            uint maxRow = sheet.Rows.MaxRow;

            Row firstRow = sheet.Rows[minRow];

            uint minCol = firstRow.Cells.MinCol;
            uint maxCol = firstRow.Cells.MaxCol;

            for (uint i = minCol; i <= maxCol; i++)
            {
                table.Columns.Add(firstRow.Cells[i].FormattedValue());
            }
            for (uint i = minRow + 1; i <= maxRow; i++)
            {
                Row row = sheet.Rows[i];
                if (row != null)
                {
                    DataRow dr = table.NewRow();
                    for (uint j = minCol; j <= maxCol; j++)
                    {
                        Cell cell = row.Cells[j];
                        if (cell != null)
                        {
                            dr[Convert.ToInt32(j)] = cell.Value != null ? cell.Value.ToString() : String.Empty;
                        }
                    }
                    table.Rows.Add(dr);
                }
            }

            return table;
        }

        public DataTable toDataTable(int index)
        {
            Worksheet sheet = this.excel.Sheets[index];
            if (sheet == null)
            {
                throw new ApplicationException(String.Format("Index: {0} does not exist", index));
            }
            return this.SaveToDataTable(sheet);
        }

        public DataTable toDataTable(string sheetName)
        {
            Worksheet sheet = this.excel.Sheets.GetByName(sheetName);
            if (sheet == null)
            {
                throw new ApplicationException(String.Format("Name: {0} does not exist", sheetName));
            }
            return this.SaveToDataTable(sheet);
        }

        public static DateTime ParseDateTime(string cellValue)
        {
            DateTime date = default(DateTime);
            double value = default(double);
            if (double.TryParse(cellValue, out value))
            {
                date = DateTime.FromOADate(value);
            }
            else
            {
                DateTime.TryParse(cellValue, out date);
            }
            return date;
        }

        public static DataTable TranslateToTable(string filePath, string sheetName)
        {
            ImportXlsUtil utils = new ImportXlsUtil(filePath);
            return utils.toDataTable(sheetName);
        }

        public static DataTable TranslateToTable(string filePath, int sheetIndex)
        {
            ImportXlsUtil utils = new ImportXlsUtil(filePath);
            return utils.toDataTable(sheetIndex);
        }

        public static DataTable TranslateToTable(string filePath)
        {
            ImportXlsUtil utils = new ImportXlsUtil(filePath);
            return utils.toDataTable(0);
        }

        public static DataTable TranslateToTable(Stream stream, string sheetName)
        {
            ImportXlsUtil utils = new ImportXlsUtil(stream);
            return utils.toDataTable(sheetName);
        }

        public static DataTable TranslateToTable(Stream stream, int sheetIndex)
        {
            ImportXlsUtil utils = new ImportXlsUtil(stream);
            return utils.toDataTable(sheetIndex);
        }

        public static DataTable TranslateToTable(Stream stream)
        {
            ImportXlsUtil utils = new ImportXlsUtil(stream);
            return utils.toDataTable(0);
        }
    }
}
