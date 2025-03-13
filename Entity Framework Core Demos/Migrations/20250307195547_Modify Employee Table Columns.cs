using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session_01_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEmployeeTableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_EmployeeDepartmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeSalary",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "Employees",
                newName: "EmpName");

            migrationBuilder.RenameColumn(
                name: "EmployeeDepartmentId",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Employees",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmployeeDepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalSchema: "Sales",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "EmployeeSalary");

            migrationBuilder.RenameColumn(
                name: "EmpName",
                table: "Employees",
                newName: "EmployeeName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employees",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "EmployeeDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_EmployeeDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_EmployeeDepartmentId",
                table: "Employees",
                column: "EmployeeDepartmentId",
                principalSchema: "Sales",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
