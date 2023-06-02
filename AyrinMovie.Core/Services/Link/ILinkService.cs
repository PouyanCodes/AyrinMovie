using AyrinMovie.DataLayer.Entities.DownloadLinks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.Services.Link
{
    public interface ILinkService
    {

        void addlinkToMovie(int movieId, string linkTitle, string linkAddress);
        void addlinkToMovie(AyrinMovie.DataLayer.Entities.DownloadLinks.Link  Link);
        void addLinksToMovie(List<AyrinMovie.DataLayer.Entities.DownloadLinks.Link> Links);
        void addLinksToMovie(int movieId, List<string> linksTitle, List<string> linksAddress);
        List<AyrinMovie.DataLayer.Entities.DownloadLinks.Link> GetDownloadLinks(int movieId);
        void DeleteLink(int linkId);
        void DeleteLinksByMovieID(int movieId);


    }


}
