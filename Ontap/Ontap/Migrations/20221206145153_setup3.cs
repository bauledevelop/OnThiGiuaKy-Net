using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ontap.Migrations
{
    public partial class setup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Stadium_IDStadium",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_IDTeam",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Matche");

            migrationBuilder.RenameIndex(
                name: "IX_Players_IDTeam",
                table: "Player",
                newName: "IX_Player_IDTeam");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_IDStadium",
                table: "Matche",
                newName: "IX_Matche_IDStadium");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matche",
                table: "Matche",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matche_Stadium_IDStadium",
                table: "Matche",
                column: "IDStadium",
                principalTable: "Stadium",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_IDTeam",
                table: "Player",
                column: "IDTeam",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matche_Stadium_IDStadium",
                table: "Matche");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_IDTeam",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matche",
                table: "Matche");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.RenameTable(
                name: "Matche",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Player_IDTeam",
                table: "Players",
                newName: "IX_Players_IDTeam");

            migrationBuilder.RenameIndex(
                name: "IX_Matche_IDStadium",
                table: "Matches",
                newName: "IX_Matches_IDStadium");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Stadium_IDStadium",
                table: "Matches",
                column: "IDStadium",
                principalTable: "Stadium",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_IDTeam",
                table: "Players",
                column: "IDTeam",
                principalTable: "Teams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
