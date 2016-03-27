namespace Bookmarks_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookmarks", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Bookmarks", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookmarks", "Address", c => c.String());
            AlterColumn("dbo.Bookmarks", "Name", c => c.String());
        }
    }
}
