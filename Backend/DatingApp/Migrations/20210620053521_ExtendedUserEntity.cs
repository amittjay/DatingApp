using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.Migrations
{
    public partial class ExtendedUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_appUsersId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "appUsersId",
                table: "Photos",
                newName: "AppUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_appUsersId",
                table: "Photos",
                newName: "IX_Photos_AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_AppUsersId",
                table: "Photos",
                column: "AppUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_AppUsersId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "AppUsersId",
                table: "Photos",
                newName: "appUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_AppUsersId",
                table: "Photos",
                newName: "IX_Photos_appUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_appUsersId",
                table: "Photos",
                column: "appUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
