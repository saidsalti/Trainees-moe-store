﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SStore.Model.Data;

#nullable disable

namespace SStore.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20230405134852_modify1")]
    partial class modify1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("SStore.Model.Data.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Category", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Order", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("OrderCreated")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderStatusId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("OrderTotalPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderUserId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.OrderDetail", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("OrderTotalPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId", "OrderId")
                        .IsUnique();

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.OrderStatus", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrderStatusNo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("location")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("StatusId");

                    b.HasIndex("ProductId", "OrderId")
                        .IsUnique();

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Payment", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("OrderTotalPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ProductPrice", "OrderTotalPrice")
                        .IsUnique();

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.PaymentMathod", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal?>("TypesofPayment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("productPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PaymentMathod");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductImageId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("ProductPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.ProductCategory", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductId", "CategoryId")
                        .IsUnique();

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.ProductImage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ImageStorgeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModifyBy")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("SStore.Model.Data.Entities.Order", "Order")
                        .WithMany("OrderDetals")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SStore.Model.Data.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.OrderStatus", b =>
                {
                    b.HasOne("SStore.Model.Data.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SStore.Model.Data.Entities.Product", "Product")
                        .WithMany("OrderStatus")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SStore.Model.Data.Entities.OrderStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Order");

                    b.Navigation("Product");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Payment", b =>
                {
                    b.HasOne("SStore.Model.Data.Entities.Product", null)
                        .WithMany("Payments")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.PaymentMathod", b =>
                {
                    b.HasOne("SStore.Model.Data.Entities.Product", null)
                        .WithMany("PaymentMathods")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.ProductCategory", b =>
                {
                    b.HasOne("SStore.Model.Data.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SStore.Model.Data.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.ProductImage", b =>
                {
                    b.HasOne("SStore.Model.Data.Entities.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Order", b =>
                {
                    b.Navigation("OrderDetals");
                });

            modelBuilder.Entity("SStore.Model.Data.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("OrderStatus");

                    b.Navigation("PaymentMathods");

                    b.Navigation("Payments");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
