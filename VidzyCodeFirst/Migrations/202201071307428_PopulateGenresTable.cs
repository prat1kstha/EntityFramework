namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Horror')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Romance')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM dbo.Genres");
        }
    }
}
