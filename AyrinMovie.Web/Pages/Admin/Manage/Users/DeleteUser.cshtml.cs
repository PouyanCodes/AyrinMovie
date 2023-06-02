using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Manage.Users
{

    [PermissionChecker(5)]

    public class DeleteUserModel : PageModel
    {

        private readonly IUserService _userService;

        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet(int id)
        {
            if (_userService.IsGraetAdmin(id) || !_userService.IsExistUser(id))
                return NotFound();

            else
            {
                var userAvatar = _userService.GetUserByUserId(id).UserAvatar;
                _userService.DeleteUserAvatar(userAvatar);
                _userService.DeleteUser(id);
                return RedirectToPage("Index");
            }       
        }


    }
}
