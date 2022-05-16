using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyBestPractices
{
    public class Product
    {
        public int ProductID { get; set;}
        public string Name { get; set;}
        public double Price { get; set;}
        public int CategoryID { get; set;}
        public int OnSale { get; set;}
        public string StockLevel { get; set;}
    }
}
