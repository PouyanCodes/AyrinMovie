using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Manage.Users
{

    [PermissionChecker(10)]

    public class ShowUserModel : PageModel
    {

        private readonly IUserService _userService;

        public ShowUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserForShowInAdminPanelViewModel UserInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            if (!_userService.IsExistUser(id))
                return NotFound();

            else
            {
                var user = _userService.GetUserByUserId(id);

                UserInfo = new UserForShowInAdminPanelViewModel()
                {
                    userId = user.UserId,
                    FullName = user.FullName,
                    UserAvatar = user.UserAvatar,
                    Biography = user.Biography,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    RegisterDate = user.RegisterDate
                };

                return Page();
            }
        }


    }
}
