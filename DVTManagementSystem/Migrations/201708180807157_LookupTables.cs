namespace DVTManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LookupTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "HouseNumber", c => c.String(nullable: false));
            AddColumn("dbo.Suburbs", "SuburbName", c => c.String());
            DropColumn("dbo.Suburbs", "HouseNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suburbs", "HouseNumber", c => c.String());
            DropColumn("dbo.Suburbs", "SuburbName");
            DropColumn("dbo.Addresses", "HouseNumber");
        }
    }
}
