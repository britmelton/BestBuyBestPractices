using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace BestBuyBestPractices
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region notes
            /*The Dapper Framework extends the IDbConnection interface available under the System.Data namespace (using directive). It has many extension
             methods defined under the SqlMapper class found under the using Dapper namespace (using directive).*/

            /*In order to use Dapper you need to declare an IDbConnection object and intitialize it to a SqlConnection to connect the database.*/
            #endregion

            //grabs the connection string info from the appsettings.json file
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            //create our IDbConnection that uses MySql, so Dapper can extend it
            IDbConnection conn = new MySqlConnection(connString);
            //in order to instanciate IDbconnection you need an instance of a class that implements it like MySqlConnection class

            var repo = new DapperProductRepository(conn);
            repo.CreateProduct("newStuff", 20.00, 1);

            var products = repo.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID}{product.Name}");
            }
        }
    }
}
