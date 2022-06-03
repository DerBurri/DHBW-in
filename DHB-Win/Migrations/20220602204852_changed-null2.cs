using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DHB_Win.Migrations
{
    public partial class changednull2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "AspNetUsers",
                type: "char(25)",
                unicode: false,
                fixedLength: true,
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(25)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "char(25)",
                unicode: false,
                fixedLength: true,
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(25)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                type: "char(25)",
                unicode: false,
                fixedLength: true,
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(25)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "AspNetUsers",
                type: "char(25)",
                unicode: false,
                fixedLength: true,
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(25)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "char(25)",
                unicode: false,
                fixedLength: true,
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(25)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "AspNetUsers",
                type: "char(25)",
                unicode: false,
                fixedLength: true,
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(25)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}
