using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace People.NewPerson
{
    public class DataClient
    {
            
            private string ConStr = Environment.GetEnvironmentVariable("SQL_DB_CONNECTION");

            private string _sqlQuery = "SELECT USER_NAME();";

            private SqlCommand _command;

            private SqlConnection _connection;

        public DataClient()
        {
            
            _connection = new SqlConnection(ConStr);
            _command = new SqlCommand(_sqlQuery, _connection);
            _connection.Open();
            SqlDataReader sqlDataReader = _command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Console.WriteLine(sqlDataReader.GetValue(0));
            }
            _connection.Close();
        }


    }
}