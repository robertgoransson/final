namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsdfdsdfsfdsdfsdfsdfsdfsfsddfsfds : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Contact_ContactId", newName: "Contacts_ContactId");
            RenameIndex(table: "dbo.Events", name: "IX_Contact_ContactId", newName: "IX_Contacts_ContactId");
            AddColumn("dbo.Events", "EventAttendees_Key", c => c.Int());
            CreateIndex("dbo.Events", "EventAttendees_Key");
            AddForeignKey("dbo.Events", "EventAttendees_Key", "dbo.EventAttendees", "Key");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventAttendees_Key", "dbo.EventAttendees");
            DropIndex("dbo.Events", new[] { "EventAttendees_Key" });
            DropColumn("dbo.Events", "EventAttendees_Key");
            RenameIndex(table: "dbo.Events", name: "IX_Contacts_ContactId", newName: "IX_Contact_ContactId");
            RenameColumn(table: "dbo.Events", name: "Contacts_ContactId", newName: "Contact_ContactId");
        }
    }
}
