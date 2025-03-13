using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Session_01_EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AlterManageDepartmentIDinDepartmentTableAllwwedNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_DepManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeDepartmentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DepManagerId",
                unique: true,
                filter: "[DepManagerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_DepManagerId",
                schema: "Sales",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeDepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepManagerId",
                schema: "Sales",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepManagerId",
                schema: "Sales",
                table: "Departments",
                column: "DepManagerId",
                unique: true);
        }
    }
}
