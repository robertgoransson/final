namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _event : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndingDate = c.DateTime(nullable: false),
                        StartHour = c.DateTime(nullable: false),
                        EndHour = c.DateTime(nullable: false),
                        Description = c.String(),
                        Location = c.Geography(),
                        Owner = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Users", t => t.Owner)
                .Index(t => t.Owner);
            
            AddColumn("dbo.Contacts", "User_Email", c => c.String(maxLength: 40));
            CreateIndex("dbo.Contacts", "User_Email");
            AddForeignKey("dbo.Contacts", "User_Email", "dbo.Users", "Email");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Owner", "dbo.Users");
            DropForeignKey("dbo.Contacts", "User_Email", "dbo.Users");
            DropIndex("dbo.Events", new[] { "Owner" });
            DropIndex("dbo.Contacts", new[] { "User_Email" });
            DropColumn("dbo.Contacts", "User_Email");
            DropTable("dbo.Events");
        }
    }
}
