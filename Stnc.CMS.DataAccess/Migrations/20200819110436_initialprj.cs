using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class Initialprj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 466291747);

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvaniIrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDeneyHayvaniIrk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvaniIrk_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvaniTur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDeneyHayvaniTur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvaniTur_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvanSayisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDeneyHayvanSayisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvanSayisi_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDestekSure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDestekSure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDestekSure_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDestekTur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDestekTur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDestekTur_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeLaboratuvarlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeLaboratuvarlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeLaboratuvarlar_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeTakip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeYurutucusu = table.Column<string>(maxLength: 500, nullable: false),
                    ProjeYurutukurumu = table.Column<string>(maxLength: 500, nullable: false),
                    ProjeYurutuTelefon = table.Column<string>(maxLength: 500, nullable: false),
                    SorumluArastirmaci = table.Column<string>(maxLength: 500, nullable: false),
                    SorumluArastirmaciTelefon = table.Column<string>(maxLength: 500, nullable: false),
                    EtikKurulOnayNumarasi = table.Column<string>(maxLength: 500, nullable: false),
                    EtikKurulOnayTarihi = table.Column<DateTime>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(nullable: true),
                    BitisTarihi = table.Column<DateTime>(nullable: true),
                    DeneyHayvaniCinsiyet = table.Column<short>(type: "smallint", nullable: false),
                    DeneyHayvaniSayisi = table.Column<short>(type: "smallint", nullable: false),
                    DeneyHayvaniYasi = table.Column<short>(type: "smallint", nullable: false),
                    DeneyHayvaniAgirligi = table.Column<short>(type: "smallint", nullable: false),
                    TeknikDestekSuresiID = table.Column<int>(nullable: false),
                    TeknikDestekTuruID = table.Column<int>(nullable: false),
                    TeknikHayvanSayisiID = table.Column<int>(nullable: false),
                    LaboratuvarID = table.Column<int>(nullable: false),
                    DeneyHayvaniIrkID = table.Column<int>(nullable: false),
                    DeneyHayvaniTurID = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                        column: x => x.DeneyHayvaniTurID,
                        principalTable: "DekamProjeDeneyHayvaniTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 342316601, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 19, 14, 4, 36, 451, DateTimeKind.Local).AddTicks(186), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 19, 14, 4, 36, 451, DateTimeKind.Local).AddTicks(9615), "", (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrk_AppUserId",
                table: "DekamProjeDeneyHayvaniIrk",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniTur_AppUserId",
                table: "DekamProjeDeneyHayvaniTur",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvanSayisi_AppUserId",
                table: "DekamProjeDeneyHayvanSayisi",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDestekSure_AppUserId",
                table: "DekamProjeDestekSure",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDestekTur_AppUserId",
                table: "DekamProjeDestekTur",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeLaboratuvarlar_AppUserId",
                table: "DekamProjeLaboratuvarlar",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_AppUserId",
                table: "DekamProjeTakip",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTakip_DeneyHayvaniTurID",
                table: "DekamProjeTakip",
                column: "DeneyHayvaniTurID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniIrk");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvanSayisi");

            migrationBuilder.DropTable(
                name: "DekamProjeDestekSure");

            migrationBuilder.DropTable(
                name: "DekamProjeDestekTur");

            migrationBuilder.DropTable(
                name: "DekamProjeLaboratuvarlar");

            migrationBuilder.DropTable(
                name: "DekamProjeTakip");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniTur");

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 342316601);

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 466291747, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 18, 17, 7, 11, 540, DateTimeKind.Local).AddTicks(4502), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 18, 17, 7, 11, 541, DateTimeKind.Local).AddTicks(3293), "", (short)0 });

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
