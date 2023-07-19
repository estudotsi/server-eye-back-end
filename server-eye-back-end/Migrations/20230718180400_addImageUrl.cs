using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_eye_back_end.Migrations
{
    public partial class addImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemURL",
                table: "Oss",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemURL",
                table: "Oss");
        }
    }
}
