using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotTournamentManagement.Migrations
{
    public partial class _26012024832 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "TeamInMatch",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MatchId",
                table: "TeamInMatch",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInMatch_MatchId",
                table: "TeamInMatch",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInMatch_TeamId",
                table: "TeamInMatch",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamInMatch_Match_MatchId",
                table: "TeamInMatch",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamInMatch_Team_TeamId",
                table: "TeamInMatch",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamInMatch_Match_MatchId",
                table: "TeamInMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamInMatch_Team_TeamId",
                table: "TeamInMatch");

            migrationBuilder.DropIndex(
                name: "IX_TeamInMatch_MatchId",
                table: "TeamInMatch");

            migrationBuilder.DropIndex(
                name: "IX_TeamInMatch_TeamId",
                table: "TeamInMatch");

            migrationBuilder.AlterColumn<string>(
                name: "TeamId",
                table: "TeamInMatch",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "MatchId",
                table: "TeamInMatch",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
