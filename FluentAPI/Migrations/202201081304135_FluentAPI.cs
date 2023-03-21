namespace FluentAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "tbl_Course");
            RenameTable(name: "dbo.TagCourses", newName: "CourseTags");
            DropIndex("dbo.tbl_Course", new[] { "Author_Id" });
            RenameColumn(table: "dbo.tbl_Course", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.CourseTags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.CourseTags", name: "Course_Id", newName: "CourseId");
            RenameIndex(table: "dbo.CourseTags", name: "IX_Course_Id", newName: "IX_CourseId");
            RenameIndex(table: "dbo.CourseTags", name: "IX_Tag_Id", newName: "IX_TagId");
            DropPrimaryKey("dbo.CourseTags");
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Course", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.tbl_Course", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.tbl_Course", "Description", c => c.String(nullable: false, maxLength: 2000));
            AlterColumn("dbo.tbl_Course", "AuthorId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CourseTags", new[] { "CourseId", "TagId" });
            CreateIndex("dbo.tbl_Course", "AuthorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Covers", "Id", "dbo.tbl_Course");
            DropIndex("dbo.Covers", new[] { "Id" });
            DropIndex("dbo.tbl_Course", new[] { "AuthorId" });
            DropPrimaryKey("dbo.CourseTags");
            AlterColumn("dbo.tbl_Course", "AuthorId", c => c.Int());
            AlterColumn("dbo.tbl_Course", "Description", c => c.String());
            AlterColumn("dbo.tbl_Course", "Name", c => c.String());
            DropTable("dbo.Covers");
            AddPrimaryKey("dbo.CourseTags", new[] { "Tag_Id", "Course_Id" });
            RenameIndex(table: "dbo.CourseTags", name: "IX_TagId", newName: "IX_Tag_Id");
            RenameIndex(table: "dbo.CourseTags", name: "IX_CourseId", newName: "IX_Course_Id");
            RenameColumn(table: "dbo.CourseTags", name: "CourseId", newName: "Course_Id");
            RenameColumn(table: "dbo.CourseTags", name: "TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.tbl_Course", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.tbl_Course", "Author_Id");
            RenameTable(name: "dbo.CourseTags", newName: "TagCourses");
            RenameTable(name: "dbo.tbl_Course", newName: "Courses");
        }
    }
}
