using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver236 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Users_UserId",
                table: "Notices");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notices",
                newName: "AddresseeId");

            migrationBuilder.RenameIndex(
                name: "IX_Notices_UserId",
                table: "Notices",
                newName: "IX_Notices_AddresseeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Users_AddresseeId",
                table: "Notices",
                column: "AddresseeId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Users_AddresseeId",
                table: "Notices");

            migrationBuilder.RenameColumn(
                name: "AddresseeId",
                table: "Notices",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notices_AddresseeId",
                table: "Notices",
                newName: "IX_Notices_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Users_UserId",
                table: "Notices",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
