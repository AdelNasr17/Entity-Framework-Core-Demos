using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session_01_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_01_EFCore.ModelConfigurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            #region Fluent APIS - Configuration Classes

            builder.ToTable("Departments", "Sales");
            builder.HasKey(d => d.Id);
            builder.Property(D => D.Id)
            .UseIdentityColumn(10, 10);
            //.ValueGeneratedNever();//Disable Identity Constraint

            //.HasDefaultValueSql("NewGuid()");

            builder.Property(D => D.Name)
             .HasColumnName("DepartmentName")
             .HasColumnType("nvarchar(50)")
             .HasMaxLength(20)

             .IsRequired(false)
             .HasDefaultValue("HR");



            builder.Property(D => D.DateOfCreation)
                     .HasAnnotation("DataType", "Date")
                     //.IsRequired(false)
                     // .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now))// Default Value = new DateOnly (2025,2,20)
                     .HasDefaultValueSql("GetDate()");//After Insert [Stay The Same ] -- Can Be Manually Set 
                     // .HasComputedColumnSql("GetDate()"); // Automatically Recalculation --Can Not Be Manually Set 


            builder.Ignore(D => D.Serial); // Not Mapped  
            #endregion



        }
    }
}
