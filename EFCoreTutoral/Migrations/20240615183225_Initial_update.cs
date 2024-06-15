using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreTutoral.Migrations
{
    /// <inheritdoc />
    public partial class Initial_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Songs_T_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "T_Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_Songs_T_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "T_Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "T_Artists",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Johnny", "Cash" },
                    { 2, "Jimmy", "Buffet" },
                    { 3, "Home", "Free" },
                    { 4, "Justin", "Johnson" },
                    { 5, "Def", "Leppard" }
                });

            migrationBuilder.InsertData(
                table: "T_Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "Rock and Roll" },
                    { 2, "R&B" },
                    { 3, "Country" },
                    { 4, "Pop" },
                    { 5, "Easy Listening" },
                    { 6, "Blues" }
                });

            migrationBuilder.InsertData(
                table: "T_Songs",
                columns: new[] { "Id", "ArtistId", "GenreId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Your Heartless" },
                    { 2, 1, 3, "Ride Bikes" },
                    { 3, 1, 3, "Your Heartless" },
                    { 4, 1, 3, "Wayfaring Stranger" },
                    { 5, 2, 2, "Son of a Sailor" },
                    { 6, 3, 3, "Sea Shanty" },
                    { 7, 2, 3, "Island" },
                    { 8, 3, 3, "Man of Constant Sorrow" },
                    { 9, 4, 6, "Laid-Back Delta Blues" },
                    { 10, 5, 1, "Pour Some Sugar on Me" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Songs_ArtistId",
                table: "T_Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_T_Songs_GenreId",
                table: "T_Songs",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Songs");

            migrationBuilder.DropTable(
                name: "T_Artists");

            migrationBuilder.DropTable(
                name: "T_Genres");
        }
    }
}
