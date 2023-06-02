using AyrinMovie.Core.DTOs.AdminPanel;
using AyrinMovie.Core.DTOs.Movie;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.Services.Movie
{
    public interface IMovieService
    {
        void DeleteMovieImage(string image);
        int AddMovie(AddMovieViewModel movie);
        int EditMovie(EditMovieViewModel editMovie);
        void DeleteMovie(int movieId);
        AyrinMovie.DataLayer.Entities.Movies.Movie GetMovieById(int movieId);
        AyrinMovie.DataLayer.Entities.Movies.Movie GetMovieByTitle(string movieTitle);
        ShowMovieListViewModel GetMovies(MovieSearchFiltersViewModel movieFilter);
        bool CheckTitleExist(string title);
        bool IsExistMovie(int movieId);
        EditMovieViewModel GetMovieForEditMode(int movieId);
        void UpdateMovie(AyrinMovie.DataLayer.Entities.Movies.Movie movie);
        List<MoviesForShowInAdminPanelViewModel> GetMovies();
        List<SelectListItem> GetGroups();
        List<SelectListItem> GetSubGroups(int groupId);

    }
}
