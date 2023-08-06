using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroApi.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "SuperHeroes");

            migrationBuilder.AddColumn<int>(
                name: "IdPlace",
                table: "SuperHeroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlaceId",
                table: "SuperHeroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SuperHeroes_PlaceId",
                table: "SuperHeroes",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperHeroes_Places_PlaceId",
                table: "SuperHeroes",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperHeroes_Places_PlaceId",
                table: "SuperHeroes");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropIndex(
                name: "IX_SuperHeroes_PlaceId",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "IdPlace",
                table: "SuperHeroes");

            migrationBuilder.DropColumn(
                name: "PlaceId",
                table: "SuperHeroes");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
