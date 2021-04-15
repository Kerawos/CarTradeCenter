using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Migrations
{
    public partial class vehicleNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageDescription",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoBasic",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoDamage",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoExtra",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InfoUsableParts",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InfoBasic",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "InfoDamage",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "InfoExtra",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "InfoUsableParts",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "DamageDescription",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
