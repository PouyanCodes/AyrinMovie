using AyrinMovie.DataLayer.Entities.DownloadLinks;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AyrinMovie.Core.DTOs.Movie
{



    public class AddMovieViewModel
    {

        [Display(Name = "عنوان فیلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieTitle { get; set; }



        [Display(Name = "توضیح فیلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieDescription { get; set; }



        [Display(Name = " داستان فیلم")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieStory { get; set; }



        [Display(Name = "میزان رضایت")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(0, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string MovieSatisfaction { get; set; }



        [Display(Name = "امتیاز فیلم")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(0, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string IMDBScore { get; set; }



        [Display(Name = "ژانر فیلم")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieGenre { get; set; }



        [Display(Name = "کشور سازنده")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CountryMaker { get; set; }



        [Display(Name = "سال ساخت")]
        [StringLength(4, ErrorMessage = "فرمت صحیح نیست")]
        public string ProductionYear { get; set; }



        [Display(Name = "بازیگران")]
        [MaxLength(600)]
        public string Actors { get; set; }



        [Display(Name = "مدت زمان")]
        [MaxLength(600)]
        public string MovieTime { get; set; }



        [Display(Name = "رده سنی")]
        [MaxLength(600)]
        public string MovieAges { get; set; }



        [Display(Name = "برچسب ها")]
        [MaxLength(600)]
        public string Tags { get; set; }

        public IFormFile MovieImage { get; set; }

        public string MovieTrailerName { get; set; }

        public int GroupId { get; set; }
        public int? SubGroup { get; set; }



    }




    public class EditMovieViewModel
    {
        public int movieId { get; set; }


        [Display(Name = "عنوان فیلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieTitle { get; set; }



        [Display(Name = "توضیح فیلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieDescription { get; set; }



        [Display(Name = " داستان فیلم")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieStory { get; set; }



        [Display(Name = "میزان رضایت")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(0, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string MovieSatisfaction { get; set; }



        [Display(Name = "امتیاز فیلم")]
        [MaxLength(10, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [MinLength(0, ErrorMessage = "{0} نمی تواند کمتر از {1} کاراکتر باشد .")]
        public string IMDBScore { get; set; }



        [Display(Name = "ژانر فیلم")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieGenre { get; set; }



        [Display(Name = "کشور سازنده")]
        [MaxLength(15, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CountryMaker { get; set; }



        [Display(Name = "سال ساخت")]
        [StringLength(4, ErrorMessage = "فرمت صحیح نیست")]
        public string ProductionYear { get; set; }



        [Display(Name = "بازیگران")]
        [MaxLength(600)]
        public string Actors { get; set; }



        [Display(Name = "مدت زمان")]
        [MaxLength(600)]
        public string MovieTime { get; set; }



        [Display(Name = "رده سنی")]
        [MaxLength(600)]
        public string MovieAges { get; set; }



        [Display(Name = "برچسب ها")]
        [MaxLength(600)]
        public string Tags { get; set; }


        [Display(Name = "لینک های دانلود")]
        public List<Link> DownloadLinks;

        public string MovieImageName { get; set; }
        public IFormFile MovieImage { get; set; }
        public string MovieTrailerName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int GroupId { get; set; }
        public int? SubGroup { get; set; }

    }



    public class ShowMovieViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDescription { get; set; }
        public string MovieStory { get; set; }
        public string MovieSaticfaction { get; set; }
        public string IMDBScore { get; set; }
        public string CountryMaker { get; set; }
        public string ProductionYear { get; set; }
        public string Actors { get; set; }
        public string MovieTime { get; set; }
        public string MovieAge { get; set; }
        public string Tags { get; set; }
        public string MovieTrailerName { get; set; }
        public string MovieImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }


    public class ShowMovieListViewModel
    {
        public List<AyrinMovie.DataLayer.Entities.Movies.Movie> Movies { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }


    public class MovieSearchFiltersViewModel
    {
        public int PageId { get; set; }
        public int Take { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public string Actors { get; set; }
        public string Country { get; set; }
        public string Tags { get; set; }
        public string GetType { get; set; }
        public string OrderBy { get; set; }
        public List<int> SelectedGenres;
    }



}
