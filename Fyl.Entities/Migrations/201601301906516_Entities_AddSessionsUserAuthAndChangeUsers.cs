namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Entities_AddSessionsUserAuthAndChangeUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Property", "LandlordId", "dbo.Landlord");
            DropForeignKey("dbo.Tenant", "Property_PropertyId", "dbo.Property");
            DropForeignKey("dbo.Property", "AddressId", "dbo.Address");
            DropIndex("dbo.Property", new[] { "LandlordId" });
            DropIndex("dbo.Tenant", new[] { "Property_PropertyId" });
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
                "dbo.UserProperty",
                c => new
                    {
                        User_UserId = c.Guid(nullable: false),
                        Property_PropertyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Property_PropertyId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Property", t => t.Property_PropertyId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Property_PropertyId);
            
            AddForeignKey("dbo.Property", "AddressId", "dbo.Address", "AddressId", cascadeDelete: true);
            DropColumn("dbo.Property", "LandlordId");
            DropTable("dbo.Landlord");
            DropTable("dbo.Tenant");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tenant",
                c => new
                    {
                        TenantId = c.Guid(nullable: false, identity: true),
                        Property_PropertyId = c.Guid(),
                    })
                .PrimaryKey(t => t.TenantId);
            
            CreateTable(
                "dbo.Landlord",
                c => new
                    {
                        LandlordId = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.LandlordId);
            
            AddColumn("dbo.Property", "LandlordId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Property", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Session", "UserId", "dbo.User");
            DropForeignKey("dbo.UserProperty", "Property_PropertyId", "dbo.Property");
            DropForeignKey("dbo.UserProperty", "User_UserId", "dbo.User");
            DropForeignKey("dbo.UserAuthentication", "UserId", "dbo.User");
            DropIndex("dbo.UserProperty", new[] { "Property_PropertyId" });
            DropIndex("dbo.UserProperty", new[] { "User_UserId" });
            DropIndex("dbo.Session", new[] { "UserId" });
            DropIndex("dbo.UserAuthentication", new[] { "UserId" });
            DropTable("dbo.UserProperty");
            DropTable("dbo.Session");
            DropTable("dbo.UserAuthentication");
            DropTable("dbo.User");
            CreateIndex("dbo.Tenant", "Property_PropertyId");
            CreateIndex("dbo.Property", "LandlordId");
            AddForeignKey("dbo.Property", "AddressId", "dbo.Address", "AddressId");
            AddForeignKey("dbo.Tenant", "Property_PropertyId", "dbo.Property", "PropertyId");
            AddForeignKey("dbo.Property", "LandlordId", "dbo.Landlord", "LandlordId");
        }
    }
}
