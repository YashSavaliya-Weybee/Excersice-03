using Excersice_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public interface IInvoiceRepository
    {
        Task<int> AddInvoice(InvoiceModel invoiceModel);
        Task<List<InvoiceModel>> GetAllInvoice();
        Task<List<AssignPartyModel>> BindProduct(int PartyId);
        Task<int> BindRate(int ProductId);
    }
}