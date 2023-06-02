using AyrinMovie.Core.DTOs.User;
using AyrinMovie.Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;

namespace AyrinMovie.Web.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IUserService _userService;

        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

    


        [BindProperty]
        public LoginViewModel Login { get; set; }


        public void OnGet()
        {
            
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var user = _userService.LoginUser(Login.Email, Login.Password);

            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.Email)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = Login.RememberMe
                    };

                    HttpContext.SignInAsync(principal, properties);

                    ViewData["isSuccess"] = true;
                    return Page();
                }
                else
                {
                    ModelState.AddModelError("Login.Email", "حساب کاربری شما فعال نمی باشد");
                }
            }

            ModelState.AddModelError("Login.Email", "کاربری با مشخصات وارد شده یافت نشد");

            return Page();



        }


    }
}
