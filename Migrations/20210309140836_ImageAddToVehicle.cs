using Microsoft.EntityFrameworkCore.Migrations;

namespace CarTradeCenter.Migrations
{
    public partial class ImageAddToVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMini",
                table: "CarsDamaged");

            migrationBuilder.DropColumn(
                name: "ImageMini",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "ImageMiniId",
                table: "CarsDamaged",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageMiniId",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: false),
                    CarDamagedId = table.Column<int>(nullable: true),
                    CarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_CarsDamaged_CarDamagedId",
                        column: x => x.CarDamagedId,
                        principalTable: "CarsDamaged",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsDamaged_ImageMiniId",
                table: "CarsDamaged",
                column: "ImageMiniId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ImageMiniId",
                table: "Cars",
                column: "ImageMiniId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CarDamagedId",
                table: "Image",
                column: "CarDamagedId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CarId",
                table: "Image",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Image_ImageMiniId",
                table: "Cars",
                column: "ImageMiniId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarsDamaged_Image_ImageMiniId",
                table: "CarsDamaged",
                column: "ImageMiniId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Image_ImageMiniId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_CarsDamaged_Image_ImageMiniId",
                table: "CarsDamaged");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_CarsDamaged_ImageMiniId",
                table: "CarsDamaged");

            migrationBuilder.DropIndex(
                name: "IX_Cars_ImageMiniId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "ImageMiniId",
                table: "CarsDamaged");

            migrationBuilder.DropColumn(
                name: "ImageMiniId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "ImageMini",
                table: "CarsDamaged",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMini",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
