namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehjdf : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Locations");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Locations", c => c.Int(nullable: false));
        }
    }
}
