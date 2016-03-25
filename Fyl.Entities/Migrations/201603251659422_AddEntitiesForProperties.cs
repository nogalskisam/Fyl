namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntitiesForProperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertyFeature",
                c => new
                    {
                        PropertyFeatureId = c.Guid(nullable: false, identity: true),
                        PropertyId = c.Guid(nullable: false),
                        Feature = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyFeatureId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.PropertyRating",
                c => new
                    {
                        PropertyRatingId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyRatingId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyRating", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.PropertyFeature", "PropertyId", "dbo.Property");
            DropIndex("dbo.PropertyRating", new[] { "PropertyId" });
            DropIndex("dbo.PropertyFeature", new[] { "PropertyId" });
            DropTable("dbo.PropertyRating");
            DropTable("dbo.PropertyFeature");
        }
    }
}
