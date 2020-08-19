using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class Initialprj_Req : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDestekSure_AspNetUsers_AppUserId",
                table: "DekamProjeDestekSure");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeDestekTur_AspNetUsers_AppUserId",
                table: "DekamProjeDestekTur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DekamProjeDestekTur",
                table: "DekamProjeDestekTur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DekamProjeDestekSure",
                table: "DekamProjeDestekSure");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 342316601);

            migrationBuilder.RenameTable(
                name: "DekamProjeDestekTur",
                newName: "DekamProjeTeknikDestekTalepTur");

            migrationBuilder.RenameTable(
                name: "DekamProjeDestekSure",
                newName: "DekamProjeTeknikDestekTalepSure");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeDestekTur_AppUserId",
                table: "DekamProjeTeknikDestekTalepTur",
                newName: "IX_DekamProjeTeknikDestekTalepTur_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeDestekSure_AppUserId",
                table: "DekamProjeTeknikDestekTalepSure",
                newName: "IX_DekamProjeTeknikDestekTalepSure_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeLaboratuvarlar",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeDeneyHayvanSayisi",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeDeneyHayvaniIrk",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeTeknikDestekTalepSure",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DekamProjeTeknikDestekTalepTur",
                table: "DekamProjeTeknikDestekTalepTur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DekamProjeTeknikDestekTalepSure",
                table: "DekamProjeTeknikDestekTalepSure",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 210767821, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 19, 15, 20, 12, 621, DateTimeKind.Local).AddTicks(8166), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 19, 15, 20, 12, 622, DateTimeKind.Local).AddTicks(6907), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTeknikDestekTalepSure_AspNetUsers_AppUserId",
                table: "DekamProjeTeknikDestekTalepSure",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTeknikDestekTalepTur_AspNetUsers_AppUserId",
                table: "DekamProjeTeknikDestekTalepTur",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTeknikDestekTalepSure_AspNetUsers_AppUserId",
                table: "DekamProjeTeknikDestekTalepSure");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTeknikDestekTalepTur_AspNetUsers_AppUserId",
                table: "DekamProjeTeknikDestekTalepTur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DekamProjeTeknikDestekTalepTur",
                table: "DekamProjeTeknikDestekTalepTur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DekamProjeTeknikDestekTalepSure",
                table: "DekamProjeTeknikDestekTalepSure");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 210767821);

            migrationBuilder.RenameTable(
                name: "DekamProjeTeknikDestekTalepTur",
                newName: "DekamProjeDestekTur");

            migrationBuilder.RenameTable(
                name: "DekamProjeTeknikDestekTalepSure",
                newName: "DekamProjeDestekSure");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeTeknikDestekTalepTur_AppUserId",
                table: "DekamProjeDestekTur",
                newName: "IX_DekamProjeDestekTur_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DekamProjeTeknikDestekTalepSure_AppUserId",
                table: "DekamProjeDestekSure",
                newName: "IX_DekamProjeDestekSure_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeLaboratuvarlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeDeneyHayvanSayisi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeDeneyHayvaniIrk",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DekamProjeDestekSure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DekamProjeDestekTur",
                table: "DekamProjeDestekTur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DekamProjeDestekSure",
                table: "DekamProjeDestekSure",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 342316601, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 19, 14, 4, 36, 451, DateTimeKind.Local).AddTicks(186), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 19, 14, 4, 36, 451, DateTimeKind.Local).AddTicks(9615), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDestekSure_AspNetUsers_AppUserId",
                table: "DekamProjeDestekSure",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeDestekTur_AspNetUsers_AppUserId",
                table: "DekamProjeDestekTur",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
