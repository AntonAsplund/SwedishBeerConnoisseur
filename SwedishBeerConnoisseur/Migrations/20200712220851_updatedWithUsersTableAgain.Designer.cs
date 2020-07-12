﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SwedishBeerConnoisseur.Data;

namespace SwedishBeerConnoisseur.Migrations
{
    [DbContext(typeof(BeerConnoisseurDbContext))]
    [Migration("20200712220851_updatedWithUsersTableAgain")]
    partial class updatedWithUsersTableAgain
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SwedishBeerConnoisseur.Models.Beverage", b =>
                {
                    b.Property<int>("BeverageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AlcoholPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Assortment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssortmentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BeverageDescriptionShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BottleTextShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EthicalLabel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompletelyOutOfStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEthical")
                        .HasColumnType("bit");

                    b.Property<bool>("IsKosher")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNews")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOrganic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTemporaryOutOfStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWebLaunch")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfRateBRatings")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<decimal>("OldHighPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OriginLevel1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginLevel2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProducerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNameBold")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNameThin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNumberShort")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RateBRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RecycleFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestrictedParcelQuantity")
                        .HasColumnType("int");

                    b.Property<string>("Seal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SellStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Style")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Taste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Volume")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BeverageId");

                    b.ToTable("Beverages");
                });

            modelBuilder.Entity("SwedishBeerConnoisseur.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Depot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActiveForAgentOrder")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAgent")
                        .HasColumnType("bit");

                    b.Property<bool>("IsStore")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("SwedishBeerConnoisseur.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
