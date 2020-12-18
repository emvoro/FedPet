using Microsoft.EntityFrameworkCore.Migrations;

namespace FedPet.Migrations
{
    public partial class StatisticsAddKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Pet_Id",
                table: "Statistics",
                column: "Pet_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Statistics_Pet_Id",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Statistics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistics",
                table: "Statistics",
                column: "Pet_Id");
        }
    }
}
