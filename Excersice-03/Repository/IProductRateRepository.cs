using Excersice_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public interface IProductRateRepository
    {
        Task<List<ProductRateModel>> GetAllProductRate();
        Task<string> AddProductRate(ProductRateModel productRateModel);
        Task<bool> DeleteProductRate(ProductRateModel productRateModel, int id);
        Task<int> UpdateProductRate(ProductRateModel productRateModel, int productId);
    }
}