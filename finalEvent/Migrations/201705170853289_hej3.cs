namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hej3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events");
            DropIndex("dbo.Contacts", new[] { "EventInfo_EventId" });
            DropColumn("dbo.Contacts", "EventInfo_EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "EventInfo_EventId", c => c.Int());
            CreateIndex("dbo.Contacts", "EventInfo_EventId");
            AddForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events", "EventId");
        }
    }
}
