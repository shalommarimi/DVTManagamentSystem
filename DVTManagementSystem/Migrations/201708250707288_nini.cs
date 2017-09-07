namespace DVTManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nini : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfiles", "IsApproved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "IsApproved", c => c.Byte(nullable: false));
        }
    }
}
