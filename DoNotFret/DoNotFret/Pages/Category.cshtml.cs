using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoNotFret.Pages
{
    public class CategoryModel : PageModel
    {
        public void OnGet()
        {

        }
    }

    public class Category
    {
        public string Name { get; set; }
        public IList<Instrument> Instruments { get; set; }
    }
}
