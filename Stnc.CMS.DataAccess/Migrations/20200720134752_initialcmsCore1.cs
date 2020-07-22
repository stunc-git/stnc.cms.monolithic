using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Stnc.CMS.DataAccess.Migrations
{
    public partial class InitialcmsCore1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostUserID = table.Column<long>(nullable: false),
                    PostDate = table.Column<DateTime>(nullable: false),
                    PostDateGmt = table.Column<DateTime>(nullable: false),
                    PostTitle = table.Column<string>(maxLength: 250, nullable: false),
                    PostContent = table.Column<string>(type: "ntext", nullable: true),
                    PostExcerpt = table.Column<string>(type: "ntext", nullable: true),
                    PostStatus = table.Column<string>(maxLength: 1, nullable: false),
                    CommentStatus = table.Column<string>(maxLength: 1, nullable: true),
                    PostPassword = table.Column<string>(maxLength: 255, nullable: true),
                    PostSlug = table.Column<string>(maxLength: 255, nullable: true),
                    MenuOrder = table.Column<int>(maxLength: 255, nullable: false),
                    PostType = table.Column<string>(nullable: true, defaultValue: "1"),
                    CommentCount = table.Column<long>(nullable: false, defaultValue: 0L),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    AppUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryBlogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<long>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBlogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryBlogs_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryBlogs_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
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
                    PostsId = table.Column<long>(nullable: true)
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
                        name: "FK_Comments_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBlogs_CategoryID",
                table: "CategoryBlogs",
                column: "CategoryID");

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
                name: "IX_Posts_AppUserId",
                table: "Posts",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryBlogs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
