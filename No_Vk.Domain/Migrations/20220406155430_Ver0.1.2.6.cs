using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver0126 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_Users_MyId",
                table: "Friend");

            migrationBuilder.DropIndex(
                name: "IX_Friend_MyId",
                table: "Friend");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Friend_MyId",
                table: "Friend",
                column: "MyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_Users_MyId",
                table: "Friend",
                column: "MyId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
