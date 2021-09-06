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
        public int CartCounter { get; set; } = 0;
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
