using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore ;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Session_01_EFCore.Models
{

        #region Session 01 : Mapping [By Convention - Data Annontaion ] 
    #region By Convention 
    //// Model  : Poco Class Plain Old CLR Object - Domain Entity 
    //internal class Employee
    //{
    //    // Public  Numeric Property Named As [Id ,EntityId] 
    //    // Automatically Assumed To Be Primary Key Of Table 
    //    public int Id { get; set; } // PK With Identity Constraint [1,1]

    //    public string? Name { get; set; }
    //    //Nullable  Referance Type
    //    // String? Is Mapped To nvarchar(Max) Allow Null ;
    //    public decimal Salary { get; set; }
    //    // Value Type 
    //    // Not Allow Null 
    //    // Decimal Is Mapped To deciaml(18,2)Not Allow null 

    //    public int Age { get; set; }
    //    // Value Type
    //    // int Is Mapped To int Not  null 



    //} 
    #endregion



    #region Data Annontaion
    [Table("Employees")]//Specifies the name of the database table to which the entity is mapped
    public class Employee
    {
        [Key] //Marks a property as the primary key for the entity
        public int Id { get; set; }



        [Column("EmpName", TypeName = "nvarchar(50)")]
        //Maps a property to a specific column in the database specifying  column types, lengths, and other properties 
        [Required]
        //Marks a property as required (the property as nullable for reference types and non-nullable for value types If this annotation is not provided)
        [MaxLength(50, ErrorMessage = "Name Of Employee Must Be Less Than 51 Char")]
        [MinLength(3, ErrorMessage = "Name Of Employee Must Be More Than 2 Char")]
        //Used to specify the maximum and minimum length of string properties
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Name Of Employee Must Be More Than 2 Char And Less Than 51 Char")]
        public string? EmpName { get; set; }





        [Column("Salary", TypeName = "decimal(10,2)")]
        public decimal? Salary { get; set; }




        [Range(maximum: 40, minimum: 25)]
        //  [AllowedValues(25,27,28,30)]
        //[DeniedValues(20,22,23)]
        //[DefaultValue(25)]
        public int? Age { get; set; }




        [Phone]//Check PhoneNumber 
        [DataType(DataType.PhoneNumber)]//To Display Value As [PhoneNumber ,Password ,EmailAddress,.....]
        public string? PhoneNumber { get; set; }




        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }




        [NotMapped]//Specifies that a property should not be mapped to a database column.
        public int PropertyName { get; set; }





        #endregion

        #endregion

        #region Session 02 :  RelationShip
        #region Part 06 : OneToOneRelationShip[Optional]
        //Navigation Property [One]
        // EF Core : Employee May Manage One Department [Partial Particpation ]
        [InverseProperty(nameof(Department.Manager))]
        public virtual  Department? ManageDepartment { get; set; }
        #endregion


        #region Part 07 : OneToOneRelationShip[Mandatory]

        public Address EmpAddress { get; set; }

        #endregion


        #region Part 08 : OneToOneRelationShip[Many Mandatory]

        [ForeignKey(nameof(EmployeeDepartment))]

        public int? DepartmentId { get; set; }
        //Navigation Property[One]
        [InverseProperty(nameof(Department.Employees))]
        public virtual  Department EmployeeDepartment { get; set; } = null!;

        #endregion 

        #endregion

    }

}
