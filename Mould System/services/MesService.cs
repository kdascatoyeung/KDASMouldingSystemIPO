using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Mould_System.services
{
    public class MesService
    {
         private SqlConnection connection;
         private static MesService _dataService = null;
        private SqlCommand command;

        private MesService()
        {
            string connectionString = "server=hkbipcsvr;database=MASTERMNG;Integrated Security=SSPI";
            //string connectionString = "server=HSP1DB02\\KM_TEST;database=db_test;user id=general;password=JLgj2007";
            //string connectionString = "server=SQLSERVER\\TESTSERVER;Integrated Security=SSPI;database=db_mould";
            connection = new SqlConnection(connectionString);
            connection.Open();
            command = new SqlCommand();
            command.Connection = connection;//
        }

        public static MesService GetInstance()
        {
            if (_dataService == null)
                _dataService = new MesService();

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
