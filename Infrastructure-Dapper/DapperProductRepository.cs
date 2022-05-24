using Dapper;
using System.Collections.Generic;
using System.Data;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        //Read data
        public IEnumerable<Product> GetAllProducts()
        {
            //dapper starts here, dapper extends ==> IDbConnection
            return _connection.Query<Product>("SELECT * FROM products;");

        }
        //Create data
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute(@"INSERT INTO PRODUCTS (Name, Price, CategoryID) 
                                  VALUES (@name, @price, @categoryID);",
            new {name = name, price = price, categoryID = categoryID});
         
        }
        //Update data
        public void UpdateProduct(int productID, string newName)
        {
            _connection.Execute("UPDATE products SET Name = @newName WHERE ProductID = @productID;",
                new { newName = newName, productID = productID });
        }
        //Delete data
        public void DeleteProduct(int productID) //need to delete from all places productID exists
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                new { productID = productID });
            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                new { productID = productID });
        }


    }
}
