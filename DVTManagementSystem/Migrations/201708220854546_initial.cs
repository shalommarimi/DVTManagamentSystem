namespace DVTManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        HouseNumber = c.String(nullable: false),
                        AddressTypeId = c.Int(nullable: false),
                        SuburbId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Suburbs", t => t.SuburbId, cascadeDelete: true)
                .Index(t => t.AddressTypeId)
                .Index(t => t.SuburbId);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        AddressTypeId = c.Int(nullable: false, identity: true),
                        TypeOfAddress = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.AddressTypeId);
            
            CreateTable(
                "dbo.Suburbs",
                c => new
                    {
                        SuburbId = c.Int(nullable: false, identity: true),
                        SuburbName = c.String(),
                        StreetName = c.String(),
                        PostalCodeId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuburbId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.PostalCodes", t => t.PostalCodeId, cascadeDelete: true)
                .Index(t => t.PostalCodeId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Provinces", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        ProvinceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            CreateTable(
                "dbo.PostalCodes",
                c => new
                    {
                        PostalCodeId = c.Int(nullable: false, identity: true),
                        PostalCodeNumber = c.String(nullable: false, maxLength: 4),
                    })
                .PrimaryKey(t => t.PostalCodeId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        UserProfileId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 200),
                        IdentityNumber = c.String(),
                        DateOfBirth = c.String(),
                        GenderTypeId = c.Int(nullable: false),
                        UserTypeId = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        EmailAddress = c.String(nullable: false),
                        PasswordHash = c.String(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserProfileId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderTypeId, cascadeDelete: true)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.GenderTypeId)
                .Index(t => t.UserTypeId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 20),
                        DepartmentDescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderType = c.String(nullable: false, maxLength: 7),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        UserRole = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.UserTypeId);
            
            CreateTable(
                "dbo.UserProfileAddresses",
                c => new
                    {
                        UserProfile_UserProfileId = c.Int(nullable: false),
                        Address_AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserProfile_UserProfileId, t.Address_AddressId })
                .ForeignKey("dbo.UserProfiles", t => t.UserProfile_UserProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.Address_AddressId, cascadeDelete: true)
                .Index(t => t.UserProfile_UserProfileId)
                .Index(t => t.Address_AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.UserProfiles", "GenderTypeId", "dbo.Genders");
            DropForeignKey("dbo.UserProfiles", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.UserProfileAddresses", "Address_AddressId", "dbo.Addresses");
            DropForeignKey("dbo.UserProfileAddresses", "UserProfile_UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.Suburbs", "PostalCodeId", "dbo.PostalCodes");
            DropForeignKey("dbo.Suburbs", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Addresses", "SuburbId", "dbo.Suburbs");
            DropForeignKey("dbo.Addresses", "AddressTypeId", "dbo.AddressTypes");
            DropIndex("dbo.UserProfileAddresses", new[] { "Address_AddressId" });
            DropIndex("dbo.UserProfileAddresses", new[] { "UserProfile_UserProfileId" });
            DropIndex("dbo.UserProfiles", new[] { "DepartmentId" });
            DropIndex("dbo.UserProfiles", new[] { "UserTypeId" });
            DropIndex("dbo.UserProfiles", new[] { "GenderTypeId" });
            DropIndex("dbo.Cities", new[] { "ProvinceId" });
            DropIndex("dbo.Suburbs", new[] { "CityId" });
            DropIndex("dbo.Suburbs", new[] { "PostalCodeId" });
            DropIndex("dbo.Addresses", new[] { "SuburbId" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeId" });
            DropTable("dbo.UserProfileAddresses");
            DropTable("dbo.UserTypes");
            DropTable("dbo.Genders");
            DropTable("dbo.Departments");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.PostalCodes");
            DropTable("dbo.Provinces");
            DropTable("dbo.Cities");
            DropTable("dbo.Suburbs");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
        }
    }
}
