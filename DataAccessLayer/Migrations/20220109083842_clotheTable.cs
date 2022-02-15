using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class clotheTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClotheId",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClotheId",
                table: "Colors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    ClotheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.ClotheId);
                    table.ForeignKey(
                        name: "FK_Clothes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_ClotheId",
                table: "Sizes",
                column: "ClotheId");

            migrationBuilder.CreateIndex(
                name: "IX_Colors_ClotheId",
                table: "Colors",
                column: "ClotheId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_ProductId",
                table: "Clothes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_SizeId",
                table: "Clothes",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Clothes_ClotheId",
                table: "Colors",
                column: "ClotheId",
                principalTable: "Clothes",
                principalColumn: "ClotheId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_Clothes_ClotheId",
                table: "Sizes",
                column: "ClotheId",
                principalTable: "Clothes",
                principalColumn: "ClotheId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Clothes_ClotheId",
                table: "Colors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_Clothes_ClotheId",
                table: "Sizes");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_ClotheId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Colors_ClotheId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "ClotheId",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "ClotheId",
                table: "Colors");
        }
    }
}
