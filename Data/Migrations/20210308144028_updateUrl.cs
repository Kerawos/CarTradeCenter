using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Data.Migrations
{
    public partial class updateUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "CarsDamaged",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "CarDamagedViewModel",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "CarsDamaged");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "CarDamagedViewModel");
        }
    }
}
