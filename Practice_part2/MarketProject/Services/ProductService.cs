using DataBaseDAL;
using DataBaseDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.Services
{
    //for_review

    public class ProductService : IProductService
    {
        private readonly OrdersDbContext _dbContext;

        public ProductService(OrdersDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddAsync(decimal price, string category, string name)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(product => product.Name == name);
            if (product != null)
            {
                throw new Exception("Product with the same name already exists");
            }

            Product newProduct = new Product()
            {
                Price = price,
                Category = category,
                Name = name
            };

            await _dbContext.Products.AddAsync(newProduct);

            await _dbContext.SaveChangesAsync();

            return newProduct;
        }
    }
}
