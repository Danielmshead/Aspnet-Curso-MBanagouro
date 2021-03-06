using BlogAspnetCursombanagouro.Data.Mapping;
using BlogAspnetCursombanagouro.Models.Entities;
using BlogAspnetCursombanagouro.Data.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogAspnetCursombanagouro.Data
{
    public class BlogContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BlogContext()
            : base("MsSqlServer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, BlogAspnetCursombanagouro.Migrations.Configuration>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PostMap());
            modelBuilder.Configurations.Add(new CommentMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}