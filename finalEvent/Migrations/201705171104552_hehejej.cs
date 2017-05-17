namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehejej : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events");
            DropIndex("dbo.Contacts", new[] { "EventInfo_EventId" });
            AddColumn("dbo.Events", "MyContacts_DataGroupField", c => c.String());
            AddColumn("dbo.Events", "MyContacts_DataTextField", c => c.String());
            AddColumn("dbo.Events", "MyContacts_DataValueField", c => c.String());
            DropColumn("dbo.Contacts", "EventInfo_EventId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "EventInfo_EventId", c => c.Int());
            DropColumn("dbo.Events", "MyContacts_DataValueField");
            DropColumn("dbo.Events", "MyContacts_DataTextField");
            DropColumn("dbo.Events", "MyContacts_DataGroupField");
            CreateIndex("dbo.Contacts", "EventInfo_EventId");
            AddForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events", "EventId");
        }
    }
}
