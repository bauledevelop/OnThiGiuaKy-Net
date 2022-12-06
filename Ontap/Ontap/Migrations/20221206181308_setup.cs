using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ontap.Migrations
{
    public partial class setup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoiBong",
                columns: table => new
                {
                    MaDoiBong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoiBong = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoiBong", x => x.MaDoiBong);
                });

            migrationBuilder.CreateTable(
                name: "SanVanDong",
                columns: table => new
                {
                    MaSan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanVanDong", x => x.MaSan);
                });

            migrationBuilder.CreateTable(
                name: "ViTri",
                columns: table => new
                {
                    MaViTri = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenViTri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViTri", x => x.MaViTri);
                });

            migrationBuilder.CreateTable(
                name: "TranDau",
                columns: table => new
                {
                    MaTranDau = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDoiBong1 = table.Column<int>(type: "int", nullable: false),
                    MaDoiBong2 = table.Column<int>(type: "int", nullable: false),
                    MaSan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranDau", x => x.MaTranDau);
                    table.ForeignKey(
                        name: "FK_TranDau_DoiBong_MaDoiBong1",
                        column: x => x.MaDoiBong1,
                        principalTable: "DoiBong",
                        principalColumn: "MaDoiBong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranDau_DoiBong_MaDoiBong2",
                        column: x => x.MaDoiBong2,
                        principalTable: "DoiBong",
                        principalColumn: "MaDoiBong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranDau_SanVanDong_MaSan",
                        column: x => x.MaSan,
                        principalTable: "SanVanDong",
                        principalColumn: "MaSan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CauThu",
                columns: table => new
                {
                    MaCauThu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCauThu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soao = table.Column<int>(type: "int", nullable: false),
                    MaViTri = table.Column<int>(type: "int", nullable: false),
                    MaDoiBong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CauThu", x => x.MaCauThu);
                    table.ForeignKey(
                        name: "FK_CauThu_DoiBong_MaDoiBong",
                        column: x => x.MaDoiBong,
                        principalTable: "DoiBong",
                        principalColumn: "MaDoiBong",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CauThu_ViTri_MaViTri",
                        column: x => x.MaViTri,
                        principalTable: "ViTri",
                        principalColumn: "MaViTri",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CauThu_MaDoiBong",
                table: "CauThu",
                column: "MaDoiBong");

            migrationBuilder.CreateIndex(
                name: "IX_CauThu_MaViTri",
                table: "CauThu",
                column: "MaViTri");

            migrationBuilder.CreateIndex(
                name: "IX_TranDau_MaDoiBong1",
                table: "TranDau",
                column: "MaDoiBong1");

            migrationBuilder.CreateIndex(
                name: "IX_TranDau_MaDoiBong2",
                table: "TranDau",
                column: "MaDoiBong2");

            migrationBuilder.CreateIndex(
                name: "IX_TranDau_MaSan",
                table: "TranDau",
                column: "MaSan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CauThu");

            migrationBuilder.DropTable(
                name: "TranDau");

            migrationBuilder.DropTable(
                name: "ViTri");

            migrationBuilder.DropTable(
                name: "DoiBong");

            migrationBuilder.DropTable(
                name: "SanVanDong");
        }
    }
}
