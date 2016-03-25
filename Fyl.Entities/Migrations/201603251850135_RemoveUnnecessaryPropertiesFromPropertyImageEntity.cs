namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnnecessaryPropertiesFromPropertyImageEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PropertyImage", "Path");
            DropColumn("dbo.PropertyImage", "FileName");
            DropColumn("dbo.PropertyImage", "FileExtension");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyImage", "FileExtension", c => c.String());
            AddColumn("dbo.PropertyImage", "FileName", c => c.String());
            AddColumn("dbo.PropertyImage", "Path", c => c.String());
        }
    }
}
