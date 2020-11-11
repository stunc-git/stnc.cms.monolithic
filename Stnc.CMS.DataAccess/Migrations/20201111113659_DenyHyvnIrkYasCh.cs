using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DenyHyvnIrkYasCh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1723776341);

            migrationBuilder.DropColumn(
                name: "HayvanIrkFiyatTipAdi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "Isım",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.AddColumn<string>(
                name: "HayvanIrkFiyatTipYasBilgisi",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YasBilgisi",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                nullable: true);

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
                columns: new[] { "CreatedAt", "UpdatedAt", "YasBilgisi" },
                values: new object[] { new DateTime(2020, 11, 11, 14, 36, 58, 353, DateTimeKind.Local).AddTicks(1136), new DateTime(2020, 11, 11, 14, 36, 58, 353, DateTimeKind.Local).AddTicks(1148), "8 Haftalık Yaşa Kadar" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1484073263);

            migrationBuilder.DropColumn(
                name: "HayvanIrkFiyatTipYasBilgisi",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "YasBilgisi",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.AddColumn<string>(
                name: "HayvanIrkFiyatTipAdi",
                table: "StShoppingCartItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isım",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 8, 57, 22, 707, DateTimeKind.Local).AddTicks(8209), new DateTime(2020, 11, 11, 8, 57, 22, 707, DateTimeKind.Local).AddTicks(8224) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Isım", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 8, 57, 22, 712, DateTimeKind.Local).AddTicks(3547), "8 Haftalık Yaşa Kadar", new DateTime(2020, 11, 11, 8, 57, 22, 712, DateTimeKind.Local).AddTicks(3557) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 8, 57, 22, 706, DateTimeKind.Local).AddTicks(5867), new DateTime(2020, 11, 11, 8, 57, 22, 706, DateTimeKind.Local).AddTicks(5894) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 8, 57, 22, 708, DateTimeKind.Local).AddTicks(7433), new DateTime(2020, 11, 11, 8, 57, 22, 708, DateTimeKind.Local).AddTicks(7444) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1723776341, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 11, 8, 57, 22, 700, DateTimeKind.Local).AddTicks(7713), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 11, 8, 57, 22, 701, DateTimeKind.Local).AddTicks(651), "", (short)0 });
        }
    }
}
