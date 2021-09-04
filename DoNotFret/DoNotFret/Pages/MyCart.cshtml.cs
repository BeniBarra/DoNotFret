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
    public class MyCartModel : PageModel
    {
        private readonly I_Instrument _service;
        private DoNotFretDbContext _context;

        public MyCartModel(I_Instrument instruments, DoNotFretDbContext context = null)
        {
            _service = instruments;
            _context = context;
        }

        public List<Instrument> Instruments { get; set; }

        public async void OnGet()
        {
            string userId = HttpContext.Request.Cookies["userId"];

            Cart exisitingCart = _context.Cart.Where(x => x.UserId == userId).FirstOrDefault();

            List<CartItem> CartItems = _context.CartItem.Where(c => c.CartId == exisitingCart.Id).ToList();

            // For every Instrument Id in cartitems, we pull the instrument via ID and add it to 
            // Instruments


            Instrument addInst = new();
            Instruments =  await _service.GetAll();


            Console.WriteLine(exisitingCart);
        }

        public void OnPost()
        {
            //TODO: Checkout
        }

    }

}
