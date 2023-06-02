using AyrinMovie.Core.DTOs.Article;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Blog
{

    [PermissionChecker(7)]
    public class AddArticleModel : PageModel
    {

        private readonly IUserService _userService;
        private readonly IArticleService _articleService;

        public AddArticleModel(IArticleService articleService , IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }


        [BindProperty]
        public CreateArticleViewModel CreateArticleViewModel { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

           if( _articleService.CheckTitleExist(CreateArticleViewModel.ArticleTitle))
            {
                ModelState.AddModelError("CreateArticleViewModel.ArticleTitle", "مقاله ای با این عنوان در سایت موجود می باشد");
                return Page();
            }

            var userId = _userService.GetIdByEmail(User.Identity.Name);

            CreateArticleViewModel.AuthorId = userId;
            _articleService.AddArticle(CreateArticleViewModel);

            return RedirectToPage("Articles");
        }


    }
}
