using HRAutomation.Core.Enums;
using HRAutomation.DataAccess.EntityFramework.Context;
using HRAutomation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace HRAutomation.Presentation.Models.SeedDataFolder
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HRAutomationDbContext>();
            dbContext.Database.Migrate();

            if (dbContext.Admins.Count() == 0)
            {
                dbContext.Admins.Add(new Admin()
                {
                    Id = Guid.NewGuid(),
                    Name = "Mehmet İkbal",
                    Surname = "Dündar",
                    EmailAddress = "mehmetikbaldundar@gmail.com",
                    Status = Status.Active,
                    Password = "1234",
                    CreatedDate = DateTime.Now,
                    Roles = Roles.Admin
                });
            }
            if (dbContext.Employees.Count() == 0)
            {
                dbContext.Employees.Add(new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Ali",
                    Surname = "Veli",
                    EmailAddress = "aliveli@gmail.com",
                    Status = Status.Active,
                    Password="1234",
                    Salary = 14500,
                    IdentityNumber = "95793796684",
                    CreatedDate = DateTime.Now,
                    Roles = Roles.Manager,
                });
            }
            dbContext.SaveChanges();
        }
    }
}
