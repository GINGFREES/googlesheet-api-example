﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcBuildingLevelSize
{
    [DbContext(typeof(MvcBuildingLevelSizeContext))]
    [Migration("20220102135351_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("google_sheet_api_service.Models.BuildingLevelSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("buildingGid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("buildingLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("buildingName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("buildingSize")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("checkAnim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("islandGid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("levelUpAnim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BuildingLevelSize");
                });
#pragma warning restore 612, 618
        }
    }
}
