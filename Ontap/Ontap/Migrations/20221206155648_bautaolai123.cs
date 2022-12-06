using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ontap.Migrations
{
    public partial class bautaolai123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matche_Stadium_IDStadium",
                table: "Matche");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_IDTeam",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_IDTeam",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Matche_IDStadium",
                table: "Matche");

            migrationBuilder.AddColumn<long>(
                name: "TeamID",
                table: "Player",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "StadiumID",
                table: "Matche",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "StadiumID1",
                table: "Matche",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamID",
                table: "Player",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Matche_StadiumID1",
                table: "Matche",
                column: "StadiumID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Matche_Stadium_StadiumID1",
                table: "Matche",
                column: "StadiumID1",
                principalTable: "Stadium",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamID",
                table: "Player",
                column: "TeamID",
                principalTable: "Team",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matche_Stadium_StadiumID1",
                table: "Matche");

            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamID",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamID",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Matche_StadiumID1",
                table: "Matche");

            migrationBuilder.DropColumn(
                name: "TeamID",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "StadiumID",
                table: "Matche");

            migrationBuilder.DropColumn(
                name: "StadiumID1",
                table: "Matche");

            migrationBuilder.CreateIndex(
                name: "IX_Player_IDTeam",
                table: "Player",
                column: "IDTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Matche_IDStadium",
                table: "Matche",
                column: "IDStadium");

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
    }
}
