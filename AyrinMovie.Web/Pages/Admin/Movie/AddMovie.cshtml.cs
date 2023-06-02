using AyrinMovie.Core.DTOs.Movie;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Link;
using AyrinMovie.Core.Services.Movie;
using AyrinMovie.DataLayer.Entities.DownloadLinks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AyrinMovie.Web.Pages.Admin.Movie
{
    public class AddMovieModel : PageModel
    {

        private readonly IMovieService _movieService;
        private readonly ILinkService _linkService;

        public AddMovieModel(IMovieService movieService, ILinkService linkService)
        {
            _movieService = movieService;
            _linkService = linkService;
        }


        [BindProperty]
        public AddMovieViewModel AddMovieViewModel { get; set; }


        public void OnGet()
        {

        }


        public IActionResult OnPost(List<string> DownLoadLinksAddress, List<string> DownloadLinksTitle)
        {
            if (!ModelState.IsValid)
                return Page();


            if (_movieService.CheckTitleExist(AddMovieViewModel.MovieTitle))
            {
                ModelState.AddModelError("AddMovieViewModel.MovieTitle", "فیلمی با این عنوان در سایت موجود می باشد");
                return Page();
            }

            foreach (var address in DownLoadLinksAddress)
            {
                if (!Validation.URLValidation(address))
                {
                    ViewData["validateLinks"] = "لینک وارد شده معتبر نیست ";
                    return Page();
                }
            }


            if (!Validation.URLValidation(AddMovieViewModel.MovieTrailerName))
            {
                ModelState.AddModelError("AddMovieViewModel.MovieTrailerName", "لینک وارد شده معتبر نمی باشد ");
                return Page();
            }


            int movieId = _movieService.AddMovie(AddMovieViewModel);
            _linkService.addLinksToMovie(movieId, DownloadLinksTitle, DownLoadLinksAddress);

            return RedirectToPage("Movies");
        }

    }
}
