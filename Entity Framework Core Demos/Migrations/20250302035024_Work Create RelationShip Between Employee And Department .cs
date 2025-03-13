using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session_01_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class WorkCreateRelationShipBetweenEmployeeAndDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeDepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeDepartmentId",
                table: "Employees",
                column: "EmployeeDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DepManagerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_DepManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DepManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_EmployeeDepartmentId",
                table: "Employees",
                column: "EmployeeDepartmentId",
                principalSchema: "Sales",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_DepManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_EmployeeDepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeDepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DepManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "EmpAddress_City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Street",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeDepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
