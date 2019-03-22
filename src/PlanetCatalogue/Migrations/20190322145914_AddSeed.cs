using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanetCatalogue.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "Forests, mountains; home planet of the House of Organa.", "alderaan.png", "Alderaan" },
                    { 2, "A gas planet with a thin layer of habitable atmosphere.", "bespin.jpg", "Bespin" },
                    { 3, "Cosmopolitan urban world consisting of one planet-wide city.", "coruscant.png", "Coruscant" },
                    { 4, "Desolate ice planet", "hoth.jpg", "Hoth" },
                    { 5, "Forest planet and home of the Wookiees", "kashyyyk.png", "Kashyyyk " },
                    { 6, "Home of Boba Fett", "mandalore.png", "Mandalore" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Planets",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
