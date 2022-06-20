using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Placement_BetOptions_OptionsID_fk",
                schema: "dhbwin",
                table: "Placement");

            migrationBuilder.DropPrimaryKey(
                name: "Placement_pk",
                schema: "dhbwin",
                table: "Placement");

            migrationBuilder.RenameColumn(
                name: "finished",
                schema: "dhbwin",
                table: "Bet",
                newName: "Finished");

            migrationBuilder.AlterColumn<int>(
                name: "OptionID_fk",
                schema: "dhbwin",
                table: "Placement",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "Placement_pk",
                schema: "dhbwin",
                table: "Placement",
                column: "PlacementID")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_Placement_UID_fk",
                schema: "dhbwin",
                table: "Placement",
                column: "UID_fk");

            migrationBuilder.AddForeignKey(
                name: "Placement_BetOptions_OptionsID_fk",
                schema: "dhbwin",
                table: "Placement",
                column: "OptionID_fk",
                principalSchema: "dhbwin",
                principalTable: "BetOptions",
                principalColumn: "OptionsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Placement_BetOptions_OptionsID_fk",
                schema: "dhbwin",
                table: "Placement");

            migrationBuilder.DropPrimaryKey(
                name: "Placement_pk",
                schema: "dhbwin",
                table: "Placement");

            migrationBuilder.DropIndex(
                name: "IX_Placement_UID_fk",
                schema: "dhbwin",
                table: "Placement");

            migrationBuilder.RenameColumn(
                name: "Finished",
                schema: "dhbwin",
                table: "Bet",
                newName: "finished");

            migrationBuilder.AlterColumn<int>(
                name: "OptionID_fk",
                schema: "dhbwin",
                table: "Placement",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "Placement_pk",
                schema: "dhbwin",
                table: "Placement",
                columns: new[] { "UID_fk", "PlacementID", "BetID_fk" })
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "Placement_BetOptions_OptionsID_fk",
                schema: "dhbwin",
                table: "Placement",
                column: "OptionID_fk",
                principalSchema: "dhbwin",
                principalTable: "BetOptions",
                principalColumn: "OptionsID");
        }
    }
}
