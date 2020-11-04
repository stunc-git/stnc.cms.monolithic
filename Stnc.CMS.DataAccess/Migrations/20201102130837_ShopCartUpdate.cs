using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class ShopCartUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StShoppingCartItem_StCart_CartId",
                table: "StShoppingCartItem");

            migrationBuilder.DropTable(
                name: "StCart");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1264878060);

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "StShoppingCartItem");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTakipID",
                table: "StShoppingCartItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "StShoppingCartItem",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 2131991788, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 2, 16, 8, 36, 511, DateTimeKind.Local).AddTicks(7396), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 2, 16, 8, 36, 512, DateTimeKind.Local).AddTicks(200), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_StShoppingCartItem_DekamProjeDeneyHayvaniIrkFiyat_CartId",
                table: "StShoppingCartItem",
                column: "CartId",
                principalTable: "DekamProjeDeneyHayvaniIrkFiyat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StShoppingCartItem_DekamProjeDeneyHayvaniIrkFiyat_CartId",
                table: "StShoppingCartItem");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 2131991788);

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "DekamProjeTakipID",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "StShoppingCartItem");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "StShoppingCartItem");

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartId",
                table: "StShoppingCartItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<int>(type: "int", nullable: false),
                    IsPreferedFood = table.Column<bool>(type: "bit", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StCart", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1264878060, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 2, 11, 17, 14, 156, DateTimeKind.Local).AddTicks(7677), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 2, 11, 17, 14, 157, DateTimeKind.Local).AddTicks(458), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_StShoppingCartItem_StCart_CartId",
                table: "StShoppingCartItem",
                column: "CartId",
                principalTable: "StCart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
