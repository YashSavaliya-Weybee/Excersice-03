using Excersice_03.Data;
using Excersice_03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly PartyProductContext _context;

        public InvoiceRepository(PartyProductContext context)
        {
            _context = context;
        }

        public async Task<List<InvoiceModel>> GetAllInvoice()
        {
            return await _context.tblInvoice.Select(Invoice => new InvoiceModel()
            {
                Id = Invoice.Id,
                PartyId = Invoice.PartyId,
                PartyName = _context.tblParty.Where(x => x.Id == Invoice.PartyId).FirstOrDefault().PartyName,
                ProductId = Invoice.ProductId,
                ProductName = _context.tblProduct.Where(x => x.Id == Invoice.ProductId).FirstOrDefault().ProductName,
                Rate = Invoice.Rate,
                Quantity = Invoice.Quantity,
                Total = Invoice.Total
            }).ToListAsync();
        }

        public async Task<int> AddInvoice(InvoiceModel invoiceModel)
        {
            var y = _context.tblInvoice
                    .Where(x => x.PartyId == invoiceModel.PartyId).Where(x => x.ProductId == invoiceModel.ProductId).Where(x => x.Rate == invoiceModel.Rate).FirstOrDefault();

            if (y == null)
            {

                var newInvoice = new Invoice()
                {
                    PartyId = (int)invoiceModel.PartyId,
                    ProductId = (int)invoiceModel.ProductId,
                    Rate = (int)invoiceModel.Rate,
                    Quantity = (int)invoiceModel.Quantity,
                    Total = (int)(invoiceModel.Quantity * invoiceModel.Rate)
                };

                await _context.AddAsync(newInvoice);
            }
            else
            {
                y.PartyId = (int)invoiceModel.PartyId;
                y.ProductId = (int)invoiceModel.ProductId;
                y.Rate = (int)invoiceModel.Rate;
                y.Quantity = (int)(y.Quantity + invoiceModel.Quantity);
                y.Total = (int)(invoiceModel.Rate * y.Quantity);
            }
            await _context.SaveChangesAsync();
            int grandTotal = (from x in _context.tblInvoice select x.Total).Sum();

            return grandTotal;
        }

        public async Task<List<AssignPartyModel>> BindProduct(int PartyId)
        {
            return await _context.tblAssignParty.Where(x => x.PartyId == PartyId)
                .Select(product => new AssignPartyModel()
                {
                    ProductId = product.ProductId,
                    ProductName = product.Product.ProductName
                }).Distinct().ToListAsync();
        }

        public async Task<int> BindRate(int ProductId)
        {
            return await _context.tblProductRate.Where(x => x.ProductId == ProductId)
                .Select(x => x.Rate).FirstOrDefaultAsync();
        }
    }
}
