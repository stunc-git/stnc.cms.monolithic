using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class options : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 2131991788);

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "ntext", nullable: true),
                    OptionValue = table.Column<string>(type: "ntext", nullable: true),
                    DefaultValue = table.Column<string>(type: "ntext", nullable: true),
                    Autoload = table.Column<string>(maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1449820355, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 4, 13, 58, 22, 411, DateTimeKind.Local).AddTicks(5860), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 4, 13, 58, 22, 411, DateTimeKind.Local).AddTicks(8781), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1449820355);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 2131991788, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 11, 2, 16, 8, 36, 511, DateTimeKind.Local).AddTicks(7396), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 11, 2, 16, 8, 36, 512, DateTimeKind.Local).AddTicks(200), "", (short)0 });
        }
    }
}
