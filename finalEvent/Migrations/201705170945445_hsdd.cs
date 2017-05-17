namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hsdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "EventInfo_EventId", c => c.Int());
            CreateIndex("dbo.Contacts", "EventInfo_EventId");
            AddForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events");
            DropIndex("dbo.Contacts", new[] { "EventInfo_EventId" });
            DropColumn("dbo.Contacts", "EventInfo_EventId");
        }
    }
}
