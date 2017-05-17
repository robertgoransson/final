namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Contacts_ContactId", c => c.Int());
            CreateIndex("dbo.Events", "Contacts_ContactId");
            AddForeignKey("dbo.Events", "Contacts_ContactId", "dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Contacts_ContactId", "dbo.Contacts");
            DropIndex("dbo.Events", new[] { "Contacts_ContactId" });
            DropColumn("dbo.Events", "Contacts_ContactId");
        }
    }
}
