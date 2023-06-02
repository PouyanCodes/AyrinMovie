using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.DataLayer.Entities.Blog
{
    public class ArticleGroup
    {

        [Key]
        public int GroupId { get; set; }


        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string GroupTitle { get; set; }


        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }



        [ForeignKey("ParentId")]
        public List<ArticleGroup> ArticleGroups { get; set; }



        [InverseProperty("ArticleGroup")]
        public List<Article> Articles { get; set; }



        [InverseProperty("Group")]
        public List<Article> SubGroup { get; set; }

        public bool isDeleted { get; set; }

    }

}
