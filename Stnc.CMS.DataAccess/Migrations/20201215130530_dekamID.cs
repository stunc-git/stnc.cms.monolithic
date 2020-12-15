using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class dekamID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1201567435);

            migrationBuilder.DropColumn(
                name: "DeneyHayvaniSayisi",
                table: "DekamProjeTakip");

            migrationBuilder.RenameColumn(
                name: "DekamProjeTakipID",
                table: "StShoppingCartItem",
                newName: "DekamProjeTakipId");

            migrationBuilder.AlterColumn<int>(
                name: "DekamProjeTakipId",
                table: "StShoppingCartItem",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTakipID",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 15, 16, 5, 29, 537, DateTimeKind.Local).AddTicks(64), new DateTime(2020, 12, 15, 16, 5, 29, 537, DateTimeKind.Local).AddTicks(72) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 15, 16, 5, 29, 541, DateTimeKind.Local).AddTicks(7762), new DateTime(2020, 12, 15, 16, 5, 29, 541, DateTimeKind.Local).AddTicks(7785) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 15, 16, 5, 29, 535, DateTimeKind.Local).AddTicks(9619), new DateTime(2020, 12, 15, 16, 5, 29, 535, DateTimeKind.Local).AddTicks(9651) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 15, 16, 5, 29, 537, DateTimeKind.Local).AddTicks(9037), new DateTime(2020, 12, 15, 16, 5, 29, 537, DateTimeKind.Local).AddTicks(9045) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 903153916, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 12, 15, 16, 5, 29, 528, DateTimeKind.Local).AddTicks(3925), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 12, 15, 16, 5, 29, 529, DateTimeKind.Local).AddTicks(2912), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_StShoppingCartItem_DekamProjeTakipID",
                table: "StShoppingCartItem",
                column: "DekamProjeTakipID");

            migrationBuilder.AddForeignKey(
                name: "FK_StShoppingCartItem_DekamProjeTakip_DekamProjeTakipID",
                table: "StShoppingCartItem",
                column: "DekamProjeTakipID",
                principalTable: "DekamProjeTakip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StShoppingCartItem_DekamProjeTakip_DekamProjeTakipID",
                table: "StShoppingCartItem");

            migrationBuilder.DropIndex(
                name: "IX_StShoppingCartItem_DekamProjeTakipID",
                table: "StShoppingCartItem");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 903153916);

            migrationBuilder.DropColumn(
                name: "DekamProjeTakipID",
                table: "StShoppingCartItem");

            migrationBuilder.RenameColumn(
                name: "DekamProjeTakipId",
                table: "StShoppingCartItem",
                newName: "DekamProjeTakipID");

            migrationBuilder.AlterColumn<int>(
                name: "DekamProjeTakipID",
                table: "StShoppingCartItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "DeneyHayvaniSayisi",
                table: "DekamProjeTakip",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 9, 15, 34, 48, 99, DateTimeKind.Local).AddTicks(345), new DateTime(2020, 12, 9, 15, 34, 48, 99, DateTimeKind.Local).AddTicks(356) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 9, 15, 34, 48, 103, DateTimeKind.Local).AddTicks(5986), new DateTime(2020, 12, 9, 15, 34, 48, 103, DateTimeKind.Local).AddTicks(6001) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 9, 15, 34, 48, 98, DateTimeKind.Local).AddTicks(670), new DateTime(2020, 12, 9, 15, 34, 48, 98, DateTimeKind.Local).AddTicks(689) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 9, 15, 34, 48, 99, DateTimeKind.Local).AddTicks(9402), new DateTime(2020, 12, 9, 15, 34, 48, 99, DateTimeKind.Local).AddTicks(9412) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1201567435, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 12, 9, 15, 34, 48, 91, DateTimeKind.Local).AddTicks(6448), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 12, 9, 15, 34, 48, 92, DateTimeKind.Local).AddTicks(7694), "", (short)0 });
        }
    }
}
