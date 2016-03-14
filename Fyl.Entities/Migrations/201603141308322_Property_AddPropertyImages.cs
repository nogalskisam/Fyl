namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Property_AddPropertyImages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyImage",
                c => new
                    {
                        PropertyImageId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        Path = c.String(),
                        FileExtension = c.String(),
                    })
                .PrimaryKey(t => t.PropertyImageId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyImage", "PropertyId", "dbo.Property");
            DropIndex("dbo.PropertyImage", new[] { "PropertyId" });
            DropTable("dbo.PropertyImage");
        }
    }
}
