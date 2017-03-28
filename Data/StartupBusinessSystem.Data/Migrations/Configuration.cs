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

        //protected override void Seed(StartupBusinessDbContext context)
        //{
        //    var hashcode = new PasswordHasher();

        //    context.Users.AddOrUpdate(u => u.UserName,
        //        new User { UserName = "Company 1", CompanyIdentityNumber = "123456789", Address = "Brisbain, Canada", PhoneNumber = "0895661244", Description = "We are company!", Email = "company1@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
        //        new User { UserName = "Company 2", CompanyIdentityNumber = "123456788", Address = "Brisbain, Canada", PhoneNumber = "0895661245", Description = "We are company!", Email = "company2@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
        //        new User { UserName = "Company 3", CompanyIdentityNumber = "123456787", Address = "Brisbain, Canada", PhoneNumber = "0895661246", Description = "We are company!", Email = "company3@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
        //        new User { UserName = "Company 4", CompanyIdentityNumber = "123456787", Address = "Brisbain, Canada", PhoneNumber = "0895661246", Description = "We are company!", Email = "company4@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
        //        new User { UserName = "Company 5", CompanyIdentityNumber = "123456787", Address = "Brisbain, Canada", PhoneNumber = "0895661246", Description = "We are company!", Email = "company5@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
        //        new User { UserName = "Company 6", CompanyIdentityNumber = "123456787", Address = "Brisbain, Canada", PhoneNumber = "0895661246", Description = "We are company!", Email = "company6@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() },
        //        new User { UserName = "Company 7", CompanyIdentityNumber = "123456787", Address = "Brisbain, Canada", PhoneNumber = "0895661246", Description = "We are company!", Email = "company7@abv.bg", PasswordHash = hashcode.HashPassword("123456"), SecurityStamp = Guid.NewGuid().ToString() }
        //        );

        //    context.SaveChanges();

        //    context.Campaigns.AddOrUpdate(c => c.Name,
        //        new Campaign { Name = "Alpha Dogs", Description = "We create Dogs!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = context.Users.SingleOrDefault(u => u.UserName == "Company 1") },
        //        new Campaign { Name = "Alpha Cats", Description = "We create Cats!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = context.Users.SingleOrDefault(u => u.UserName == "Company 2") },
        //        new Campaign { Name = "Alpha Dogs Again", Description = "We create Dogs too!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = context.Users.SingleOrDefault(u => u.UserName == "Company 3") },
        //        new Campaign { Name = "Alpha Cats Again", Description = "We create Cats too!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = context.Users.SingleOrDefault(u => u.UserName == "Company 2") },
        //        new Campaign { Name = "Alpha Dogs 2", Description = "We create Dogs!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = context.Users.SingleOrDefault(u => u.UserName == "Company 1") },
        //        new Campaign { Name = "Alpha Dogs 3", Description = "We create Dogs!", GoalPrice = 40000, TotalShares = 100, CurrentShares = 100, User = context.Users.SingleOrDefault(u => u.UserName == "Company 6") }
        //        );

        //    context.SaveChanges();
        //}
    }
}