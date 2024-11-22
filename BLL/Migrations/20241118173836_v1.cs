using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    surName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeCarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeCars_TypeCars_TypeCarId",
                        column: x => x.TypeCarId,
                        principalTable: "TypeCars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDamaged = table.Column<bool>(type: "bit", nullable: false),
                    modelYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeCarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_TypeCars_TypeCarId",
                        column: x => x.TypeCarId,
                        principalTable: "TypeCars",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Ownerid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOwners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarOwners_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarOwners_Owners_Ownerid",
                        column: x => x.Ownerid,
                        principalTable: "Owners",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOwners_CarId",
                table: "CarOwners",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarOwners_Ownerid",
                table: "CarOwners",
                column: "Ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TypeCarId",
                table: "Cars",
                column: "TypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeCars_TypeCarId",
                table: "TypeCars",
                column: "TypeCarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOwners");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "TypeCars");
        }
    }
}
