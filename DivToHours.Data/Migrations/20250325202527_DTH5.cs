using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DivToHours.Data.Migrations
{
    public partial class DTH5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Password",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");
        }
    }
}
