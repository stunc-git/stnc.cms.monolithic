using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class cartAgrilikCh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1560730076);

            migrationBuilder.AlterColumn<string>(
                name: "HayvanAgirlik",
                table: "StShoppingCartItem",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 16, 16, 0, 4, 62, DateTimeKind.Local).AddTicks(1149), new DateTime(2020, 11, 16, 16, 0, 4, 62, DateTimeKind.Local).AddTicks(1169) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 16, 16, 0, 4, 66, DateTimeKind.Local).AddTicks(9026), new DateTime(2020, 11, 16, 16, 0, 4, 66, DateTimeKind.Local).AddTicks(9041) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 16, 16, 0, 4, 61, DateTimeKind.Local).AddTicks(1217), new DateTime(2020, 11, 16, 16, 0, 4, 61, DateTimeKind.Local).AddTicks(1254) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 16, 16, 0, 4, 63, DateTimeKind.Local).AddTicks(2640), new DateTime(2020, 11, 16, 16, 0, 4, 63, DateTimeKind.Local).AddTicks(2657) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 940240346, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 16, 16, 0, 4, 55, DateTimeKind.Local).AddTicks(4365), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 16, 16, 0, 4, 55, DateTimeKind.Local).AddTicks(7363), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 940240346);

            migrationBuilder.AlterColumn<byte>(
                name: "HayvanAgirlik",
                table: "StShoppingCartItem",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255,
                oldNullable: true);

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
    }
}
