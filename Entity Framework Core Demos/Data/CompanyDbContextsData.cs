using Session_01_EFCore.DbContexts;
using Session_01_EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Session_01_EFCore.Data
{
    internal class CompanyDbContextsData
    {
        public static bool DataSeeding(CompanyDbContext db)
        {
            try
            {
                if (db.Employees.Any())
                {
                    if (File.Exists("Files\\employees.json"))
                    {
                        var EmployeeData = File.ReadAllText("Files\\employees.json");
                        var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeeData);
                        if (Employees?.Count > 0)
                        {
                            //foreach (var Employee in Employees)
                            //{
                            //    db.Employees.Add(Employee);
                            //}
                            db.Employees.AddRange(Employees);
                            db.SaveChanges();

                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
