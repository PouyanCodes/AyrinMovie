using AyrinMovie.DataLayer.Entities.Movies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.DataLayer.Entities.DownloadLinks
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }

        [Required]
        public int FileId { get; set; }


        [Display(Name = "عنوان لینک")]
        public string LinkTitle { get; set; }


        [Display(Name = "آدرس لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LinkAddress { get; set; }

        public bool isDeleted { get; set; }


    }



}
