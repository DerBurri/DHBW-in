using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class foreignkey2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_UserForeignKey",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.AlterColumn<string>(
                name: "UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_UsersId",
                schema: "dhbwin",
                table: "Bet",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AspNetUsers_UsersId",
                schema: "dhbwin",
                table: "Bet",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AspNetUsers_UsersId",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_UsersId",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "UsersId",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.AlterColumn<string>(
                name: "UserForeignKey",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
