using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoNotFret.Pages
{
    public class CheckoutModel : PageModel
    {
        public void OnGet()
        {
            string username = HttpContext.Request.Cookies["username"];
            ViewData["username"] = username;
        }
    }
}
