namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUsersAndPasswordAuthEntities : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "PasswordAuthorisationId", "dbo.PasswordAuthorisation");
            DropForeignKey("dbo.Landlord", "UserId", "dbo.User");
            DropForeignKey("dbo.Tenant", "UserId", "dbo.User");
            DropIndex("dbo.Landlord", new[] { "UserId" });
            DropIndex("dbo.User", new[] { "PasswordAuthorisationId" });
            DropIndex("dbo.Tenant", new[] { "UserId" });
            DropColumn("dbo.Landlord", "UserId");
            DropColumn("dbo.Tenant", "UserId");
            DropTable("dbo.User");
            DropTable("dbo.PasswordAuthorisation");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PasswordAuthorisation",
                c => new
                    {
                        PasswordAuthorisationId = c.Guid(nullable: false, identity: true),
                        Hash = c.String(),
                        Salt = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PasswordAuthorisationId);
            
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
                        DateRegistered = c.DateTime(nullable: false),
                        Role = c.Int(nullable: false),
                        PasswordAuthorisationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddColumn("dbo.Tenant", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Landlord", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tenant", "UserId");
            CreateIndex("dbo.User", "PasswordAuthorisationId");
            CreateIndex("dbo.Landlord", "UserId");
            AddForeignKey("dbo.Tenant", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Landlord", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.User", "PasswordAuthorisationId", "dbo.PasswordAuthorisation", "PasswordAuthorisationId");
        }
    }
}
