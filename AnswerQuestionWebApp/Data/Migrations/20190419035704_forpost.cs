using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class forpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUsersId",
                table: "posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubtagId",
                table: "posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "subtags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subtags", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_ApplicationUsersId",
                table: "posts",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_SubtagId",
                table: "posts",
                column: "SubtagId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_ApplicationUsersId",
                table: "posts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_subtags_SubtagId",
                table: "posts",
                column: "SubtagId",
                principalTable: "subtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_ApplicationUsersId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_subtags_SubtagId",
                table: "posts");

            migrationBuilder.DropTable(
                name: "subtags");

            migrationBuilder.DropIndex(
                name: "IX_posts_ApplicationUsersId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_SubtagId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "ApplicationUsersId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "SubtagId",
                table: "posts");
        }
    }
}
