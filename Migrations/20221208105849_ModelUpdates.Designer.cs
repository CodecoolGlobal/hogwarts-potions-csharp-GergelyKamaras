﻿// <auto-generated />
using System;
using HogwartsPotions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HogwartsPotions.Migrations
{
    [DbContext(typeof(HogwartsContext))]
    [Migration("20221208105849_ModelUpdates")]
    partial class ModelUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Ingredient", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PotionID")
                        .HasColumnType("bigint");

                    b.Property<long?>("RecipeID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("PotionID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Potion", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<byte>("BrewingStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("RecipeID")
                        .HasColumnType("bigint");

                    b.Property<long?>("StudentID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.HasIndex("StudentID");

                    b.ToTable("Potions");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Recipe", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("StudentID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("StudentID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Room", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Student", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<byte>("HouseType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfDiscoveries")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPotions")
                        .HasColumnType("int");

                    b.Property<byte>("PetType")
                        .HasColumnType("tinyint");

                    b.Property<long?>("RoomID")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Ingredient", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Potion", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("PotionID");

                    b.HasOne("HogwartsPotions.Models.Entities.Recipe", null)
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Potion", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID");

                    b.HasOne("HogwartsPotions.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Recipe");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Recipe", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Student", b =>
                {
                    b.HasOne("HogwartsPotions.Models.Entities.Room", "Room")
                        .WithMany("Residents")
                        .HasForeignKey("RoomID");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Potion", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("HogwartsPotions.Models.Entities.Room", b =>
                {
                    b.Navigation("Residents");
                });
#pragma warning restore 612, 618
        }
    }
}
