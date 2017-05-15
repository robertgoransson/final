namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deltagare : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        IdEvent = c.Int(nullable: false),
                        Attendes = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Key)
                .ForeignKey("dbo.Users", t => t.Attendes)
                .ForeignKey("dbo.Events", t => t.IdEvent, cascadeDelete: true)
                .Index(t => t.IdEvent)
                .Index(t => t.Attendes);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventAttendees", "IdEvent", "dbo.Events");
            DropForeignKey("dbo.EventAttendees", "Attendes", "dbo.Users");
            DropIndex("dbo.EventAttendees", new[] { "Attendes" });
            DropIndex("dbo.EventAttendees", new[] { "IdEvent" });
            DropTable("dbo.EventAttendees");
        }
    }
}
