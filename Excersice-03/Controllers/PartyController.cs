using Excersice_03.Models;
using Excersice_03.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excersice_03.Controllers
{
    public class PartyController : Controller
    {
        private readonly IPartyRepository _partyRepository;
        public PartyController(IPartyRepository partyRepository)
        {
            _partyRepository = partyRepository;
        }
        public async Task<IActionResult> GetAllParty()
        {
            var Party = await _partyRepository.GetAllParty();
            return View(Party);
        }
        public ViewResult AddNewParty(string PartyName, int isSuccess = 0)
        {
            ViewBag.isEdit = false;
            ViewBag.partyName = PartyName;
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewParty(PartyModel partyModel)
        {
            if (ModelState.IsValid)
            {
                string PartyName = await _partyRepository.AddParty(partyModel);

                if (PartyName != null)
                {
                    return RedirectToAction(nameof(AddNewParty), new { isSuccess = 1, partyName = PartyName });
                }
                ViewBag.isEdit = false;
                return RedirectToAction(nameof(AddNewParty), new { isSuccess = 2 });
            }
            ViewBag.isEdit = false;
            return View();
        }

        [HttpGet("EditParty/{id}/{partyName}")]
        public ViewResult EditParty(string partyName)
        {
            ViewBag.isEdit = true;
            return View("AddNewParty");
        }

        [HttpPost("EditParty/{id}/{partyName}")]
        public async Task<IActionResult> EditParty(PartyModel partyModel, int id)
        {
            if (ModelState.IsValid)
            {
                int x = await _partyRepository.UpdateParty(partyModel, id);
                if (x == 0)
                {
                    return RedirectToAction(nameof(AddNewParty), new { isSuccess = 2 });
                }
            }
            return RedirectToAction(nameof(GetAllParty));
        }

        public async Task<IActionResult> DeleteParty(int id, PartyModel partyModel)
        {
            bool x = await _partyRepository.DeleteParty(partyModel, id);
            if (x)
            {
                return RedirectToAction("GetAllParty");
            }
            return null;
        }
    }
}
