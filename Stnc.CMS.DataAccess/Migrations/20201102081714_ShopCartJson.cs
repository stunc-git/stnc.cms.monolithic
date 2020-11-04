using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class ShopCartJson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 773705585);

            migrationBuilder.AddColumn<string>(
                name: "DestekTalepTurleriJson",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1264878060, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 2, 11, 17, 14, 156, DateTimeKind.Local).AddTicks(7677), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 2, 11, 17, 14, 157, DateTimeKind.Local).AddTicks(458), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1264878060);

            migrationBuilder.DropColumn(
                name: "DestekTalepTurleriJson",
                table: "StShoppingCartItem");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 773705585, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 27, 16, 55, 32, 269, DateTimeKind.Local).AddTicks(7896), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 27, 16, 55, 32, 270, DateTimeKind.Local).AddTicks(741), "", (short)0 });
        }
    }
}
