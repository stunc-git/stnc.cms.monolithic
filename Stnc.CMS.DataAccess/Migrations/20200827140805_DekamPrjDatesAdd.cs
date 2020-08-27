using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DekamPrjDatesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_PostsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 391232456);

            migrationBuilder.DropColumn(
                name: "BaslangicTarihi",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "BitisTarihi",
                table: "DekamProjeTakip");

            migrationBuilder.AlterColumn<int>(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LaboratuvarBaslangicTarihi",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LaboratuvarBitisTarihi",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjeBaslangicTarihi",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProjeBitisTarihi",
                table: "DekamProjeTakip",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 576916282, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 27, 17, 8, 5, 111, DateTimeKind.Local).AddTicks(563), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 27, 17, 8, 5, 111, DateTimeKind.Local).AddTicks(9457), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniTurId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip",
                column: "DekamProjeLaboratuvarlarId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip",
                column: "DekamProjeTeknikDestekTalepHayvanSayisiId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip",
                column: "DekamProjeTeknikDestekTalepSureId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip",
                column: "DekamProjeTeknikDestekTalepTurId");



            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniIrkId",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip",
                column: "DekamProjeDeneyHayvaniTurId",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeLaboratuvarlar_DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip",
                column: "DekamProjeLaboratuvarlarId",
                principalTable: "DekamProjeLaboratuvarlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip",
                column: "DekamProjeTeknikDestekTalepHayvanSayisiId",
                principalTable: "DekamProjeDeneyHayvanSayisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip",
                column: "DekamProjeTeknikDestekTalepSureId",
                principalTable: "DekamProjeTeknikDestekTalepSure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip",
                column: "DekamProjeTeknikDestekTalepTurId",
                principalTable: "DekamProjeTeknikDestekTalepTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropForeignKey(
                name: "FK_Comments_DekamProjeTakip_PostsId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeLaboratuvarlar_DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 576916282);

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "LaboratuvarBaslangicTarihi",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "LaboratuvarBitisTarihi",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "ProjeBaslangicTarihi",
                table: "DekamProjeTakip");

            migrationBuilder.DropColumn(
                name: "ProjeBitisTarihi",
                table: "DekamProjeTakip");

            migrationBuilder.AlterColumn<int>(
                name: "DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<DateTime>(
                name: "BaslangicTarihi",
                table: "DekamProjeTakip",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BitisTarihi",
                table: "DekamProjeTakip",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 391232456, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 20, 9, 22, 53, 549, DateTimeKind.Local).AddTicks(1932), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 20, 9, 22, 53, 550, DateTimeKind.Local).AddTicks(599), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID");



            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_PostsId",
                table: "Comments",
                column: "PostsId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
