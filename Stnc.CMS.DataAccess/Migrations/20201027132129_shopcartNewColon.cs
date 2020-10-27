using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class shopcartNewColon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 784958997);

            migrationBuilder.AddColumn<string>(
                name: "DestekTalepTurleri",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 458036770, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 27, 16, 21, 29, 399, DateTimeKind.Local).AddTicks(1835), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 27, 16, 21, 29, 399, DateTimeKind.Local).AddTicks(4572), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 458036770);

            migrationBuilder.DropColumn(
                name: "DestekTalepTurleri",
                table: "StShoppingCartItem");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 784958997, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 26, 13, 28, 28, 198, DateTimeKind.Local).AddTicks(4541), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 26, 13, 28, 28, 199, DateTimeKind.Local).AddTicks(6609), "", (short)0 });
        }
    }
}
