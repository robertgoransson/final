namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletemessage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Message");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Message", c => c.String(nullable: false));
        }
    }
}
