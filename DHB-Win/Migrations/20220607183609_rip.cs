using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class rip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                newName: "UserForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                newName: "IX_Bet_UserForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                newName: "UID_fk2");

            migrationBuilder.RenameIndex(
                name: "IX_Bet_UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                newName: "IX_Bet_UID_fk2");
        }
    }
}
