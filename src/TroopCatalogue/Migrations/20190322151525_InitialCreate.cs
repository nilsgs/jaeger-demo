using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TroopCatalogue.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Troopers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troopers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Troopers",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "stromtrooper.png", "Stormtrooper" },
                    { 2, "deathtrooper.png", "Death trooper" },
                    { 3, "shadowtrooper.png", "Shadow trooper" },
                    { 4, "scouttrooper.png", "Scout trooper" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Troopers");
        }
    }
}
