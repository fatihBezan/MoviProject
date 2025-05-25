using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieProject.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist_db",
                columns: table => new
                {
                    ArtistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist_db", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Categories_db",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_db", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Director_db",
                columns: table => new
                {
                    DirectorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director_db", x => x.DirectorId);
                });

            migrationBuilder.CreateTable(
                name: "Movies_db",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMDB = table.Column<double>(type: "float", nullable: false),
                    PublishTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DirectorId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies_db", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_db_Categories_db_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories_db",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_db_Director_db_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director_db",
                        principalColumn: "DirectorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieArtist_db",
                columns: table => new
                {
                    MovieArtistId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<long>(type: "bigint", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieArtist_db", x => x.MovieArtistId);
                    table.ForeignKey(
                        name: "FK_MovieArtist_db_Artist_db_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist_db",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieArtist_db_Movies_db_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies_db",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories_db",
                columns: new[] { "CategoryId", "Created", "CategoryName", "UpdateTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 13, 20, 53, 7, 511, DateTimeKind.Utc).AddTicks(5377), "korku", null },
                    { 2, new DateTime(2025, 5, 13, 20, 53, 7, 511, DateTimeKind.Utc).AddTicks(5378), "dram", null }
                });

            migrationBuilder.InsertData(
                table: "Director_db",
                columns: new[] { "DirectorId", "BirthDay", "Created", "ImageUrl", "Name", "Surname", "UpdateTime" },
                values: new object[] { 1L, new DateTime(1959, 2, 9, 16, 39, 25, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 13, 20, 53, 7, 511, DateTimeKind.Utc).AddTicks(8115), "https://www.hollywoodreporter.com/movies/movie-news/legend-of-the-croisette-nuri-bilge-ceylan-cannes2023-1235502380/", "Nuri bilge", "Ceylan", null });

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtist_db_ArtistId",
                table: "MovieArtist_db",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtist_db_MovieId",
                table: "MovieArtist_db",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_db_CategoryId",
                table: "Movies_db",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_db_DirectorId",
                table: "Movies_db",
                column: "DirectorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieArtist_db");

            migrationBuilder.DropTable(
                name: "Artist_db");

            migrationBuilder.DropTable(
                name: "Movies_db");

            migrationBuilder.DropTable(
                name: "Categories_db");

            migrationBuilder.DropTable(
                name: "Director_db");
        }
    }
}
