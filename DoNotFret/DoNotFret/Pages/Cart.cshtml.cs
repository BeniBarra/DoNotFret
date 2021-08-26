using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoNotFret.Pages
{
    public class CartModel : PageModel
    {
        public void OnGet()
        {

        }
    }

    public class Cart
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public IList<Instrument> CartItem { get; set; }
    }
}
