using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class chopCartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 674510660);

            migrationBuilder.DropColumn(
                name: "GunlukUcretId",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "TeknikDestekId",
                table: "StShoppingCartItem");

            migrationBuilder.AddColumn<int>(
                name: "BakimDestegiGunSayisi",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestekIstenenHayvanSayisi",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "GunlukBakimUcreti",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HayvanAdi",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HayvanFiyati",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "HayvanIrkAdi",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HayvanIrkFiyatTipAdi",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IstenenHayvanSayisi",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Otenazi",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "OtenaziUcreti",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1590829858, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 26, 11, 39, 34, 789, DateTimeKind.Local).AddTicks(4763), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 26, 11, 39, 34, 790, DateTimeKind.Local).AddTicks(5620), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1590829858);

            migrationBuilder.DropColumn(
                name: "BakimDestegiGunSayisi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "DestekIstenenHayvanSayisi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "GunlukBakimUcreti",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvanAdi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvanFiyati",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvanIrkAdi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvanIrkFiyatTipAdi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "IstenenHayvanSayisi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "Otenazi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "OtenaziUcreti",
                table: "StShoppingCartItem");

            migrationBuilder.AddColumn<int>(
                name: "GunlukUcretId",
                table: "StShoppingCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeknikDestekId",
                table: "StShoppingCartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 674510660, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 21, 16, 22, 32, 860, DateTimeKind.Local).AddTicks(4050), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 21, 16, 22, 32, 861, DateTimeKind.Local).AddTicks(4809), "", (short)0 });
        }
    }
}
