using AyrinMovie.Core.DTOs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyrinMovie.DataLayer.Entities.Blog;
using Microsoft.AspNetCore.Mvc.Rendering;
using AyrinMovie.Core.DTOs.AdminPanel;

namespace AyrinMovie.Core.Services.Article
{
    public interface IArticleService
    {
        int AddArticle(CreateArticleViewModel article);
        void UpdateArticle(AyrinMovie.DataLayer.Entities.Blog.Article article);
        List<SelectListItem> GetGroups();
        List<SelectListItem> GetSubGroups(int groupId);
        List<ArticlesForShowInAdminPanelViewModel> GetArticles(int userId);
        ShowArticleListViewModel GetArticles(int pageId = 1, string filter = "", int take = 0);
        EditArticleViewModel GetArticleForEditMode(int articleId);
        bool CheckTitleExist(string title);
        AyrinMovie.DataLayer.Entities.Blog.Article GetArticleById(int articleId);
        AyrinMovie.DataLayer.Entities.Blog.Article GetArticleByTitle(string articleTitle);
        int EditArticle(EditArticleViewModel editArticle);
        void DeleteArticle(int articleId);
        bool CheckArticleAuthorIdentity(int articleId, int userId);
        bool IsExistArticle(int articleId);
        string GetAuthorNameByAuthorId(int authorId);
        void DeleteArticleImage(string image);

    }
}
