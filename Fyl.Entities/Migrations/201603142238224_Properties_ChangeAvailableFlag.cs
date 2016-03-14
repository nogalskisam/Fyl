namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Properties_ChangeAvailableFlag : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Property", "Available");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "Available", c => c.Boolean(nullable: false));
        }
    }
}
