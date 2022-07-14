using Microsoft.EntityFrameworkCore.Migrations;

namespace WebVendasMVC.Migrations
{
    public partial class DepartmentForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Department_DepartmentId",
                table: "Vendedores");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Vendedores",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Department_DepartmentId",
                table: "Vendedores",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedores_Department_DepartmentId",
                table: "Vendedores");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Vendedores",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedores_Department_DepartmentId",
                table: "Vendedores",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
