using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class RenameSourceUserColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_SourdeUserId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "SourdeUserId",
                table: "Likes",
                newName: "SourceUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_SourceUserId",
                table: "Likes",
                column: "SourceUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_SourceUserId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "SourceUserId",
                table: "Likes",
                newName: "SourdeUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_SourdeUserId",
                table: "Likes",
                column: "SourdeUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
