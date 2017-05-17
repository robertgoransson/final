namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfffsdfsdf : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Events", name: "Contacts_ContactId", newName: "Contact_ContactId");
            RenameIndex(table: "dbo.Events", name: "IX_Contacts_ContactId", newName: "IX_Contact_ContactId");
            DropColumn("dbo.Events", "MyContacts_DataGroupField");
            DropColumn("dbo.Events", "MyContacts_DataTextField");
            DropColumn("dbo.Events", "MyContacts_DataValueField");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "MyContacts_DataValueField", c => c.String());
            AddColumn("dbo.Events", "MyContacts_DataTextField", c => c.String());
            AddColumn("dbo.Events", "MyContacts_DataGroupField", c => c.String());
            RenameIndex(table: "dbo.Events", name: "IX_Contact_ContactId", newName: "IX_Contacts_ContactId");
            RenameColumn(table: "dbo.Events", name: "Contact_ContactId", newName: "Contacts_ContactId");
        }
    }
}
