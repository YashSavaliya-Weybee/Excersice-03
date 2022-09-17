using Excersice_03.Models;
using Excersice_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Controllers
{
    public class AssignPartyController : Controller
    {
        private readonly IAssignPartyRepository _assignPartyRepository;

        public AssignPartyController(IAssignPartyRepository assignPartyRepository)
        {
            _assignPartyRepository = assignPartyRepository;
        }
        public async Task<IActionResult> GetAllAssignParty()
        {
            var Party = await _assignPartyRepository.GetAllAssignParty();
            return View(Party);
        }
        public ViewResult AddNewAssignParty(string PartyName, string ProductName, int isSuccess = 0, int id = 0)
        {
            ViewBag.isEdit = false;
            ViewBag.partyName = PartyName;
            ViewBag.productName = ProductName;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAssignParty(AssignPartyModel assignPartyModel)
        {
            if (ModelState.IsValid)
            {
                var partyProductName = await _assignPartyRepository.AddAssignParty(assignPartyModel);

                if (partyProductName != null)
                {
                    return RedirectToAction(nameof(AddNewAssignParty), new { isSuccess = 1, partyName = partyProductName.Item1, productName = partyProductName.Item2 });
                }
                ViewBag.isEdit = false;
                return RedirectToAction(nameof(AddNewAssignParty), new { isSuccess = 2 });
            }
            ViewBag.isEdit = false;
            return View();
        }

        [HttpGet("EditAssignParty/{id}/{partyId}/{productId}")]
        public ViewResult EditAssignParty(int partyId, int productId, [FromRoute] int id = 0)
        {
            ViewBag.isEdit = true;
            return View("AddNewAssignParty");
        }

        [HttpPost("EditAssignParty/{id}/{partyId}/{productId}")]
        public async Task<IActionResult> EditAssignParty(AssignPartyModel assignPartyModel, [FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                int x = await _assignPartyRepository.UpdateAssignParty(assignPartyModel, id);
                if (x == 0)
                {
                    return RedirectToAction(nameof(AddNewAssignParty), new { isSuccess = 2 });
                }
            }
            return RedirectToActionPermanent(nameof(GetAllAssignParty));
        }

        public async Task<IActionResult> DeleteAssignParty(int id, AssignPartyModel assignPartyModel)
        {
            bool x = await _assignPartyRepository.DeleteAssignParty(assignPartyModel, id);
            if (x)
            {
                return RedirectToAction("GetAllAssignParty");
            }
            return null;
        }
    }
}
