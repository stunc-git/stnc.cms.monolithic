using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class DekamPrjDatesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 846875515, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 27, 17, 12, 49, 945, DateTimeKind.Local).AddTicks(6284), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 27, 17, 12, 49, 946, DateTimeKind.Local).AddTicks(4958), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniIrkID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniIrkID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_LaboratuvarID",
                table: "DekamProjeTakip",
                column: "LaboratuvarID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_TeknikDestekSuresiID",
                table: "DekamProjeTakip",
                column: "TeknikDestekSuresiID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_TeknikDestekTuruID",
                table: "DekamProjeTakip",
                column: "TeknikDestekTuruID");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_TeknikHayvanSayisiID",
                table: "DekamProjeTakip",
                column: "TeknikHayvanSayisiID");

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DeneyHayvaniIrkID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniIrkID",
                principalTable: "DekamProjeDeneyHayvaniIrk",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID",
                principalTable: "DekamProjeDeneyHayvaniTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeLaboratuvarlar_LaboratuvarID",
                table: "DekamProjeTakip",
                column: "LaboratuvarID",
                principalTable: "DekamProjeLaboratuvarlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_TeknikDestekSuresiID",
                table: "DekamProjeTakip",
                column: "TeknikDestekSuresiID",
                principalTable: "DekamProjeTeknikDestekTalepSure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_TeknikDestekTuruID",
                table: "DekamProjeTakip",
                column: "TeknikDestekTuruID",
                principalTable: "DekamProjeTeknikDestekTalepTur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_TeknikHayvanSayisiID",
                table: "DekamProjeTakip",
                column: "TeknikHayvanSayisiID",
                principalTable: "DekamProjeDeneyHayvanSayisi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DeneyHayvaniIrkID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeLaboratuvarlar_LaboratuvarID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_TeknikDestekSuresiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_TeknikDestekTuruID",
                table: "DekamProjeTakip");

            migrationBuilder.DropForeignKey(
                name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_TeknikHayvanSayisiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniIrkID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_LaboratuvarID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_TeknikDestekSuresiID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_TeknikDestekTuruID",
                table: "DekamProjeTakip");

            migrationBuilder.DropIndex(
                name: "IX_DekamProjeTakip_TeknikHayvanSayisiID",
                table: "DekamProjeTakip");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 846875515);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeLaboratuvarlarId",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTeknikDestekTalepHayvanSayisiId",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTeknikDestekTalepSureId",
                table: "DekamProjeTakip",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DekamProjeTeknikDestekTalepTurId",
                table: "DekamProjeTakip",
                type: "int",
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
    }
}
