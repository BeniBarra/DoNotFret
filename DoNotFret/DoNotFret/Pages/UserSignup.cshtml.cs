using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoNotFret.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DoNotFret.Models;
using Microsoft.AspNetCore.Identity;
using AuthDemo.Auth.Services.Interfaces;
using AuthDemo.Auth.Models.Dto;

namespace DoNotFret.Pages
{
    public class UserSignupModel : PageModel
    {
        private IUserService _userService {get;}

        [BindProperty]
        public RegisterUser NewUser { get; set; }

        public UserSignupModel(IUserService service)
        {
            _userService = service;
        }

        public void OnGetAsync()
        {
            // Returns the view.
        }

        public async Task<ActionResult> OnPostAsync()
        {
            NewUser.Roles = new List<string> { "User" };

            var newUser = await _userService.Register(NewUser, this.ModelState);

            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            else { return Redirect("usersignup"); }
        }
    }
}
