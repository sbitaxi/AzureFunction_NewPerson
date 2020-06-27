using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Reflection;
using Microsoft.Azure.Services.AppAuthentication;

namespace People.NewPerson
{
    public class DataClient
    {
            
            private string ConStr = Environment.GetEnvironmentVariable("SQL_DB_CONNECTION");

            private string _sprocName = "dbo.AddNewPerson";

            private SqlCommand _command;

            private SqlConnection _connection;

            private Person _person { get; set; }


        public DataClient(Person person)
        {
                _person = person;
                InitConnection();
                InitCommand();
                PopulateParamCollection();
                ExecSproc();

        }

        private void InitConnection()
        {
            _connection = new SqlConnection(ConStr);
            _connection.AccessToken = (new Microsoft.Azure.Services
                            .AppAuthentication.AzureServiceTokenProvider())
                            .GetAccessTokenAsync("https://database.windows.net/").Result;
        }

        private void InitCommand()
        {
            _command = new SqlCommand();
            _command.Connection = _connection;
            _command.CommandType = CommandType.StoredProcedure;
            _command.CommandText = _sprocName;
        }

        private void PopulateParamCollection()
        {

            // Get all the properties of the Person object.
            // In the future this method could be more generic
            // by passing in an object instead of hardcoding it.
            PropertyInfo[] properties = typeof(Person).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                // Initialize a new parameter
                SqlParameter sqlParameter = new SqlParameter();

                // Prepend Property name with @ to match SProc Parameter name
                sqlParameter.ParameterName = "@" + property.Name.ToString();

                // Assign a type to the Parameter
                sqlParameter.SqlDbType = SqlDbType.NVarChar;
                sqlParameter.Direction = ParameterDirection.Input;

                // Assign the value from the Person object
                sqlParameter.Value = property.GetValue(_person);

                // Append the Parameter to the parameters collection
                // of the SqlCommand object
                _command.Parameters.Add(sqlParameter);
            }
        }

        private void ExecSproc()
        {
                _connection.Open();
                _command.ExecuteNonQuery();

                _connection.Close();
        }


    }
}