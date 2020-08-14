using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class SeedInitialDataTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<short>(
                name: "PostType",
                table: "Posts",
                type: "smallint",
                nullable: true,
                defaultValue: (short)1);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Name", "Slug", "UpdatedAt" },
                values: new object[] { 40, null, null, null, "John Doe", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DropColumn(
                name: "PostType",
                table: "Posts");


    }
    }
}
