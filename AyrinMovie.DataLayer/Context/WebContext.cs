using AyrinMovie.DataLayer.Entities.Blog;
using AyrinMovie.DataLayer.Entities.DownloadLinks;
using AyrinMovie.DataLayer.Entities.Movies;
using AyrinMovie.DataLayer.Entities.Permission;
using AyrinMovie.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyrinMovie.DataLayer.Context
{
    public class WebContext :DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region  Filter Deleted Items

            modelBuilder.Entity<User>().HasQueryFilter(u => u.isDeleted == false);

            modelBuilder.Entity<Role>().HasQueryFilter(r => r.isDeleted == false);

            modelBuilder.Entity<ArticleGroup>().HasQueryFilter(g => g.isDeleted == false);

            modelBuilder.Entity<Article>().HasQueryFilter(a => a.isDeleted == false);

            modelBuilder.Entity<MovieGroup>().HasQueryFilter(g => g.isDeleted == false);

            modelBuilder.Entity<Movie>().HasQueryFilter(m => m.isDeleted == false);

            modelBuilder.Entity<Link>().HasQueryFilter(l => l.isDeleted == false);


            #endregion


            modelBuilder.Entity<Article>()
               .HasOne<ArticleGroup>(f => f.ArticleGroup)
               .WithMany(g => g.Articles)
               .HasForeignKey(f => f.GroupId);


            modelBuilder.Entity<Article>()
                .HasOne<ArticleGroup>(f => f.Group)
                .WithMany(g => g.SubGroup)
                .HasForeignKey(f => f.SubGroup);


            modelBuilder.Entity<Movie>()
              .HasOne<MovieGroup>(f => f.MovieGroup)
              .WithMany(g => g.Movies)
              .HasForeignKey(f => f.GroupId);


            modelBuilder.Entity<Movie>()
                .HasOne<MovieGroup>(f => f.Group)
                .WithMany(g => g.SubGroup)
                .HasForeignKey(f => f.SubGroup);


            base.OnModelCreating(modelBuilder);
        }

        #region User

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        #endregion       

        #region Permission

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        #endregion

        #region Weblog

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }

        #endregion

        #region Movies

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGroup> MovieGroups { get; set; }

        #endregion

        #region DownloadLinks

        public DbSet<Link> Links { get; set; }

        #endregion

    }

}
