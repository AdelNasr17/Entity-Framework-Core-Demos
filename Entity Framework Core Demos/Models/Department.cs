using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_01_EFCore.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateOnly? DateOfCreation { get; set; }

        public int? Serial { get; set; }

        #region Session : 02 : Relationahip

        #region Part 06 : OneToOneRelationShip[Optional]
        // //FK Must Be Name As [ManagerId , ManagerEmpId , EmployeeId ,EmployeeEmpId ]
        // //If You Didn't Repersent Forenkey In Model
        //// 
        // public int ManagerId { get; set; }
        [ForeignKey(nameof(Manager))]
        public int? DepManagerId { get; set; }
        // Navigation Property 
        //EF Core : Department Must Has  One Employee To Manage  It [TotalParticpation]
        [InverseProperty(nameof(Employee.ManageDepartment))]
        public virtual Employee Manager { get; set; } = null!;
        #endregion


        #region Part 08 : OneToOneRelationShip[Many Mandatory]
        [InverseProperty(nameof(Employee.EmployeeDepartment))]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();


        #endregion


        #endregion
    }
}
