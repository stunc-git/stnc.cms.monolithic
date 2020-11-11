using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class CartAdd_otenazi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 771592251);

            migrationBuilder.AlterColumn<int>(
                name: "Otenazi",
                table: "StShoppingCartItem",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<decimal>(
                name: "OtenaziToplamUcreti",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 919525412);

            migrationBuilder.DropColumn(
                name: "OtenaziToplamUcreti",
                table: "StShoppingCartItem");

            migrationBuilder.AlterColumn<bool>(
                name: "Otenazi",
                table: "StShoppingCartItem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 9, 11, 52, 24, 391, DateTimeKind.Local).AddTicks(5435), new DateTime(2020, 11, 9, 11, 52, 24, 391, DateTimeKind.Local).AddTicks(5449) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 9, 11, 52, 24, 395, DateTimeKind.Local).AddTicks(9421), new DateTime(2020, 11, 9, 11, 52, 24, 395, DateTimeKind.Local).AddTicks(9432) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 9, 11, 52, 24, 390, DateTimeKind.Local).AddTicks(5417), new DateTime(2020, 11, 9, 11, 52, 24, 390, DateTimeKind.Local).AddTicks(5439) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 11, 9, 11, 52, 24, 392, DateTimeKind.Local).AddTicks(4877), new DateTime(2020, 11, 9, 11, 52, 24, 392, DateTimeKind.Local).AddTicks(4888) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 771592251, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 9, 11, 52, 24, 384, DateTimeKind.Local).AddTicks(2437), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 9, 11, 52, 24, 384, DateTimeKind.Local).AddTicks(5211), "", (short)0 });
        }
    }
}
