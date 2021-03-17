using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerWholesaler");

            migrationBuilder.DropColumn(
                name: "WholesalerBeerName",
                table: "Beers");

            migrationBuilder.CreateTable(
                name: "BeerWholesalers",
                columns: table => new
                {
                    BeerId = table.Column<int>(type: "int", nullable: false),
                    WholesalerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerWholesalers", x => new { x.BeerId, x.WholesalerId });
                    table.ForeignKey(
                        name: "FK_BeerWholesalers_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerWholesalers_Wholesalers_WholesalerId",
                        column: x => x.WholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerWholesalers_WholesalerId",
                table: "BeerWholesalers",
                column: "WholesalerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerWholesalers");

            migrationBuilder.AddColumn<string>(
                name: "WholesalerBeerName",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BeerWholesaler",
                columns: table => new
                {
                    WBeersListBeerId = table.Column<int>(type: "int", nullable: false),
                    WholesalerListBeerWholesalerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeerWholesaler", x => new { x.WBeersListBeerId, x.WholesalerListBeerWholesalerId });
                    table.ForeignKey(
                        name: "FK_BeerWholesaler_Beers_WBeersListBeerId",
                        column: x => x.WBeersListBeerId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeerWholesaler_Wholesalers_WholesalerListBeerWholesalerId",
                        column: x => x.WholesalerListBeerWholesalerId,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeerWholesaler_WholesalerListBeerWholesalerId",
                table: "BeerWholesaler",
                column: "WholesalerListBeerWholesalerId");
        }
    }
}
