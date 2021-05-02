using Microsoft.EntityFrameworkCore.Migrations;

namespace TFE_Khalifa_Sami_2021.Migrations
{
    public partial class PropertyNullableAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandProperty_CommandUser_IdOwner",
                table: "CommandProperty");

            migrationBuilder.AlterColumn<int>(
                name: "IdOwner",
                table: "CommandProperty",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "FixedChargesCost",
                table: "CommandProperty",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandProperty_CommandUser_IdOwner",
                table: "CommandProperty",
                column: "IdOwner",
                principalTable: "CommandUser",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandProperty_CommandUser_IdOwner",
                table: "CommandProperty");

            migrationBuilder.AlterColumn<int>(
                name: "IdOwner",
                table: "CommandProperty",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "FixedChargesCost",
                table: "CommandProperty",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandProperty_CommandUser_IdOwner",
                table: "CommandProperty",
                column: "IdOwner",
                principalTable: "CommandUser",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
