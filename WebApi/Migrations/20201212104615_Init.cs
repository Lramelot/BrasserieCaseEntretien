using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breweries",
                columns: table => new
                {
                    BreweryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreweryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breweries", x => x.BreweryId);
                });

            migrationBuilder.CreateTable(
                name: "Wholesalers",
                columns: table => new
                {
                    WholesalerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WholesalerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wholesalers", x => x.WholesalerId);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BreweryBeerId = table.Column<int>(type: "int", nullable: false),
                    WholesalerBeerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                    table.ForeignKey(
                        name: "FK_Beers_Breweries_BreweryBeerId",
                        column: x => x.BreweryBeerId,
                        principalTable: "Breweries",
                        principalColumn: "BreweryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beers_Wholesalers_WholesalerBeerId",
                        column: x => x.WholesalerBeerId,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryBeerId",
                table: "Beers",
                column: "BreweryBeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_WholesalerBeerId",
                table: "Beers",
                column: "WholesalerBeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Breweries");

            migrationBuilder.DropTable(
                name: "Wholesalers");
        }
    }
}
