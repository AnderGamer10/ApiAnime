using Microsoft.EntityFrameworkCore.Migrations;


namespace ApiAnime.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_User_UserData_UsuarioId",
                table: "Anime_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_Anime_User_UsuarioId",
                table: "Anime_User");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Anime_User");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserData",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Anime_User",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_User_Username",
                table: "Anime_User",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_User_UserData_Username",
                table: "Anime_User",
                column: "Username",
                principalTable: "UserData",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anime_User_UserData_Username",
                table: "Anime_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserData",
                table: "UserData");

            migrationBuilder.DropIndex(
                name: "IX_Anime_User_Username",
                table: "Anime_User");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Anime_User");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Anime_User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserData",
                table: "UserData",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Anime_User_UsuarioId",
                table: "Anime_User",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anime_User_UserData_UsuarioId",
                table: "Anime_User",
                column: "UsuarioId",
                principalTable: "UserData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
