using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DenyHyvnYasDROP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1146002850);

            migrationBuilder.DropColumn(
                name: "HayvanYas",
                table: "StShoppingCartItem");

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
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 11, 8, 57, 22, 712, DateTimeKind.Local).AddTicks(3547), new DateTime(2020, 11, 11, 8, 57, 22, 712, DateTimeKind.Local).AddTicks(3557) });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1723776341);

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
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 186, DateTimeKind.Local).AddTicks(4075), new DateTime(2020, 11, 10, 16, 26, 1, 186, DateTimeKind.Local).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 190, DateTimeKind.Local).AddTicks(9115), new DateTime(2020, 11, 10, 16, 26, 1, 190, DateTimeKind.Local).AddTicks(9125) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 185, DateTimeKind.Local).AddTicks(2410), new DateTime(2020, 11, 10, 16, 26, 1, 185, DateTimeKind.Local).AddTicks(2435) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 10, 16, 26, 1, 187, DateTimeKind.Local).AddTicks(3235), new DateTime(2020, 11, 10, 16, 26, 1, 187, DateTimeKind.Local).AddTicks(3246) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1146002850, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 10, 16, 26, 1, 179, DateTimeKind.Local).AddTicks(7010), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 10, 16, 26, 1, 179, DateTimeKind.Local).AddTicks(9866), "", (short)0 });
        }
    }
}
