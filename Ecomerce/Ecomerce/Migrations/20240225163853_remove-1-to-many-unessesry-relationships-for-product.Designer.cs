﻿// <auto-generated />
using System;
using Ecomerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecomerce.Migrations
{
    [DbContext(typeof(SystemContext))]
    [Migration("20240225163853_remove-1-to-many-unessesry-relationships-for-product")]
    partial class remove1tomanyunessesryrelationshipsforproduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecomerce.Models.Block", b =>
                {
                    b.Property<int?>("Block_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Block_Id"));

                    b.Property<string>("Block_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Block_image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Block_title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Product_Id")
                        .HasColumnType("int");

                    b.HasKey("Block_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Blocks");
                });

            modelBuilder.Entity("Ecomerce.Models.Categoriy", b =>
                {
                    b.Property<int?>("Categoriy_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Categoriy_Id"));

                    b.Property<string>("Categoriy_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categoriy_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Categoriy_Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Ecomerce.Models.Image", b =>
                {
                    b.Property<int?>("Image_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Image_Id"));

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Style_Id")
                        .HasColumnType("int");

                    b.HasKey("Image_Id");

                    b.HasIndex("Style_Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Ecomerce.Models.Product", b =>
                {
                    b.Property<int?>("Product_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Product_Id"));

                    b.Property<string>("Product_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Product_rate")
                        .HasColumnType("int");

                    b.HasKey("Product_Id");

                    b.ToTable("ProductList");
                });

            modelBuilder.Entity("Ecomerce.Models.ProductCategoriy", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriyId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoriyId");

                    b.HasIndex("CategoriyId");

                    b.ToTable("ProductCategoriys");
                });

            modelBuilder.Entity("Ecomerce.Models.ProductSize", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("productSizes");
                });

            modelBuilder.Entity("Ecomerce.Models.Size", b =>
                {
                    b.Property<int?>("SizeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("SizeID"));

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.HasKey("SizeID");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("Ecomerce.Models.Style", b =>
                {
                    b.Property<int?>("Style_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Style_Id"));

                    b.Property<int?>("Product_Id")
                        .HasColumnType("int");

                    b.Property<string>("Style_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Style_price")
                        .HasColumnType("int");

                    b.HasKey("Style_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("Ecomerce.Models.StyleSize", b =>
                {
                    b.Property<int>("StyleId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("StyleId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("StyleSizes");
                });

            modelBuilder.Entity("Ecomerce.Models.Block", b =>
                {
                    b.HasOne("Ecomerce.Models.Product", null)
                        .WithMany("Product_blocks")
                        .HasForeignKey("Product_Id");
                });

            modelBuilder.Entity("Ecomerce.Models.Image", b =>
                {
                    b.HasOne("Ecomerce.Models.Style", null)
                        .WithMany("Style_images")
                        .HasForeignKey("Style_Id");
                });

            modelBuilder.Entity("Ecomerce.Models.ProductCategoriy", b =>
                {
                    b.HasOne("Ecomerce.Models.Categoriy", "categoriy")
                        .WithMany()
                        .HasForeignKey("CategoriyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecomerce.Models.Product", "product")
                        .WithMany("Product_Categoriys")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoriy");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Ecomerce.Models.ProductSize", b =>
                {
                    b.HasOne("Ecomerce.Models.Product", "product")
                        .WithMany("Product_sizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecomerce.Models.Size", "size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");

                    b.Navigation("size");
                });

            modelBuilder.Entity("Ecomerce.Models.Style", b =>
                {
                    b.HasOne("Ecomerce.Models.Product", null)
                        .WithMany("Product_styles")
                        .HasForeignKey("Product_Id");
                });

            modelBuilder.Entity("Ecomerce.Models.StyleSize", b =>
                {
                    b.HasOne("Ecomerce.Models.Size", "size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecomerce.Models.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Style");

                    b.Navigation("size");
                });

            modelBuilder.Entity("Ecomerce.Models.Product", b =>
                {
                    b.Navigation("Product_Categoriys");

                    b.Navigation("Product_blocks");

                    b.Navigation("Product_sizes");

                    b.Navigation("Product_styles");
                });

            modelBuilder.Entity("Ecomerce.Models.Style", b =>
                {
                    b.Navigation("Style_images");
                });
#pragma warning restore 612, 618
        }
    }
}
