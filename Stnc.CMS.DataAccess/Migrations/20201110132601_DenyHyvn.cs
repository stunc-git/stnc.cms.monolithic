using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DenyHyvn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 186, DateTimeKind.Local).AddTicks(4075), new DateTime(2020, 11, 10, 16, 26, 1, 186, DateTimeKind.Local).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 190, DateTimeKind.Local).AddTicks(9115), new DateTime(2020, 11, 10, 16, 26, 1, 190, DateTimeKind.Local).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 185, DateTimeKind.Local).AddTicks(2410), new DateTime(2020, 11, 10, 16, 26, 1, 185, DateTimeKind.Local).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 187, DateTimeKind.Local).AddTicks(3235), new DateTime(2020, 11, 10, 16, 26, 1, 187, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1146002850, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 10, 16, 26, 1, 179, DateTimeKind.Local).AddTicks(7010), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 10, 16, 26, 1, 179, DateTimeKind.Local).AddTicks(9866), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1146002850);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                type: "int",
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
    }
}
