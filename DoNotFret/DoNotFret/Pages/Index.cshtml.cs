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
using DoNotFret.Pages.Component;

namespace DoNotFret.Pages
{
    public class IndexModel : PageModel
    {
        private readonly I_Instrument _instrumentService;
        private readonly ICategory _categoryService;

        private readonly DoNotFretDbContext _context;

        // DI
        public IndexModel(I_Instrument instrument = null, ICategory category = null, DoNotFretDbContext context = null)
        {
            _instrumentService = instrument;
            _context = context;
            _categoryService = category;
        }

        //public CartCount CartCount { get; set; } = new CartCount();

        public class CartInstrumentId
        {
            public string Id { get; set; }
        }

        [BindProperty]
        public CartInstrumentId Input { get; set; }
        public List<Instrument> Instruments { get; set; }

        //Constructor for Instrument List
        public List<Instrument> Filtered { get; set; } = new List<Instrument>();
        public Instrument Instrument { get; set; }
        public List<Category> Categories { get; set; }

        public bool IsFiltered { get; set; } = false;

        public async Task OnGet(int category = 0)
        {
            IsFiltered = category != 0;

            Instruments = await _instrumentService.GetAll();
            Filtered = Instruments.Where(x => x.CategoryId == category).ToList();
            Categories = await _categoryService.GetAll();

            string username = HttpContext.Request.Cookies["username"];
            ViewData["username"] = username;
        }

        // Called when a user adds something to their cart and is logged in.
        public async Task<IActionResult> OnPostAsync()
        {

            string userId = HttpContext.Request.Cookies["userId"];
            Cart exisitingCart = _context.Cart.Where(x => x.UserId == userId).SingleOrDefault();

            if (exisitingCart != null)
            {
                await CreateCartItem(Convert.ToInt32(Input.Id), exisitingCart.Id);
                
                //Switching the "has been added" boolean to true to determine whether or not
                //we display the Added to Cart button.
                await HasBeenAdded(Input);
                return Redirect("/");
            }

            Cart newCart = await CreateUserCartAsync(userId);
            await CreateCartItem(Convert.ToInt32(Input.Id), newCart.Id);

            //Switching the "has been added" boolean to true to determine whether or not
            // we display the Added to Cart button.
            await HasBeenAdded(Input);
            return Redirect("/");
        }

        public async Task HasBeenAdded(CartInstrumentId input)
        {
            Instrument inst = await _context.Instrument.FindAsync(Convert.ToInt32(input.Id));
            inst.HasBeenAdded = true;
            Console.WriteLine(inst.HasBeenAdded);
            await _instrumentService.Update(inst);
        }

        public async Task<Cart> CreateUserCartAsync(string userId)
        {
            Cart newCart = new()
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
