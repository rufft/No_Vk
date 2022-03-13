using Microsoft.EntityFrameworkCore.Migrations;

namespace No_Vk.Domain.Migrations
{
    public partial class Ver233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Friend1Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Friend2Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Friends_Users_Friend1Id",
                        column: x => x.Friend1Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Friends_Users_Friend2Id",
                        column: x => x.Friend2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friends_Friend1Id",
                table: "Friends",
                column: "Friend1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_Friend2Id",
                table: "Friends",
                column: "Friend2Id");
        }
    }
}
