using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DenyHyvnFiyatcartIdDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StShoppingCartItem_DekamProjeDeneyHayvaniIrkFiyat_CartId",
                table: "StShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_StShoppingCartItem_CartId",
                table: "StShoppingCartItem");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 2094634567);

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "StShoppingCartItem");

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 43, 48, 840, DateTimeKind.Local).AddTicks(5385), new DateTime(2020, 11, 11, 16, 43, 48, 840, DateTimeKind.Local).AddTicks(5402) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 43, 48, 845, DateTimeKind.Local).AddTicks(2694), new DateTime(2020, 11, 11, 16, 43, 48, 845, DateTimeKind.Local).AddTicks(2706) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 43, 48, 839, DateTimeKind.Local).AddTicks(5498), new DateTime(2020, 11, 11, 16, 43, 48, 839, DateTimeKind.Local).AddTicks(5515) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 16, 43, 48, 841, DateTimeKind.Local).AddTicks(6995), new DateTime(2020, 11, 11, 16, 43, 48, 841, DateTimeKind.Local).AddTicks(7007) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1560730076, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 11, 16, 43, 48, 834, DateTimeKind.Local).AddTicks(182), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 11, 16, 43, 48, 834, DateTimeKind.Local).AddTicks(2966), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1560730076);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "StShoppingCartItem",
                type: "int",
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
                name: "IX_StShoppingCartItem_CartId",
                table: "StShoppingCartItem",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_StShoppingCartItem_DekamProjeDeneyHayvaniIrkFiyat_CartId",
                table: "StShoppingCartItem",
                column: "CartId",
                principalTable: "DekamProjeDeneyHayvaniIrkFiyat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
