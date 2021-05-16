namespace CodeForMigration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSurName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "FName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "FName");
        }
    }
}
