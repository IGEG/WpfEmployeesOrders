using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfEmployeesOrders.Migrations
{
    /// <inheritdoc />
    public partial class pkemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Divisions_DivisionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DivisionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Divisions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_EmployeeId",
                table: "Divisions",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Divisions_Employees_EmployeeId",
                table: "Divisions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Divisions_Employees_EmployeeId",
                table: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Divisions_EmployeeId",
                table: "Divisions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Divisions");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "Employees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DivisionId",
                table: "Employees",
                column: "DivisionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Divisions_DivisionId",
                table: "Employees",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
