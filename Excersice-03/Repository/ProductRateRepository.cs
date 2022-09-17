using Excersice_03.Data;
using Excersice_03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public class ProductRateRepository : IProductRateRepository
    {
        private readonly PartyProductContext _context;

        public ProductRateRepository(PartyProductContext context)
        {
            _context = context;
        }

        public async Task<List<ProductRateModel>> GetAllProductRate()
        {
            return await _context.tblProductRate.Select(productRate => new ProductRateModel()
            {
                Id = productRate.Id,
                ProductId = productRate.ProductId,
                ProductName = productRate.Product.ProductName,
                Rate = productRate.Rate,
                DateOfRate = DateTime.Now
            }).ToListAsync();
        }

        public async Task<string> AddProductRate(ProductRateModel productRateModel)
        {
            var y = _context.tblProductRate
                   .Where(x => x.ProductId == productRateModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var newProductRate = new ProductRate()
                {
                    ProductId = (int)productRateModel.ProductId,
                    Rate = (int)productRateModel.Rate,
                    DateOfRate = productRateModel.DateOfRate
                };

                await _context.AddAsync(newProductRate);
                await _context.SaveChangesAsync();
                var productRate = await _context.tblProduct.FindAsync(productRateModel.ProductId);
                return productRate.ProductName;
            }
            return null;
        }

        public async Task<bool> DeleteProductRate(ProductRateModel productRateModel, int id)
        {
            if (id == productRateModel.Id)
            {
                var productRate = new ProductRate()
                {
                    Id = id
                };
                _context.tblProductRate.Remove(productRate);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> UpdateProductRate(ProductRateModel productRateModel, int productId)
        {
            var y = _context.tblProductRate
                    .Where(x => x.ProductId == productRateModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var newProductRate = new ProductRate()
                {
                    Id = productId,
                    ProductId = (int)productRateModel.ProductId,
                    Rate = (int)productRateModel.Rate,
                    DateOfRate = DateTime.UtcNow,
                };
                _context.tblProductRate.Update(newProductRate);
                await _context.SaveChangesAsync();
                return newProductRate.Id;
            }
            return 0;
        }
    }
}
