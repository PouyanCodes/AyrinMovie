using AyrinMovie.Core.Convertors;
using AyrinMovie.Core.DTOs.User;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AyrinMovie.Web.Pages.Admin.Manage.Users
{

    [PermissionChecker(4)]

    public class EditUserModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        public EditUserModel(IUserService userService , IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }


        [BindProperty]
        public EditUserViewModel EditUserViewModel { get; set; }


        public void OnGet(int id)
        {
            EditUserViewModel = _userService.GetUserForEditMode(id);
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();


            if (!Validation.EmailValidation(FixedText.FixEmail(EditUserViewModel.Email)))
            {
                ModelState.AddModelError("EditUserViewModel.Email", "ایمیل وارد شده معتبر نیست");
                return Page();
            }


            if (!string.IsNullOrEmpty(EditUserViewModel.Password))
            {
                if (PasswordHelper.CheckPasswordStrength(EditUserViewModel.Password) < 2)
                {
                    ModelState.AddModelError("EditUserViewModel.Password", "رمز عبور شما خیلی ساده است ؛ از رمز های قوی تر استفاده کنید");
                    return Page();
                }
            }

            int userId = _userService.EditUser(EditUserViewModel);
            _permissionService.EditUserRole(EditUserViewModel.UserRole, userId);

            return RedirectToPage("Index");
        }


    }
}
