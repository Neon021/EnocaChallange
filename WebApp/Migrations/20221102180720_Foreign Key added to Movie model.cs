using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NET_Web.Migrations
{
    public partial class ForeignKeyaddedtoMoviemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "MovieModels");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "MovieModels",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MovieModels",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "MovieModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
