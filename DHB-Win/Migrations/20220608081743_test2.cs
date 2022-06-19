using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_UserId",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.AddColumn<string>(
                name: "UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                column: "UserForeignKey");

            migrationBuilder.AddForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                column: "UserForeignKey",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_UserForeignKey",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "UserForeignKey",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UserId",
                schema: "dhbwin",
                table: "Bet",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
