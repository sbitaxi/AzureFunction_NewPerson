using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.Azure.Services.AppAuthentication;

namespace People.NewPerson
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
/*            var conn =  (SqlConnection) this.Database.GetDbConnection();
            conn.AccessToken = (new Microsoft.Azure.Services
                            .AppAuthentication.AzureServiceTokenProvider())
                            .GetAccessTokenAsync("https://database.windows.net/").Result;
 */       }

    }
}