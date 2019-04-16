using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class fileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Photo",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
