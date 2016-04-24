namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Property_RemoveFeatureProperty : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyFeature", "PropertyId", "dbo.Property");
            DropIndex("dbo.PropertyFeature", new[] { "PropertyId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.PropertyFeature", "PropertyId");
            AddForeignKey("dbo.PropertyFeature", "PropertyId", "dbo.Property", "PropertyId", cascadeDelete: true);
        }
    }
}
