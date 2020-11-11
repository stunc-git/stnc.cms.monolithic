using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DenyHyvnFiyatUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1484073263);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 41, 36, 475, DateTimeKind.Local).AddTicks(2545), new DateTime(2020, 11, 11, 16, 41, 36, 475, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 41, 36, 479, DateTimeKind.Local).AddTicks(9525), new DateTime(2020, 11, 11, 16, 41, 36, 479, DateTimeKind.Local).AddTicks(9536) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 41, 36, 474, DateTimeKind.Local).AddTicks(2745), new DateTime(2020, 11, 11, 16, 41, 36, 474, DateTimeKind.Local).AddTicks(2760) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 41, 36, 476, DateTimeKind.Local).AddTicks(1841), new DateTime(2020, 11, 11, 16, 41, 36, 476, DateTimeKind.Local).AddTicks(1852) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 2094634567, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 11, 16, 41, 36, 468, DateTimeKind.Local).AddTicks(7448), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 11, 16, 41, 36, 469, DateTimeKind.Local).AddTicks(424), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_StShoppingCartItem_AppUserId",
                table: "StShoppingCartItem",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StShoppingCartItem_AspNetUsers_AppUserId",
                table: "StShoppingCartItem",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StShoppingCartItem_AspNetUsers_AppUserId",
                table: "StShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_StShoppingCartItem_AppUserId",
                table: "StShoppingCartItem");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 2094634567);

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "StShoppingCartItem");

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 14, 36, 58, 348, DateTimeKind.Local).AddTicks(3879), new DateTime(2020, 11, 11, 14, 36, 58, 348, DateTimeKind.Local).AddTicks(3893) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 14, 36, 58, 353, DateTimeKind.Local).AddTicks(1136), new DateTime(2020, 11, 11, 14, 36, 58, 353, DateTimeKind.Local).AddTicks(1148) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 14, 36, 58, 347, DateTimeKind.Local).AddTicks(4023), new DateTime(2020, 11, 11, 14, 36, 58, 347, DateTimeKind.Local).AddTicks(4040) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 14, 36, 58, 349, DateTimeKind.Local).AddTicks(2742), new DateTime(2020, 11, 11, 14, 36, 58, 349, DateTimeKind.Local).AddTicks(2753) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1484073263, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 11, 14, 36, 58, 341, DateTimeKind.Local).AddTicks(8446), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 11, 14, 36, 58, 342, DateTimeKind.Local).AddTicks(1302), "", (short)0 });
        }
    }
}
