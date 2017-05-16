namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tjenis : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "StartDate", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "EndingDate", c => c.String(nullable: false));
            AlterColumn("dbo.Events", "StartHour", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "StartHour", c => c.String());
            AlterColumn("dbo.Events", "EndingDate", c => c.String());
            AlterColumn("dbo.Events", "StartDate", c => c.String());
        }
    }
}
