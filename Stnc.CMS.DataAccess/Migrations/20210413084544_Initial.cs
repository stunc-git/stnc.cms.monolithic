using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aciliyetler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aciliyetler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Surname = table.Column<string>(maxLength: 100, nullable: true),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Slug = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(nullable: true),
                    OptionValue = table.Column<string>(nullable: true),
                    DefaultValue = table.Column<string>(nullable: true),
                    Autoload = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bildirimler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(nullable: true),
                    Durum = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bildirimler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bildirimler_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvaniIrk",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DeneyHayvaniTurID = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvaniTur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 500, nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    GunlukBakimUcret = table.Column<decimal>(nullable: false),
                    OtenaziUcret = table.Column<decimal>(nullable: false),
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeLaboratuvarlar",
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
                    table.PrimaryKey("PK_DekamProjeLaboratuvarlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeLaboratuvarlar_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeTeknikDestekTalepTur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeTeknikDestekTalepTur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeTeknikDestekTalepTur_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Gorevler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    Durum = table.Column<bool>(nullable: false),
                    OlusturulmaTarih = table.Column<DateTime>(nullable: false),
                    AciliyetId = table.Column<int>(nullable: false),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gorevler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gorevler_Aciliyetler_AciliyetId",
                        column: x => x.AciliyetId,
                        principalTable: "Aciliyetler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gorevler_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(nullable: true),
                    UrlAddress = table.Column<string>(nullable: true),
                    UrlType = table.Column<int>(nullable: false),
                    Excerpt = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    MenuOrder = table.Column<int>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slider_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HayvaniIrkFiyatID = table.Column<int>(nullable: false),
                    DekamProjeTakipID = table.Column<int>(nullable: false),
                    HayvanAdi = table.Column<string>(nullable: true),
                    HayvanIrkAdi = table.Column<string>(nullable: true),
                    HayvanIrkFiyatTipYasBilgisi = table.Column<string>(nullable: true),
                    IstenenHayvanSayisi = table.Column<int>(nullable: false),
                    DestekIstenenHayvanSayisi = table.Column<int>(nullable: false),
                    BakimDestegiGunSayisi = table.Column<int>(nullable: false),
                    Otenazi = table.Column<int>(nullable: false),
                    OtenaziUcreti = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    OtenaziToplamUcreti = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    HayvanFiyati = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    GunlukBakimUcreti = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    DestekTalepTurleri = table.Column<string>(maxLength: 255, nullable: true),
                    DeneyHayvaniCinsiyet = table.Column<bool>(nullable: false),
                    HayvanAgirlik = table.Column<string>(maxLength: 255, nullable: true),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    DestekTalepTurleriJson = table.Column<string>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StShoppingCartItem_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(nullable: true),
                    PostContent = table.Column<string>(nullable: true),
                    PostExcerpt = table.Column<string>(nullable: true),
                    PostStatus = table.Column<bool>(nullable: false),
                    CommentStatus = table.Column<bool>(nullable: false),
                    PostPassword = table.Column<string>(nullable: true),
                    PostSlug = table.Column<string>(nullable: true),
                    MenuOrder = table.Column<int>(nullable: false),
                    PostType = table.Column<int>(nullable: true),
                    CommentCount = table.Column<long>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DekamProjeDeneyHayvaniIrkFiyat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YasBilgisi = table.Column<string>(nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true),
                    DekamProjeDeneyHayvaniTurId = table.Column<int>(nullable: true),
                    DekamProjeDeneyHayvaniIrkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeDeneyHayvaniIrkFiyat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvaniIrkFiyat_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrk_DekamProjeDeneyHayvaniIrkId",
                        column: x => x.DekamProjeDeneyHayvaniIrkId,
                        principalTable: "DekamProjeDeneyHayvaniIrk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTur_DekamProjeDeneyHayvaniTurId",
                        column: x => x.DekamProjeDeneyHayvaniTurId,
                        principalTable: "DekamProjeDeneyHayvaniTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
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
                    ProjeBaslangicTarihi = table.Column<DateTime>(nullable: true),
                    ProjeBitisTarihi = table.Column<DateTime>(nullable: true),
                    LaboratuvarBaslangicTarihi = table.Column<DateTime>(nullable: true),
                    LaboratuvarBitisTarihi = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true),
                    LaboratuvarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Siparisler_DekamProjeLaboratuvarlar_LaboratuvarID",
                        column: x => x.LaboratuvarID,
                        principalTable: "DekamProjeLaboratuvarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raporlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(nullable: true),
                    Detay = table.Column<string>(nullable: true),
                    GorevId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raporlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raporlar_Gorevler_GorevId",
                        column: x => x.GorevId,
                        principalTable: "Gorevler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<long>(nullable: false),
                    ParentCommentId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    CommentContent = table.Column<string>(nullable: true),
                    CommentAuthor = table.Column<string>(nullable: true),
                    CommentAuthorEmail = table.Column<string>(nullable: true),
                    CommentAuthorUrl = table.Column<string>(nullable: true),
                    CommentAuthorIP = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentDateGmt = table.Column<DateTime>(nullable: true),
                    CommentApproved = table.Column<string>(nullable: true),
                    CommentAgent = table.Column<string>(nullable: true),
                    CommentType = table.Column<string>(nullable: true),
                    CommentParent = table.Column<long>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    PostsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Siparisler_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DekamProjeDeneyHayvaniIrk",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DeletedAt", "DeneyHayvaniTurID", "Description", "Name", "UpdatedAt" },
                values: new object[] { 1, null, new DateTime(2021, 4, 13, 11, 45, 44, 292, DateTimeKind.Local).AddTicks(2780), null, 1, null, "fare (Balb-C)", new DateTime(2021, 4, 13, 11, 45, 44, 292, DateTimeKind.Local).AddTicks(2792) });

            migrationBuilder.InsertData(
                table: "DekamProjeDeneyHayvaniTur",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DeletedAt", "GunlukBakimUcret", "Name", "OtenaziUcret", "Picture", "UpdatedAt" },
                values: new object[] { 1, null, new DateTime(2021, 4, 13, 11, 45, 44, 289, DateTimeKind.Local).AddTicks(7260), null, 10m, "Fare", 1m, null, new DateTime(2021, 4, 13, 11, 45, 44, 290, DateTimeKind.Local).AddTicks(5097) });

            migrationBuilder.InsertData(
                table: "DekamProjeLaboratuvarlar",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[] { 1, null, new DateTime(2021, 4, 13, 11, 45, 44, 293, DateTimeKind.Local).AddTicks(1088), null, "Ernam", new DateTime(2021, 4, 13, 11, 45, 44, 293, DateTimeKind.Local).AddTicks(1095) });

            migrationBuilder.InsertData(
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                columns: new[] { "Id", "AppUserId", "CreatedAt", "DekamProjeDeneyHayvaniIrkId", "DekamProjeDeneyHayvaniTurId", "DeletedAt", "Fiyat", "UpdatedAt", "YasBilgisi" },
                values: new object[] { 1, null, new DateTime(2021, 4, 13, 11, 45, 44, 295, DateTimeKind.Local).AddTicks(5483), 1, 1, null, 5m, new DateTime(2021, 4, 13, 11, 45, 44, 295, DateTimeKind.Local).AddTicks(5492), "8 Haftalık Yaşa Kadar" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bildirimler_AppUserId",
                table: "Bildirimler",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostsId",
                table: "Comments",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrk_AppUserId",
                table: "DekamProjeDeneyHayvaniIrk",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_AppUserId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniIrkId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniIrkId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniIrkFiyat_DekamProjeDeneyHayvaniTurId",
                table: "DekamProjeDeneyHayvaniIrkFiyat",
                column: "DekamProjeDeneyHayvaniTurId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvaniTur_AppUserId",
                table: "DekamProjeDeneyHayvaniTur",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeLaboratuvarlar_AppUserId",
                table: "DekamProjeLaboratuvarlar",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTeknikDestekTalepTur_AppUserId",
                table: "DekamProjeTeknikDestekTalepTur",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_AciliyetId",
                table: "Gorevler",
                column: "AciliyetId");

            migrationBuilder.CreateIndex(
                name: "IX_Gorevler_AppUserId",
                table: "Gorevler",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Raporlar_GorevId",
                table: "Raporlar",
                column: "GorevId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_AppUserId",
                table: "Siparisler",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_LaboratuvarID",
                table: "Siparisler",
                column: "LaboratuvarID");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_AppUserId",
                table: "Slider",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StShoppingCartItem_AppUserId",
                table: "StShoppingCartItem",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bildirimler");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniIrkFiyat");

            migrationBuilder.DropTable(
                name: "DekamProjeTeknikDestekTalepTur");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Raporlar");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "StShoppingCartItem");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniIrk");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniTur");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "DekamProjeLaboratuvarlar");

            migrationBuilder.DropTable(
                name: "Aciliyetler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
