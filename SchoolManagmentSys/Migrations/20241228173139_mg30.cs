using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSys.Migrations
{
    /// <inheritdoc />
    public partial class mg30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Departments");

            migrationBuilder.AlterColumn<string>(
                name: "Pname",
                table: "Professors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Pname",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Budget",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
