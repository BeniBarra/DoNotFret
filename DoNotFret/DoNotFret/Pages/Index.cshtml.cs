using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Models;
using DoNotFret.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoNotFret.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Instrument> Instruments { get; set; }

        private readonly I_Instrument _service;

        public IndexModel(I_Instrument instruments)
        {
            _service = instruments;
        }

        public async Task OnGet()
        {
            Instruments = await _service.GetAll();
        }
    }
}
