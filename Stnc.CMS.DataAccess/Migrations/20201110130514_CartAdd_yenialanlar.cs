using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class CartAdd_yenialanlar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 919525412);

            migrationBuilder.AlterColumn<decimal>(
                name: "OtenaziToplamUcreti",
                table: "StShoppingCartItem",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "DeneyHayvaniCinsiyet",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "HayvanAgirlik",
                table: "StShoppingCartItem",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "HayvanYas",
                table: "StShoppingCartItem",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(331), new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(344) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 578, DateTimeKind.Local).AddTicks(6013), new DateTime(2020, 11, 10, 16, 5, 13, 578, DateTimeKind.Local).AddTicks(6025) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 573, DateTimeKind.Local).AddTicks(406), new DateTime(2020, 11, 10, 16, 5, 13, 573, DateTimeKind.Local).AddTicks(436) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(9585), new DateTime(2020, 11, 10, 16, 5, 13, 574, DateTimeKind.Local).AddTicks(9598) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 299583810, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 10, 16, 5, 13, 565, DateTimeKind.Local).AddTicks(1779), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 10, 16, 5, 13, 565, DateTimeKind.Local).AddTicks(5486), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 299583810);

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniCinsiyet",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvanAgirlik",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "HayvanYas",
                table: "StShoppingCartItem");

            migrationBuilder.AlterColumn<decimal>(
                name: "OtenaziToplamUcreti",
                table: "StShoppingCartItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 14, 49, 17, 355, DateTimeKind.Local).AddTicks(2998), new DateTime(2020, 11, 10, 14, 49, 17, 355, DateTimeKind.Local).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 14, 49, 17, 359, DateTimeKind.Local).AddTicks(6851), new DateTime(2020, 11, 10, 14, 49, 17, 359, DateTimeKind.Local).AddTicks(6861) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 14, 49, 17, 354, DateTimeKind.Local).AddTicks(2978), new DateTime(2020, 11, 10, 14, 49, 17, 354, DateTimeKind.Local).AddTicks(3001) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 14, 49, 17, 356, DateTimeKind.Local).AddTicks(2406), new DateTime(2020, 11, 10, 14, 49, 17, 356, DateTimeKind.Local).AddTicks(2418) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 919525412, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 10, 14, 49, 17, 348, DateTimeKind.Local).AddTicks(1533), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 10, 14, 49, 17, 348, DateTimeKind.Local).AddTicks(4563), "", (short)0 });
        }
    }
}
