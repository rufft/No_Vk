using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver0124 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageCreationTime",
                table: "Messages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FriendUserId",
                table: "Friend",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChatCreationTime",
                table: "Chats",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friend",
                column: "FriendUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Users_FriendUserId",
                table: "Friend",
                column: "FriendUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_FromUserId",
                table: "Messages",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_FriendUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageCreationTime",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FriendUserId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "ChatCreationTime",
                table: "Chats");
        }
    }
}
