using DoNotFret.Models;
using DoNotFret.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Controllers
{
    public class HomeController : Controller //inhertics Controller
    {
        private readonly I_Instruments _service;

        public HomeController(I_Instruments instruments)
        {
            _service = instruments;
        }

        public async Task<ActionResult<IEnumerable<Instruments>>> Index()
        {
            var list = await _service.GetAll();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Instruments instruments)
        {
            await _service.Create(instruments);
            if (!ModelState.IsValid) { return View(); }
            return Content("Instrument was added");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Instruments instrument = await _service.GetOne(id);
            return View(instrument);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Instruments instrument)
        {
            await _service.Update(instrument);
            if (!ModelState.IsValid) { return View(); }
            return Content("Instrument was updated");
        }
    }
}
