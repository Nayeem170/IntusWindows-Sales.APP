﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales.DAL.Data;

#nullable disable

namespace Sales.DAL.Migrations
{
    [DbContext(typeof(SalesDbContext))]
    partial class SalesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sales.API.Models.ElementType", b =>
                {
                    b.Property<Guid>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("UId");

                    b.ToTable("ElementTypes");

                    b.HasData(
                        new
                        {
                            UId = new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"),
                            Name = "Doors"
                        },
                        new
                        {
                            UId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                            Name = "Window"
                        });
                });

            modelBuilder.Entity("Sales.API.Models.Order", b =>
                {
                    b.Property<Guid>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("UId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            UId = new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"),
                            Name = "New York Building 1",
                            State = "NY"
                        },
                        new
                        {
                            UId = new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"),
                            Name = "California Hotel AJK",
                            State = "CA"
                        });
                });

            modelBuilder.Entity("Sales.API.Models.SubElement", b =>
                {
                    b.Property<Guid>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<Guid>("ElementTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<Guid>("WindowId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UId");

                    b.HasIndex("ElementTypeId");

                    b.HasIndex("WindowId");

                    b.ToTable("SubElements");

                    b.HasData(
                        new
                        {
                            UId = new Guid("b76d17b2-73c6-4071-99ca-40c7fde6c988"),
                            Element = 1,
                            ElementTypeId = new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"),
                            Height = 1850,
                            Quantity = 1,
                            Width = 1200,
                            WindowId = new Guid("a6831805-0892-4b76-878a-32d586d49aad")
                        },
                        new
                        {
                            UId = new Guid("f86e0c8e-52ea-4dc5-abd0-7394fef50f97"),
                            Element = 2,
                            ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                            Height = 1850,
                            Quantity = 1,
                            Width = 800,
                            WindowId = new Guid("a6831805-0892-4b76-878a-32d586d49aad")
                        },
                        new
                        {
                            UId = new Guid("b3ae868a-fb83-40d9-8b04-50b8207357b1"),
                            Element = 3,
                            ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                            Height = 1850,
                            Quantity = 1,
                            Width = 700,
                            WindowId = new Guid("a6831805-0892-4b76-878a-32d586d49aad")
                        },
                        new
                        {
                            UId = new Guid("15c6e0a1-048f-4766-a622-d16caa14dbf7"),
                            Element = 1,
                            ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                            Height = 2000,
                            Quantity = 1,
                            Width = 1500,
                            WindowId = new Guid("1b110392-9652-44b3-81c5-ff2f8689e873")
                        },
                        new
                        {
                            UId = new Guid("de86fd8d-c953-48bb-bef5-b8b7f90bf6c1"),
                            Element = 1,
                            ElementTypeId = new Guid("6d2c8ccb-731b-4ab8-8ec8-089c25917522"),
                            Height = 2200,
                            Quantity = 1,
                            Width = 1400,
                            WindowId = new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd")
                        },
                        new
                        {
                            UId = new Guid("fa6066d3-7ac5-4a47-95ac-d5757f83893a"),
                            Element = 2,
                            ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                            Height = 2200,
                            Quantity = 1,
                            Width = 600,
                            WindowId = new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd")
                        },
                        new
                        {
                            UId = new Guid("f534c91e-c0df-4e80-acf7-0a3907669dbb"),
                            Element = 1,
                            ElementTypeId = new Guid("e53175a6-5319-42ad-ab86-ac050f568e02"),
                            Height = 2000,
                            Quantity = 2,
                            Width = 1500,
                            WindowId = new Guid("a06e1626-10e7-472b-9373-0d673868c699")
                        });
                });

            modelBuilder.Entity("Sales.API.Models.Window", b =>
                {
                    b.Property<Guid>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("UId");

                    b.HasIndex("OrderId");

                    b.ToTable("Windows");

                    b.HasData(
                        new
                        {
                            UId = new Guid("a6831805-0892-4b76-878a-32d586d49aad"),
                            Name = "A51",
                            OrderId = new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"),
                            Quantity = 4
                        },
                        new
                        {
                            UId = new Guid("1b110392-9652-44b3-81c5-ff2f8689e873"),
                            Name = "C Zone 5",
                            OrderId = new Guid("b3ca33e7-c319-40fd-a681-7e479364a352"),
                            Quantity = 2
                        },
                        new
                        {
                            UId = new Guid("d1f084c1-0c59-4ee3-8674-af2ece39c7bd"),
                            Name = "GLB",
                            OrderId = new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"),
                            Quantity = 3
                        },
                        new
                        {
                            UId = new Guid("a06e1626-10e7-472b-9373-0d673868c699"),
                            Name = "OHF",
                            OrderId = new Guid("4b103f67-130e-4e20-b4d4-7023871bc52a"),
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("Sales.API.Models.SubElement", b =>
                {
                    b.HasOne("Sales.API.Models.ElementType", "ElementType")
                        .WithMany()
                        .HasForeignKey("ElementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.API.Models.Window", "Window")
                        .WithMany("SubElements")
                        .HasForeignKey("WindowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElementType");

                    b.Navigation("Window");
                });

            modelBuilder.Entity("Sales.API.Models.Window", b =>
                {
                    b.HasOne("Sales.API.Models.Order", "Order")
                        .WithMany("Windows")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Sales.API.Models.Order", b =>
                {
                    b.Navigation("Windows");
                });

            modelBuilder.Entity("Sales.API.Models.Window", b =>
                {
                    b.Navigation("SubElements");
                });
#pragma warning restore 612, 618
        }
    }
}
