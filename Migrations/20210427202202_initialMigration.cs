using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFE_Khalifa_Sami_2021.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandUser",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Civility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalRegister = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandUser", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "CommandProperty",
                columns: table => new
                {
                    IdProperty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOwner = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentCost = table.Column<float>(type: "real", nullable: false),
                    FixedChargesCost = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandProperty", x => x.IdProperty);
                    table.ForeignKey(
                        name: "FK_CommandProperty_CommandUser_IdOwner",
                        column: x => x.IdOwner,
                        principalTable: "CommandUser",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandContract",
                columns: table => new
                {
                    IdContract = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProperty = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    BeginContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndContract = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuaranteeAmount = table.Column<float>(type: "real", nullable: false),
                    SignatureDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandContract", x => x.IdContract);
                    table.ForeignKey(
                        name: "FK_CommandContract_CommandProperty_IdProperty",
                        column: x => x.IdProperty,
                        principalTable: "CommandProperty",
                        principalColumn: "IdProperty",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommandContract_CommandUser_IdUser",
                        column: x => x.IdUser,
                        principalTable: "CommandUser",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_IdProperty",
                table: "CommandContract",
                column: "IdProperty");

            migrationBuilder.CreateIndex(
                name: "IX_CommandContract_IdUser",
                table: "CommandContract",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CommandProperty_IdOwner",
                table: "CommandProperty",
                column: "IdOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandContract");

            migrationBuilder.DropTable(
                name: "CommandProperty");

            migrationBuilder.DropTable(
                name: "CommandUser");
        }
    }
}
