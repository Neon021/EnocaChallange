using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    public partial class AddedFKtoMovieModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salons");

            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "MovieModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SalonModelId",
                table: "MovieModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SalonModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalonModels", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieModels_SalonModels_SalonModelId",
                table: "MovieModels");

            migrationBuilder.DropTable(
                name: "SalonModels");

            migrationBuilder.DropIndex(
                name: "IX_MovieModels_SalonModelId",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "SalonModelId",
                table: "MovieModels");

            migrationBuilder.CreateTable(
                name: "Salons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salons", x => x.Id);
                });
        }
    }
}
