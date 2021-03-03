using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class final3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ticketprice",
                table: "events",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ticketprice",
                table: "events");
        }
    }
}
