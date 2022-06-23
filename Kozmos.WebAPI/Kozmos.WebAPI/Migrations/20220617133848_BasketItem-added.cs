using Microsoft.EntityFrameworkCore.Migrations;

namespace Kozmos.WebAPI.Migrations
{
    public partial class BasketItemadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProdId",
                table: "Checkouts");

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CheckoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Checkouts_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "Checkouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CheckoutId",
                table: "BasketItems",
                column: "CheckoutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.AddColumn<string>(
                name: "ProdId",
                table: "Checkouts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
