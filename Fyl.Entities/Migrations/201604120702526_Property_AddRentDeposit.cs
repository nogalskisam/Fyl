namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Property_AddRentDeposit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "Rent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Property", "Deposit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Property", "Deposit");
            DropColumn("dbo.Property", "Rent");
        }
    }
}
