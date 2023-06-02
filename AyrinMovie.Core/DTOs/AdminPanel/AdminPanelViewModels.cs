using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.DTOs.AdminPanel
{

    public class UserForShowInAdminPanelViewModel
    {
        public int userId { get; set; }
        public string FullName { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserAvatar { get; set; }
        public DateTime RegisterDate { get; set; }
        public int UserRole { get; set; }

    }


    public class ArticlesForShowInAdminPanelViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleText { get; set; }
        public string ArticleImageName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string AuthorName{ get; set; }
        public string Tags { get; set; }

    }



    public class MoviesForShowInAdminPanelViewModel
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public string MovieDescription { get; set; }
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
        public string MovieStory { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }



}
