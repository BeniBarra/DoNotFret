using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthDemo.Auth.Services.Interfaces;
using DoNotFret.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static DoNotFret.Pages.UserSignupModel;

namespace DoNotFret.Pages
{
    public class UserLoginModel : PageModel
    {
        private IUserService _userService { get; }
        public UserLoginModel(IUserService service)
        {
            _userService = service;
        }

        [BindProperty]
        public LoginData LoginData { get; set; }



        public void OnGet()
        {

        }

        public async Task<ActionResult> OnPost()
        {
            var user = await _userService.Authenticate(LoginData.Username, LoginData.Password);

            if (user == null)
            {
                this.ModelState.AddModelError(String.Empty, "Invalid Login, Please try again.");
                return Redirect("userlogin");
            }
            return Redirect("/");
        }
    }

    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
