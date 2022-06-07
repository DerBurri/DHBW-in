using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class foreignkey4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                newName: "IX_Bet_UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsersId",
                schema: "dhbwin",
                table: "Bet",
                newName: "UserForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UsersId",
                schema: "dhbwin",
                table: "Bet",
                newName: "IX_Bet_UserForeignKey");
        }
    }
}
