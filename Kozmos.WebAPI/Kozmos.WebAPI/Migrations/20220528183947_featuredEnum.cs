using Microsoft.EntityFrameworkCore.Migrations;

namespace Kozmos.WebAPI.Migrations
{
    public partial class featuredEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsFeatured",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsFeatured",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
