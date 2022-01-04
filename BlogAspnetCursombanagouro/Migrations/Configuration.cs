namespace BlogAspnetCursombanagouro.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogAspnetCursombanagouro.Data.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogAspnetCursombanagouro.Data.BlogContext context)
        {
            context.Posts.Add(new Models.Entities.Post
            {
                Permalink = "primeiro-post",
                Title = "primeiro-post",
                Summary = "teste do primeiro-post",
                Content = "bla bla bla"

            });
        }
    }
}
