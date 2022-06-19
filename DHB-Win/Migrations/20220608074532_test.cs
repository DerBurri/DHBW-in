using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersId",
                schema: "dhbwin",
                table: "Bet",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UsersId",
                schema: "dhbwin",
                table: "Bet",
                newName: "IX_Bet_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "dhbwin",
                table: "Bet",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UserId",
                schema: "dhbwin",
                table: "Bet",
                newName: "IX_Bet_UsersId");
        }
    }
}
