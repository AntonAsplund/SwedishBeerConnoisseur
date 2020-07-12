using Microsoft.EntityFrameworkCore.Migrations;

namespace SwedishBeerConnoisseur.Migrations
{
    public partial class updateModelDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "LatitudePosition",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "LongitudePosition",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "OpeningHoursToday",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Stores");

            migrationBuilder.AlterColumn<string>(
                name: "SiteId",
                table: "Stores",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Depot",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "Stores",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActiveForAgentOrder",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAgent",
                table: "Stores",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Stores",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductNumberShort",
                table: "Beverages",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "AlcoholPercentage",
                table: "Beverages",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Assortment",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssortmentText",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BeverageDescriptionShort",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BottleTextShort",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EthicalLabel",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompletelyOutOfStock",
                table: "Beverages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNews",
                table: "Beverages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTemporaryOutOfStock",
                table: "Beverages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWebLaunch",
                table: "Beverages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OriginLevel1",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginLevel2",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProducerName",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestrictedParcelQuantity",
                table: "Beverages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Seal",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellStartDate",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "Beverages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Taste",
                table: "Beverages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Depot",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsActiveForAgentOrder",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IsAgent",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "AlcoholPercentage",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "Assortment",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "AssortmentText",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "BeverageDescriptionShort",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "BottleTextShort",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "EthicalLabel",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "IsCompletelyOutOfStock",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "IsNews",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "IsTemporaryOutOfStock",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "IsWebLaunch",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "OriginLevel1",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "OriginLevel2",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "ProducerName",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "RestrictedParcelQuantity",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "Seal",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "SellStartDate",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "Beverages");

            migrationBuilder.DropColumn(
                name: "Taste",
                table: "Beverages");

            migrationBuilder.AlterColumn<int>(
                name: "SiteId",
                table: "Stores",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatitudePosition",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongitudePosition",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningHoursToday",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductNumberShort",
                table: "Beverages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
