using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnswerQuestionWebApp.Data.Migrations
{
    public partial class Changephoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Photo",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Photo",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(byte[]));
        }
    }
}
