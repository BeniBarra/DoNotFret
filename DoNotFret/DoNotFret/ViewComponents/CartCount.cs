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
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }

    public class UserCart
    {
        public string Id { get; set; }
        public string Username { get; set; }
        IList<Instrument> CartItem { get; set; }
    }
}
