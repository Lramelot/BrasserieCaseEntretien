using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devis",
                columns: table => new
                {
                    DevisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WholesalerDevisId = table.Column<int>(type: "int", nullable: false),
                    WholesalerDevisName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockDevis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeerDevisId = table.Column<int>(type: "int", nullable: false),
                    BeerDevisName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devis", x => x.DevisId);
                    table.ForeignKey(
                        name: "FK_Devis_Beers_BeerDevisId",
                        column: x => x.BeerDevisId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Devis_Wholesalers_WholesalerDevisId",
                        column: x => x.WholesalerDevisId,
                        principalTable: "Wholesalers",
                        principalColumn: "WholesalerId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devis_BeerDevisId",
                table: "Devis",
                column: "BeerDevisId");

            migrationBuilder.CreateIndex(
                name: "IX_Devis_WholesalerDevisId",
                table: "Devis",
                column: "WholesalerDevisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devis");
        }
    }
}
