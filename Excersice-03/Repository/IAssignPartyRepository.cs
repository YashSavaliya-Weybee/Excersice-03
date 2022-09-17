using Excersice_03.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excersice_03.Repository
{
    public interface IAssignPartyRepository
    {
        Task<List<AssignPartyModel>> GetAllAssignParty();
        Task<Tuple<string, string>> AddAssignParty(AssignPartyModel assignPartyModel);
        Task<bool> DeleteAssignParty(AssignPartyModel assignPartyModel, int id);

        Task<int> UpdateAssignParty(AssignPartyModel assignPartyModel, int assignPartyId);
    }
}