using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.DataLayer.Entities.Blog
{
    public class Article
    {

        [Key]
        public int ArticleId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }

        [Required]
        public int AuthorId { get; set; }


        [Display(Name = "عنوان مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleTitle { get; set; }


        [Display(Name = "متن مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ArticleText{ get; set; }


        [Display(Name = "مقدمه مقاله")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(5000, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleIntroduction { get; set; }



        [Display(Name = "برچسب ها")]
        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ArticleImageName { get; set; }


        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool isDeleted { get; set; }


        #region Relations


        [ForeignKey("AuthorId")]
        public User.User User { get; set; }

        [ForeignKey("GroupId")]
        public ArticleGroup ArticleGroup { get; set; }

        [ForeignKey("SubGroup")]
        public ArticleGroup Group { get; set; }


        #endregion

    }


}
