using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class optionsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 506630051);

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "Autoload", "CreatedAt", "DefaultValue", "DeletedAt", "OptionName", "OptionValue", "UpdatedAt" },
                values: new object[] { 1L, null, null, null, null, "front-menu", "", null });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1470176986, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 4, 23, 25, 59, 759, DateTimeKind.Local).AddTicks(7565), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 4, 23, 25, 59, 760, DateTimeKind.Local).AddTicks(6608), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1470176986);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 506630051, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 4, 23, 9, 28, 549, DateTimeKind.Local).AddTicks(3998), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 4, 23, 9, 28, 550, DateTimeKind.Local).AddTicks(2767), "", (short)0 });
        }
    }
}
