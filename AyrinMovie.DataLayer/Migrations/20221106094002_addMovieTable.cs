using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AyrinMovie.DataLayer.Migrations
{
    public partial class addMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieGroups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGroups", x => x.GroupId);
                    table.ForeignKey(
                        name: "FK_MovieGroups_MovieGroups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MovieGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    SubGroup = table.Column<int>(type: "int", nullable: true),
                    MovieTitle = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieIntroduction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MovieSatisfaction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IMDBScore = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MovieGenre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryMaker = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ProductionYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Actors = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    MovieTime = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    MovieAges = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    MovieImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MovieTrailerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_MovieGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "MovieGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_MovieGroups_SubGroup",
                        column: x => x.SubGroup,
                        principalTable: "MovieGroups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieGroups_ParentId",
                table: "MovieGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GroupId",
                table: "Movies",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_SubGroup",
                table: "Movies",
                column: "SubGroup");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "MovieGroups");
        }
    }
}
