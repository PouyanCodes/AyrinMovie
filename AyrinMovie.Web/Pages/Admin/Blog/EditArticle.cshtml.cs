using AyrinMovie.Core.DTOs.Article;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Blog
{

    [PermissionChecker(8)]

    public class EditArticleModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IArticleService _articleService;


        public EditArticleModel(IArticleService articleService, IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }



        [BindProperty]
        public EditArticleViewModel EditArticleViewModel { get; set; }
        public int userId { get; set; }



        public IActionResult OnGet(int id)
        {
            userId = _userService.GetIdByEmail(User.Identity.Name);

            if (!((_articleService.CheckArticleAuthorIdentity(id, userId)) || _userService.IsGraetAdmin(userId)))
                return NotFound();

            else
            {
                if (_userService.IsGraetAdmin(userId))
                {
                    if (!_articleService.IsExistArticle(id))
                        return NotFound();
                }

                EditArticleViewModel = _articleService.GetArticleForEditMode(id);
                return Page();
            }
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            userId = _userService.GetIdByEmail(User.Identity.Name);
            EditArticleViewModel.AuthorId = userId;

            _articleService.EditArticle(EditArticleViewModel);

            return RedirectToPage("Articles");
        }


    }
}
