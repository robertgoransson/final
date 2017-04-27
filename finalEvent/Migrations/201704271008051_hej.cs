namespace finalEvent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hej : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 20),
                        Firstname = c.String(nullable: false, maxLength: 20),
                        Lastname = c.String(nullable: false, maxLength: 25),
                        Phonenumber = c.String(nullable: false),
                        Picture = c.String(),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
