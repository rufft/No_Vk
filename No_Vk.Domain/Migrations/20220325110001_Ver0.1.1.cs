using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_FriendUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_FromUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Users_AddresseeId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_AddresseeId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friend");

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddresseeId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "Object",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notices");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Users",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AddresseeId",
                table: "Notices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Object",
                table: "Notices",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notices",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Notices_AddresseeId",
                table: "Notices",
                column: "AddresseeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Users_AddresseeId",
                table: "Notices",
                column: "AddresseeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
