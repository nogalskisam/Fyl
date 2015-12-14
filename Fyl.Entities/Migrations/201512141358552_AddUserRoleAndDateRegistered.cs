namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoleAndDateRegistered : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "DateRegistered", c => c.DateTime(nullable: false));
            AddColumn("dbo.User", "Role", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Role");
            DropColumn("dbo.User", "DateRegistered");
        }
    }
}
