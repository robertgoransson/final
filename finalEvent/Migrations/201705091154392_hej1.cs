namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hej1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Message", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Message");
        }
    }
}
