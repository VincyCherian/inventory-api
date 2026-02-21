
using InventoryProject.Models;

namespace InventoryProject.Services
{
    public interface IProductServices
    {

        public Task<Product?> CreateProductAsync(Product pdt);

        public Task<Product?> UpdateProductAsync(int id, Product pdt);

        public Task<bool> DeleteProductAsync(int id);

        public Task<Product?> GetProductByIDAsync(int id);

        public Task<List<Product>> GetAllProductAsync();


    }
}
