using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AyrinMovie.Web.Pages.Admin.Manage.Users
{

    [PermissionChecker(2)]

    public class IndexModel : PageModel
    {

        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserForShowInAdminPanelViewModel> Users { get; set; }


        public void OnGet()
        {
            Users = _userService.GetUsers();
        }


    }
}
