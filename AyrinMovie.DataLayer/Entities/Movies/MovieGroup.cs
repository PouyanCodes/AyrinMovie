using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.DataLayer.Entities.Movies
{
    public class MovieGroup
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
        public List<MovieGroup> MovieGroups { get; set; }



        [InverseProperty("MovieGroup")]
        public List<Movie> Movies { get; set; }



        [InverseProperty("Group")]
        public List<Movie> SubGroup { get; set; }

        public bool isDeleted { get; set; }


    }
}
