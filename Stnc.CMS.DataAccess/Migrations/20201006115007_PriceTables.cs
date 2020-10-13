using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class PriceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 278785307);

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "StShoppingCartItem");

            migrationBuilder.AddColumn<int>(
                name: "GunlukUcretId",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HayvaniIrkFiyatID",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeknikDestekId",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamFiyat",
                table: "StShoppingCartItem",
                type: "decimal(6,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DekamProjeDeneyHayvaniIrk",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvaniIrkFiyat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DeneyHayvaniIrkID = table.Column<int>(nullable: false),
                    DeneyHayvaniZaman = table.Column<int>(nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDeneyHayvaniIrkFiyat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvaniIrkFiyat_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GunlukUcretler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BakimTurID = table.Column<int>(nullable: false),
                    DeneyHayvaniTurID = table.Column<int>(nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_GunlukUcretler", x => x.Id));

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1448279227, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 6, 14, 50, 6, 939, DateTimeKind.Local).AddTicks(8959), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 6, 14, 50, 6, 940, DateTimeKind.Local).AddTicks(9976), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkFiyatId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_AppUserId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkFiyatId",
                principalTable: "DekamProjeDeneyHayvaniIrkFiyat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropTable(
                name: "GunlukUcretler");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1448279227);

            migrationBuilder.DropColumn(
                name: "GunlukUcretId",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvaniIrkFiyatID",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "TeknikDestekId",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "ToplamFiyat",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DekamProjeDeneyHayvaniIrk");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "StShoppingCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 278785307, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 5, 16, 54, 47, 734, DateTimeKind.Local).AddTicks(8794), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 5, 16, 54, 47, 735, DateTimeKind.Local).AddTicks(9621), "", (short)0 });
        }
    }
}
