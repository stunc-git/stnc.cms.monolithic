using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class IrkfiyatRelaEdit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { 1063131734, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 17, 14, 9, 648, DateTimeKind.Local).AddTicks(4177), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 17, 14, 9, 649, DateTimeKind.Local).AddTicks(4997), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1063131734);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1467227976, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 16, 52, 10, 194, DateTimeKind.Local).AddTicks(3443), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 16, 52, 10, 195, DateTimeKind.Local).AddTicks(4222), "", (short)0 });
        }
    }
}
