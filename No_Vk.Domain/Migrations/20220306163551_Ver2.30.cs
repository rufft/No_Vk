using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver230 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Chats_ChatsId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Users_UsersId",
                table: "ChatUser");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ChatUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ChatsId",
                table: "ChatUser",
                newName: "ChatId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_UsersId",
                table: "ChatUser",
                newName: "IX_ChatUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Chats_ChatId",
                table: "ChatUser",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Users_UserId",
                table: "ChatUser",
                column: "UserId",
                principalTable: "UserIds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Chats_ChatId",
                table: "ChatUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatUser_Users_UserId",
                table: "ChatUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ChatUser",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "ChatId",
                table: "ChatUser",
                newName: "ChatsId");

            migrationBuilder.RenameIndex(
                name: "IX_ChatUser_UserId",
                table: "ChatUser",
                newName: "IX_ChatUser_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Chats_ChatsId",
                table: "ChatUser",
                column: "ChatsId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatUser_Users_UsersId",
                table: "ChatUser",
                column: "UsersId",
                principalTable: "UserIds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
