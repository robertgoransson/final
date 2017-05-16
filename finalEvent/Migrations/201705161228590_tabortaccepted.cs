namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabortaccepted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "Accepted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Accepted", c => c.Boolean(nullable: false));
        }
    }
}
