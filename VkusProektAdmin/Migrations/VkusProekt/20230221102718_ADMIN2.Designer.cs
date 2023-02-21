﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VkusProektAdmin.Connections;

#nullable disable

namespace VkusProektAdmin.Migrations.VkusProekt
{
    [DbContext(typeof(VkusProektContext))]
    [Migration("20230221102718_ADMIN2")]
    partial class ADMIN2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VkusProektAdmin.Bludo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit")
                        .HasColumnName("available");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("categoryID");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("img");

                    b.Property<bool>("IsFavourite")
                        .HasColumnType("bit")
                        .HasColumnName("isFavourite");

                    b.Property<string>("LongDesc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("longDesc");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("ShortDesc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("shortDesc");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Bludo_categoryID");

                    b.ToTable("Bludo", (string)null);
                });

            modelBuilder.Entity("VkusProektAdmin.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("categoryName");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("desc");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("VkusProektAdmin.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)")
                        .HasColumnName("adress")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("email")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("name")
                        .HasDefaultValueSql("(N'')");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("orderTime");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("phone")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("surname")
                        .HasDefaultValueSql("(N'')");

                    b.HasKey("Id");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("VkusProektAdmin.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BludoId")
                        .HasColumnType("int")
                        .HasColumnName("bludoID");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("orderID");

                    b.Property<long>("Price")
                        .HasColumnType("bigint")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BludoId" }, "IX_OrderDetail_bludoID");

                    b.HasIndex(new[] { "OrderId" }, "IX_OrderDetail_orderID");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("VkusProektAdmin.ShopCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Bludoid")
                        .HasColumnType("int")
                        .HasColumnName("bludoid");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<string>("ShopCartId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Bludoid" }, "IX_ShopCartItem_bludoid");

                    b.ToTable("ShopCartItem", (string)null);
                });

            modelBuilder.Entity("VkusProektAdmin.Bludo", b =>
                {
                    b.HasOne("VkusProektAdmin.Category", "Category")
                        .WithMany("Bludos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("VkusProektAdmin.OrderDetail", b =>
                {
                    b.HasOne("VkusProektAdmin.Bludo", "Bludo")
                        .WithMany("OrderDetails")
                        .HasForeignKey("BludoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VkusProektAdmin.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bludo");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("VkusProektAdmin.ShopCartItem", b =>
                {
                    b.HasOne("VkusProektAdmin.Bludo", "Bludo")
                        .WithMany("ShopCartItems")
                        .HasForeignKey("Bludoid");

                    b.Navigation("Bludo");
                });

            modelBuilder.Entity("VkusProektAdmin.Bludo", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ShopCartItems");
                });

            modelBuilder.Entity("VkusProektAdmin.Category", b =>
                {
                    b.Navigation("Bludos");
                });

            modelBuilder.Entity("VkusProektAdmin.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
