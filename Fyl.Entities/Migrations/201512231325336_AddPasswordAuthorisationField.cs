namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPasswordAuthorisationField : DbMigration
    {
        public override void Up()
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
            AddColumn("dbo.User", "PasswordAuthorisationId", c => c.Guid(nullable: false));
            CreateIndex("dbo.User", "PasswordAuthorisationId");
            AddForeignKey("dbo.User", "PasswordAuthorisationId", "dbo.PasswordAuthorisation", "PasswordAuthorisationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "PasswordAuthorisationId", "dbo.PasswordAuthorisation");
            DropIndex("dbo.User", new[] { "PasswordAuthorisationId" });
            DropColumn("dbo.User", "PasswordAuthorisationId");
            DropTable("dbo.PasswordAuthorisation");
        }
    }
}
