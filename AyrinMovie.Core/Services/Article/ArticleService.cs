using AyrinMovie.Core.DTOs.Article;
using AyrinMovie.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using AyrinMovie.Core.Convertors;
using AyrinMovie.Core.Generator;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using AyrinMovie.Core.DTOs.AdminPanel;

namespace AyrinMovie.Core.Services.Article
{
    public class ArticleService : IArticleService
    {

        private readonly WebContext _context;

        public ArticleService(WebContext context)
        {
            _context = context;
        }

        public int AddArticle(CreateArticleViewModel article)
        {
            var newArticle = new DataLayer.Entities.Blog.Article();

            #region Save Image

            if (article.ArticleImage != null)
            {
                // Main Image

                newArticle.ArticleImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(article.ArticleImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Blog/", newArticle.ArticleImageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    article.ArticleImage.CopyTo(stream);
                }

                // Create Thumbnail

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Blog/Thumbnail/", newArticle.ArticleImageName);
                ImageConvertor.Image_Resize(imagePath, thumbnailPath, 200);

            }

            else
                newArticle.ArticleImageName = "Defult.jpg";


            #endregion

            newArticle.ArticleTitle = article.ArticleTitle;
            newArticle.ArticleText = article.ArticleText;
            newArticle.ArticleIntroduction = article.ArticleIntroduction;
            newArticle.Tags = article.Tags;
            newArticle.CreateDate = DateTime.Now;
            newArticle.AuthorId = article.AuthorId;
            newArticle.GroupId = article.GroupId;
            newArticle.SubGroup = article.SubGroup;

            _context.Articles.Add(newArticle);
            _context.SaveChanges();

            return newArticle.ArticleId;
        }


        public List<SelectListItem> GetGroups()
        {
            return _context.ArticleGroups.Where(g => g.ParentId == null).Select(g => new SelectListItem()
            {
                Value = g.GroupId.ToString(),
                Text = g.GroupTitle

            }).ToList();
        }


        public List<SelectListItem> GetSubGroups(int groupId)
        {
            return _context.ArticleGroups.Where(g => g.ParentId == groupId).Select(g => new SelectListItem()
            {
                Value = g.GroupId.ToString(),
                Text = g.GroupTitle

            }).ToList();
        }



        public List<ArticlesForShowInAdminPanelViewModel> GetArticles(int userId)
        {
            List<AyrinMovie.DataLayer.Entities.Blog.Article> articles = new List<DataLayer.Entities.Blog.Article>();
            List<ArticlesForShowInAdminPanelViewModel> userArticles = new List<ArticlesForShowInAdminPanelViewModel>();


            #region Check Is Great Admin ??

            bool isGreatAdmin = false;

            List<int> UserRoles = _context.UserRoles.Where(r => r.UserId == userId).Select(r => r.RoleId).ToList();
            List<int> GreatAdmins = _context.Roles.Where(r => r.isGreatAdmin).Select(r => r.RoleId).ToList();

            foreach (var item in GreatAdmins)
            {
                if (UserRoles.Contains(item))
                    isGreatAdmin = true;
            }

            #endregion 


            if (isGreatAdmin)
                articles = _context.Articles.ToList();
            else
                articles = _context.Articles.Where(a => a.AuthorId == userId).ToList();

            foreach (var item in articles)
            {
                userArticles.Add(new ArticlesForShowInAdminPanelViewModel()
                {
                    ArticleId = item.ArticleId,
                    ArticleImageName = item.ArticleImageName,
                    ArticleTitle = item.ArticleTitle,
                    AuthorName = _context.Users.SingleOrDefault(u => u.UserId == item.AuthorId).FullName,
                    CreateDate = item.CreateDate,
                    UpdateDate = item.UpdateDate

                });
            }

            return userArticles.OrderByDescending(a => a.CreateDate).ToList();
        }



        public void UpdateArticle(DataLayer.Entities.Blog.Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
        }


        public EditArticleViewModel GetArticleForEditMode(int articleId)
        {
            return _context.Articles.Where(a => a.ArticleId == articleId).Select(a => new EditArticleViewModel()
            {
                articleId = a.ArticleId,
                ArticleTitle = a.ArticleTitle,
                ArticleText = a.ArticleText,
                ArticleIntroduction = a.ArticleIntroduction,
                ArticleImageName = a.ArticleImageName,
                GroupId = a.GroupId,
                SubGroup = a.SubGroup,
                Tags = a.Tags,
            }).Single();
        }


        public bool CheckTitleExist(string title)
        {
            var ArticleTitles = _context.Articles.Select(a => a.ArticleTitle.Replace(" ", string.Empty).ToLower()).ToList();
            title = title.Replace(" ", string.Empty).ToLower();
            return ArticleTitles.Contains(title);
        }


        public DataLayer.Entities.Blog.Article GetArticleById(int articleId)
        {
            return _context.Articles.Find(articleId);
        }


        public int EditArticle(EditArticleViewModel editArticle)
        {
            AyrinMovie.DataLayer.Entities.Blog.Article newArticle = GetArticleById(editArticle.articleId);

            if (editArticle.ArticleImage != null)
            {
                // Delete Old Article Image

                DeleteArticleImage(editArticle.ArticleImageName);

                #region Save New Article Image

                // Edit Main Image

                newArticle.ArticleImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(editArticle.ArticleImage.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Blog", newArticle.ArticleImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editArticle.ArticleImage.CopyTo(stream);
                }

                // Edit Thumbnail

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Blog/Thumbnail", newArticle.ArticleImageName);
                ImageConvertor.Image_Resize(imagePath, thumbnailPath, 200);

                #endregion

            }


            newArticle.ArticleTitle = editArticle.ArticleTitle;
            newArticle.ArticleText = editArticle.ArticleText;
            newArticle.ArticleIntroduction = editArticle.ArticleIntroduction;
            newArticle.UpdateDate = DateTime.Now;
            newArticle.GroupId = editArticle.GroupId;
            newArticle.SubGroup = editArticle.SubGroup;
            newArticle.AuthorId = editArticle.AuthorId;
            newArticle.Tags = editArticle.Tags;

            UpdateArticle(newArticle);
            return newArticle.ArticleId;

        }

        public void DeleteArticle(int articleId)
        {
            var article = _context.Articles.Find(articleId);
            article.isDeleted = true;
            _context.SaveChanges();
        }

        public bool CheckArticleAuthorIdentity(int articleId, int userId)
        {
            return _context.Articles.Any(a => a.ArticleId == articleId && a.AuthorId == userId);
        }

        public bool IsExistArticle(int articleId)
        {
            return _context.Articles.Any(a => a.ArticleId == articleId);
        }

        public string GetAuthorNameByAuthorId(int authorId)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == authorId).FullName;
        }

        public ShowArticleListViewModel GetArticles(int pageId = 1, string filter = "", int take = 0)
        {

            IQueryable<AyrinMovie.DataLayer.Entities.Blog.Article> result = _context.Articles;

            // Show Item In Page

            ShowArticleListViewModel list = new ShowArticleListViewModel();

            if (take == 0)
                take = 5;

            int skip = (pageId - 1) * take;
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;

            list.Articles = result.OrderBy(u => u.CreateDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public DataLayer.Entities.Blog.Article GetArticleByTitle(string articleTitle)
        {
            return _context.Articles.Single(a => a.ArticleTitle == articleTitle);
        }

        public void DeleteArticleImage(string image)
        {
            if (image != "Defult.jpg")
            {
                string mainImageDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Blog", image);
                string thumbnailDeletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/Blog/Thumbnail", image);

                if (File.Exists(mainImageDeletePath))
                    File.Delete(mainImageDeletePath);

                if (File.Exists(thumbnailDeletePath))
                    File.Delete(thumbnailDeletePath);
            }
        }



    }
}
