using BestBuyBestPractices;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void CreateProduct(string name, double price, int categoryID);
    }

}
