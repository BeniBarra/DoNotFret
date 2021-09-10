using DoNotFret.Data;
using DoNotFret.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Pages.Component
{
    public class CartCount : ViewComponent
    {
        private DoNotFretDbContext _context;

        public CartCount(DoNotFretDbContext context)
        {
            _context = context;
        }

        public int CartCounter { get; set; } = new();

        public class ViewModel
        {
            public int vmCounter { get; set; } = new();
        }

        public IViewComponentResult Invoke()
        {
            string userId = HttpContext.Request.Cookies["userId"];
            Cart exisitingCart = _context.Cart.Where(x => x.UserId == userId).FirstOrDefault();
            List<CartItem> cartItems = _context.CartItem.Where(x => x.CartId == exisitingCart.Id).ToList();

            ViewModel cart = new ViewModel()
            {
                vmCounter = cartItems.Count
            };
            return View(cart);
        }
    }
}
