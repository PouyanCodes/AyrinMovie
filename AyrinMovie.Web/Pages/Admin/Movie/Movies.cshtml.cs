using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AyrinMovie.Web.Pages.Admin.Movie
{

    [PermissionChecker(12)]
    public class MoviesModel : PageModel
    {
        private readonly IMovieService _movieService;

        public MoviesModel(IMovieService movieService)
        {
            _movieService = movieService;
        }


        public List<MoviesForShowInAdminPanelViewModel> Movies { get; set; }

        public void OnGet()
        {
            Movies = _movieService.GetMovies();
        }



    }
}
