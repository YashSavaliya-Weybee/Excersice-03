using Excersice_03.Data;
using Excersice_03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public class AssignPartyRepository : IAssignPartyRepository
    {
        private readonly PartyProductContext _context;

        public AssignPartyRepository(PartyProductContext context)
        {
            _context = context;
        }

        public async Task<List<AssignPartyModel>> GetAllAssignParty()
        {
            return await _context.tblAssignParty.Select(AssignParty => new AssignPartyModel()
            {
                Id = AssignParty.Id,
                PartyId = AssignParty.PartyId,
                PartyName = AssignParty.Party.PartyName,
                ProductId = AssignParty.ProductId,
                ProductName = AssignParty.Product.ProductName
            }).ToListAsync();
        }

        public async Task<Tuple<string, string>> AddAssignParty(AssignPartyModel assignPartyModel)
        {
            var y = _context.tblAssignParty
                   .Where(x => x.PartyId == assignPartyModel.PartyId && x.ProductId == assignPartyModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var newAssignParty = new AssignParty()
                {
                    PartyId = (int)assignPartyModel.PartyId,
                    ProductId = (int)assignPartyModel.ProductId
                };

                await _context.tblAssignParty.AddAsync(newAssignParty);
                await _context.SaveChangesAsync();

                var party = await _context.tblParty.FindAsync(assignPartyModel.PartyId);
                var product = await _context.tblProduct.FindAsync(assignPartyModel.ProductId);

                return Tuple.Create(party.PartyName, product.ProductName);
            }
            return null;
        }

        public async Task<bool> DeleteAssignParty(AssignPartyModel assignPartyModel, int id)
        {
            if (id == assignPartyModel.Id)
            {
                var assignParty = new AssignParty()
                {
                    Id = assignPartyModel.Id
                };
                _context.tblAssignParty.Remove(assignParty);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> UpdateAssignParty(AssignPartyModel assignPartyModel, int assignPartyId)
        {
            var y = _context.tblAssignParty
                  .Where(x => x.PartyId == assignPartyModel.PartyId && x.ProductId == assignPartyModel.ProductId).FirstOrDefault();

            if (y == null)
            {
                var assignParty = new AssignParty()
                {
                    Id = assignPartyId,
                    PartyId = (int)assignPartyModel.PartyId,
                    ProductId = (int)assignPartyModel.ProductId
                };
                _context.tblAssignParty.Update(assignParty);
                await _context.SaveChangesAsync();
                return assignParty.Id;
            }
            return 0;


        }
    }
}
