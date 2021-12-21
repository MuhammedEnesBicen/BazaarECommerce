using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddressTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cvc2",
                table: "Cards",
                newName: "SecurityCode");

            migrationBuilder.AddColumn<int>(
                name: "MonthlySalesCurrent",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonthlySalesPrevious",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BankOrCredit",
                table: "Cards",
                type: "nvarchar(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOnCard",
                table: "Cards",
                type: "nvarchar(75)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropColumn(
                name: "MonthlySalesCurrent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MonthlySalesPrevious",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BankOrCredit",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "NameOnCard",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "SecurityCode",
                table: "Cards",
                newName: "Cvc2");
        }
    }
}
