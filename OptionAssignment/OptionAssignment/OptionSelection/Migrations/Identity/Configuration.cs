namespace OptionSelection.Migrations.Identity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OptionSelection.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionSelection.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Identity";
        }

        protected override void Seed(OptionSelection.Models.ApplicationDbContext context)
        {
            this.AddUsersAndRoles();
        }

        private bool AddUsersAndRoles()
        {
            bool success = false;

            var idManager = new IdentityManager();
            success = idManager.CreateRole("Admin");
            if (!success == true) return success;

            success = idManager.CreateRole("Student");
            if (!success == true) return success;

            var admin1 = new ApplicationUser()
            {
                UserName = "Admin1",
            };

            var admin2 = new ApplicationUser()
            {
                UserName = "Admin2",
            };

            var student1 = new ApplicationUser()
            {
                UserName = "Student1",
            };

            success = idManager.CreateUser(admin1, "P@$$w0rd");
            if (!success) return success;

            success = idManager.AddUserToRole(admin1.Id, "Admin");
            if (!success) return success;

            success = idManager.CreateUser(admin2, "P@$$w0rd");
            if (!success) return success;

            success = idManager.AddUserToRole(admin2.Id, "Admin");
            if (!success) return success;

            success = idManager.CreateUser(student1, "P@$$w0rd");
            if (!success) return success;

            success = idManager.AddUserToRole(student1.Id, "Student");
            if (!success) return success;

            return success;
        }
    }
}
