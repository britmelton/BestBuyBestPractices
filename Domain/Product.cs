using Domain.Repositories;
using System;

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



        public static void DeleteProduct()
        {
            var configuration = new ConnectionStringProvider();
            using var conn = configuration.GetConnectionString();
            //ProductRepository instance - so we can call our dapper methods
            var prodRepo = new DapperProductRepository(conn);

            //User interaction
            Console.WriteLine($"Please enter the productID of the product you would like to delete:");
            var productID = Convert.ToInt32(Console.ReadLine());

            //Call the Dapper method
            prodRepo.DeleteProduct(productID);
        }


        public static void UpdateProductName()
        {

            var configuration = new ConnectionStringProvider();
            using var conn = configuration.GetConnectionString();

            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine($"What is the productID of the product you would like to update?");
            var productID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"What is the new name you would like for the product with an id of {productID}?");
            var updatedName = Console.ReadLine();

            prodRepo.UpdateProduct(productID, updatedName);
        }

        public static void CreateAndListProducts()
        {

            var configuration = new ConnectionStringProvider();
            using var conn = configuration.GetConnectionString();

            //created instance so we can call methods that hit the database
            var prodRepo = new DapperProductRepository(conn);

            Console.WriteLine($"What is the new product name?");
            var prodName = Console.ReadLine();

            Console.WriteLine($"What is the new product's price?");
            var price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"What is the new product's category id?");
            var categoryID = Convert.ToInt32(Console.ReadLine());

            prodRepo.CreateProduct(prodName, price, categoryID);


            //call the GetAllProducts method using that instance and store the result
            //in the products variable
            var products = prodRepo.GetAllProducts();

            //print each product from the products collection to the console
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }
        }

        public static void ListProducts()
        {

            var configuration = new ConnectionStringProvider();
            using var conn = configuration.GetConnectionString();

            var prodRepo = new DapperProductRepository(conn);
            var products = prodRepo.GetAllProducts();

            //print each product from the products collection to the console
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} {product.Name}");
            }
        }

    }
}
