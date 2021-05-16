namespace CodeForMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Marks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Marks", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "Marks");
        }
    }
}
