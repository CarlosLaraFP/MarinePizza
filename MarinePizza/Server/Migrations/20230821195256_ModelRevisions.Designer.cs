﻿// <auto-generated />
using System;
using MarinePizza.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarinePizza.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20230821195256_ModelRevisions")]
    partial class ModelRevisions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("MarinePizza.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsGlutenFree")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int?>("SauceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SauceId");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("MarinePizza.Models.Sauce", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sauces");
                });

            modelBuilder.Entity("MarinePizza.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Calories")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaTopping", b =>
                {
                    b.Property<int>("PizzasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ToppingsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PizzasId", "ToppingsId");

                    b.HasIndex("ToppingsId");

                    b.ToTable("PizzaTopping");
                });

            modelBuilder.Entity("MarinePizza.Models.Pizza", b =>
                {
                    b.HasOne("MarinePizza.Models.Sauce", "Sauce")
                        .WithMany()
                        .HasForeignKey("SauceId");

                    b.Navigation("Sauce");
                });

            modelBuilder.Entity("PizzaTopping", b =>
                {
                    b.HasOne("MarinePizza.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarinePizza.Models.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
