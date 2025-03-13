using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session_01_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Session_01_EFCore.ModelConfigurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            #region Session 02 
            #region Mapping By Fluent Syntax 
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EmpName)
                                           .HasColumnName("EmpName")
                                           //.HasColumnType("nvarchar(100)")==
                                           .HasMaxLength(100)
                                           .IsRequired(false);//allowes null 
            #endregion


            #region Part 06 :- One To One Relationship[Optional]
            builder.HasOne(e => e.ManageDepartment)
                            .WithOne(D => D.Manager)
                            .HasForeignKey<Department>(D => D.DepManagerId)
                            .OnDelete(DeleteBehavior.NoAction);

            #endregion



            #region Part 07:- One To One Relationship[Mandatory]
            builder.OwnsOne(E => E.EmpAddress, Address => Address.WithOwner());



            #endregion



            #region Part 08 :- One To many Relationship[many Mandatory]
            builder.HasOne(E => E.EmployeeDepartment) //Each Must Belong  To One Department
              .WithMany(D => D.Employees) // Each Department be Has Multiple Employees
              .HasForeignKey(E => E.DepartmentId)
              .OnDelete(DeleteBehavior.NoAction);
            #endregion 

            #endregion
        }
    }
}
