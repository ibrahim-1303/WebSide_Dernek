using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje008.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anasayfas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResimYolu = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AnasayfaBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimYolu1 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ResimYolu2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ResimYolu3 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AnasayfaBaslik2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaAciklama2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaBaslik3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaAciklama3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaBaslik4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaAciklama4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaBaslik5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnasayfaAciklama5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResimYolu4 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PeopleSaysBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeopleSaysAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anasayfas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anasayfas");
        }
    }
}
