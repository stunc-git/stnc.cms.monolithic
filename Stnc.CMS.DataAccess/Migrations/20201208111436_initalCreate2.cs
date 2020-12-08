using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class initalCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 365488076);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 14, 14, 35, 488, DateTimeKind.Local).AddTicks(9342), new DateTime(2020, 12, 8, 14, 14, 35, 488, DateTimeKind.Local).AddTicks(9352) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 14, 14, 35, 493, DateTimeKind.Local).AddTicks(8242), new DateTime(2020, 12, 8, 14, 14, 35, 493, DateTimeKind.Local).AddTicks(8265) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 14, 14, 35, 487, DateTimeKind.Local).AddTicks(8169), new DateTime(2020, 12, 8, 14, 14, 35, 487, DateTimeKind.Local).AddTicks(8193) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 14, 14, 35, 489, DateTimeKind.Local).AddTicks(8894), new DateTime(2020, 12, 8, 14, 14, 35, 489, DateTimeKind.Local).AddTicks(8902) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AppUserId", "CategoryId", "CommentStatus", "CreatedAt", "DeletedAt", "MenuOrder", "Picture", "PostContent", "PostExcerpt", "PostPassword", "PostSlug", "PostStatus", "PostTitle", "UpdatedAt" },
                values: new object[] { 454034180, 1, 1, false, new DateTime(2020, 12, 8, 14, 14, 35, 467, DateTimeKind.Local).AddTicks(5424), null, 1, "default.jpg", "<p>Erciyes Üniversitesi Tıp Fakültesine bağlı bir merkez olarak; Hakan ÇETİNSAYA’nın (1976-1996) anısına, amcası hayırsever işadamı Sayın Süleyman ÇETİNSAYA tarafından yaptırılan merkez 1997 tarihinde hizmete açılmıştır. </ p >< p >< img src = \"/upload/file/tarihce-res1.jpg\" >< br ></ p >< p >•Hakan Çetinsaya Deneysel ve Klinik Araştırma Merkez'inde kurulduğu günden itibaren çok sayıda deneysel çalışmalar yapılmış ve bu çalışmalar ulusal ve uluslar arası dergilerde yayınlanmış, kongrelerde sunulmuş ve çeşitli ödüller almıştır.•21 Haziran 2013 tarihli ve 28684 sayılı Resmi Gazete’de yayımlanan Yönetmelik kapsamında Erciyes Üniversitesi \"Deneysel Araştırmalar Uygulama ve Araştırma Merkezi - DEKAM\" olarak isimlendirildi. </ p > ", null, null, "hakkimizda", true, "HAKKIMIZDA", new DateTime(2020, 12, 8, 14, 14, 35, 468, DateTimeKind.Local).AddTicks(6235) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1768819076, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 12, 8, 14, 14, 35, 482, DateTimeKind.Local).AddTicks(3748), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 12, 8, 14, 14, 35, 482, DateTimeKind.Local).AddTicks(3782), "", (short)0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 454034180);

            migrationBuilder.DeleteData(
                table: "Slider",
                keyColumn: "Id",
                keyValue: 1768819076);

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrk",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 13, 50, 10, 616, DateTimeKind.Local).AddTicks(7721), new DateTime(2020, 12, 8, 13, 50, 10, 616, DateTimeKind.Local).AddTicks(7732) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 13, 50, 10, 621, DateTimeKind.Local).AddTicks(9682), new DateTime(2020, 12, 8, 13, 50, 10, 621, DateTimeKind.Local).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "DekamProjeDeneyHayvaniTur",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 13, 50, 10, 615, DateTimeKind.Local).AddTicks(6493), new DateTime(2020, 12, 8, 13, 50, 10, 615, DateTimeKind.Local).AddTicks(6525) });

            migrationBuilder.UpdateData(
                table: "DekamProjeLaboratuvarlar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2020, 12, 8, 13, 50, 10, 617, DateTimeKind.Local).AddTicks(8559), new DateTime(2020, 12, 8, 13, 50, 10, 617, DateTimeKind.Local).AddTicks(8576) });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 365488076, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 12, 8, 13, 50, 10, 608, DateTimeKind.Local).AddTicks(4355), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 12, 8, 13, 50, 10, 609, DateTimeKind.Local).AddTicks(3666), "", (short)0 });
        }
    }
}
