using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.DTOs.Article;
using AyrinMovie.Core.DTOs.Movie;
using AyrinMovie.Core.Services;
using AyrinMovie.Core.Services.Article;
using AyrinMovie.Core.Services.Movie;
using AyrinMovie.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AyrinMovie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IArticleService _articleService;
        private readonly IMovieService _movieService;
        public HomeController(ILogger<HomeController> logger, IArticleService articleService, IUserService userService, IMovieService movieService)
        {
            _logger = logger;
            _userService = userService;
            _articleService = articleService;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            MovieSearchFiltersViewModel filter = new MovieSearchFiltersViewModel();
            ShowMovieListViewModel Movies = _movieService.GetMovies(filter);

            ViewBag.movieList = Movies;

            return View();
        }


        [Route("Blog")]
        public IActionResult Blog(int pageId = 1, string filter = "")
        {
            ShowArticleListViewModel Articles = _articleService.GetArticles(pageId, filter);


            ViewBag.articlesList = Articles;

            return View();
        }


        public IActionResult Article(string id)
        {
            if (!_articleService.CheckTitleExist(id))
                return NotFound();

            else
            {
                var article = _articleService.GetArticleByTitle(id);

                ShowArticleViewModel articleForShow = new ShowArticleViewModel()
                {
                    ArticleTitle = article.ArticleTitle,
                    ArticleText = article.ArticleText,
                    ArticleImage = article.ArticleImageName,
                    AuthorName = _articleService.GetAuthorNameByAuthorId(article.AuthorId),
                    AuthorDescription = _userService.GetUserDescription(article.AuthorId),
                    AuthorProfile = _userService.GetUserAvatar(article.AuthorId),
                    CreateDate = article.CreateDate,
                    UpdateDate = article.UpdateDate,
                    Tags = article.Tags
                };

                ViewBag.article = articleForShow;
            }

            return View();
        }



        [Route("Movies")]
        [Route("MovieList")]
        [Route("MoviesList")]
        public IActionResult MoviesList(int pageId = 1, int take = 0, string movieTitle = "", string tags = "", string movieGenre = "",
            string getType = "", string actors = "", string country = "", string orderBy = "")
        {
            MovieSearchFiltersViewModel filter = new MovieSearchFiltersViewModel
            {
                Take = take,
                PageId = pageId,
                MovieTitle = movieTitle,
                MovieGenre = movieGenre,
                Country = country,
                Actors = actors,
                Tags = tags,
                GetType = getType,
                OrderBy = orderBy,
            };

            ViewBag.pageId = pageId;
            ViewBag.movieFilter = filter;

           ShowMovieListViewModel Movies = _movieService.GetMovies(filter);

            ViewBag.movieList = Movies;

            return View();
        }


        public IActionResult Movie(string id)
        {
            if (!_movieService.CheckTitleExist(id))
                return NotFound();

            else
            {

                var movie = _movieService.GetMovieByTitle(id);

                ShowMovieViewModel movieForShow = new ShowMovieViewModel()
                {
                    MovieId = movie.MovieId,
                    MovieTitle = movie.MovieTitle,
                    MovieStory = movie.MovieStory,
                    MovieDescription = movie.MovieDescription,
                    MovieGenre = movie.MovieGenre,
                    ProductionYear = movie.ProductionYear,
                    MovieAge = movie.MovieAges,
                    IMDBScore = movie.IMDBScore,
                    MovieSaticfaction = movie.MovieSatisfaction,
                    Actors = movie.Actors,
                    MovieTime = movie.MovieTime,
                    MovieImageName = movie.MovieImageName,
                    MovieTrailerName = movie.MovieTrailerName,
                    CountryMaker = movie.CountryMaker,
                    CreateDate = movie.CreateDate,
                    UpdateDate = movie.UpdateDate,
                    Tags = movie.Tags
                };

                ViewBag.movie = movieForShow;
            }

            return View();

        }




        #region Get Sub Groups For Articles

        public JsonResult GetSubGroups(int id)
        {
            var subGroups = _articleService.GetSubGroups(id);
            return Json(new SelectList(subGroups, "Value", "Text"));
        }

        #endregion

        #region Ck Editor File Upload


        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0)
                return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();


            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/MyImages", fileName);


            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            var url = $"{"/Files/MyImages/"}{fileName}";

            return Json(new { uploaded = true, url });
        }


        #endregion



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("PageNotFound")]
        public IActionResult PageNotFound()
        {
            return View();
        }


    }
}
