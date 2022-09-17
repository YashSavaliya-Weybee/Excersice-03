using Excersice_03.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public interface IPartyRepository
    {
        Task<List<PartyModel>> GetAllParty();
        Task<string> AddParty(PartyModel partyModel);
        Task<bool> DeleteParty(PartyModel partyModel, int id);
        Task<int> UpdateParty(PartyModel partyModel, int partyId);
    }
}