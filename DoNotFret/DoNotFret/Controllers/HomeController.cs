using DoNotFret.Models;
using DoNotFret.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Controllers
{
    public class HomeController : Controller //inhertics Controller
    {
        private readonly I_Instrument _service;

        public const string HOME_ROUTE = "home";

        public HomeController(I_Instrument instruments)
        {
            _service = instruments;
        }

        public async Task<ActionResult<IEnumerable<Instrument>>> HomeIndex()
        {
            var list = await _service.GetAll();
            return View(list);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(Instrument instruments)
        {
            await _service.Create(instruments);
            if (!ModelState.IsValid) { return View(); }
            return View("Added");
        }

        [Authorize(Roles="Admin, Technician")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Instrument instrument = await _service.GetOne(id);
            return View(instrument);
        }

        [Authorize(Roles ="Admin, Technician")]
        [HttpPost]
        public async Task<IActionResult> Update(Instrument instrument)
        {
            await _service.Update(instrument);
            if (!ModelState.IsValid) { return View(); }
            return Content("Instrument was updated");
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return View("Deleted");
        }

        public IActionResult RememberName(string name)
        {
            if (name != null)
            {
                //Set a cookie with the name in it.
                CookieOptions cookieOptions = new CookieOptions();
                // Cookie will expire in 7 days
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
                HttpContext.Response.Cookies.Append("name", name, cookieOptions);

                return Content("Cookie for name saved.");
            }
            return Content("Please provide a name");
        }

        public IActionResult IAm()
        {
            // app.get
            string name = HttpContext.Request.Cookies["name"];
            ViewData["name"] = name;
            return View();
        }
    }
}
