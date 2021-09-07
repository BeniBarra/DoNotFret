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
using Microsoft.EntityFrameworkCore;

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

        public class CartInstrumentId
        {
            public string Id { get; set; }
        }

        [BindProperty]
        public CartInstrumentId Input { get; set; }
        public List<Instrument> Instruments { get; private set; } = new List<Instrument>();

        public async Task OnGet()
        {
            //Instruments = new List<Instrument

            string userId = HttpContext.Request.Cookies["userId"];
            Cart exisitingCart = _context.Cart.Where(x => x.UserId == userId).FirstOrDefault();

            List<CartItem> CartItems = _context.CartItem.Where(c => c.CartId == exisitingCart.Id).ToList();

            // For every Instrument Id in cartitems, we pull the instrument via ID and add it to 
            // Instruments
            foreach (var cartId in CartItems)
            {
                Instrument inst = new();
                inst = await _service.GetOne(cartId.InstrumentId);
                Instruments.Add(inst);
            }
        }

        public async Task OnPost(int cartId, int instrumentId)
        {
            string userId = HttpContext.Request.Cookies["userId"];
            Cart exisitingCart = _context.Cart.Where(x => x.UserId == userId).FirstOrDefault();

            List<CartItem> cartItems = new(); 

            foreach(var cartItem in exisitingCart.Instruments)
            {
                cartItems.Add(cartItem);
            }

            foreach(var instId in cartItems)
            {
                if (instId.InstrumentId == instrumentId)
                {
                    _context.Entry(instId).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    await hasBeenRemoved(Input);
                    break;
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task hasBeenRemoved(CartInstrumentId input)
        {
            Instrument inst = await _context.Instrument.FindAsync(Convert.ToInt32(input.Id));
            inst.HasBeenAdded = false;
            Console.WriteLine(inst.HasBeenAdded);
            await _service.Update(inst);
        }

    }
}
