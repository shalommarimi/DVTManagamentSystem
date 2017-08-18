using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVTManagementSystem.Models.Context
{
    public class DVTManagementSystemContext: DbContext
    {
        public DVTManagementSystemContext() : base("name=DVTManagementSystemContext")
        {

        }

        public DbSet<UserType > UserTypes { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Department > Departments { get; set; }

        public DbSet<UserProfile > UserProfiles { get; set; }

        public DbSet<AddressType> AddressTypes { get; set; }

        public DbSet<Suburb> Suburbs { get; set; }

        public DbSet<PostalCode> PostalCodes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<Address> Addresses { get; set; }
    }
}