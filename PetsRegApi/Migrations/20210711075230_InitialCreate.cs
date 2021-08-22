using Microsoft.EntityFrameworkCore.Migrations;

namespace PetsRegApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetsList",
                columns: table => new
                {
                    petId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    petName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    age = table.Column<int>(nullable: false),
                    species = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsList", x => x.petId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetsList");
        }
    }
}
