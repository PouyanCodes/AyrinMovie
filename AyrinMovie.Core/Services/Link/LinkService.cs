using AyrinMovie.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.Core.Services.Link
{
    public class LinkService : ILinkService
    {

        private readonly WebContext _context;

        public LinkService(WebContext context)
        {
            _context = context;
        }


        public void addlinkToMovie(DataLayer.Entities.DownloadLinks.Link Link)
        {
            _context.Links.Add(Link);
            _context.SaveChanges();
        }


        public void addlinkToMovie(int movieId, string linkTitle, string linkAddress)
        {
            var newLink = new AyrinMovie.DataLayer.Entities.DownloadLinks.Link();

            newLink.LinkTitle = linkTitle;
            newLink.LinkAddress = linkAddress;
            newLink.FileId = movieId;

            _context.Links.Add(newLink);
            _context.SaveChanges();
        }


        public void addLinksToMovie(List<DataLayer.Entities.DownloadLinks.Link> Links)
        {
            foreach(var link in Links)
            {
                addlinkToMovie(link);
            }
        }


        public void addLinksToMovie(int movieId, List<string> linksTitle, List<string> linksAddress)
        {
            for (int i = 0; i < linksAddress.Count; i++)
            {
                addlinkToMovie(movieId, linksTitle[i], linksAddress[i]);
            }
        }


        public List<DataLayer.Entities.DownloadLinks.Link> GetDownloadLinks(int movieId)
        {
            return _context.Links.Where(l => l.FileId == movieId).Select(l => new DataLayer.Entities.DownloadLinks.Link()
            {
                LinkId = l.LinkId,
                LinkAddress = l.LinkAddress,
                LinkTitle = l.LinkTitle,
            }).ToList();
        }


        public void DeleteLink(int linkId)
        {
            var link = _context.Links.SingleOrDefault(l => l.LinkId == linkId);
            link.isDeleted = true;
            _context.SaveChanges();
        }


        public void DeleteLinksByMovieID(int movieId)
        {
            var movieLinks = _context.Links.Where(l => l.FileId == movieId).Select(l => l.LinkId).ToList();

            foreach (var linkId in movieLinks)
            {
                DeleteLink(linkId);
            }

        }

        

       


    }
}
