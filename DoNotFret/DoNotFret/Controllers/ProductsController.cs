using DoNotFret.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WindInstrument()
        {
            WindInstrument panFlute = new WindInstrument()
            {
                Name = "Pan Flute",
                Material = "Wood"
            };

            return View(panFlute);
        }
        public IActionResult WindInstruments()
        {
            return View();
        }
        public IActionResult StringInstruments()
        {
            return View();
        }
    }
}
