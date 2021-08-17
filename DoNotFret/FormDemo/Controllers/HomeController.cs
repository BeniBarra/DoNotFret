using FormDemo.Interfaces;
using FormDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormDemo.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPet _petService;

        // Controller now has access to petservice.
        public HomeController(IPet p)
        {
            _petService = p;
        }

        public async Task<ActionResult<IEnumerable<Pet>>> Index()
        {
            var list = await _petService.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add1(Pet pet)
        {
            if (!ModelState.IsValid) { return View(); }
            return Content("Pet has been added.");
        }
        [HttpPost]
        public async Task<IActionResult> Create(Pet pet)
        {
            await _petService.Create(pet);
            if (!ModelState.IsValid) { return View(); }
            return Content("Pet has been added.");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Pet pet)
        {
            await _petService.Update(pet);
            // If the model state is not valid, then just give them the view again.
            if (!ModelState.IsValid) { return View(); }
            return Content("Pet Added.");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            // Expects (within the query) the ID of 1.
            Pet pet = await _petService.GetOne(id);
            return View(pet);
        }
    }
}
