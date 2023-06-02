using AyrinMovie.Core.DTOs.User;
using AyrinMovie.Core.Generator;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Account
{
    public class ResetPasswordModel : PageModel
    {

        private readonly IUserService _userService;


        public ResetPasswordModel(IUserService userService)
        {
            _userService = userService;
        }


        [BindProperty]
        public ResetPasswordViewModel Reset { get; set; }


        public IActionResult OnGet(string id)
        {
            if (!_userService.IsExistActiceCode(id))
                return NotFound();

            else
            {
                Reset = new ResetPasswordViewModel();
                Reset.ActiveCode = id;
                return Page();
            }
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (PasswordHelper.CheckPasswordStrength(Reset.Password) < 2)
            {
                ModelState.AddModelError("Reset.RePassword", "رمز عبور شما خیلی ساده است ؛ از رمز های قوی تر استفاده کنید");
                return Page();
            }

            var user = _userService.GetUserByActiveCode(Reset.ActiveCode);

            if (user == null)
                return NotFound();

            else
            {
                string hashNewPassword = PasswordHelper.EncodePasswordMd5(Reset.Password);

                user.Password = hashNewPassword;
                user.ActiveCode = NameGenerator.GenerateUniqCode();
                _userService.UpdateUser(user);

                ViewData["isSuccess"] = true;
                return Page();
            }

        }



    }
}
