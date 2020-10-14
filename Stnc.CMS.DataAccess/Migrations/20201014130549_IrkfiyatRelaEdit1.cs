using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class IrkfiyatRelaEdit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_AspNetUsers_AppUserId",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 448522521);

            migrationBuilder.RenameColumn(
                name: "DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "DekamProjeDeneyHayvaniTurId");

            migrationBuilder.RenameColumn(
                name: "DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "DekamProjeDeneyHayvaniIrkId");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurId");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkId");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1847719039, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 16, 5, 48, 956, DateTimeKind.Local).AddTicks(7031), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 16, 5, 48, 957, DateTimeKind.Local).AddTicks(9891), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_AspNetUsers_AppUserId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniIrkId",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniTurId",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_AspNetUsers_AppUserId",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1847719039);

            migrationBuilder.RenameColumn(
                name: "DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "DekamProjeDeneyHayvaniTurID");

            migrationBuilder.RenameColumn(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "DekamProjeDeneyHayvaniIrkID");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurID");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                newName: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkID");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 448522521, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 10, 14, 11, 37, 31, 913, DateTimeKind.Local).AddTicks(960), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 10, 14, 11, 37, 31, 914, DateTimeKind.Local).AddTicks(2236), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_AspNetUsers_AppUserId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniIrkID",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurID",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniTurID",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
