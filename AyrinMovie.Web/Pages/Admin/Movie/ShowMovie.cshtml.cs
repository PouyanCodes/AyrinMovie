using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AyrinMovie.Web.Pages.Admin.Movie
{

    [PermissionChecker(16)]
    public class ShowMovieModel : PageModel
    {

        private readonly IMovieService _movieService;

        public ShowMovieModel(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [BindProperty]
        public MoviesForShowInAdminPanelViewModel MovieInfo { get; set; }

        public IActionResult OnGet(int id)
        {
            var movie = _movieService.GetMovieById(id);

            MovieInfo = new MoviesForShowInAdminPanelViewModel()
            {
                MovieId = movie.MovieId,
                MovieTitle = movie.MovieTitle,
                MovieAge = movie.MovieAges,
                MovieDescription = movie.MovieDescription,
                MovieSaticfaction = movie.MovieSatisfaction,
                MovieStory = movie.MovieStory,
                MovieTime = movie.MovieTime,
                CountryMaker = movie.CountryMaker,
                IMDBScore = movie.IMDBScore,
                Actors = movie.Actors,
                ProductionYear = movie.ProductionYear,              
                Tags = movie.Tags,
                MovieGenre = movie.MovieGenre,
                MovieImageName = movie.MovieImageName,
                MovieTrailerName = movie.MovieTrailerName,
                CreateDate = movie.CreateDate,
                UpdateDate = movie.UpdateDate
            };

            return Page();

        }


    }
}
