namespace Bookmarks_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Bookmarks", "User_Id");
            AddForeignKey("dbo.Bookmarks", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookmarks", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Bookmarks", new[] { "User_Id" });
            DropColumn("dbo.Bookmarks", "User_Id");
        }
    }
}
