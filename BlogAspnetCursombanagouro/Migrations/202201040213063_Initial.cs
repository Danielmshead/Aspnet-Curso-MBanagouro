namespace BlogAspnetCursombanagouro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 80),
                        Permalink = c.String(nullable: false, maxLength: 80),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Permalink, unique: true, name: "IX_dbo.Categories.Permalink");
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Permalink = c.String(nullable: false, maxLength: 100),
                        Title = c.String(nullable: false, maxLength: 70),
                        Summary = c.String(nullable: false, maxLength: 500),
                        Content = c.String(nullable: false),
                        Tags = c.String(),
                        PublishedOn = c.DateTime(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.PostsComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Content = c.String(nullable: false),
                        PublishedOn = c.DateTime(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.PostsComments", "Post_Id", "dbo.Posts");
            DropIndex("dbo.PostsComments", new[] { "Post_Id" });
            DropIndex("dbo.Posts", new[] { "Category_Id" });
            DropIndex("dbo.Categories", "IX_dbo.Categories.Permalink");
            DropTable("dbo.PostsComments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
