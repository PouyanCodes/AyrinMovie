using AyrinMovie.Core.Convertors;
using AyrinMovie.Core.DTOs.User;
using AyrinMovie.Core.Senders;
using AyrinMovie.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {

        private readonly IUserService _userService;
        private IViewRenderService _viewRender;

        public ForgotPasswordModel(IUserService userService, IViewRenderService viewRender)
        {
            _userService = userService;
            _viewRender = viewRender;
        }


        [BindProperty]
        public ForgotPasswordViewModel Forgot { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            string fixedEmail = FixedText.FixEmail(Forgot.Email);
            var user = _userService.GetUserByEmail(fixedEmail);

            if (user == null)
            {
                ModelState.AddModelError("Forgot.Email", "چنین ایمیلی در سایت موجود نیست");
                return Page();
            }

            string bodyEmail = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.Email, "بازیابی حساب کاربری", bodyEmail);

            ViewData["isSuccess"] = true;
            return Page();
        }




    }
}
