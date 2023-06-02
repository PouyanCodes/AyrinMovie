using AyrinMovie.Core.DTOs.Movie;
using AyrinMovie.Core.Security;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Movie;
using AyrinMovie.DataLayer.Entities.DownloadLinks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AyrinMovie.Web.Pages.Admin.Movie
{
    [PermissionChecker(14)]

    public class EditMovieModel : PageModel
    {

        private readonly IMovieService _movieService;

        public EditMovieModel(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [BindProperty]
        public EditMovieViewModel EditMovieViewModel { get; set; }


        public IActionResult OnGet(int id)
        {
            if (!_movieService.IsExistMovie(id))
                return NotFound();

            EditMovieViewModel = _movieService.GetMovieForEditMode(id);
            return Page();

        }


        public IActionResult OnPost(List<string> DownLoadLinksAddress, List<string> DownloadLinksTitle)
        {
            if (!ModelState.IsValid)
                return Page();


            
            for (int i = 0; i < DownLoadLinksAddress.Count; i++)
            {
                if (!Validation.URLValidation(DownLoadLinksAddress[i]))
                {
                    ViewData["validateLinks"] = "لینک وارد شده معتبر نیست ";
                    return Page();
                }
            }


            EditMovieViewModel.DownloadLinks = new List<Link>();


            for (int i = 0; i < DownLoadLinksAddress.Count; i++)
            {
                EditMovieViewModel.DownloadLinks.Add(new Link
                {
                    FileId = EditMovieViewModel.movieId,
                    LinkAddress = DownLoadLinksAddress[i],
                    LinkTitle = DownloadLinksTitle[i]
                });
            }



            if (!Validation.URLValidation(EditMovieViewModel.MovieTrailerName))
            {
                ModelState.AddModelError("EditMovieViewModel.MovieTrailerName", "لینک وارد شده معتبر نمی باشد ");
                return Page();
            }

            _movieService.EditMovie(EditMovieViewModel);

            return RedirectToPage("Movies");
        }


    }
}
