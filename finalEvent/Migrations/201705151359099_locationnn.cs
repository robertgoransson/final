namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationnn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Locations", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Locations");
        }
    }
}
