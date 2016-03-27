namespace Bookmarks_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isPublic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "IsPublic", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "IsPublic");
        }
    }
}
