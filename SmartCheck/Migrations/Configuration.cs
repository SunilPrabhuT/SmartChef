namespace SmartChef.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SmartChef.Auth.Infrastructure;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SmartChef.Auth.Infrastructure.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            var adminUser = new ApplicationUser()
            {
                UserName = "Admin",
                Email = "sunilp@nalashaa.com",
                EmailConfirmed = true,
                FirstName = "Sunil",
                LastName = "Prabhu",
                IschangePasswordRequired = false,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy="System",
                CreatedDate =DateTime.Now.ToString(),
                IsActive =true
            };

            manager.Create(adminUser, "admin123");

            var physicianUser = new ApplicationUser()
            {
                UserName = "Physician",
                Email = "sunilp@nalashaa.com",
                EmailConfirmed = true,
                FirstName = "Thejesh",
                LastName = "Kumar",
                IschangePasswordRequired = false,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "System",
                CreatedDate = DateTime.Now.ToString(),
                IsActive = true
            };
            manager.Create(physicianUser, "phy123");

            var nurseUser = new ApplicationUser()
            {
                UserName = "Nurse",
                Email = "sunilp@nalashaa.com",
                EmailConfirmed = true,
                FirstName = "Akshatha",
                LastName = "Kumari",
                PhoneNumberConfirmed = true,
                IschangePasswordRequired = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0,
                CreatedBy = "System",
                CreatedDate = DateTime.Now.ToString(),
                IsActive = true
            };
            manager.Create(nurseUser, "nur123");
        }
    }
}
