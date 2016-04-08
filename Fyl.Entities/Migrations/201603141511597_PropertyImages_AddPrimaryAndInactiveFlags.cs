namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyImages_AddPrimaryAndInactiveFlags : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyImage", "FileName", c => c.String());
            AddColumn("dbo.PropertyImage", "Primary", c => c.Boolean(nullable: false));
            AddColumn("dbo.PropertyImage", "Inactive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyImage", "Inactive");
            DropColumn("dbo.PropertyImage", "Primary");
            DropColumn("dbo.PropertyImage", "FileName");
        }
    }
}
