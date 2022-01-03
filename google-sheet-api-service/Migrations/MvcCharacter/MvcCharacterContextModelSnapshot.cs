﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcCharacter
{
    [DbContext(typeof(MvcCharacterContext))]
    partial class MvcCharacterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("google_sheet_api_service.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("descriptionKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("gId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("imageKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("islandGid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nameKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("unlockedBuildingGid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("unlockedBuildingLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("unlockedBuildingName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Character");
                });
#pragma warning restore 612, 618
        }
    }
}
