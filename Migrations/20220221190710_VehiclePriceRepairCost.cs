using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Migrations
{
    public partial class VehiclePriceRepairCost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PriceBrandNew",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceBrandNew",
                table: "Vehicles");
        }
    }
}
