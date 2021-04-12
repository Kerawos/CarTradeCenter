using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Migrations
{
    public partial class VehicleFieldsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Vehicles_VehicleId",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Vehicles_VehicleId",
                table: "Images",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Vehicles_VehicleId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Vehicles");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Vehicles_VehicleId",
                table: "Images",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
