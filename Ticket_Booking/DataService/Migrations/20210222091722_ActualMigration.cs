using Microsoft.EntityFrameworkCore.Migrations;

namespace DataService.Migrations
{
    public partial class ActualMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_events_venue_id",
                table: "events",
                column: "venue_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_event_id",
                table: "comments",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "ix_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_comments_events_event_id",
                table: "comments",
                column: "event_id",
                principalTable: "events",
                principalColumn: "event_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_comments_users_user_id",
                table: "comments",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_events_venues_venue_id",
                table: "events",
                column: "venue_id",
                principalTable: "venues",
                principalColumn: "venue_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_comments_events_event_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_comments_users_user_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "fk_events_venues_venue_id",
                table: "events");

            migrationBuilder.DropIndex(
                name: "ix_events_venue_id",
                table: "events");

            migrationBuilder.DropIndex(
                name: "ix_comments_event_id",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "ix_comments_user_id",
                table: "comments");
        }
    }
}
