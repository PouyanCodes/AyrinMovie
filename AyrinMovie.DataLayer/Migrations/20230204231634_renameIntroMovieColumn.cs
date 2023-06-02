using Microsoft.EntityFrameworkCore.Migrations;

namespace AyrinMovie.DataLayer.Migrations
{
    public partial class renameIntroMovieColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieIntroduction",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "MovieStory",
                table: "Movies",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieStory",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "MovieIntroduction",
                table: "Movies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
