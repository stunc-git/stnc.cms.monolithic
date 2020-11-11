using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class CartAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DeneyHayvaniIrkID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_TeknikDestekTuruID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniIrkID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_TeknikDestekTuruID",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 299583810);

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniAgirligi",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniCinsiyet",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniIrkID",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniYasi",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "TeknikDestekTuruID",
                table: "DekamProjeTakip");

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 23, 11, 367, DateTimeKind.Local).AddTicks(1726), new DateTime(2020, 11, 10, 16, 23, 11, 367, DateTimeKind.Local).AddTicks(1740) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 23, 11, 371, DateTimeKind.Local).AddTicks(7428), new DateTime(2020, 11, 10, 16, 23, 11, 371, DateTimeKind.Local).AddTicks(7440) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 23, 11, 366, DateTimeKind.Local).AddTicks(1589), new DateTime(2020, 11, 10, 16, 23, 11, 366, DateTimeKind.Local).AddTicks(1614) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 23, 11, 368, DateTimeKind.Local).AddTicks(1117), new DateTime(2020, 11, 10, 16, 23, 11, 368, DateTimeKind.Local).AddTicks(1130) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 145301609, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 10, 16, 23, 11, 360, DateTimeKind.Local).AddTicks(4402), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 10, 16, 23, 11, 360, DateTimeKind.Local).AddTicks(7237), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkId");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkId",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 145301609);

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip");

            migrationBuilder.AddColumn<short>(
                name: "DeneyHayvaniAgirligi",
                table: "DekamProjeTakip",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "DeneyHayvaniCinsiyet",
                table: "DekamProjeTakip",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniIrkID",
                table: "DekamProjeTakip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "DeneyHayvaniYasi",
                table: "DekamProjeTakip",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<int>(
                name: "TeknikDestekTuruID",
                table: "DekamProjeTakip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(331), new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 578, DateTimeKind.Local).AddTicks(6013), new DateTime(2020, 11, 10, 16, 5, 13, 578, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 573, DateTimeKind.Local).AddTicks(406), new DateTime(2020, 11, 10, 16, 5, 13, 573, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(9585), new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 299583810, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 10, 16, 5, 13, 565, DateTimeKind.Local).AddTicks(1779), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 10, 16, 5, 13, 565, DateTimeKind.Local).AddTicks(5486), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniIrkID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniIrkID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_TeknikDestekTuruID",
                table: "DekamProjeTakip",
                column: "TeknikDestekTuruID");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DeneyHayvaniIrkID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniIrkID",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_TeknikDestekTuruID",
                table: "DekamProjeTakip",
                column: "TeknikDestekTuruID",
                principalTable: "DekamProjeTeknikDestekTalepTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
