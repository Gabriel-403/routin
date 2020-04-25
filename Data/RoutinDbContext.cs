using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using routin.entities;

namespace routin.Data
{
    public class RoutinDbContext : DbContext
    {
        public RoutinDbContext(DbContextOptions<RoutinDbContext> options) : base(options) { }

        public DbSet<Company> Companies{get;set;}
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { modelBuilder.Entity<Company>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(x => x.Introduction).IsRequired().HasMaxLength(500);
            modelBuilder.Entity<Employee>().Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>().Property(x => x.FistName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().HasOne(x => x.Company)
                .WithMany(x => x.Employees).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Company>().HasData(new Company
            {

                Id = Guid.Parse("bbdee09c-089d-4e30-be42-bbdee09a"),
                Name = "Micorsoft",
                Introduction = "great compancy"
            },
            new Company
            {

                Id = Guid.Parse("bbdee09c-089d-4e30-be42-bbdee09b"),
                Name = "google",
                Introduction = "no envy compancy"
            },
            new Company
            {

                Id = Guid.Parse("bbdee09c-089d-4e30-be42-bbdee09c"),
                Name = "aili",
                Introduction = "Fubao"
            });

        }
    }
    
    

}
