using AuthDemo.Auth.Models.Dto;
using AuthDemo.Auth.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoNotFret.Controllers
{
    public class AuthController : Controller
    {
        private IUserService _userService;

        public AuthController(IUserService service)
        {
            _userService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Signup(RegisterUser data)
        {
            // Hardcode the role
            data.Roles = new List<string> { "user"};

            // Create a user with that service
            var user = await _userService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            else { return View(); }
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(LoginData data)
        {
            var user = await _userService.Authenticate(data.Username, data.Password);
            if (user == null)
            {
                this.ModelState.AddModelError(String.Empty, "Invalid Login, Please try again.");
                return RedirectToAction("Index");
            }
            return Redirect("/home/iam");
        }
        //Token validation
        //Check with the user service to see if we're in the system.
        // If so, set a cookie

    }
}
