using Excersice_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProduct();
        Task<string> AddProduct(ProductModel productModel);
        Task<int> UpdateProduct(ProductModel productModel, int productId);

        Task<bool> DeleteProduct(ProductModel productModel, int id);
    }
}