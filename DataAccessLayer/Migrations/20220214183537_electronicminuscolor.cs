using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class electronicminuscolor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Electronics_Colors_ColorId",
                table: "Electronics");

            migrationBuilder.DropIndex(
                name: "IX_Electronics_ColorId",
                table: "Electronics");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Electronics");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Electronics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Electronics_ColorId",
                table: "Electronics",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Electronics_Colors_ColorId",
                table: "Electronics",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "ColorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
