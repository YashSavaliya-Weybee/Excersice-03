using Excersice_03.Data;
using Excersice_03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PartyProductContext _context;

        public ProductRepository(PartyProductContext context)
        {
            _context = context;
        }

        public async Task<List<ProductModel>> GetAllProduct()
        {
            return await _context.tblProduct.Select(product => new ProductModel()
            {
                Id = product.Id,
                ProductName = product.ProductName
            }).ToListAsync();
        }

        public async Task<string> AddProduct(ProductModel productModel)
        {
            var y = _context.tblProduct
                    .Where(x => x.ProductName == productModel.ProductName).FirstOrDefault();

            if (y == null)
            {
                var newProduct = new Product()
                {
                    ProductName = productModel.ProductName
                };
                await _context.AddAsync(newProduct);
                await _context.SaveChangesAsync();
                return newProduct.ProductName;
            }
            return null;
        }

        public async Task<bool> DeleteProduct(ProductModel productModel, int id)
        {
            if (id == productModel.Id)
            {
                var product = new Product()
                {
                    Id = id
                };
                _context.tblProduct.Remove(product);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> UpdateProduct(ProductModel productModel, int productId)
        {
            var y = _context.tblProduct
                    .Where(x => x.ProductName == productModel.ProductName).FirstOrDefault();

            if (y == null)
            {
                var product = await _context.tblProduct.FindAsync(productId);
                if (product != null)
                {
                    product.ProductName = productModel.ProductName;
                    await _context.SaveChangesAsync();
                }
                return product.Id;
            }
            return 0;
        }
    }
}
