using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Data.Migrations
{
    public partial class AddVehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DateAuctionEnd = table.Column<DateTime>(nullable: false),
                    DateAuctionStart = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarsDamaged",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    DateAuctionEnd = table.Column<DateTime>(nullable: false),
                    DateAuctionStart = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<int>(nullable: true),
                    DamageDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsDamaged", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarsDamaged_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImageId",
                table: "Cars",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_CarsDamaged_ImageId",
                table: "CarsDamaged",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "CarsDamaged");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
