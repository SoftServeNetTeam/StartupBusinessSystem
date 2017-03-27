namespace StartupBusinessSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;

    using StartupBusinessSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<StartupBusinessDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StartupBusinessDbContext context)
        {
            var hashcode = new PasswordHasher();

            var users = new List<User>
            {
                new User { UserName = "Company 1", CompanyIdentityNumber = "123456789", Address = "Brisbain, Canada", PhoneNumber = "0895661244", Description = "We are company!", Email = "company1@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString()},
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var startups = new List<Campaign>
            {
                new Campaign {Name = "Alpha Dogs", Description = "We create Dogs!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = users.Single(u => u.UserName == "Company 1")},
            };

            startups.ForEach(c => context.Campaigns.Add(c));
            context.SaveChanges();
        }
    }
}