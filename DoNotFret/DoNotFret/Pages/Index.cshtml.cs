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

        public async void OnPost(string instrumentId)
        {
            string username = HttpContext.Request.Cookies["username"];
            Instrument = await _service.GetOne(Convert.ToInt32(instrumentId));
            UserCart exisitingCart = await _context.UserCart.FindAsync(GetCartIdFromCookie());

            if (exisitingCart != null)
            {
                exisitingCart.CartItem.Add(Instrument);
                _context.Entry(exisitingCart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await _context.SaveChangesAsync();
                return;
            }

            UserCart newCart = CreatUserCart(Instrument, username);
            CreateCartIdCookie(newCart);
            _context.Entry(newCart).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return;
        }


        public UserCart CreatUserCart(Instrument instrument, string username)
        {
            UserCart userCart = new UserCart();
            //Set a cookie with the name in it.
            userCart.Username = username;
            userCart.CartItem.Add(instrument);
            return userCart;
        }


        public void CreateCartIdCookie(UserCart newCart)
        {
            CookieOptions cookieOptions = new CookieOptions();
            // Cookie will expire in 7 days
            cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(7));
            HttpContext.Response.Cookies.Append("cartId", newCart.Id.ToString(), cookieOptions);
        }

        public int GetCartIdFromCookie()
        {
            string username = HttpContext.Request.Cookies["cartId"];
            int cartId = Convert.ToInt32(username);
            return cartId;
        }

        public class CartInstrumentId
        {
            public string InstrumendId { get; set; }
        }

    }
}
