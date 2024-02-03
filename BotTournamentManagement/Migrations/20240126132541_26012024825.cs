using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BotTournamentManagement.Migrations
{
    public partial class _26012024825 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamActivity_Match_MatchId",
                table: "TeamActivity");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamActivity_Team_TeamId",
                table: "TeamActivity");

            migrationBuilder.DropTable(
                name: "TeamResult");

            migrationBuilder.DropIndex(
                name: "IX_TeamActivity_MatchId",
                table: "TeamActivity");

            migrationBuilder.DropColumn(
                name: "MatchId",
                table: "TeamActivity");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamActivity",
                newName: "TeamInMatchId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamActivity_TeamId",
                table: "TeamActivity",
                newName: "IX_TeamActivity_TeamInMatchId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "TeamActivity",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "TeamActivity",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.CreateTable(
                name: "TeamInMatch",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: true),
                    isWinner = table.Column<bool>(type: "bit", nullable: true),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInMatch", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TeamActivity_TeamInMatch_TeamInMatchId",
                table: "TeamActivity",
                column: "TeamInMatchId",
                principalTable: "TeamInMatch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamActivity_TeamInMatch_TeamInMatchId",
                table: "TeamActivity");

            migrationBuilder.DropTable(
                name: "TeamInMatch");

            migrationBuilder.RenameColumn(
                name: "TeamInMatchId",
                table: "TeamActivity",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamActivity_TeamInMatchId",
                table: "TeamActivity",
                newName: "IX_TeamActivity_TeamId");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "StartTime",
                table: "TeamActivity",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "EndTime",
                table: "TeamActivity",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MatchId",
                table: "TeamActivity",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TeamResult",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeamId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DeletedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    LastUpdatedTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    isWinner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamResult_Match_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamResult_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamActivity_MatchId",
                table: "TeamActivity",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamResult_MatchId",
                table: "TeamResult",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamResult_TeamId",
                table: "TeamResult",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamActivity_Match_MatchId",
                table: "TeamActivity",
                column: "MatchId",
                principalTable: "Match",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamActivity_Team_TeamId",
                table: "TeamActivity",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
