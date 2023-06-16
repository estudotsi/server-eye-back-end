using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_eye_back_end.Migrations
{
    public partial class mudarTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Servers",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Servers",
                newName: "Nome");
        }
    }
}
