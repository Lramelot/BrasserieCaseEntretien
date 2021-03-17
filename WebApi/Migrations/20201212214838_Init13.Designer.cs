﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

namespace WebApi.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20201212214838_Init13")]
    partial class Init13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("WebApi.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BeerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BreweryBeerId")
                        .HasColumnType("int");

                    b.Property<string>("BreweryBeerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Degree")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("WholesalerBeerId")
                        .HasColumnType("int");

                    b.Property<string>("WholesalerBeerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BeerId");

                    b.HasIndex("BreweryBeerId");

                    b.HasIndex("WholesalerBeerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("WebApi.Models.Brewery", b =>
                {
                    b.Property<int>("BreweryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BreweryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BreweryId");

                    b.ToTable("Breweries");
                });

            modelBuilder.Entity("WebApi.Models.Devis", b =>
                {
                    b.Property<int>("DevisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("BeerDevisId")
                        .HasColumnType("int");

                    b.Property<string>("BeerDevisName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneCustomer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceDevis")
                        .HasColumnType("float");

                    b.Property<double>("StockDevis")
                        .HasColumnType("float");

                    b.Property<int>("WholesalerDevisId")
                        .HasColumnType("int");

                    b.Property<string>("WholesalerDevisName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DevisId");

                    b.HasIndex("BeerDevisId");

                    b.HasIndex("WholesalerDevisId");

                    b.ToTable("Devis");
                });

            modelBuilder.Entity("WebApi.Models.Wholesaler", b =>
                {
                    b.Property<int>("WholesalerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("WholesalerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WholesalerId");

                    b.ToTable("Wholesalers");
                });

            modelBuilder.Entity("WebApi.Models.Beer", b =>
                {
                    b.HasOne("WebApi.Models.Brewery", "BreweryBeer")
                        .WithMany("BBeersList")
                        .HasForeignKey("BreweryBeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Wholesaler", "WholesalerBeer")
                        .WithMany("WBeersList")
                        .HasForeignKey("WholesalerBeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BreweryBeer");

                    b.Navigation("WholesalerBeer");
                });

            modelBuilder.Entity("WebApi.Models.Devis", b =>
                {
                    b.HasOne("WebApi.Models.Beer", "BeerDevis")
                        .WithMany()
                        .HasForeignKey("BeerDevisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Models.Wholesaler", "WholesalerDevis")
                        .WithMany()
                        .HasForeignKey("WholesalerDevisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BeerDevis");

                    b.Navigation("WholesalerDevis");
                });

            modelBuilder.Entity("WebApi.Models.Brewery", b =>
                {
                    b.Navigation("BBeersList");
                });

            modelBuilder.Entity("WebApi.Models.Wholesaler", b =>
                {
                    b.Navigation("WBeersList");
                });
#pragma warning restore 612, 618
        }
    }
}