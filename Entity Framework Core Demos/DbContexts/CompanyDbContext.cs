using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Session_01_EFCore.Models;
using Session_01_EFCore.ModelConfigurations;
using System.Reflection;

namespace Session_01_EFCore.DbContexts
{
    internal class CompanyDbContext : DbContext
    {
       public CompanyDbContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source = .; Initail Catalog = CpmpanyDb; Integrated Security = True");
            optionsBuilder.UseSqlServer("Server= .; Database = CompanyDb; Trusted_Connection = True; TrustServerCertificate = True").UseLazyLoadingProxies();

        }


        #region Session 02 : Part02 : Fluent APIS
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        //    modelBuilder.Entity<Employee>().Property(e => e.Name)
        //                                   .HasColumnName("EmployeeName")
        //                                   //.HasColumnType("nvarchar(100)")==
        //                                   .HasMaxLength(100)
        //                                   .IsRequired(false);//allowes null

        //    modelBuilder.Entity<Department>(D =>

        //        {

        //            D.ToTable("Departments", "Sales");
        //            D.HasKey(d => d.Id);
        //            D.Property(D => D.Id)
        //            .UseIdentityColumn(10, 10);
        //            //.ValueGeneratedNever();//Disable Identity Constraint

        //            //.HasDefaultValueSql("NewGuid()");

        //            D.Property(D => D.Name)
        //             .HasColumnName("DepartmentName")
        //             .HasColumnType("nvarchar(50)")
        //             .HasMaxLength(20)
        //             .IsRequired(false)
        //             .HasDefaultValue("HR");


        //            D.Property(D => D.DateOfCreation)
        //             .HasAnnotation("DataType", "Date")
        //             //.IsRequired(false)
        //             // .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now))// Default Value = new DateOnly (2025,2,20)
        //             .HasDefaultValueSql("GetDate()");//After Insert [Stay The Same ] -- Can Be Manually Set 
        //                                              // .HasComputedColumnSql("GetDate()"); // Automatically Recalculation --Can Not Be Manually Set 


        //            D.Ignore(D => D.Serial); // Not Mapped 


        //        }); 

        //}
        #endregion


        #region  Fluent APIS - Configuration Classes 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfigurations());
            //modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Automatically Apply All Fluent APIS Configurations From Configuration Classes From Executing Assimbly



            #region Session 02 : Part 06 :- One To One Relationship[Optional]
            //modelBuilder.Entity<Department>()
            //             .HasOne(D => D.Manager)
            //             .WithOne(E => E.ManageDepartment);



            //modelBuilder.Entity<Employee>()
            //             .HasOne(e => e.ManageDepartment)
            //             .WithOne(D => D.Manager)
            //             .HasForeignKey<Department>(D => D.DepManagerId)
            //             .OnDelete(DeleteBehavior.NoAction)
            //             .IsRequired(true);


            //modelBuilder.Entity<Employee>()
            //             .HasOne<Department>()
            //             .WithOne()
            //             .HasForeignKey<Department>(D => D.DepManagerId); 
            #endregion

            #region Session 02 : Part 08 :- One To many Relationship[many Mandatory]

            //modelBuilder.Entity<Employee>()
            //            .HasOne(E => E.EmployeeDepartment) //Each Must Belong  To One Department  
            //            .WithMany(D => D.Employees) // Each Department be Has Multiple Employees
            //            .HasForeignKey(E => E.EmployeeDepartmentId)
            //            .IsRequired()//== Not Null // Make RelationShip  Required 
            //            .OnDelete(DeleteBehavior.NoAction);


            //modelBuilder.Entity<Department>()
            //            .HasMany(D=>D.Employees)
            //            .WithOne(E=> E.EmployeeDepartment)
            //            .HasForeignKey(E => E.EmployeeDepartmentId) 
            //            .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Session 03 : Part 02 :- Many To Many RelationShip

            //modelBuilder.Entity<Student>()
            //            .HasMany(S => S.Courses)
            //            .WithMany(C => C.Students)
            //            .UsingEntity(RT => RT.ToTable("Student_Course"));





            //modelBuilder.Entity<StudentCourses>()
            //            .HasKey(SC => new { SC.StdId, SC.CrsId });



            modelBuilder.Entity<Student>()
                        .HasMany(S => S.StudentCourses)
                        .WithOne(SC => SC.Student)
                        .HasForeignKey(SC => SC.StdId)
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();


            modelBuilder.Entity<Course>()
                        .HasMany(C => C.CourseStudents)
                        .WithOne(SC => SC.Course)
                        .HasForeignKey(SC => SC.CrsId);


            #endregion


        }

        #endregion







        public DbSet<Employee>? Employees { get; set; }
     //   public DbSet<Department>? Departments { get; set; }

     //   public DbSet<Product>? Products { get; set; }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

       

    }
}
