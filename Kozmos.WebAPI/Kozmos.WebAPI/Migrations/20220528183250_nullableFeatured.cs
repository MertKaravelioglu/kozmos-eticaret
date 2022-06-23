using Microsoft.EntityFrameworkCore.Migrations;

namespace Kozmos.WebAPI.Migrations
{
    public partial class nullableFeatured : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isFeatured",
                table: "Products",
                newName: "IsFeatured");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFeatured",
                table: "Products",
                newName: "isFeatured");

            migrationBuilder.AlterColumn<bool>(
                name: "isFeatured",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
