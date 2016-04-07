namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyRequestEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PropertySignRequest",
                c => new
                    {
                        PropertySignRequestId = c.Guid(nullable: false, identity: true),
                        PropertyId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        DateRequested = c.DateTime(nullable: false),
                        DateAccepted = c.DateTime(),
                    })
                .PrimaryKey(t => t.PropertySignRequestId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertySignRequest", "PropertyId", "dbo.Property");
            DropIndex("dbo.PropertySignRequest", new[] { "PropertyId" });
            DropTable("dbo.PropertySignRequest");
        }
    }
}
