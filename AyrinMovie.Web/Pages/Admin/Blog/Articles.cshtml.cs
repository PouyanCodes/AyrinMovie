using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AyrinMovie.Web.Pages.Admin.Blog
{

    [PermissionChecker(6)]
    public class ArticlesModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IArticleService _articleService;
        

        public ArticlesModel(IArticleService articleService , IUserService userService)
        {
            _userService = userService;
            _articleService = articleService;          
        }


        public List<ArticlesForShowInAdminPanelViewModel> Articles { get; set; }


        public void OnGet()
        {
            var userId = _userService.GetIdByEmail(User.Identity.Name);
            Articles = _articleService.GetArticles(userId);
        }


    }
}
