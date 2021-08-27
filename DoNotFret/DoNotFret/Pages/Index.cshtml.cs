using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Data;
using DoNotFret.Models;
using DoNotFret.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoNotFret.Pages
{
    public class IndexModel : PageModel
    {
        private readonly I_Instrument _service;
        private DoNotFretDbContext _context;

        public IndexModel(I_Instrument instruments, DoNotFretDbContext context)
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
        public List<Instrument> Instruments { get; set; }
        public Instrument Instrument { get; set; }

        public async Task OnGet()
        {
            Instruments = await _service.GetAll();
            string username = HttpContext.Request.Cookies["username"];
            ViewData["username"] = username;
        }

        public async Task OnPostAsync()
        {
            string userId = HttpContext.Request.Cookies["userId"];
            if(userId == null) { throw new Exception("Please Log in to add items to cart"); }
            Cart exisitingCart = _context.Cart.Where(x => x.UserId == userId).SingleOrDefault();

            if (exisitingCart != null)
            {
                await CreateCartItem(Convert.ToInt32(Input.Id), exisitingCart.Id);
                return;
            }

            Cart newCart = await CreateUserCartAsync(userId);
            await CreateCartItem(Convert.ToInt32(Input.Id), newCart.Id);
            return;
        }

        public async Task<Cart> CreateUserCartAsync(string userId)
        {
            Cart newCart = new Cart()
            {
                UserId = userId
            };
            _context.Entry(newCart).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return newCart;
        }

        public async Task CreateCartItem(int instrumentId, int cartId)
        {
            CartItem addingToCart = new()
            {
                InstrumentId = instrumentId,
                CartId = cartId
            };
            _context.Entry(addingToCart).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public int GetUserIdFromCookie()
        {
            string username = HttpContext.Request.Cookies["userId"];
            int userId = Convert.ToInt32(username);
            return userId;
        }
    }
}
