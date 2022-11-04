using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    public partial class TryingtheICollectionapproach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieModels_SalonModels_SalonModelId",
                table: "MovieModels");

            migrationBuilder.DropIndex(
                name: "IX_MovieModels_SalonModelId",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "SalonModelId",
                table: "MovieModels");

            migrationBuilder.CreateTable(
                name: "MovieModelSalonModel",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    SalonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieModelSalonModel", x => new { x.MoviesId, x.SalonId });
                    table.ForeignKey(
                        name: "FK_MovieModelSalonModel_MovieModels_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "MovieModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieModelSalonModel_SalonModels_SalonId",
                        column: x => x.SalonId,
                        principalTable: "SalonModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieModelSalonModel_SalonId",
                table: "MovieModelSalonModel",
                column: "SalonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieModelSalonModel");

            migrationBuilder.AddColumn<int>(
                name: "SalonModelId",
                table: "MovieModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieModels_SalonModelId",
                table: "MovieModels",
                column: "SalonModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieModels_SalonModels_SalonModelId",
                table: "MovieModels",
                column: "SalonModelId",
                principalTable: "SalonModels",
                principalColumn: "Id");
        }
    }
}
