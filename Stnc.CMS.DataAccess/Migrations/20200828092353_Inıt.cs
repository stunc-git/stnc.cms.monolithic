using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class Inıt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aciliyetler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(maxLength: 100, nullable: true)
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Slug = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "ntext", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
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
                name: "DekamProjeDeneyHayvanSayisi",
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
                    table.PrimaryKey("PK_DekamProjeDeneyHayvanSayisi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeDeneyHayvanSayisi_AspNetUsers_AppUserId",
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
                name: "DekamProjeTeknikDestekTalepSure",
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
                    table.PrimaryKey("PK_DekamProjeTeknikDestekTalepSure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeTeknikDestekTalepSure_AspNetUsers_AppUserId",
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
                    Name = table.Column<string>(nullable: true),
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
                    Ad = table.Column<string>(maxLength: 200, nullable: false),
                    Aciklama = table.Column<string>(type: "ntext", nullable: true),
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
                    Caption = table.Column<string>(maxLength: 250, nullable: true),
                    UrlAddress = table.Column<string>(nullable: true),
                    UrlType = table.Column<short>(type: "smallint", nullable: false),
                    Excerpt = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    MenuOrder = table.Column<int>(maxLength: 255, nullable: false, defaultValue: 1),
                    Picture = table.Column<string>(type: "ntext", nullable: false),
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(maxLength: 250, nullable: false),
                    PostContent = table.Column<string>(type: "ntext", nullable: true),
                    PostExcerpt = table.Column<string>(type: "ntext", nullable: true),
                    PostStatus = table.Column<bool>(nullable: false),
                    CommentStatus = table.Column<bool>(nullable: false),
                    PostPassword = table.Column<string>(maxLength: 255, nullable: true),
                    PostSlug = table.Column<string>(maxLength: 255, nullable: true),
                    MenuOrder = table.Column<int>(maxLength: 255, nullable: false, defaultValue: 1),
                    PostType = table.Column<short>(type: "smallint", nullable: true, defaultValue: (short)1),
                    CommentCount = table.Column<long>(nullable: false, defaultValue: 1L),
                    Picture = table.Column<string>(type: "ntext", nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true),
                    CategoryId = table.Column<int>(nullable: true)
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
                    ProjeBaslangicTarihi = table.Column<DateTime>(nullable: true),
                    ProjeBitisTarihi = table.Column<DateTime>(nullable: true),
                    DeneyHayvaniCinsiyet = table.Column<short>(type: "smallint", nullable: false),
                    DeneyHayvaniSayisi = table.Column<short>(type: "smallint", nullable: false),
                    DeneyHayvaniYasi = table.Column<short>(type: "smallint", nullable: false),
                    DeneyHayvaniAgirligi = table.Column<short>(type: "smallint", nullable: false),
                    LaboratuvarBaslangicTarihi = table.Column<DateTime>(nullable: true),
                    LaboratuvarBitisTarihi = table.Column<DateTime>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: true),
                    DeneyHayvaniIrkID = table.Column<int>(nullable: false),
                    DeneyHayvaniTurID = table.Column<int>(nullable: false),
                    LaboratuvarID = table.Column<int>(nullable: false),
                    TeknikHayvanSayisiID = table.Column<int>(nullable: false),
                    TeknikDestekSuresiID = table.Column<int>(nullable: false),
                    TeknikDestekTuruID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DekamProjeTakip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniIrk_DeneyHayvaniIrkID",
                        column: x => x.DeneyHayvaniIrkID,
                        principalTable: "DekamProjeDeneyHayvaniIrk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeDeneyHayvaniTur_DeneyHayvaniTurID",
                        column: x => x.DeneyHayvaniTurID,
                        principalTable: "DekamProjeDeneyHayvaniTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeLaboratuvarlar_LaboratuvarID",
                        column: x => x.LaboratuvarID,
                        principalTable: "DekamProjeLaboratuvarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepSure_TeknikDestekSuresiID",
                        column: x => x.TeknikDestekSuresiID,
                        principalTable: "DekamProjeTeknikDestekTalepSure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeTeknikDestekTalepTur_TeknikDestekTuruID",
                        column: x => x.TeknikDestekTuruID,
                        principalTable: "DekamProjeTeknikDestekTalepTur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DekamProjeTakip_DekamProjeDeneyHayvanSayisi_TeknikHayvanSayisiID",
                        column: x => x.TeknikHayvanSayisiID,
                        principalTable: "DekamProjeDeneyHayvanSayisi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Raporlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tanim = table.Column<string>(maxLength: 100, nullable: false),
                    Detay = table.Column<string>(type: "ntext", nullable: true),
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
                name: "CategoryBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<int>(nullable: false),
                    PostsId = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryBlogs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBlogs_DekamProjeTakip_PostsId",
                        column: x => x.PostsId,
                        principalTable: "DekamProjeTakip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CommentContent = table.Column<string>(type: "ntext", nullable: true),
                    CommentAuthor = table.Column<string>(maxLength: 100, nullable: false),
                    CommentAuthorEmail = table.Column<string>(maxLength: 100, nullable: false),
                    CommentAuthorUrl = table.Column<string>(maxLength: 255, nullable: false),
                    CommentAuthorIP = table.Column<string>(maxLength: 255, nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CommentDateGmt = table.Column<DateTime>(nullable: true),
                    CommentApproved = table.Column<string>(maxLength: 1, nullable: true, defaultValue: "0"),
                    CommentAgent = table.Column<string>(maxLength: 255, nullable: false),
                    CommentType = table.Column<string>(maxLength: 255, nullable: false),
                    CommentParent = table.Column<long>(maxLength: 255, nullable: false),
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
                        name: "FK_Comments_DekamProjeTakip_PostsId",
                        column: x => x.PostsId,
                        principalTable: "DekamProjeTakip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Slider",
                columns: new[] { "Id", "AppUserId", "Caption", "CreatedAt", "DeletedAt", "Excerpt", "MenuOrder", "Picture", "Status", "UpdatedAt", "UrlAddress", "UrlType" },
                values: new object[] { 1598024890, null, "Lorem ipsum laramde loremde ipsumda inmpala", new DateTime(2020, 8, 28, 12, 23, 53, 232, DateTimeKind.Local).AddTicks(4363), null, "exceprt data loremmmmmm ipsummmmm", 1, "default.jpg", true, new DateTime(2020, 8, 28, 12, 23, 53, 233, DateTimeKind.Local).AddTicks(3215), "", (short)0 });

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
                name: "IX_CategoryBlogs_CategoryID",
                table: "CategoryBlogs",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlogs_PostsId",
                table: "CategoryBlogs",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlogs_PostID_CategoryID",
                table: "CategoryBlogs",
                columns: new[] { "PostID", "CategoryID" },
                unique: true);

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
                name: "IX_DekamProjeDeneyHayvaniTur_AppUserId",
                table: "DekamProjeDeneyHayvaniTur",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeDeneyHayvanSayisi_AppUserId",
                table: "DekamProjeDeneyHayvanSayisi",
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

            migrationBuilder.CreateIndex(
                name: "IX_DekamProjeTeknikDestekTalepSure_AppUserId",
                table: "DekamProjeTeknikDestekTalepSure",
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
                name: "IX_Slider_AppUserId",
                table: "Slider",
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
                name: "CategoryBlogs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Raporlar");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DekamProjeTakip");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Gorevler");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniIrk");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvaniTur");

            migrationBuilder.DropTable(
                name: "DekamProjeLaboratuvarlar");

            migrationBuilder.DropTable(
                name: "DekamProjeTeknikDestekTalepSure");

            migrationBuilder.DropTable(
                name: "DekamProjeTeknikDestekTalepTur");

            migrationBuilder.DropTable(
                name: "DekamProjeDeneyHayvanSayisi");

            migrationBuilder.DropTable(
                name: "Aciliyetler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
