namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tenant_MakePropertyIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tenant", "PropertyId", "dbo.Property");
            DropIndex("dbo.Tenant", new[] { "PropertyId" });
            AlterColumn("dbo.Tenant", "PropertyId", c => c.Guid());
            CreateIndex("dbo.Tenant", "PropertyId");
            AddForeignKey("dbo.Tenant", "PropertyId", "dbo.Property", "PropertyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenant", "PropertyId", "dbo.Property");
            DropIndex("dbo.Tenant", new[] { "PropertyId" });
            AlterColumn("dbo.Tenant", "PropertyId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tenant", "PropertyId");
            AddForeignKey("dbo.Tenant", "PropertyId", "dbo.Property", "PropertyId", cascadeDelete: true);
        }
    }
}
