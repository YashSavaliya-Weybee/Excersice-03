using Excersice_03.Data;
using Excersice_03.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly PartyProductContext _context;

        public PartyRepository(PartyProductContext context)
        {
            _context = context;
        }

        public async Task<List<PartyModel>> GetAllParty()
        {
            return await _context.tblParty.Select(party => new PartyModel()
            {
                Id = party.Id,
                PartyName = party.PartyName
            }).ToListAsync();
        }

        public async Task<string> AddParty(PartyModel partyModel)
        {
            var y = _context.tblParty
                    .Where(x => x.PartyName == partyModel.PartyName).FirstOrDefault();

            if (y == null)
            {
                var newParty = new Party()
                {
                    PartyName = partyModel.PartyName
                };
                await _context.AddAsync(newParty);
                await _context.SaveChangesAsync();
                return newParty.PartyName;
            }
            return null;
        }

        public async Task<bool> DeleteParty(PartyModel partyModel, int id)
        {
            if (id == partyModel.Id)
            {
                var party = new Party()
                {
                    Id = id
                };
                _context.tblParty.Remove(party);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> UpdateParty(PartyModel partyModel, int partyId)
        {
            var y = _context.tblParty
                    .Where(x => x.PartyName == partyModel.PartyName).FirstOrDefault();

            if (y == null)
            {
                var newParty = new Party()
                {
                    Id = partyId,
                    PartyName = partyModel.PartyName
                };
                _context.tblParty.Update(newParty);
                await _context.SaveChangesAsync();
                return newParty.Id;
            }
            return 0;
        }
    }
}
