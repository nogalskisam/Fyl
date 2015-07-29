namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Guid(nullable: false, identity: true),
                        HouseName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Area = c.String(),
                        City = c.String(),
                        County = c.String(),
                        Country = c.String(),
                        Postcode = c.String(),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Landlord",
                c => new
                    {
                        LandlordId = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LandlordId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        ContactNumber = c.String(),
                        EmailAddress = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        PropertyId = c.Guid(nullable: false, identity: true),
                        AddressId = c.Guid(nullable: false),
                        Beds = c.Int(nullable: false),
                        LandlordId = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Landlord", t => t.LandlordId)
                .Index(t => t.AddressId)
                .Index(t => t.LandlordId);
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        TenantId = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Property_PropertyId = c.Guid(),
                    })
                .PrimaryKey(t => t.TenantId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Property", t => t.Property_PropertyId)
                .Index(t => t.UserId)
                .Index(t => t.Property_PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenant", "Property_PropertyId", "dbo.Property");
            DropForeignKey("dbo.Tenant", "UserId", "dbo.User");
            DropForeignKey("dbo.Property", "LandlordId", "dbo.Landlord");
            DropForeignKey("dbo.Property", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Landlord", "UserId", "dbo.User");
            DropIndex("dbo.Tenant", new[] { "Property_PropertyId" });
            DropIndex("dbo.Tenant", new[] { "UserId" });
            DropIndex("dbo.Property", new[] { "LandlordId" });
            DropIndex("dbo.Property", new[] { "AddressId" });
            DropIndex("dbo.Landlord", new[] { "UserId" });
            DropTable("dbo.Tenant");
            DropTable("dbo.Property");
            DropTable("dbo.User");
            DropTable("dbo.Landlord");
            DropTable("dbo.Address");
        }
    }
}
