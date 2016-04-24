namespace Fyl.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertySignRequest_ChangeDateRespondedName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertySignRequest", "DateResponded", c => c.DateTime());
            DropColumn("dbo.PropertySignRequest", "DateAccepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertySignRequest", "DateAccepted", c => c.DateTime());
            DropColumn("dbo.PropertySignRequest", "DateResponded");
        }
    }
}
