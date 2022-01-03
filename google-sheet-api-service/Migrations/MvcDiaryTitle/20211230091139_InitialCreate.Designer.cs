﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace google_sheet_api_service.Migrations.MvcDiaryTitle
{
    [DbContext(typeof(MvcDiaryTitleContext))]
    [Migration("20211230091139_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("google_sheet_api_service.Models.DiaryTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("diaryTitleKey")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("diaryTitleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DiaryTitle");
                });
#pragma warning restore 612, 618
        }
    }
}
