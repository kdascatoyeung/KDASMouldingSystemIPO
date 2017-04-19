using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Net.SourceForge.Koogra.Excel2007;
using Net.SourceForge.Koogra;

namespace Mould_System.file.excel
{
    public class ImportXls2007Util
    {
        private Workbook excel;

        public ImportXls2007Util(String filePath)
        {
            this.excel = new Workbook(filePath);
        }

        public ImportXls2007Util(Stream stream)
        {
            this.excel = new Workbook(stream);
        }

        protected DataTable SaveToDataTable(Worksheet sheet)
        {
            DataTable table = new DataTable();

            uint minRow = sheet.CellMap.FirstRow;
            uint maxRow = sheet.CellMap.LastRow;

            Row firstRow = sheet.GetRow(minRow);

            uint minCol = sheet.CellMap.FirstCol;
            uint maxCol = sheet.CellMap.LastCol;

            for (uint i = minCol; i <= maxCol; i++)
            {
                table.Columns.Add(firstRow.GetCell(i).GetFormattedValue());
            }

            for (uint r = minRow + 1; r <= maxRow; r++)
            {
                Row row = sheet.GetRow(r);
                if (row != null)
                {
                    DataRow dr = table.NewRow();
                    for (uint j = minCol; j <= maxCol; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell != null && cell.Value != "null")
                        {
                            //Debug.WriteLine(cell.Value.ToString());
                            dr[Convert.ToInt32(j)] = cell.Value != null ? cell.Value.ToString() : string.Empty;
                        }
                    }
                    table.Rows.Add(dr);
                }
            }
            return table;
        }

        public DataTable toDataTable(int index)
        {
            Worksheet sheet = this.excel.GetWorksheet(0);
            if (sheet == null)
            {
                throw new ApplicationException(String.Format("Index: {0} does not exist", index));
            }
            return this.SaveToDataTable(sheet);
        }

        public DataTable toDataTable(string sheetName)
        {
            Worksheet sheet = this.excel.GetWorksheetByName(sheetName);
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
            ImportXls2007Util utils = new ImportXls2007Util(filePath);
            return utils.toDataTable(sheetName);
        }

        public static DataTable TranslateToTable(string filePath, int sheetIndex)
        {
            ImportXls2007Util utils = new ImportXls2007Util(filePath);
            return utils.toDataTable(sheetIndex);
        }

        public static DataTable TranslateToTable(string filePath)
        {
            ImportXls2007Util utils = new ImportXls2007Util(filePath);
            return utils.toDataTable(0);
        }

        public static DataTable TranslateToTable(Stream stream, string sheetName)
        {
            ImportXls2007Util utils = new ImportXls2007Util(stream);
            return utils.toDataTable(sheetName);
        }

        public static DataTable TranslateToTable(Stream stream, int sheetIndex)
        {
            ImportXls2007Util utils = new ImportXls2007Util(stream);
            return utils.toDataTable(sheetIndex);
        }

        public static DataTable TranslateToTable(Stream stream)
        {
            ImportXls2007Util utils = new ImportXls2007Util(stream);
            return utils.toDataTable(0);
        }
    }
}
