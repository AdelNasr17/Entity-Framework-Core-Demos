using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Session_01_EFCore.DbContexts;
using Session_01_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Session_01_EFCore.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace Session_01_EFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Session 01 :
            #region Part 01 : Entity Framework Core Overview

            ///Entity Framework Core
            ///It's an Object-Relational Mapper (ORM) that allows developers to interact with relational databases using .NET objects.
            ///EF Core supports a wide range of database providers such as SQL Server, SQLite, PostgreSQL, MySQL, and more.
            ///Database [Relational] <---> Models [Object]


            ///Model development (Mapping) approaches :            
            ///1. From Code (Models)  Generate DB (Tables , Views)   =====>   Code First *Most Common Used*
            ///2. Generate a model from an existing database         =====>  Database First (Reverse Engineering)
            ///3. Hand-code a model to match the database

            #endregion

            #region Part 02 : Entity Framework core Vs Ado.Net Vs Dapper
            /// They are data access technologies to interacting with databases in .NET each with its own strengths and trade-offs


            #region 1. Entity Framework Core (EF Core)

            ///Key Features :
            ///1. Object-Oriented
            ///2. Code - First or Database-First
            ///3. Automatic Change Tracking
            ///4. Migrations
            ///5. LINQ Support
            ///6. Cross - platform
            ///7. Supports Multiple Databases


            ///Disadvantages :
            ///1. Performance: Does a lot of work behind the scenes(change tracking, etc.), so it can be slower for simple operations
            ///2. Complexity: It abstracts a lot of SQL behind the scenes, which can lead to unexpected behavior in certain situations.



            #endregion

            #region 2. Ado.Net

            ///Key Features :
            ///1.  Low Level framework[Fine - Grained Control]
            ///2.  No Change Tracking
            ///3.  Manual Connection Management
            ///4.  Direct SQL Access

            ///Disadvantages :
            ///1. Requires writing more code for tasks like opening connections, executing commands, and mapping results to objects.
            ///2. Dealing directly with SQL


            #endregion

            #region 3. Dapper
            ///Key Features :
            /// 1. Lightweight
            /// 2. No Change Tracking, Migrations
            /// 3. Fast
            /// 4. Simple API
            /// 5. Simplicity
            /// 6. Flexibility


            ///Disadvantages:
            ///1. Limited Features
            ///2. Dealing directly with SQL(Manual SQL)




            #endregion

            #endregion

            #region Part 03 : DbContext 
            ///DbContext :
            ///Central class in EF Core, it represents a session between your application and the database ,
            ///tracks changes to entities and handles operations like querying and saving data


            /// DbSet:
            ///Represents a collection of entities of a specific type that can be queried or saved each Dbset represents a table in the database .


            ///Migrations :
            ///They allow you to develop your database schema over time as your model changes.


            ///Change Tracker :
            ///EF Core automatically tracks changes to entities so You can detect what data needs to be updated when you call SaveChanges()



            //using CompanyDbContext db = new CompanyDbContext();
            ////some code 


            //// Database Connection [Unmanaged Rosourse ]
            //try
            //{
            //    //Some Code
            //}
            //finally
            //{
            //    db.Dispose();
            //}


            #endregion

            #region Part 04 :  Mapping Ways (By Convention)

            ///Mapping Ways :
            ///EF Core uses several techniques to handle this mapping, Each of these techniques allows developers to configure 
            ///the mapping between C# entities (classes) and database tables (schemas)
            /// 1. By Convention 
            /// 2. Data Annotation
            /// 3. Fluent API


            ///By Convention
            ///EF Core follows a set of default conventions to map classes to database tables, and properties to columns, 
            ///without requiring explicit configuration




            #endregion

            #region Part 05 : Migration Example 01 :
            // using CompanyDbContext db = new CompanyDbContext();
            // //var Employee01 = db.Employees.Where(E=> E.Id ==10).FirstOrDefault();
            //// db.Database.Migrate();//Applay To All pending Migration 

            #endregion
            #endregion


            #region Session 02 : 

            #region part 04 : Query Object Model
            //// Required KeyWord : (C#11 ,.Net7 ) Ensure Not-Null Value In Compilation Time [Not Mapped in Database]
            //// Required Attribute : Validates A Required Value at Run-Time [Mapped in Database ]
            //using CompanyDbContext db = new CompanyDbContext();
            //db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll; // defualt 
            ////db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; // defualt 

            //Employee employee01 = new Employee()
            //{
            //    Name = "Adel",
            //    Age = 22,
            //    EmailAddress = "AdelNasr@gmail.com",
            //    Salary = 40000,
            //    PhoneNumber = "0123456789",

            //    PropertyName = 32

            //};

            //Console.WriteLine(db.Entry<Employee>(employee01).State); //Detached
            //employee01.Name = "Amr";
            //Console.WriteLine(db.Entry<Employee>(employee01).State); //Detached




            #region Insert 
            //// Add New Record in Table employee in database 

            //db.Employees.Add(employee01);
            //db.Set<Employee>().Add(employee01);
            //db.Add(employee01);
            //db.Entry<Employee>(employee01).State = EntityState.Added;


            //Console.WriteLine(db.Entry<Employee>(employee01).State); //Added           
            //db.SaveChanges();
            //Console.WriteLine("==================After SaveChanges============");
            //Console.WriteLine(db.Entry<Employee>(employee01).State); //Unchanged

            #endregion

            #region Select

            //// var Emp01 = db.Employees.Where(e => e.Id == 1).FirstOrDefault();
            //var Emp01 = db.Employees.AsNoTracking().FirstOrDefault(e => e.Id == 2);           
            //if (Emp01 is not null)
            //{
            //    Console.WriteLine(db.Entry<Employee>(Emp01).State); //Detached
            //    Console.WriteLine($" EmpID ={Emp01.Id} , Name = {Emp01.Name}");
            //}


            #endregion


            #region Update

            //var Emp01 = db.Employees.AsNoTracking().FirstOrDefault(e => e.Id == 2);
            //if (Emp01 is not null)
            //{
            //    Console.WriteLine(db.Entry<Employee>(Emp01).State); //Detached
            //    Console.WriteLine($" EmpID ={Emp01.Id} , Name = {Emp01.Name}");
            //}
            //var Emp02 = db.Employees.FirstOrDefault(e => e.Id == 2);
            //Console.WriteLine(db.Entry<Employee>(Emp02).State); //Unchanged

            //Emp02.Salary = 20000;
            //Console.WriteLine("============After Alter Salary  ============= ");
            //Console.WriteLine(db.Entry<Employee>(Emp02).State); //Modified
            //db.SaveChanges();
            //Console.WriteLine("============After SaveChanges ============= ");
            //Console.WriteLine(db.Entry<Employee>(Emp02).State); //Unchanged

            #endregion


            #region Delete          
            //var Emp01 = db.Employees.FirstOrDefault(e => e.Id == 2);
            //Console.WriteLine(db.Entry<Employee>(Emp01).State);//Unchanged

            //db.Employees.Remove(Emp01);
            //db.Remove(Emp01);
            //Console.WriteLine("==============After remove================");
            //Console.WriteLine(db.Entry<Employee>(Emp01).State);//Deleted 
            //db.SaveChanges();
            //Console.WriteLine("===After SaveChanges=======");
            //Console.WriteLine(db.Entry<Employee>(Emp01).State);//Detached
            #endregion
            #endregion

            #endregion


            #region Session 03 : 


            #region Part 03 : Data Seeding
            #region Manual Data Seeding 
            //  using CompanyDbContext db = new CompanyDbContext();

            // Department Dep01 = new Department() { Name = "HR", DateOfCreation = new DateOnly(2024,2,27) };


            //List<Department> departments = new List<Department>()
            //{
            //    new Department()  { Name = "IT", DateOfCreation = new DateOnly(2024,2,27) },
            //    new Department()  { Name = "Development", DateOfCreation = new DateOnly(2024,3,27) },
            //};




            //db.Set<Department>().AddRange(departments);




            // db.SaveChanges();


            #endregion


            #region Dynamic Data Seeding 
            //using CompanyDbContext db = new CompanyDbContext();

            //bool Flag = CompanyDbContextsData.DataSeeding(db);
            //if (Flag == true)
            //{
            //    Console.WriteLine("Done");
            //}
            //else
            //    Console.WriteLine("UnFinshed");

            #endregion


            #endregion

            #region  Loading Related Data  ( Using Navigation Property )                      
            //using CompanyDbContext db = new CompanyDbContext();


            #region Example 01 :
            //var Result = db.Employees.FirstOrDefault(E => E.Id == 14);


            //if (Result is not null)
            //{
            //    Console.WriteLine($"EmpName = {Result.EmpName}\nDepartmentId = {Result.DepartmentId}\n");

            //    var EmpDept= (from D in db.Set<Department>()
            //                 where D.Id == Result.DepartmentId
            //                 select D).FirstOrDefault();
            //    Console.WriteLine($"DepartmentName = {EmpDept?.Name}");
            //} 
            #endregion

            #region Part 04 : Eager Loading [Iclude() , ThenInclude()]
            ////var Result = db.Employees.Include(E => E.EmployeeDepartment).FirstOrDefault(E => E.Id == 14);


            //var Result = db.Employees.Include(E => E.EmployeeDepartment).ThenInclude(D => D.Manager)
            //    .FirstOrDefault(E => E.Id == 14);
            //if (Result is not null)
            //{
            //    Console.WriteLine($"EmpName = {Result.EmpName}\nDepartmentId = {Result.DepartmentId}\n" +
            //    $"DepartmentName = {Result.EmployeeDepartment.Name} \n Manage = {Result.ManageDepartment?.Name} ");
            //}         
            #endregion

            #region Part 05 : Explicit Loading  [Entry().Reference().Load()-Collection().Query ]         

            #region Example01 :
            //var Emp01 = db.Employees.FirstOrDefault(E => E.Id == 14);


            //if (Emp01 is not null)
            //{
            //    Console.WriteLine($"EmpName = {Emp01.EmpName}\nDepartmentId = {Emp01.DepartmentId}\n");

            //    db.Entry(Emp01).Reference(E => E.EmployeeDepartment).Load();
            //    Console.WriteLine($"DepartmentName = {Emp01.EmployeeDepartment.Name} ");
            //} 
            #endregion


            #region Example02 : 

            //var Department01 = db.Set<Department>().FirstOrDefault(D => D.Id == 120);

            //if(Department01 is not null )
            //{
            //    Console.WriteLine(Department01.Name);

            //    db.Entry(Department01).Collection(D => D.Employees).Query().Where(E => E.Id >= 22).Load();

            //    foreach (var Emp in Department01.Employees)
            //    {
            //        Console.WriteLine(Emp.EmpName);
            //    }
            //}
            #endregion

            #endregion

            #region Part 06 : Loading Related Data : Lazy Loading 
            //var Result = db.Employees.FirstOrDefault(E => E.Id == 14);


            //if (Result is not null)
            //{
            //    Console.WriteLine($"EmpName = {Result.EmpName}\nDepartmentId = {Result.DepartmentId}\n");

            //    var EmpDept = (from D in db.Set<Department>()
            //                   where D.Id == Result.DepartmentId
            //                   select D).FirstOrDefault();
            //    Console.WriteLine($"DepartmentName = {EmpDept?.Name}");
            //}




            #endregion
            #endregion

            #region Joins Category
            //using CompanyDbContext db = new CompanyDbContext();

            #region Part 07 : Inner Join 

            #region Department That Employees 



            //// Fluent syntax 
            //var Result = db.Set<Department>().Join(db.Employees
            //                                        , D => D.Id
            //                                        , E => E.DepartmentId
            //                                        , (D, E) => new
            //                                        {
            //                                            EmployeeId = E.Id,
            //                                            EmployeeName= E.EmpName,
            //                                            DepartmentId = D.Id,
            //                                            DepartmentName= D.Name
            //                                        });



            //// Query Syntax 
            //Result = from D in db.Set<Department>()
            //         join E in db.Employees
            //         on D.Id equals E.DepartmentId
            //         select new

            //         {
            //             EmployeeId = E.Id,
            //             EmployeeName = E.EmpName,
            //             DepartmentId = D.Id,
            //             DepartmentName = D.Name
            //         };


            //if (Result != null )
            //{
            //    foreach (var item in Result)
            //        Console.WriteLine(item);

            //}


            #endregion

            #region Department Manager 

            //var Result = db.Employees.Join(db.Set<Department>(),
            //                                E => E.Id,
            //                                D => D.DepManagerId
            //                                , (E, D) => new
            //                                {
            //                                    DepartmentID = D.Id,
            //                                    DepartmentName = D.Name,
            //                                    ManagerId = E.Id,
            //                                    ManagerName = E.EmpName
            //                                });

            //Result = from E in db.Employees
            //         join D in db.Set<Department>()
            //         on E.Id equals D.DepManagerId
            //         select new
            //         {
            //             DepartmentID = D.Id,
            //             DepartmentName = D.Name,
            //             ManagerId = E.Id,
            //             ManagerName = E.EmpName
            //         };

            //if (Result != null)
            //{
            //    foreach (var item in Result)
            //        Console.WriteLine(item);

            //}


            #endregion
            #endregion

            #region Part 08 : Group join - Left Outer Join
            #region Example 01 : 
            //var Result = db.Set<Department>().GroupJoin(db.Employees
            //                                            , D => D.Id
            //                                            , E => E.DepartmentId
            //                                            , (D, E) => new
            //                                            {
            //                                                Department = D,
            //                                                E
            //                                            });


            ////var Result = from D in db.Set<Department>()
            ////         join E in db.Employees
            ////         on D.Id equals E.DepartmentId into Groups
            ////         select new
            ////         {
            ////             Department = D,
            ////             Employees = Groups
            ////         };

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Department id = {item.Department.Id}                Department Name = {item.Department.Name}");
            //    foreach (var emp in item.E)
            //    {

            //        Console.WriteLine($"Employee Name = {emp.EmpName}");

            //    }
            //    Console.WriteLine("==========================================");

            //}

            #endregion

            #region Example 02 :


            //var Result = db.Set<Department>().GroupJoin(db.Employees
            //                                            , D => D.Id
            //                                            , E => E.DepartmentId
            //                                            , (D, E) => new
            //                                            {
            //                                                Department = D,
            //                                                E
            //                                            }).Where(R=> R.E.Count()< 2);


            //var Result = from D in db.Set<Department>()
            //             join E in db.Employees
            //             on D.Id equals E.DepartmentId into Groups
            //             select new
            //             {
            //                 Department = D,
            //                 Employees = Groups
            //             }into Group
            //             where Group.Employees.Count()< 2
            //             select Group;

            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"Department id = {item.Department.Id} \n Department Name = {item.Department.Name}");
            //    foreach (var emp in item.Employees)
            //    {
            //        Console.WriteLine("==========================================");
            //        Console.WriteLine($"Employee Name = {emp.EmpName}");
            //    }

            //}

            #endregion

            #endregion

            #region Part 09 : Left Outer Join
            #region LeftJoin() is Not Working
            //var Result = db.Set<Department>().LeftJoin(db.Employees
            //                                            , D => D.Id
            //                                            , E => E.DepartmentId
            //                                            , (D, E) => new
            //                                            {
            //                                                Department = D,
            //                                                Employee =E
            //                                            });

            //foreach (var item in Result)
            //    Console.WriteLine(item);

            #endregion

            #region Department Left Join Employees
            #region Example 01 :
            ////var Result = db.Set<Department>().GroupJoin(db.Employees
            ////                                            , D => D.Id
            ////                                            , E => E.DepartmentId
            ////                                            , (D, E) => new
            ////                                            {
            ////                                                Department = D,
            ////                                                E
            ////                                            })//.Select(R=> R.Department);
            ////                                              .SelectMany(R => R.E);



            ////var Result = from D in db.Set<Department>()
            ////         join E in db.Employees
            ////         on D.Id equals E.DepartmentId
            ////         into EmployeesGroup
            ////         select new
            ////         {
            ////             Department = D,
            ////             employee = EmployeesGroup
            ////         } into Groups
            ////         select Groups.Department;



            //foreach (var item in Result)
            //{
            //    Console.WriteLine($"{item.Name}");
            //    //foreach (var item02 in item.E)
            //    //{
            //    //    Console.WriteLine(item02.EmpName);
            //    //}
            //    //Console.WriteLine("================================");
            //}

            #endregion

            #region Example 02
            //var Result = db.Set<Department>().GroupJoin(db.Employees
            //                                            , D => D.Id
            //                                            , E => E.DepartmentId
            //                                            , (D, E) => new
            //                                            {
            //                                                Department = D,
            //                                                E
            //                                            })//.Select(R=> R.Department);
            //                                              .SelectMany(R => R.E);

            //Result = from D in db.Set<Department>()
            //         join E in db.Employees
            //         on D.Id equals E.DepartmentId
            //         into EmployeesGroup
            //         select new
            //         {
            //             Department = D,
            //             employee = EmployeesGroup
            //         } into Groups
            //         from Emp in Groups.employee
            //         select Emp;


            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item.EmpName);
            //} 
            #endregion

            #region Example 03 
            // var Result = db.Set<Department>().GroupJoin(db.Employees
            //                                           , D => D.Id
            //                                           , E => E.DepartmentId
            //                                           , (D, E) => new
            //                                           {
            //                                               Department = D,
            //                                               E
            //                                           })//.Select(R=> R.Department);
            //                                             .SelectMany(R => R.E.DefaultIfEmpty(), (R, employee) => new
            //                                             {
            //                                                 DepartmentId = R.Department.Id,
            //                                                 DepartmentName = R.Department.Name,
            //                                                 EmployeeName = employee != null ? employee.EmpName : "No Employee"
            //                                             });


            // Result = from D in db.Set<Department>()
            // join E in db.Employees
            //on D.Id equals E.DepartmentId
            //into EmployeesGroup
            //select new
            //{
            //    Department = D,
            //    employee = EmployeesGroup.DefaultIfEmpty()
            //} into Groups
            //from Emp in Groups.employee
            //select new
            //{
            //    DepartmentId = Groups.Department.Id,
            //    DepartmentName = Groups.Department.Name,
            //    EmployeeName = Emp != null ? Emp.EmpName : "No Employee"
            //};





            // foreach (var item in Result)
            // {
            //     Console.WriteLine(item);
            // } 
            #endregion

            #endregion

            #endregion

            #endregion

            #endregion


            

        }
    }
}



