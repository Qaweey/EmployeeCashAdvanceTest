using EmployeeCashAdvanceApp.Domain.Shared.Constants;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCashAdvanceApp.Domain.Models
{
    public class AppDbContext : IdentityDbContext
    {

        public DbSet<EmployeeDetails> Employeedetails { get; set; }
        public DbSet<Department> Departments { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT", HODEmail = "soetanqaweey@gmail.com", HODName = "Qaweey Soetan" },
                 new Department { DepartmentId = 2, DepartmentName = "HR", HODEmail = "Bisi@gmail.com", HODName = "Bisi Olatilo" },
                  new Department { DepartmentId = 3, DepartmentName = "Finance", HODEmail = "Ogechi@gmail.com", HODName = "Ogechi Alari" },
                   new Department { DepartmentId = 4, DepartmentName = "Marketing", HODEmail = "Halimat@gmail.com", HODName = "Halimat Oke" }
                );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Constants.DB_CONNECTION);
            }
        }

    }
}
