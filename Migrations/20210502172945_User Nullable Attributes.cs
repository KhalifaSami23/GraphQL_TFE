using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFE_Khalifa_Sami_2021.Migrations
{
    public partial class UserNullableAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Civility",
                table: "CommandUser");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "CommandUser",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "CommandUser",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Civility",
                table: "CommandUser",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
