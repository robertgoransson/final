namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sfjdsfsd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
