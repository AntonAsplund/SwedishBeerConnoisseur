using Microsoft.EntityFrameworkCore.Migrations;

namespace SwedishBeerConnoisseur.Migrations
{
    public partial class updatedrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Lat",
                table: "Stores",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Long",
                table: "Stores",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RateURating",
                table: "Beverages",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "BeveragesInStore",
                columns: table => new
                {
                    BeverageId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeveragesInStore", x => new { x.StoreId, x.BeverageId });
                    table.ForeignKey(
                        name: "FK_BeveragesInStore_Beverages_BeverageId",
                        column: x => x.BeverageId,
                        principalTable: "Beverages",
                        principalColumn: "BeverageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeveragesInStore_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "StoreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeveragesInStore_BeverageId",
                table: "BeveragesInStore",
                column: "BeverageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeveragesInStore");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Long",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "RateURating",
                table: "Beverages");
        }
    }
}
