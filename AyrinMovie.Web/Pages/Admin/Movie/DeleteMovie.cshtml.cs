using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Movie
{

    [PermissionChecker(15)]

    public class DeleteMovieModel : PageModel
    {

        private readonly IMovieService _movieService;

        public DeleteMovieModel(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public IActionResult OnGet(int id)
        {
            if (!_movieService.IsExistMovie(id))
                return NotFound();
            else
            {
                var moviePoster = _movieService.GetMovieById(id).MovieImageName;

                _movieService.DeleteMovie(id);
                _movieService.DeleteMovieImage(moviePoster);

                return RedirectToPage("Movies");
            }

        }



    }
}
