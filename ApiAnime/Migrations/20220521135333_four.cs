using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiAnime.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Biografia",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Biografia",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "UserData");
        }
    }
}
