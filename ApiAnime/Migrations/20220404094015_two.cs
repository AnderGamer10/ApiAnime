using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAnime.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Studio",
                table: "AnimeData",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "AnimeData",
                newName: "Producers");

            migrationBuilder.RenameColumn(
                name: "Chapters",
                table: "AnimeData",
                newName: "Premiered");

            migrationBuilder.AddColumn<string>(
                name: "Broadcast",
                table: "AnimeData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Demographic",
                table: "AnimeData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "AnimeData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Episodes",
                table: "AnimeData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genres",
                table: "AnimeData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Broadcast",
                table: "AnimeData");

            migrationBuilder.DropColumn(
                name: "Demographic",
                table: "AnimeData");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AnimeData");

            migrationBuilder.DropColumn(
                name: "Episodes",
                table: "AnimeData");

            migrationBuilder.DropColumn(
                name: "Genres",
                table: "AnimeData");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AnimeData",
                newName: "Studio");

            migrationBuilder.RenameColumn(
                name: "Producers",
                table: "AnimeData",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "Premiered",
                table: "AnimeData",
                newName: "Chapters");
        }
    }
}
