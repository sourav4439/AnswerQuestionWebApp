using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class Postmodelmodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_posts_PostId",
                table: "CommentPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Likeposts_posts_PostId",
                table: "Likeposts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_AspNetUsers_ApplicationUsersId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_subtags_SubtagId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_postTags_TagId",
                table: "posts");

            migrationBuilder.DropForeignKey(
                name: "FK_subtags_postTags_MainTagId",
                table: "subtags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subtags",
                table: "subtags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_postTags",
                table: "postTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_posts",
                table: "posts");

            migrationBuilder.RenameTable(
                name: "subtags",
                newName: "Subtags");

            migrationBuilder.RenameTable(
                name: "postTags",
                newName: "PostTags");

            migrationBuilder.RenameTable(
                name: "posts",
                newName: "Posts");

            migrationBuilder.RenameIndex(
                name: "IX_subtags_MainTagId",
                table: "Subtags",
                newName: "IX_Subtags_MainTagId");

            migrationBuilder.RenameColumn(
                name: "PostDT",
                table: "Posts",
                newName: "PostDt");

            migrationBuilder.RenameIndex(
                name: "IX_posts_TagId",
                table: "Posts",
                newName: "IX_Posts_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_SubtagId",
                table: "Posts",
                newName: "IX_Posts_SubtagId");

            migrationBuilder.RenameIndex(
                name: "IX_posts_ApplicationUsersId",
                table: "Posts",
                newName: "IX_Posts_ApplicationUsersId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Posts",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subtags",
                table: "Subtags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_Posts_PostId",
                table: "CommentPosts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likeposts_Posts_PostId",
                table: "Likeposts",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUsersId",
                table: "Posts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Subtags_SubtagId",
                table: "Posts",
                column: "SubtagId",
                principalTable: "Subtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostTags_TagId",
                table: "Posts",
                column: "TagId",
                principalTable: "PostTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Subtags_PostTags_MainTagId",
                table: "Subtags",
                column: "MainTagId",
                principalTable: "PostTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_Posts_PostId",
                table: "CommentPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Likeposts_Posts_PostId",
                table: "Likeposts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ApplicationUsersId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Subtags_SubtagId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostTags_TagId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Subtags_PostTags_MainTagId",
                table: "Subtags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subtags",
                table: "Subtags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.RenameTable(
                name: "Subtags",
                newName: "subtags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "postTags");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "posts");

            migrationBuilder.RenameIndex(
                name: "IX_Subtags_MainTagId",
                table: "subtags",
                newName: "IX_subtags_MainTagId");

            migrationBuilder.RenameColumn(
                name: "PostDt",
                table: "posts",
                newName: "PostDT");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_TagId",
                table: "posts",
                newName: "IX_posts_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_SubtagId",
                table: "posts",
                newName: "IX_posts_SubtagId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_ApplicationUsersId",
                table: "posts",
                newName: "IX_posts_ApplicationUsersId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "posts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "posts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_subtags",
                table: "subtags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_postTags",
                table: "postTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_posts",
                table: "posts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_posts_PostId",
                table: "CommentPosts",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likeposts_posts_PostId",
                table: "Likeposts",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_AspNetUsers_ApplicationUsersId",
                table: "posts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_subtags_SubtagId",
                table: "posts",
                column: "SubtagId",
                principalTable: "subtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_postTags_TagId",
                table: "posts",
                column: "TagId",
                principalTable: "postTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_subtags_postTags_MainTagId",
                table: "subtags",
                column: "MainTagId",
                principalTable: "postTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
