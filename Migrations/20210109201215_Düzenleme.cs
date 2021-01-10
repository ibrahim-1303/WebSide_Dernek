using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje008.Migrations
{
    public partial class Düzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnasayfaAciklama5",
                table: "Anasayfas");

            migrationBuilder.DropColumn(
                name: "AnasayfaBaslik5",
                table: "Anasayfas");

            migrationBuilder.DropColumn(
                name: "PeopleSaysAciklama",
                table: "Anasayfas");

            migrationBuilder.DropColumn(
                name: "PeopleSaysBaslik",
                table: "Anasayfas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnasayfaAciklama5",
                table: "Anasayfas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnasayfaBaslik5",
                table: "Anasayfas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeopleSaysAciklama",
                table: "Anasayfas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeopleSaysBaslik",
                table: "Anasayfas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
