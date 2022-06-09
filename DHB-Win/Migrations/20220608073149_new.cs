using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.AlterColumn<string>(
                name: "UsersId",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet");

            migrationBuilder.AlterColumn<string>(
                name: "UsersId",
                schema: "dhbwin",
                table: "Bet",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "UID_fk2",
                schema: "dhbwin",
                table: "Bet",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
