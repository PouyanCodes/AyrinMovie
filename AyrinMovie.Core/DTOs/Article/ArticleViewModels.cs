using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.DTOs.Article
{
    public class CreateArticleViewModel
    {
        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleTitle { get; set; }


        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ArticleText { get; set; }



        [Display(Name = "مقدمه مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleIntroduction { get; set; }



        [Display(Name = "برچسب ها")]
        [MaxLength(600)]
        public string Tags { get; set; }


        [Display(Name = "نویسنده")]
        public int AuthorId { get; set; }


        public IFormFile ArticleImage { get; set; }
        public int GroupId { get; set; }
        public int SubGroup { get; set; }

    }



    public class EditArticleViewModel
    {
        public int articleId { get; set; }

        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleTitle { get; set; }


        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ArticleText { get; set; }


        [Display(Name = "مقدمه مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleIntroduction { get; set; }


        [Display(Name = "برچسب ها")]
        [MaxLength(600)]
        public string Tags { get; set; }


        [Display(Name = "نویسنده")]
        public int AuthorId { get; set; }


        public IFormFile ArticleImage { get; set; }
        public string ArticleImageName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int GroupId { get; set; }
        public int? SubGroup { get; set; }

    }


    public class ShowArticleViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleText { get; set; }
        public string ArticleIntrodution { get; set; }
        public string Tags { get; set; }
        public string AuthorName { get; set; }
        public string AuthorProfile { get; set; }
        public string AuthorDescription { get; set; }
        public string ArticleImage { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }     
        public int GroupId { get; set; }
        public int SubGroup { get; set; }
    }


    public class ShowArticleListViewModel
    {
        public List<AyrinMovie.DataLayer.Entities.Blog.Article> Articles { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

}
