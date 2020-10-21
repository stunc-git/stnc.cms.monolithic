using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class TurFiyatAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1063131734);

            migrationBuilder.AddColumn<decimal>(
                name: "GunlukBakimUcret",
                table: "DekamProjeDeneyHayvaniTur",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OtenaziUcret",
                table: "DekamProjeDeneyHayvaniTur",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 674510660, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 21, 16, 22, 32, 860, DateTimeKind.Local).AddTicks(4050), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 21, 16, 22, 32, 861, DateTimeKind.Local).AddTicks(4809), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 674510660);

            migrationBuilder.DropColumn(
                name: "GunlukBakimUcret",
                table: "DekamProjeDeneyHayvaniTur");

            migrationBuilder.DropColumn(
                name: "OtenaziUcret",
                table: "DekamProjeDeneyHayvaniTur");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1063131734, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 17, 14, 9, 648, DateTimeKind.Local).AddTicks(4177), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 17, 14, 9, 649, DateTimeKind.Local).AddTicks(4997), "", (short)0 });
        }
    }
}
