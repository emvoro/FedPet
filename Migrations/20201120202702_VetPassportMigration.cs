using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FedPet.Migrations
{
    public partial class VetPassportMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedings",
                columns: table => new
                {
                    Pet_Id = table.Column<int>(type: "int", nullable: false),
                    Portion = table.Column<int>(type: "int", nullable: false),
                    Interval = table.Column<int>(type: "int", nullable: false),
                    FeedingTime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedings", x => x.Pet_Id);
                    table.ForeignKey(
                        name: "FK_Feedings_Pets_Pet_Id",
                        column: x => x.Pet_Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VetPassports",
                columns: table => new
                {
                    Pet_Id = table.Column<int>(type: "int", nullable: false),
                    PassportSerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OwnerSurname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    OwnerAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SignatureLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransponderAlphanumericCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfTransponderApplication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransponderLocation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TattooAlphanumericalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfTattooApplication = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TattooLocation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NameOfVeterinarian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressOfIssuing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCodeOfIssuing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityOfIssuing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryOfIssuing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IssuingPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IssuingEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfIssuing = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManufacturerAndNameOfVaccine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorizedVeterinarian = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetPassports", x => x.Pet_Id);
                    table.ForeignKey(
                        name: "FK_VetPassports_Pets_Pet_Id",
                        column: x => x.Pet_Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedings");

            migrationBuilder.DropTable(
                name: "VetPassports");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
