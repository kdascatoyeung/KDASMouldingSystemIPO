using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Mould_System.test
{
    public class DataRetriever : IDataPageRetriever
    {
        private string tableName;
        private SqlCommand command;

        public DataRetriever(string table, SqlConnection connection)
        {
            command = connection.CreateCommand();
            this.tableName = table;
        }

        private int rowCountValue = -1;

        public int RowCount
        {
            get
            {
                if (rowCountValue != -1)
                    return rowCountValue;

                command.CommandText = "SELECT COUNT(*) FROM " + tableName;
                rowCountValue = (int)command.ExecuteScalar();
                return rowCountValue;
            }
        }

        private DataColumnCollection columnsValue;

        public DataColumnCollection Columns
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (columnsValue != null)
                {
                    return columnsValue;
                }

                // Retrieve the column information from the database.
                command.CommandText = "SELECT * FROM " + tableName;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.FillSchema(table, SchemaType.Source);
                columnsValue = table.Columns;
                return columnsValue;
            }
        }

        private string commaSeparatedListOfColumnNamesValue = null;

        private string CommaSeparatedListOfColumnNames
        {
            get
            {
                // Return the existing value if it has already been determined. 
                if (commaSeparatedListOfColumnNamesValue != null)
                {
                    return commaSeparatedListOfColumnNamesValue;
                }

                // Store a list of column names for use in the 
                // SupplyPageOfData method.
                System.Text.StringBuilder commaSeparatedColumnNames =
                    new System.Text.StringBuilder();
                bool firstColumn = true;
                foreach (DataColumn column in Columns)
                {
                    if (!firstColumn)
                    {
                        commaSeparatedColumnNames.Append(", ");
                    }
                    commaSeparatedColumnNames.Append(column.ColumnName);
                    firstColumn = false;
                }

                commaSeparatedListOfColumnNamesValue =
                    commaSeparatedColumnNames.ToString();
                return commaSeparatedListOfColumnNamesValue;
            }
        }

        // Declare variables to be reused by the SupplyPageOfData method. 
        private string columnToSortBy;
        private SqlDataAdapter adapter = new SqlDataAdapter();

        public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            // Store the name of the ID column. This column must contain unique  
            // values so the SQL below will work properly. 
            if (columnToSortBy == null)
            {
                columnToSortBy = this.Columns[0].ColumnName;
            }

            if (!this.Columns[columnToSortBy].Unique)
            {
                throw new InvalidOperationException(String.Format(
                    "Column {0} must contain unique values.", columnToSortBy));
            }

            // Retrieve the specified number of rows from the database, starting 
            // with the row specified by the lowerPageBoundary parameter.
            command.CommandText = "Select Top " + rowsPerPage + " " +
                CommaSeparatedListOfColumnNames + " From " + tableName +
                " WHERE " + columnToSortBy + " NOT IN (SELECT TOP " +
                lowerPageBoundary + " " + columnToSortBy + " From " +
                tableName + " Order By " + columnToSortBy +
                ") Order By " + columnToSortBy;
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);
            return table;
        }
    }
}
