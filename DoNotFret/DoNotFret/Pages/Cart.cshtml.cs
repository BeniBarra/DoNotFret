using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Data;
using DoNotFret.Models;
using DoNotFret.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoNotFret.Pages
{
    public class CartModel : PageModel
    {
        private readonly I_Instrument _service;
        private DoNotFretDbContext _context;

        public CartModel(I_Instrument instruments, DoNotFretDbContext context)
        {
            _service = instruments;
            _context = context;
        }

        public async void OnGet()
        {
            string username = HttpContext.Request.Cookies["username"];
            UserCart exisitingCart = await _context.UserCart.FindAsync(username);
        }
    }

    public class UserCart
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public IList<Instrument> CartItem { get; set; }
    }
}
