namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.Property",
                c => new
                    {
                        PropertyId = c.Guid(nullable: false, identity: true),
                        AddressId = c.Guid(nullable: false),
                        Beds = c.Int(nullable: false),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deposit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        LandlordId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyId)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Landlord", t => t.LandlordId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.LandlordId);
            
            CreateTable(
                "dbo.PropertyImage",
                c => new
                    {
                        PropertyImageId = c.Guid(nullable: false, identity: true),
                        PropertyId = c.Guid(nullable: false),
                        Primary = c.Boolean(nullable: false),
                        Inactive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyImageId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
            CreateTable(
                "dbo.Landlord",
                c => new
                    {
                        LandlordId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LandlordId)
                .ForeignKey("dbo.User", t => t.LandlordId)
                .Index(t => t.LandlordId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        DateRegistered = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserAuthentication",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PasswordHash = c.Binary(maxLength: 32),
                        PasswordSalt = c.Binary(maxLength: 32),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.Guid(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ValidFromUtc = c.DateTime(nullable: false),
                        ValidUntilUtc = c.DateTime(nullable: false),
                        IpAddress = c.String(maxLength: 46),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        TenantId = c.Guid(nullable: false),
                        PropertyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.TenantId)
                .ForeignKey("dbo.Property", t => t.PropertyId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.TenantId)
                .Index(t => t.TenantId)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tenant", "TenantId", "dbo.User");
            DropForeignKey("dbo.Tenant", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.PropertyRating", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.PropertyFeature", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.PropertySignRequest", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Property", "LandlordId", "dbo.Landlord");
            DropForeignKey("dbo.Landlord", "LandlordId", "dbo.User");
            DropForeignKey("dbo.Session", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAuthentication", "UserId", "dbo.User");
            DropForeignKey("dbo.PropertyImage", "PropertyId", "dbo.Property");
            DropForeignKey("dbo.Property", "AddressId", "dbo.Address");
            DropIndex("dbo.Tenant", new[] { "PropertyId" });
            DropIndex("dbo.Tenant", new[] { "TenantId" });
            DropIndex("dbo.PropertyRating", new[] { "PropertyId" });
            DropIndex("dbo.PropertyFeature", new[] { "PropertyId" });
            DropIndex("dbo.PropertySignRequest", new[] { "PropertyId" });
            DropIndex("dbo.Session", new[] { "UserId" });
            DropIndex("dbo.UserAuthentication", new[] { "UserId" });
            DropIndex("dbo.Landlord", new[] { "LandlordId" });
            DropIndex("dbo.PropertyImage", new[] { "PropertyId" });
            DropIndex("dbo.Property", new[] { "LandlordId" });
            DropIndex("dbo.Property", new[] { "AddressId" });
            DropTable("dbo.Tenant");
            DropTable("dbo.PropertyRating");
            DropTable("dbo.PropertyFeature");
            DropTable("dbo.PropertySignRequest");
            DropTable("dbo.Session");
            DropTable("dbo.UserAuthentication");
            DropTable("dbo.User");
            DropTable("dbo.Landlord");
            DropTable("dbo.PropertyImage");
            DropTable("dbo.Property");
            DropTable("dbo.Address");
        }
    }
}
