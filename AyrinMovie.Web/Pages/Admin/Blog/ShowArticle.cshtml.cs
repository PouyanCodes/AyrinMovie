using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Blog
{

    [PermissionChecker(11)]
    public class ShowArticleModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IArticleService _articleService;

        public ShowArticleModel(IArticleService articleService, IUserService userService)
        {
            _userService = userService;
            _articleService = articleService;
        }


        [BindProperty]
        public ArticlesForShowInAdminPanelViewModel ArticleInfo { get; set; }


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

                var article = _articleService.GetArticleById(id);

                ArticleInfo = new ArticlesForShowInAdminPanelViewModel()
                {
                    ArticleId = article.ArticleId,
                    ArticleTitle = article.ArticleTitle,
                    ArticleText = article.ArticleText,
                    ArticleImageName = article.ArticleImageName,
                    CreateDate = article.CreateDate,
                    UpdateDate = article.UpdateDate,
                    AuthorName = _articleService.GetAuthorNameByAuthorId(article.AuthorId),
                    Tags = article.Tags
                };

                return Page();
            }
        }


    }
}
