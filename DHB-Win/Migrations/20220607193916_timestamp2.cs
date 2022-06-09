using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class timestamp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "dhbwin",
                table: "Bet",
                type: "datetime",
                rowVersion: true,
                nullable: true,
                computedColumnSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldRowVersion: true,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "dhbwin",
                table: "Bet",
                type: "datetime",
                rowVersion: true,
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldRowVersion: true,
                oldNullable: true,
                oldComputedColumnSql: "getutcdate()");
        }
    }
}
