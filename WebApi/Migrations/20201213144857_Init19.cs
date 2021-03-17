using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeerWholesalers");

            migrationBuilder.AddColumn<int>(
                name: "WholesalerBeerId",
                table: "Beers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WholesalerBeerName",
                table: "Beers",
                type: "nvarchar(max)",
                nullable: true);

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
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
