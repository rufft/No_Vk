using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notices_Users_UserId",
                table: "Notices");

            migrationBuilder.DropIndex(
                name: "IX_Notices_UserId",
                table: "Notices");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Notices",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notices_UserId",
                table: "Notices",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notices_Users_UserId",
                table: "Notices",
                column: "UserId",
                principalTable: "UserIds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
