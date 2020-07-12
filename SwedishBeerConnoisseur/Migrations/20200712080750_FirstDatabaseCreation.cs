using Microsoft.EntityFrameworkCore.Migrations;

namespace SwedishBeerConnoisseur.Migrations
{
    public partial class FirstDatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    BeverageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<int>(nullable: false),
                    ProductNameBold = table.Column<string>(nullable: true),
                    ProductNameThin = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    ProductNumberShort = table.Column<int>(nullable: false),
                    SupplierName = table.Column<string>(nullable: true),
                    IsKosher = table.Column<bool>(nullable: false),
                    IsOrganic = table.Column<bool>(nullable: false),
                    IsEthical = table.Column<bool>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OldHighPrice = table.Column<decimal>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    Usage = table.Column<string>(nullable: true),
                    RecycleFee = table.Column<decimal>(nullable: false),
                    Rating = table.Column<decimal>(nullable: false),
                    NumberOfRatings = table.Column<int>(nullable: false),
                    RateBRating = table.Column<decimal>(nullable: false),
                    NumberOfRateBRatings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.BeverageId);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    StoreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteId = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Alias = table.Column<string>(nullable: true),
                    IsStore = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    LongitudePosition = table.Column<string>(nullable: true),
                    LatitudePosition = table.Column<string>(nullable: true),
                    OpeningHoursToday = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.StoreId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
