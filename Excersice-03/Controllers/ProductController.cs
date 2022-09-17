using Excersice_03.Models;
using Excersice_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IActionResult> GetAllProduct()
        {
            var Product = await _productRepository.GetAllProduct();
            return View(Product);
        }
        public ViewResult AddNewProduct(string ProductName, int isSuccess = 0)
        {
            ViewBag.isEdit = false;
            ViewBag.productName = ProductName;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                string ProductName = await _productRepository.AddProduct(productModel);

                if (ProductName != null)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = 1, productName = ProductName });
                }
                ViewBag.isEdit = false;
                return RedirectToAction(nameof(AddNewProduct), new { isSuccess = 2 });
            }
            ViewBag.isEdit = false;
            return View();
        }

        [HttpGet("EditProduct/{id}/{productName}")]
        public ViewResult EditProduct(string productName)
        {
            ViewBag.isEdit = true;
            return View("AddNewProduct");
        }

        [HttpPost("EditProduct/{id}/{productName}")]
        public async Task<IActionResult> EditProduct(ProductModel productModel, int id)
        {
            if (ModelState.IsValid)
            {
                int x = await _productRepository.UpdateProduct(productModel, id);
                if (x == 0)
                {
                    return RedirectToAction(nameof(AddNewProduct), new { isSuccess = 2 });
                }
            }
            return RedirectToAction(nameof(GetAllProduct));
        }

        public async Task<IActionResult> DeleteProduct(int id, ProductModel productModel)
        {
            bool x = await _productRepository.DeleteProduct(productModel, id);
            if (x)
            {
                return RedirectToAction("GetAllProduct");
            }
            return null;
        }
    }
}
