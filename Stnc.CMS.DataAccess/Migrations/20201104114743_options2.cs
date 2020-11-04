using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class options2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1449820355);

            migrationBuilder.AlterColumn<string>(
                name: "OptionName",
                table: "Options",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 299449392, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 4, 14, 47, 42, 976, DateTimeKind.Local).AddTicks(9790), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 4, 14, 47, 42, 977, DateTimeKind.Local).AddTicks(2743), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 299449392);

            migrationBuilder.AlterColumn<string>(
                name: "OptionName",
                table: "Options",
                type: "ntext",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1449820355, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 4, 13, 58, 22, 411, DateTimeKind.Local).AddTicks(5860), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 4, 13, 58, 22, 411, DateTimeKind.Local).AddTicks(8781), "", (short)0 });
        }
    }
}
