namespace DVTManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class azureDb : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserProfiles", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfiles", "IsDeleted", c => c.Boolean(nullable: false));
        }
    }
}
