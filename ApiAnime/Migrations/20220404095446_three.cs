using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAnime.Migrations
{
    public partial class three : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Producers",
                table: "AnimeData",
                newName: "Studios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Studios",
                table: "AnimeData",
                newName: "Producers");
        }
    }
}
