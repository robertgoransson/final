namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contact : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        SenderEmail = c.String(maxLength: 40),
                        ReceiverEmail = c.String(maxLength: 40),
                        Accepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Users", t => t.ReceiverEmail)
                .ForeignKey("dbo.Users", t => t.SenderEmail)
                .Index(t => t.SenderEmail)
                .Index(t => t.ReceiverEmail);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "SenderEmail", "dbo.Users");
            DropForeignKey("dbo.Contacts", "ReceiverEmail", "dbo.Users");
            DropIndex("dbo.Contacts", new[] { "ReceiverEmail" });
            DropIndex("dbo.Contacts", new[] { "SenderEmail" });
            DropTable("dbo.Contacts");
        }
    }
}
