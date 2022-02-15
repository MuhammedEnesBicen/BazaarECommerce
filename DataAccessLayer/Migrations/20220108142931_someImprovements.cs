using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class someImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "Electronics",
                columns: table => new
                {
                    ElectronicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    DisplayCard = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    ScreenSize = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Webcam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electronics", x => x.ElectronicId);
                    table.ForeignKey(
                        name: "FK_Electronics_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Electronics_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Electronics_ColorId",
                table: "Electronics",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Electronics_ProductId",
                table: "Electronics",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Electronics");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    DisplayCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memory = table.Column<int>(type: "int", nullable: false),
                    MemoryType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    ScreenSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Webcam = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.ComputerId);
                    table.ForeignKey(
                        name: "FK_Computers_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Computers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ColorId",
                table: "Computers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_ProductId",
                table: "Computers",
                column: "ProductId");
        }
    }
}
