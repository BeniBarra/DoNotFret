using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public void OnGet()
        {
            string userId = HttpContext.Request.Cookies["userId"];
            List<Cart> exisitingCart = _context.Cart.Where(x => x.UserId == userId).ToList();
        }

        public void OnPost()
        {
        }
    }

    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> Instrument { get; set; } 
    }
}
