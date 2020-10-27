using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class HyavansayisiTalepsureDestekSure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_TeknikDestekSuresiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_TeknikHayvanSayisiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvanSayisi");

            migrationBuilder.DropTable(
                name: "DekamProjeTeknikDestekTalepSure");

            migrationBuilder.DropTable(
                name: "GunlukUcretler");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_TeknikDestekSuresiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_TeknikHayvanSayisiID",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1590829858);

            migrationBuilder.DropColumn(
                name: "TeknikDestekSuresiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "TeknikHayvanSayisiID",
                table: "DekamProjeTakip");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 784958997, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 26, 13, 28, 28, 198, DateTimeKind.Local).AddTicks(4541), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 26, 13, 28, 28, 199, DateTimeKind.Local).AddTicks(6609), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 784958997);

            migrationBuilder.AddColumn<int>(
                name: "TeknikDestekSuresiID",
                table: "DekamProjeTakip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeknikHayvanSayisiID",
                table: "DekamProjeTakip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvanSayisi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDeneyHayvanSayisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvanSayisi_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeTeknikDestekTalepSure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeTeknikDestekTalepSure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeTeknikDestekTalepSure_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "GunlukUcretler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakimTurID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeneyHayvaniTurID = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GunlukUcretler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1590829858, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 26, 11, 39, 34, 789, DateTimeKind.Local).AddTicks(4763), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 26, 11, 39, 34, 790, DateTimeKind.Local).AddTicks(5620), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_TeknikDestekSuresiID",
                table: "DekamProjeTakip",
                column: "TeknikDestekSuresiID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_TeknikHayvanSayisiID",
                table: "DekamProjeTakip",
                column: "TeknikHayvanSayisiID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvanSayisi_AppUserId",
                table: "DekamProjeDeneyHayvanSayisi",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTeknikDestekTalepSure_AppUserId",
                table: "DekamProjeTeknikDestekTalepSure",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_TeknikDestekSuresiID",
                table: "DekamProjeTakip",
                column: "TeknikDestekSuresiID",
                principalTable: "DekamProjeTeknikDestekTalepSure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_TeknikHayvanSayisiID",
                table: "DekamProjeTakip",
                column: "TeknikHayvanSayisiID",
                principalTable: "DekamProjeDeneyHayvanSayisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
