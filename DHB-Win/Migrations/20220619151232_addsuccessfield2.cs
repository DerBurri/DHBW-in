using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class addsuccessfield2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "finished",
                schema: "dhbwin",
                table: "Bet",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "finished",
                schema: "dhbwin",
                table: "Bet");
        }
    }
}
