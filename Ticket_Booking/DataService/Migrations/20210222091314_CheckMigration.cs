using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class CheckMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_bookings_event_id",
                table: "bookings",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "ix_bookings_user_id",
                table: "bookings",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_events_event_id",
                table: "bookings",
                column: "event_id",
                principalTable: "events",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_bookings_users_user_id",
                table: "bookings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_bookings_events_event_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "fk_bookings_users_user_id",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "ix_bookings_event_id",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "ix_bookings_user_id",
                table: "bookings");
        }
    }
}
