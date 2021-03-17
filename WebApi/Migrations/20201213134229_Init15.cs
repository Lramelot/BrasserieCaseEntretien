using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Wholesalers_WholesalerBeerId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_WholesalerBeerId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "WholesalerBeerId",
                table: "Beers");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerWholesaler");

            migrationBuilder.AddColumn<int>(
                name: "WholesalerBeerId",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_WholesalerBeerId",
                table: "Beers",
                column: "WholesalerBeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Wholesalers_WholesalerBeerId",
                table: "Beers",
                column: "WholesalerBeerId",
                principalTable: "Wholesalers",
                principalColumn: "WholesalerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
