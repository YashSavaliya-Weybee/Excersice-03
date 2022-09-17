using Excersice_03.Data;
using Excersice_03.Models;
using Excersice_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<ViewResult> AddNewInvoice(bool isAdded = false, int grandTotal = 0)
        {
            if (isAdded)
            {
                ViewBag.AllInvoice = await _invoiceRepository.GetAllInvoice();
                ViewBag.display = true;
                ViewBag.grandTotal = grandTotal;
                return View();
            }
            ViewBag.display = false;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewInvoice(InvoiceModel invoiceModel)
        {
            int grandTotal = 0;
            if (ModelState.IsValid)
            {
                grandTotal = await _invoiceRepository.AddInvoice(invoiceModel);
                return RedirectToAction(nameof(AddNewInvoice), new { isAdded = true, grandTotal = grandTotal });
            }
            ViewBag.display = false;
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> BindProductDetails(int PartyId)
        {
            var productDetails = await _invoiceRepository.BindProduct(PartyId);

            return Json(productDetails);
        }

        [HttpGet]
        public async Task<JsonResult> BindRateDetails(int ProductId)
        {
            int rate = await _invoiceRepository.BindRate(ProductId);

            return Json(rate);
        }

        public IActionResult InvoiceClose(bool isAdded = false)
        {
            return RedirectToAction(nameof(AddNewInvoice), new { isAdded = false });
        }
    }
}
