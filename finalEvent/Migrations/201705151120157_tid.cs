namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "EndingDate", c => c.String());
            AlterColumn("dbo.Events", "StartHour", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "StartHour", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "EndingDate", c => c.DateTime(nullable: false));
        }
    }
}
