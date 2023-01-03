using HRAutomation.DataAccess.EntityFramework.Mapping;
using HRAutomation.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRAutomation.DataAccess.EntityFramework.Context
{
    public class HRAutomationDbContext : DbContext
    {
        public HRAutomationDbContext(DbContextOptions<HRAutomationDbContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminMapping())
                .ApplyConfiguration(new EmployeeMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
