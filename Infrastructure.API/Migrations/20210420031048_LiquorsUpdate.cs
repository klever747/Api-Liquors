using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.API.Migrations
{
    public partial class LiquorsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CantProduct",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CantProduct",
                table: "Orders");
        }
    }
}
