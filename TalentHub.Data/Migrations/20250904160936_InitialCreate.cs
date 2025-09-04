using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TalentHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Academies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Describtion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Is_Partner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademyTeams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgeGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademyTeams_Academies_AcademyId",
                        column: x => x.AcademyId,
                        principalTable: "Academies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AwayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Venue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HomeScore = table.Column<int>(type: "int", nullable: false),
                    AwayScore = table.Column<int>(type: "int", nullable: false),
                    Kickoff = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_AcademyTeams_AwayId",
                        column: x => x.AwayId,
                        principalTable: "AcademyTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_AcademyTeams_HomeId",
                        column: x => x.HomeId,
                        principalTable: "AcademyTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FavouriteFoot = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    TotalMatches = table.Column<int>(type: "int", nullable: false),
                    TotalGoals = table.Column<int>(type: "int", nullable: false),
                    TotalAssists = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ShirtNumber = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    TotalSaves = table.Column<int>(type: "int", nullable: false),
                    TotalInterceptions = table.Column<int>(type: "int", nullable: false),
                    TotalTackles = table.Column<int>(type: "int", nullable: false),
                    SuccessTackles = table.Column<int>(type: "int", nullable: false),
                    TotalMinutes = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_AcademyTeams_AcademyTeamId",
                        column: x => x.AcademyTeamId,
                        principalTable: "AcademyTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerMatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcademyTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Saves = table.Column<int>(type: "int", nullable: false),
                    Tackles = table.Column<int>(type: "int", nullable: false),
                    SuccessTackles = table.Column<int>(type: "int", nullable: false),
                    Interceptions = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_AcademyTeams_AcademyTeamId",
                        column: x => x.AcademyTeamId,
                        principalTable: "AcademyTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerMatches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSkills_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademyTeams_AcademyId_AgeGroup",
                table: "AcademyTeams",
                columns: new[] { "AcademyId", "AgeGroup" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_AwayId",
                table: "Matches",
                column: "AwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeId_AwayId_Kickoff",
                table: "Matches",
                columns: new[] { "HomeId", "AwayId", "Kickoff" });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_AcademyTeamId",
                table: "PlayerMatches",
                column: "AcademyTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_MatchId_PlayerId",
                table: "PlayerMatches",
                columns: new[] { "MatchId", "PlayerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerMatches_PlayerId",
                table: "PlayerMatches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_AcademyTeamId_ShirtNumber",
                table: "Players",
                columns: new[] { "AcademyTeamId", "ShirtNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSkills_PlayerId_Skill",
                table: "PlayerSkills",
                columns: new[] { "PlayerId", "Skill" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerMatches");

            migrationBuilder.DropTable(
                name: "PlayerSkills");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "AcademyTeams");

            migrationBuilder.DropTable(
                name: "Academies");
        }
    }
}
