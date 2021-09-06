using Microsoft.EntityFrameworkCore.Migrations;

namespace DisneyCodeFirst.Migrations
{
    public partial class SegundaDisney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personaje_PeliculaOSerie_PeliculaOSerieID",
                table: "Personaje");

            migrationBuilder.DropIndex(
                name: "IX_Personaje_PeliculaOSerieID",
                table: "Personaje");

            migrationBuilder.DropColumn(
                name: "PeliculaOSerieID",
                table: "Personaje");

            migrationBuilder.CreateTable(
                name: "PeliculaOSeriePersonaje",
                columns: table => new
                {
                    PeliculaOSeriesID = table.Column<int>(type: "int", nullable: false),
                    personajeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaOSeriePersonaje", x => new { x.PeliculaOSeriesID, x.personajeID });
                    table.ForeignKey(
                        name: "FK_PeliculaOSeriePersonaje_PeliculaOSerie_PeliculaOSeriesID",
                        column: x => x.PeliculaOSeriesID,
                        principalTable: "PeliculaOSerie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaOSeriePersonaje_Personaje_personajeID",
                        column: x => x.personajeID,
                        principalTable: "Personaje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaOSeriePersonaje_personajeID",
                table: "PeliculaOSeriePersonaje",
                column: "personajeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaOSeriePersonaje");

            migrationBuilder.AddColumn<int>(
                name: "PeliculaOSerieID",
                table: "Personaje",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personaje_PeliculaOSerieID",
                table: "Personaje",
                column: "PeliculaOSerieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personaje_PeliculaOSerie_PeliculaOSerieID",
                table: "Personaje",
                column: "PeliculaOSerieID",
                principalTable: "PeliculaOSerie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
