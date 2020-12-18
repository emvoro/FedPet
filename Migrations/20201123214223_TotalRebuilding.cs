using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FedPet.Migrations
{
    public partial class TotalRebuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedings_Pets_Pet_Id",
                table: "Feedings");

            migrationBuilder.DropColumn(
                name: "AddressOfIssuing",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "AuthorizedVeterinarian",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "BatchNumber",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "City",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "CityOfIssuing",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "CountryOfIssuing",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "DateOfVaccination",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "IssuingEmail",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "IssuingPhone",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "ManufacturerAndNameOfVaccine",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "NameOfVeterinarian",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "OwnerAddress",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "OwnerSurname",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "PostCodeOfIssuing",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "SignatureLink",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "ValidFrom",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "ValidUntil",
                table: "VetPassports");

            migrationBuilder.AddColumn<int>(
                name: "PassportIssuingOrgan_Id",
                table: "VetPassports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoLink",
                table: "Pets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Feeders",
                columns: table => new
                {
                    Pet_Id = table.Column<int>(type: "int", nullable: false),
                    AddFood = table.Column<bool>(type: "bit", nullable: false),
                    CurrentWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeders", x => x.Pet_Id);
                    table.ForeignKey(
                        name: "FK_Feeders_Pets_Pet_Id",
                        column: x => x.Pet_Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthIndicators",
                columns: table => new
                {
                    Pet_Id = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Obesity = table.Column<bool>(type: "bit", nullable: false),
                    SensitiveDigestion = table.Column<bool>(type: "bit", nullable: false),
                    Pregnancy = table.Column<bool>(type: "bit", nullable: false),
                    UrolithiasisDisease = table.Column<bool>(type: "bit", nullable: false),
                    HairLoss = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthIndicators", x => x.Pet_Id);
                    table.ForeignKey(
                        name: "FK_HealthIndicators_Pets_Pet_Id",
                        column: x => x.Pet_Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnerDatas",
                columns: table => new
                {
                    Owner_Login = table.Column<string>(type: "nvarchar(40)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerSignatureLink = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerDatas", x => x.Owner_Login);
                    table.ForeignKey(
                        name: "FK_OwnerDatas_Owners_Owner_Login",
                        column: x => x.Owner_Login,
                        principalTable: "Owners",
                        principalColumn: "Login",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassportIssuingOrgans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfVeterinarian = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressOfIssuing = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostCodeOfIssuing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityOfIssuing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CountryOfIssuing = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IssuingPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IssuingEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportIssuingOrgans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Pet_Id = table.Column<int>(type: "int", nullable: false),
                    DateOfFeeding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AmountOfFood = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Pet_Id);
                    table.ForeignKey(
                        name: "FK_Statistics_Pets_Pet_Id",
                        column: x => x.Pet_Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pet_Id = table.Column<int>(type: "int", nullable: false),
                    ManufacturerAndVaccineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfVaccination = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorizedVeterinarian = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Pets_Pet_Id",
                        column: x => x.Pet_Id,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VetPassports_PassportIssuingOrgan_Id",
                table: "VetPassports",
                column: "PassportIssuingOrgan_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_Pet_Id",
                table: "Vaccinations",
                column: "Pet_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedings_Feeders_Pet_Id",
                table: "Feedings",
                column: "Pet_Id",
                principalTable: "Feeders",
                principalColumn: "Pet_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VetPassports_PassportIssuingOrgans_PassportIssuingOrgan_Id",
                table: "VetPassports",
                column: "PassportIssuingOrgan_Id",
                principalTable: "PassportIssuingOrgans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedings_Feeders_Pet_Id",
                table: "Feedings");

            migrationBuilder.DropForeignKey(
                name: "FK_VetPassports_PassportIssuingOrgans_PassportIssuingOrgan_Id",
                table: "VetPassports");

            migrationBuilder.DropTable(
                name: "Feeders");

            migrationBuilder.DropTable(
                name: "HealthIndicators");

            migrationBuilder.DropTable(
                name: "OwnerDatas");

            migrationBuilder.DropTable(
                name: "PassportIssuingOrgans");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_VetPassports_PassportIssuingOrgan_Id",
                table: "VetPassports");

            migrationBuilder.DropColumn(
                name: "PassportIssuingOrgan_Id",
                table: "VetPassports");

            migrationBuilder.AddColumn<string>(
                name: "AddressOfIssuing",
                table: "VetPassports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AuthorizedVeterinarian",
                table: "VetPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BatchNumber",
                table: "VetPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "VetPassports",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CityOfIssuing",
                table: "VetPassports",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "VetPassports",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryOfIssuing",
                table: "VetPassports",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfVaccination",
                table: "VetPassports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IssuingEmail",
                table: "VetPassports",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IssuingPhone",
                table: "VetPassports",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerAndNameOfVaccine",
                table: "VetPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameOfVeterinarian",
                table: "VetPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerAddress",
                table: "VetPassports",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "VetPassports",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OwnerSurname",
                table: "VetPassports",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "VetPassports",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "VetPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostCodeOfIssuing",
                table: "VetPassports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SignatureLink",
                table: "VetPassports",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidFrom",
                table: "VetPassports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidUntil",
                table: "VetPassports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "PhotoLink",
                table: "Pets",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedings_Pets_Pet_Id",
                table: "Feedings",
                column: "Pet_Id",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
