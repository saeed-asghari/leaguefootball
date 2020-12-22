using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace leaguefootball.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    LeagueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FoundingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.LeagueID);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeagueID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FoundingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Team_League_LeagueID",
                        column: x => x.LeagueID,
                        principalTable: "League",
                        principalColumn: "LeagueID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Player_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "LeagueID", "FoundingDate", "Name" },
                values: new object[] { 1, new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "لیگ برتر" });

            migrationBuilder.InsertData(
                table: "League",
                columns: new[] { "LeagueID", "FoundingDate", "Name" },
                values: new object[] { 2, new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "لیگ آزادگان" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "FoundingDate", "LeagueID", "Name" },
                values: new object[] { 1, new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "پرسپولیس" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "FoundingDate", "LeagueID", "Name" },
                values: new object[] { 2, new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "استقلال" });

            migrationBuilder.InsertData(
                table: "Team",
                columns: new[] { "TeamId", "FoundingDate", "LeagueID", "Name" },
                values: new object[] { 3, new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "تیم دسته دو" });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "DateOfBirth", "FirstName", "LastName", "TeamId" },
                values: new object[] { 1, new DateTime(1980, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "سیدجلال ", "حسینی", 1 });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "DateOfBirth", "FirstName", "LastName", "TeamId" },
                values: new object[] { 2, new DateTime(1980, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "وریا ", "غفوری", 2 });

            migrationBuilder.InsertData(
                table: "Player",
                columns: new[] { "PlayerId", "DateOfBirth", "FirstName", "LastName", "TeamId" },
                values: new object[] { 3, new DateTime(1980, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "علی ", "محمدی", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LeagueID",
                table: "Team",
                column: "LeagueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "League");
        }
    }
}
