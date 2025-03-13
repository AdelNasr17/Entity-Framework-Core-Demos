using Microsoft.EntityFrameworkCore;
using Part_02_Inhertiance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_02_Inhertiance.DbContexts
{
    internal class MyCompany02DbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= .; Database = MyCompany02; Trusted_Connection = True; TrustServerCertificate = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Table-per-Hierarchy (TPH)

            //modelBuilder.Entity<FullTimeEmployee>()
            //              .HasBaseType<Employee>();

            //modelBuilder.Entity<partTimeEmployee>()
            //            .HasBaseType<Employee>();


            //modelBuilder.Entity<Employee>()
            //            .HasDiscriminator<string>("EmployeeType")
            //            .HasValue<FullTimeEmployee>("FTE")
            //            .HasValue<partTimeEmployee>("PTE");
            #endregion

            #region 3. Table-per-Type (TPT)
            //modelBuilder.Entity<FullTimeEmployee>().ToTable("FullTimeEmployee");
            //modelBuilder.Entity<partTimeEmployee>().ToTable("PartTimeEmployee");

            #endregion
        }

        //public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        //public DbSet<partTimeEmployee> partTimeEmployees { get; set; }


        //DbSet<Employee> Employees { get; set; }
    }
}
