namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabortlocation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Location", c => c.Geography());
        }
    }
}
