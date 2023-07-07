using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_eye_back_end.Migrations
{
    public partial class realAppDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DBId",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Apps_DBId",
                table: "Apps",
                column: "DBId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_DBs_DBId",
                table: "Apps",
                column: "DBId",
                principalTable: "DBs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_DBs_DBId",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_DBId",
                table: "Apps");

            migrationBuilder.DropColumn(
                name: "DBId",
                table: "Apps");
        }
    }
}
