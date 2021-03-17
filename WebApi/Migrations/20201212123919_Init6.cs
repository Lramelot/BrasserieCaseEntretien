using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Wholesalers_WholesalerId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_WholesalerId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "BreweryId",
                table: "Beers");

            migrationBuilder.DropColumn(
                name: "WholesalerId",
                table: "Beers");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryBeerId",
                table: "Beers",
                column: "BreweryBeerId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_WholesalerBeerId",
                table: "Beers",
                column: "WholesalerBeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweryBeerId",
                table: "Beers",
                column: "BreweryBeerId",
                principalTable: "Breweries",
                principalColumn: "BreweryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Wholesalers_WholesalerBeerId",
                table: "Beers",
                column: "WholesalerBeerId",
                principalTable: "Wholesalers",
                principalColumn: "WholesalerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Breweries_BreweryBeerId",
                table: "Beers");

            migrationBuilder.DropForeignKey(
                name: "FK_Beers_Wholesalers_WholesalerBeerId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_BreweryBeerId",
                table: "Beers");

            migrationBuilder.DropIndex(
                name: "IX_Beers_WholesalerBeerId",
                table: "Beers");

            migrationBuilder.AddColumn<int>(
                name: "BreweryId",
                table: "Beers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WholesalerId",
                table: "Beers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beers_BreweryId",
                table: "Beers",
                column: "BreweryId");

            migrationBuilder.CreateIndex(
                name: "IX_Beers_WholesalerId",
                table: "Beers",
                column: "WholesalerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Breweries_BreweryId",
                table: "Beers",
                column: "BreweryId",
                principalTable: "Breweries",
                principalColumn: "BreweryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beers_Wholesalers_WholesalerId",
                table: "Beers",
                column: "WholesalerId",
                principalTable: "Wholesalers",
                principalColumn: "WholesalerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
