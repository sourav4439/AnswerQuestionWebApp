using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class ModifyLikeComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_AspNetUsers_ApplicationUsersId",
                table: "CommentPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_AspNetUsers_UserIdId",
                table: "CommentPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Likeposts_AspNetUsers_ApplicationUsersId",
                table: "Likeposts");

            migrationBuilder.DropForeignKey(
                name: "FK_Likeposts_AspNetUsers_UserIdId",
                table: "Likeposts");

            migrationBuilder.DropIndex(
                name: "IX_Likeposts_UserIdId",
                table: "Likeposts");

            migrationBuilder.DropIndex(
                name: "IX_CommentPosts_UserIdId",
                table: "CommentPosts");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "Likeposts");

            migrationBuilder.DropColumn(
                name: "UserIdId",
                table: "CommentPosts");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUsersId",
                table: "Likeposts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUsersId",
                table: "CommentPosts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_AspNetUsers_ApplicationUsersId",
                table: "CommentPosts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likeposts_AspNetUsers_ApplicationUsersId",
                table: "Likeposts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPosts_AspNetUsers_ApplicationUsersId",
                table: "CommentPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Likeposts_AspNetUsers_ApplicationUsersId",
                table: "Likeposts");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUsersId",
                table: "Likeposts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "Likeposts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUsersId",
                table: "CommentPosts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "UserIdId",
                table: "CommentPosts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Likeposts_UserIdId",
                table: "Likeposts",
                column: "UserIdId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPosts_UserIdId",
                table: "CommentPosts",
                column: "UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_AspNetUsers_ApplicationUsersId",
                table: "CommentPosts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPosts_AspNetUsers_UserIdId",
                table: "CommentPosts",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likeposts_AspNetUsers_ApplicationUsersId",
                table: "Likeposts",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likeposts_AspNetUsers_UserIdId",
                table: "Likeposts",
                column: "UserIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
