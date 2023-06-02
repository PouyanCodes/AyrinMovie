using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Blog
{

    [PermissionChecker(9)]

    public class DeleteArticleModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IArticleService _articleService;


        public DeleteArticleModel(IArticleService articleService, IUserService userService)
        {
            _userService = userService;
            _articleService = articleService;
        }


        public IActionResult OnGet(int id)
        {
            int userId = _userService.GetIdByEmail(User.Identity.Name);

            if (!((_articleService.CheckArticleAuthorIdentity(id, userId)) || _userService.IsGraetAdmin(userId)))
                return NotFound();
            else
            {
                if (_userService.IsGraetAdmin(userId))
                {
                    if (!_articleService.IsExistArticle(id))
                        return NotFound();
                }

                var articleImage = _articleService.GetArticleById(id).ArticleImageName;

                _articleService.DeleteArticleImage(articleImage);
                _articleService.DeleteArticle(id);

                return RedirectToPage("Articles");
            }
        }



    }
}
