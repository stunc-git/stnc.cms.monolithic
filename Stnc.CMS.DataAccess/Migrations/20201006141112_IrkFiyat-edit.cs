using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class IrkFiyatedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1448279227);

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniZaman",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Isım",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 818212263, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 6, 17, 11, 12, 372, DateTimeKind.Local).AddTicks(4624), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 6, 17, 11, 12, 373, DateTimeKind.Local).AddTicks(5549), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 818212263);

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropColumn(
                name: "Isım",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.AddColumn<int>(
                name: "DeneyHayvaniZaman",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1448279227, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 6, 14, 50, 6, 939, DateTimeKind.Local).AddTicks(8959), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 6, 14, 50, 6, 940, DateTimeKind.Local).AddTicks(9976), "", (short)0 });
        }
    }
}
