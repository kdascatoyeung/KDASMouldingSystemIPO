using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Mould_System.services
{
    class DataService
    {
        private SqlConnection connection;
        private static DataService _dataService = null;
        private SqlCommand command;

        private DataService()
        {
            //string connectionString = "server=HSP1DB01\\KM_SQUARE;database=db_mould;user id=general;password=JLgj2007";
            string connectionString = "server=KDTHK-INTDB\\KDTHK_DB;database=db_mould;user id=sa;password=Aa123456";
            //string connectionString = "server=SQLSERVER\\TESTSERVER;Integrated Security=SSPI;database=db_mould";
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;//
        }

        public static DataService GetInstance()
        {
            if (_dataService == null)
                _dataService = new DataService();

            return _dataService;
        }

        public SqlConnection Connection
        {
            get { return connection; }
        }

        public SqlDataReader ExecuteReader(string query)
        {
            command.CommandText = query;
            return command.ExecuteReader();
        }

        public object ExecuteScalar(string query)
        {
            command.CommandText = query;
            return command.ExecuteScalar();
        }

        public SqlCommand CreateCommand(string query)
        {
            return connection.CreateCommand();
        }

        public int ExecuteNonQuery(string commandText)
        {
            command.CommandText = commandText;
            return command.ExecuteNonQuery();
        }

        public SqlTransaction BeginTransaction()
        {
            return Connection.BeginTransaction();
        }
    }
}
