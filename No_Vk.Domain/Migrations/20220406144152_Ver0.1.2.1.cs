using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver0121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddresseeId",
                table: "Notices",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notices_AddresseeId",
                table: "Notices",
                column: "AddresseeId");

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

            migrationBuilder.DropIndex(
                name: "IX_Notices_AddresseeId",
                table: "Notices");

            migrationBuilder.DropColumn(
                name: "AddresseeId",
                table: "Notices");
        }
    }
}
