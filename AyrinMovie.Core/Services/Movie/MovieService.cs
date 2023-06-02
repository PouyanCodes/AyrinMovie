using AyrinMovie.Core.Convertors;
using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.DTOs.Movie;
using AyrinMovie.Core.Generator;
using AyrinMovie.Core.Services.Link;
using AyrinMovie.DataLayer.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.Services.Movie
{
    public class MovieService : IMovieService
    {

        private readonly WebContext _context;
        private readonly ILinkService _linkService;

        public MovieService(WebContext context, ILinkService linkService)
        {
            _context = context;
            _linkService = linkService;
        }


        public int AddMovie(AddMovieViewModel movie)
        {
            var newMovie = new AyrinMovie.DataLayer.Entities.Movies.Movie();

            #region Save Image

            if (movie.MovieImage != null)
            {
                // Main Image

                newMovie.MovieImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(movie.MovieImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Movies/", newMovie.MovieImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    movie.MovieImage.CopyTo(stream);
                }

                // Create Thumbnail

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Movies/Thumbnail/", newMovie.MovieImageName);
                ImageConvertor.Image_Resize(imagePath, thumbnailPath, 200);

            }

            else
                newMovie.MovieImageName = "Defult.jpg";


            #endregion

            newMovie.MovieTitle = movie.MovieTitle;
            newMovie.MovieDescription = movie.MovieDescription;
            newMovie.MovieStory = movie.MovieStory;
            newMovie.Tags = movie.Tags;
            newMovie.Actors = movie.Actors;
            newMovie.CountryMaker = movie.CountryMaker;
            newMovie.IMDBScore = movie.IMDBScore;
            newMovie.MovieAges = movie.MovieAges;
            newMovie.MovieGenre = movie.MovieGenre;
            newMovie.MovieSatisfaction = movie.MovieSatisfaction;
            newMovie.MovieTime = movie.MovieTime;
            newMovie.ProductionYear = movie.ProductionYear;
            newMovie.CreateDate = DateTime.Now;
            newMovie.GroupId = movie.GroupId;
            newMovie.SubGroup = movie.SubGroup;

            _context.Movies.Add(newMovie);
            _context.SaveChanges();

            return newMovie.MovieId;
        }


        public bool CheckTitleExist(string title)
        {
            var MovieTitles = _context.Movies.Select(m => m.MovieTitle.Replace(" ", string.Empty).ToLower()).ToList();
            title = title.Replace(" ", string.Empty).ToLower();
            return MovieTitles.Contains(title);
        }

        public int EditMovie(EditMovieViewModel editMovie)
        {
            var newMovie = GetMovieById(editMovie.movieId);

            if (editMovie.MovieImage != null)
            {

                // Delete Old Movie Poster

                DeleteMovieImage(editMovie.MovieImageName);

                #region Save New Poster

                // Edit Main Image

                newMovie.MovieImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(editMovie.MovieImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Movies", newMovie.MovieImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editMovie.MovieImage.CopyTo(stream);
                }

                // Edit Thumbnail

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Movies/Thumbnail", newMovie.MovieImageName);
                ImageConvertor.Image_Resize(imagePath, thumbnailPath, 200);

                #endregion

            }

            #region Edit Links

            // Delete Old Links
            _linkService.DeleteLinksByMovieID(editMovie.movieId);

            // Add New Links
            _linkService.addLinksToMovie(editMovie.DownloadLinks);

            #endregion


            newMovie.MovieTitle = editMovie.MovieTitle;
            newMovie.MovieAges = editMovie.MovieAges;
            newMovie.MovieSatisfaction = editMovie.MovieSatisfaction;
            newMovie.MovieDescription = editMovie.MovieDescription;
            newMovie.MovieTrailerName = editMovie.MovieTrailerName;
            newMovie.MovieStory = editMovie.MovieStory;
            newMovie.Tags = editMovie.Tags;
            newMovie.Actors = editMovie.Actors;
            newMovie.CountryMaker = editMovie.CountryMaker;
            newMovie.IMDBScore = editMovie.IMDBScore;
            newMovie.MovieGenre = editMovie.MovieGenre;
            newMovie.MovieTime = editMovie.MovieTime;
            newMovie.ProductionYear = editMovie.ProductionYear;
            newMovie.UpdateDate = DateTime.Now;
            newMovie.GroupId = editMovie.GroupId;
            newMovie.SubGroup = editMovie.SubGroup;

            UpdateMovie(newMovie);
            return newMovie.MovieId;
        }

        public List<SelectListItem> GetGroups()
        {
            return _context.MovieGroups.Where(g => g.ParentId == null).Select(g => new SelectListItem()
            {
                Value = g.GroupId.ToString(),
                Text = g.GroupTitle

            }).ToList();
        }

        public List<SelectListItem> GetSubGroups(int groupId)
        {
            return _context.MovieGroups.Where(g => g.ParentId == groupId).Select(g => new SelectListItem()
            {
                Value = g.GroupId.ToString(),
                Text = g.GroupTitle

            }).ToList();
        }

        public DataLayer.Entities.Movies.Movie GetMovieById(int movieId)
        {
            return _context.Movies.Find(movieId);
        }

        public DataLayer.Entities.Movies.Movie GetMovieByTitle(string movieTitle)
        {
            return _context.Movies.Single(m => m.MovieTitle == movieTitle);
        }

        public EditMovieViewModel GetMovieForEditMode(int movieId)
        {
            return _context.Movies.Where(m => m.MovieId == movieId).Select(m => new EditMovieViewModel()
            {
                movieId = m.MovieId,
                MovieAges = m.MovieAges,
                MovieSatisfaction = m.MovieSatisfaction,
                MovieTrailerName = m.MovieTrailerName,
                CountryMaker = m.CountryMaker,
                IMDBScore = m.IMDBScore,
                Actors = m.Actors,
                MovieGenre = m.MovieGenre,
                MovieTime = m.MovieTime,
                ProductionYear = m.ProductionYear,
                MovieTitle = m.MovieTitle,
                MovieDescription = m.MovieDescription,
                MovieStory = m.MovieStory,
                MovieImageName = m.MovieImageName,
                GroupId = m.GroupId,
                SubGroup = m.SubGroup,
                Tags = m.Tags,
                DownloadLinks = _linkService.GetDownloadLinks(movieId)

            }).Single();
        }

        public List<MoviesForShowInAdminPanelViewModel> GetMovies()
        {
            return _context.Movies.Select(m => new MoviesForShowInAdminPanelViewModel()
            {
                MovieId = m.MovieId,
                MovieTitle = m.MovieTitle,
                MovieGenre = m.MovieGenre,
                MovieImageName = m.MovieImageName,
                CreateDate = m.CreateDate,
                UpdateDate = m.UpdateDate

            }).OrderByDescending(m => m.CreateDate).ToList();
        }


        public ShowMovieListViewModel GetMovies(MovieSearchFiltersViewModel movieFilter)
        {

            IQueryable<AyrinMovie.DataLayer.Entities.Movies.Movie> result = _context.Movies;

            if (!string.IsNullOrWhiteSpace(movieFilter.MovieTitle))
            {
                result = result.Where(m => m.MovieTitle.Contains(movieFilter.MovieTitle));
            }


            if (!string.IsNullOrWhiteSpace(movieFilter.MovieGenre))
            {
                result = result.Where(m => m.MovieGenre.Contains(movieFilter.MovieGenre));
            }


            if (!string.IsNullOrWhiteSpace(movieFilter.Tags))
            {
                result = result.Where(m => m.Tags.Contains(movieFilter.Tags));
            }

            if (!string.IsNullOrWhiteSpace(movieFilter.Country))
            {
                result = result.Where(m => m.CountryMaker.Contains(movieFilter.Country));
            }

            if (!string.IsNullOrWhiteSpace(movieFilter.Actors))
            {
                result = result.Where(m => m.Actors.Contains(movieFilter.Actors));
            }

            switch (movieFilter.GetType)
            {
                case "all":
                    break;
            }

            switch (movieFilter.OrderBy)
            {
                case "imdb":
                    result = result.OrderByDescending(m => m.IMDBScore);
                    break;

                case "pruductYear":
                    result = result.OrderByDescending(m => m.ProductionYear);
                    break;
            }


            result = result.OrderByDescending(m => m.CreateDate);


            // Show Movies In Page

            ShowMovieListViewModel list = new ShowMovieListViewModel();

            if (movieFilter.Take == 0)
                movieFilter.Take = 4;

            if (movieFilter.PageId == 0)
                movieFilter.PageId = 1;


            int skip = (movieFilter.PageId - 1) * movieFilter.Take;
            list.CurrentPage = movieFilter.PageId;
            list.PageCount = result.Count() / movieFilter.Take;

            list.Movies = result.Skip(skip).Take(movieFilter.Take).ToList();

            return list;
        }



        public bool IsExistMovie(int movieId)
        {
            return _context.Movies.Any(a => a.MovieId == movieId);
        }


        public void UpdateMovie(DataLayer.Entities.Movies.Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(int movieId)
        {
            var movie = _context.Movies.Find(movieId);
            movie.isDeleted = true;
            _context.SaveChanges();
        }

        public void DeleteMovieImage(string image)
        {
            if (image != "Defult.jpg")
            {
                string mainImageDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Movies", image);
                string thumbnailDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Movies/Thumbnail", image);

                if (File.Exists(mainImageDeletePath))
                    File.Delete(mainImageDeletePath);

                if (File.Exists(thumbnailDeletePath))
                    File.Delete(thumbnailDeletePath);
            }
        }






    }

}
