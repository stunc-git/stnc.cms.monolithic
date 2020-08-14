using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class SeedDataSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "Slug", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, null, null, null, "Genel", null, null },
                    { 2, null, null, null, "Kurumsal", null, null },
                    { 3, null, null, null, "Yönetim", null, null },
                    { 4, null, null, null, "Belge Bilgi", null, null },
                    { 5, null, null, null, "Galeri", null, null },
                    { 6, null, null, null, "İletişim", null, null },
                    { 7, null, null, null, "Duyurular", null, null }
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 404801026, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 14, 17, 28, 45, 563, DateTimeKind.Local).AddTicks(6360), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 14, 17, 28, 46, 862, DateTimeKind.Local).AddTicks(6608), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 404801026);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "Slug", "UpdatedAt" },
                values: new object[] { 40, null, null, null, "John Doe", null, null });
        }
    }
}
