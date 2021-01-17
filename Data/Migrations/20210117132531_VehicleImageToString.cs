using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Data.Migrations
{
    public partial class VehicleImageToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Image_ImageId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsDamaged_Image_ImageId",
                table: "CarsDamaged");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_CarsDamaged_ImageId",
                table: "CarsDamaged");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ImageId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "CarsDamaged");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ImageMini",
                table: "CarsDamaged",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMini",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CarDamagedViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DateAuctionEnd = table.Column<DateTime>(nullable: false),
                    DateAuctionStart = table.Column<DateTime>(nullable: false),
                    ImageMini = table.Column<string>(nullable: true),
                    DamageDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDamagedViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarDamagedViewModel");

            migrationBuilder.DropColumn(
                name: "ImageMini",
                table: "CarsDamaged");

            migrationBuilder.DropColumn(
                name: "ImageMini",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "CarsDamaged",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsDamaged_ImageId",
                table: "CarsDamaged",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImageId",
                table: "Cars",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Image_ImageId",
                table: "Cars",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDamaged_Image_ImageId",
                table: "CarsDamaged",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
