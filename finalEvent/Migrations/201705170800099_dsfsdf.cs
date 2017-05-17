namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsfsdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "EventInfo_EventId", c => c.Int());
            AddColumn("dbo.Events", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Contacts", "EventInfo_EventId");
            AddForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events", "EventId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "EventInfo_EventId", "dbo.Events");
            DropIndex("dbo.Contacts", new[] { "EventInfo_EventId" });
            DropColumn("dbo.Events", "Discriminator");
            DropColumn("dbo.Contacts", "EventInfo_EventId");
        }
    }
}
