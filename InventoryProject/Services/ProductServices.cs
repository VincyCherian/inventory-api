using InventoryProject.Models;
using Microsoft.EntityFrameworkCore;


using InventoryProject.Data;

namespace InventoryProject.Services
{
    public class ProductServices : IProductServices
    {
        private readonly AppDbContext _context;
        public ProductServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> CreateProductAsync(Product pdt)
        {
            if(pdt == null) return null;
            
                await _context.Products.AddAsync(pdt);
                await _context.SaveChangesAsync();
            return pdt;
        }
        public async Task<Product?> UpdateProductAsync(int id, Product p)
        {
             var old_pdt = await _context.Products.FirstOrDefaultAsync(prd => prd.ProductId == id);

            if(old_pdt == null)
            {
                return null;
            }

 
                old_pdt.ProductName = p.ProductName;
                old_pdt.ProductPrice = p.ProductPrice;
                old_pdt.ProductQuantity = p.ProductQuantity;
                old_pdt.ProductCategory = p.ProductCategory;

                await _context.SaveChangesAsync();
               
            return (old_pdt);
        }
        public async Task<bool> DeleteProductAsync(int id)
        {
            var p = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);

            if(p == null) return false;

            _context.Products.Remove(p);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product?> GetProductByIDAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(pdt => pdt.ProductId == id);
        }
        public async Task<List<Product>> GetAllProductAsync()
        {
            var pdt = await _context.Products.ToListAsync();

            return pdt;
        }


    }
}
