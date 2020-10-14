using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class IrkfiyatRelaEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1847719039);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1467227976, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 16, 52, 10, 194, DateTimeKind.Local).AddTicks(3443), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 16, 52, 10, 195, DateTimeKind.Local).AddTicks(4222), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1467227976);

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1847719039, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 16, 5, 48, 956, DateTimeKind.Local).AddTicks(7031), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 16, 5, 48, 957, DateTimeKind.Local).AddTicks(9891), "", (short)0 });
        }
    }
}
