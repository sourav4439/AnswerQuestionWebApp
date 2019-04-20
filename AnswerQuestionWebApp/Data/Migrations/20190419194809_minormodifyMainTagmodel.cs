using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class minormodifyMainTagmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_postTags_subtags_SubtagId",
                table: "postTags");

            migrationBuilder.DropIndex(
                name: "IX_postTags_SubtagId",
                table: "postTags");

            migrationBuilder.DropColumn(
                name: "SubtagId",
                table: "postTags");

            migrationBuilder.AddColumn<int>(
                name: "MainTagId",
                table: "subtags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_subtags_MainTagId",
                table: "subtags",
                column: "MainTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_subtags_postTags_MainTagId",
                table: "subtags",
                column: "MainTagId",
                principalTable: "postTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subtags_postTags_MainTagId",
                table: "subtags");

            migrationBuilder.DropIndex(
                name: "IX_subtags_MainTagId",
                table: "subtags");

            migrationBuilder.DropColumn(
                name: "MainTagId",
                table: "subtags");

            migrationBuilder.AddColumn<int>(
                name: "SubtagId",
                table: "postTags",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_postTags_SubtagId",
                table: "postTags",
                column: "SubtagId");

            migrationBuilder.AddForeignKey(
                name: "FK_postTags_subtags_SubtagId",
                table: "postTags",
                column: "SubtagId",
                principalTable: "subtags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
