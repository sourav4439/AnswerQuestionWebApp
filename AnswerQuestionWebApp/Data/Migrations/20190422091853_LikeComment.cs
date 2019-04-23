using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class LikeComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentPosts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommentDescription = table.Column<string>(maxLength: 100, nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    ApplicationUsersId = table.Column<string>(nullable: true),
                    UserIdId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPosts_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentPosts_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CommentPosts_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Likeposts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LikeCount = table.Column<byte>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    ApplicationUsersId = table.Column<string>(nullable: true),
                    UserIdId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likeposts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likeposts_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likeposts_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Likeposts_AspNetUsers_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_ApplicationUsersId",
                table: "CommentPosts",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_PostId",
                table: "CommentPosts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_UserIdId",
                table: "CommentPosts",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_Likeposts_ApplicationUsersId",
                table: "Likeposts",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Likeposts_PostId",
                table: "Likeposts",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likeposts_UserIdId",
                table: "Likeposts",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentPosts");

            migrationBuilder.DropTable(
                name: "Likeposts");
        }
    }
}
