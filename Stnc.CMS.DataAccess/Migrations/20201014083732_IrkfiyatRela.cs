using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class IrkfiyatRela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 818212263);

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeTeknikDestekTalepTur",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 448522521, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 11, 37, 31, 913, DateTimeKind.Local).AddTicks(960), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 11, 37, 31, 914, DateTimeKind.Local).AddTicks(2236), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniIrkID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniTurID");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniIrkID",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniTurID",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 448522521);

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeTeknikDestekTalepTur",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 818212263, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 6, 17, 11, 12, 372, DateTimeKind.Local).AddTicks(4624), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 6, 17, 11, 12, 373, DateTimeKind.Local).AddTicks(5549), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkFiyatId");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkFiyatId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkFiyatId",
                principalTable: "DekamProjeDeneyHayvaniIrkFiyat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
