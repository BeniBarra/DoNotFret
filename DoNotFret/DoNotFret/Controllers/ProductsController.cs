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
            Instruments listAll = new Instruments();
            listAll.StringInstruments.Add(new StringInstrument() { Name = "Bass", Strings = 4 });
            listAll.StringInstruments.Add(new StringInstrument() { Name = "Mandalin", Strings = 8 });
            listAll.StringInstruments.Add(new StringInstrument() { Name = "Theorbo", Strings = 11 });
            listAll.WindInstruments.Add(new WindInstrument() { Name = "Pan Flute", Material = "wood" });
            listAll.WindInstruments.Add(new WindInstrument() { Name = "Trumpet", Material = "Brass" });
            listAll.WindInstruments.Add(new WindInstrument() { Name = "Clarinet", Material = "wood" });
            return View(listAll);
        }

        public IActionResult WindInstrument(string name, string mat)
        {
            WindInstrument panFlute = new WindInstrument()
            {
                Name = name,
                Material = mat
            };

            return View(panFlute);
        }

        public IActionResult WindInstruments()
        {
            List<WindInstrument> winds = new List<WindInstrument>();
            winds.Add(new WindInstrument() { Name = "Pan Flute", Material = "wood"});
            winds.Add(new WindInstrument() { Name = "Trumpet", Material = "Brass" });
            winds.Add(new WindInstrument() { Name = "Clarinet", Material = "wood" });

            return View(winds);
        }

        public IActionResult StringInstrument(string name, int stringCount)
        {
            StringInstrument guitar = new StringInstrument()
            {
                Name = name,
                Strings = stringCount
            };
            return View(guitar);
        }

        public IActionResult StringInstruments()
        {
            List<StringInstrument> strings = new List<StringInstrument>();
            strings.Add(new StringInstrument() { Name = "Bass", Strings = 4 });
            strings.Add(new StringInstrument() { Name = "Mandalin", Strings = 8 });
            strings.Add(new StringInstrument() { Name = "Theorbo", Strings = 11 });

            return View(strings);
        }
    }
}
