using Excersice_03.Models;
using Excersice_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Controllers
{
    public class ProductRateController : Controller
    {
        private readonly IProductRateRepository _productRateRepository;
        public ProductRateController(IProductRateRepository productRateRepository)
        {
            _productRateRepository = productRateRepository;
        }
        public async Task<IActionResult> GetAllProductRate()
        {
            var Product = await _productRateRepository.GetAllProductRate();
            return View(Product);
        }
        public ViewResult AddNewProductRate(string ProductName, int isSuccess = 0)
        {
            ViewBag.isEdit = false;
            ViewBag.productName = ProductName;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductRate(ProductRateModel productRateModel)
        {
            if (ModelState.IsValid)
            {
                string ProductName = await _productRateRepository.AddProductRate(productRateModel);

                if (ProductName != null)
                {
                    return RedirectToAction(nameof(AddNewProductRate), new { isSuccess = 1, productName = ProductName });
                }
                ViewBag.isEdit = false;
                return RedirectToAction(nameof(AddNewProductRate), new { isSuccess = 2 });
            }
            ViewBag.isEdit = false;
            return View();
        }

        [HttpGet("EditProduct/{id}/{productId}/{rate}/{dateOfRate}")]
        public ViewResult EditProductRate(string productId, int rate, DateTime dateOfRate)
        {
            ViewBag.isEdit = true;
            return View("AddNewProductRate");
        }

        [HttpPost("EditProduct/{id}/{productId}/{rate}/{dateOfRate}")]
        public async Task<IActionResult> EditProductRate(ProductRateModel productModel, int id)
        {
            if (ModelState.IsValid)
            {
                int x = await _productRateRepository.UpdateProductRate(productModel, id);
                if (x == 0)
                {
                    return RedirectToAction(nameof(AddNewProductRate), new { isSuccess = 2 });
                }
            }
            return RedirectToAction(nameof(GetAllProductRate));
        }

        public async Task<IActionResult> DeleteProductRate(int id, ProductRateModel productRateModel)
        {
            bool x = await _productRateRepository.DeleteProductRate(productRateModel, id);
            if (x)
            {
                return RedirectToAction("GetAllProductRate");
            }
            return null;
        }
    }
}
