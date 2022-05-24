using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace BestBuyBestPractices
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringProvider()
        {

        }

        public IDbConnection GetConnectionString()
        {
            //grabs the connection string info from the appsettings.json file
            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connString = configuration.GetConnectionString("DefaultConnection");
            //create our IDbConnection that uses MySql, so Dapper can extend it
            IDbConnection conn = new MySqlConnection(connString);
            //in order to instanciate IDbconnection you need an instance of a class that implements it like MySqlConnection class
            return conn;
        }

    }
}
