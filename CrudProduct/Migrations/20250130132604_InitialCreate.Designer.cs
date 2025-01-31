﻿// <auto-generated />
using System;
using CrudProduct.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrudProduct.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250130132604_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("CrudProduct.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("registrationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
