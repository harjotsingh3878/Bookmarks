namespace Bookmarks_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookmark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookmarks", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookmarks", "Tags");
        }
    }
}
