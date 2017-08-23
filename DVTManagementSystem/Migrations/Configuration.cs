namespace DVTManagementSystem.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVTManagementSystem.Models.Context.DVTManagementSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVTManagementSystem.Models.Context.DVTManagementSystemContext context)
        {
            var province = new List<Province>
            {
                new Province {ProvinceId = 1,ProvinceName = "Gauteng"},
                new Province {ProvinceId = 2, ProvinceName = "Limpopo"},
                new Province {ProvinceId = 3, ProvinceName = "Free State"},
                new Province {ProvinceId = 4, ProvinceName = "North West"},
                new Province {ProvinceId = 5, ProvinceName = "Western Cape"},
                new Province {ProvinceId = 6, ProvinceName = "Kwazulu Natal" },
                new Province {ProvinceId = 7, ProvinceName = "Northern Cape" },
                new Province {ProvinceId = 8, ProvinceName = "Eastern Cape" },
                new Province {ProvinceId = 9, ProvinceName = "Mpumalanga" }



            };
            province.ForEach(pro => context.Provinces.AddOrUpdate(pr => new
            {
                pr.ProvinceName
            }, pro));

            var postalcode = new List<PostalCode>
            {
                new PostalCode {PostalCodeId = 1,PostalCodeNumber = "2192"},
                new PostalCode {PostalCodeId = 2,PostalCodeNumber = "2190"},
                new PostalCode {PostalCodeId = 3,PostalCodeNumber = "2091"},
                new PostalCode {PostalCodeId = 3,PostalCodeNumber = "0008"}
            };
            postalcode.ForEach(p => context.PostalCodes.AddOrUpdate(pc => pc.PostalCodeNumber, p));


            var city = new List<City>
            {
                new City {CityId= 1,CityName = "Johannesburg", Province = province[0]},
                new City {CityId=2,CityName = "Tshwane", Province = province[0]}
            };
            city.ForEach(c => context.Cities.AddOrUpdate(ci => new { ci.CityName, ci.ProvinceId }, c));


            var suburb = new List<Suburb>
            {
                new Suburb {SuburbId =1,SuburbName = "ABBOTSFORD", PostalCode= postalcode[1], City = city[1]},
                new Suburb {SuburbId =2, SuburbName = "AEROTON", PostalCode = postalcode[2], City = city[1]},
                new Suburb {SuburbId =3,SuburbName = "ALAN-MANOR", PostalCode = postalcode[2], City = city[1]},
                new Suburb {SuburbId =4,SuburbName = "Midrand", PostalCode= postalcode[3], City= city[1] }

            };
            suburb.ForEach(su => context.Suburbs.AddOrUpdate(s => new { s.SuburbName, s.PostalCodeId, s.CityId }, su));


            var gender = new List<Gender>
            {
                new Gender { GenderId=1,GenderType  = "Male"},
                new Gender {  GenderId=2,GenderType  = "Female" }
            };
            gender.ForEach(ge => context.Genders.AddOrUpdate(g => g.GenderType, ge));

            var userType = new List<UserType>
            {
                new UserType {UserTypeId=1,UserRole = "Staff" },
                new UserType {UserTypeId=2,UserRole = "Administrator" }
            };
            userType.ForEach(usety => context.UserTypes.AddOrUpdate(ut => ut.UserRole, usety));


            var addressType = new List<AddressType>
            {
                new AddressType {AddressTypeId = 1, TypeOfAddress = "Physical Address" },
                new AddressType {AddressTypeId = 2 , TypeOfAddress =" Postal Address"},

            };

            addressType.ForEach(daddty => context.AddressTypes.AddOrUpdate(add => add.TypeOfAddress, daddty));


            var department = new List<Department>
            {
                new Department  {DepartmentId = 1, DepartmentName = "GMIC", DepartmentDescription = "Gauteng Microsoft  "},
                new Department  {DepartmentId = 2 , DepartmentName ="GMOB", DepartmentDescription="Gauteng Mobility"},
                 new Department  {DepartmentId = 3 , DepartmentName ="GQUA", DepartmentDescription="Gauteng Quality Assurence"},

            };

            department.ForEach(d => context.Departments.AddOrUpdate(dep => dep.DepartmentName, d));
            context.SaveChanges();



        }
    }
}
