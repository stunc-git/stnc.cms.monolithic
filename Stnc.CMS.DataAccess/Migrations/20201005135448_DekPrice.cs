using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DekPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1968405088);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "DekamProjeTeknikDestekTalepTur",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "DekamProjeDeneyHayvaniTur",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrk",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 278785307, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 5, 16, 54, 47, 734, DateTimeKind.Local).AddTicks(8794), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 5, 16, 54, 47, 735, DateTimeKind.Local).AddTicks(9621), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 278785307);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "DekamProjeTeknikDestekTalepTur");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "DekamProjeDeneyHayvaniTur");

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrk");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1968405088, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 9, 16, 15, 40, 15, 511, DateTimeKind.Local).AddTicks(563), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 9, 16, 15, 40, 15, 512, DateTimeKind.Local).AddTicks(1885), "", (short)0 });
        }
    }
}
