using Microsoft.EntityFrameworkCore.Migrations;

namespace AyrinMovie.DataLayer.Migrations
{
    public partial class removeMovieLinksTableSomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLinks");

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileId",
                table: "Links");

            migrationBuilder.CreateTable(
                name: "MovieLinks",
                columns: table => new
                {
                    MovieLink_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLinks", x => x.MovieLink_Id);
                    table.ForeignKey(
                        name: "FK_MovieLinks_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieLinks_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieLinks_LinkId",
                table: "MovieLinks",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLinks_MovieId",
                table: "MovieLinks",
                column: "MovieId");
        }
    }
}
