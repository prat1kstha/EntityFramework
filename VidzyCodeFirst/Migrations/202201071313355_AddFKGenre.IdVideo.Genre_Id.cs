namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFKGenreIdVideoGenre_Id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Videos", "Genre_Id");
            AddForeignKey("dbo.Videos", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Videos", new[] { "Genre_Id" });
            DropColumn("dbo.Videos", "Genre_Id");
        }
    }
}
