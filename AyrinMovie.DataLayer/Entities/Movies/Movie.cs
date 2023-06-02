using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.DataLayer.Entities.Movies
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }


        [Display(Name = "عنوان فیلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieTitle { get; set; }



        [Display(Name = "توضیح فیلم")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string MovieDescription { get; set; }



        [Display(Name = "داستان فیلم")]
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



        [MaxLength(50)]
        public string MovieImageName { get; set; }



        [MaxLength(500)]
        public string MovieTrailerName { get; set; }


        [Required]
        public DateTime CreateDate { get; set; }


        public DateTime? UpdateDate { get; set; }


        public bool isDeleted { get; set; }


        #region GroupSubgroup Relations



        [ForeignKey("GroupId")]
        public MovieGroup MovieGroup { get; set; }

        [ForeignKey("SubGroup")]
        public MovieGroup Group { get; set; }




        #endregion


    }
}
