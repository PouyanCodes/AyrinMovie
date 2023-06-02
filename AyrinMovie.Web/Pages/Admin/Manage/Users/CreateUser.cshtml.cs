using AyrinMovie.Core.Convertors;
using AyrinMovie.Core.DTOs.User;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AyrinMovie.Web.Pages.Admin.Manage.Users
{

    [PermissionChecker(3)]

    public class CreateUserModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public CreateUserModel(IUserService userService , IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }


        [BindProperty]
        public CreateUserViewModel CreateUserViewModel { get; set; }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (!Validation.EmailValidation(FixedText.FixEmail(CreateUserViewModel.Email)))
            {
                ModelState.AddModelError("CreateUserViewModel.Email", "ایمیل وارد شده معتبر نیست");
                return Page();
            }

            else if (_userService.IsExistEmail(FixedText.FixEmail(CreateUserViewModel.Email)))
            {
                ModelState.AddModelError("CreateUserViewModel.Email", "این ایمیل هم اکنون در سایت موجود می باشد ؛ ایمیل دیگری را امتحان کنید ");
                return Page();
            }

            if (PasswordHelper.CheckPasswordStrength(CreateUserViewModel.Password) < 2)
            {
                ModelState.AddModelError("CreateUserViewModel.Password", "رمز عبور شما خیلی ساده است ؛ از رمز های قوی تر استفاده کنید");
                return Page();
            }

            var userId = _userService.AddUser(CreateUserViewModel);
            _permissionService.AddRoleToUser(CreateUserViewModel.UserRole,userId);

            return RedirectToPage("Index");
        }




    }
}
