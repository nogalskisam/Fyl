namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyImage_GivePrimaryKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PropertyImage");
            AlterColumn("dbo.PropertyImage", "PropertyImageId", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.PropertyImage", "PropertyImageId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PropertyImage");
            AlterColumn("dbo.PropertyImage", "PropertyImageId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.PropertyImage", "PropertyImageId");
        }
    }
}
