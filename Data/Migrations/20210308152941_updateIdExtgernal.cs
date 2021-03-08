using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Data.Migrations
{
    public partial class updateIdExtgernal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdExternal",
                table: "CarsDamaged",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdExternal",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdExternal",
                table: "CarDamagedViewModel",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdExternal",
                table: "CarsDamaged");

            migrationBuilder.DropColumn(
                name: "IdExternal",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IdExternal",
                table: "CarDamagedViewModel");
        }
    }
}
