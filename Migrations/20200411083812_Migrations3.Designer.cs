﻿// <auto-generated />
using System;
using CarPoolAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPoolAPI.Migrations
{
    [DbContext(typeof(CarPoolContext))]
    [Migration("20200411083812_Migrations3")]
    partial class Migrations3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPoolAPI.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("BookingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartingTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("FarePrice")
                        .HasColumnType("real");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int>("SeatsBooked")
                        .HasColumnType("int");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OfferId");

                    b.HasIndex("SourceId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CarPoolAPI.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Lattitude")
                        .HasColumnType("bigint");

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Longitude")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("CarPoolAPI.Models.Offerring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("CurrentLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("Discount")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("PricePerKM")
                        .HasColumnType("real");

                    b.Property<int>("SeatsAvailable")
                        .HasColumnType("int");

                    b.Property<int>("SeatsOffered")
                        .HasColumnType("int");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("TotalEarning")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VechicleRef")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrentLocationId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("SourceId");

                    b.HasIndex("UserId");

                    b.HasIndex("VechicleRef")
                        .IsUnique();

                    b.ToTable("Offerrings");
                });

            modelBuilder.Entity("CarPoolAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUploadedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 3301,
                            Active = false,
                            Age = 20,
                            Gender = "MALE",
                            Name = "Monu",
                            Password = "monu"
                        },
                        new
                        {
                            Id = 3302,
                            Active = false,
                            Age = 22,
                            Gender = "MALE",
                            Name = "Abhinav",
                            Password = "abhinav"
                        },
                        new
                        {
                            Id = 3306,
                            Active = false,
                            Age = 24,
                            Gender = "MALE",
                            Name = "Sreyash",
                            Password = "sreyash"
                        },
                        new
                        {
                            Id = 3305,
                            Active = false,
                            Age = 21,
                            Gender = "FEMALE",
                            Name = "Priya",
                            Password = "priya"
                        },
                        new
                        {
                            Id = 3308,
                            Active = false,
                            Age = 24,
                            Gender = "MALE",
                            Name = "Devansh",
                            Password = "devansh"
                        });
                });

            modelBuilder.Entity("CarPoolAPI.Models.Vechicles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("NumberPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Vechicles");
                });

            modelBuilder.Entity("CarPoolAPI.Models.ViaPoints", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("OfferId")
                        .HasColumnType("int");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfferId");

                    b.HasIndex("PlaceId");

                    b.ToTable("ViaPoints");
                });

            modelBuilder.Entity("CarPoolAPI.Models.Booking", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Location", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId");

                    b.HasOne("CarPoolAPI.Models.Offerring", "Offerring")
                        .WithMany("Bookings")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolAPI.Models.Location", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.HasOne("CarPoolAPI.Models.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPoolAPI.Models.Offerring", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Location", "CurrentLocation")
                        .WithMany()
                        .HasForeignKey("CurrentLocationId");

                    b.HasOne("CarPoolAPI.Models.Location", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId");

                    b.HasOne("CarPoolAPI.Models.Location", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.HasOne("CarPoolAPI.Models.User", "User")
                        .WithMany("Offerrings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolAPI.Models.Vechicles", "Vechicles")
                        .WithOne("Offerring")
                        .HasForeignKey("CarPoolAPI.Models.Offerring", "VechicleRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarPoolAPI.Models.ViaPoints", b =>
                {
                    b.HasOne("CarPoolAPI.Models.Offerring", "Offerring")
                        .WithMany("ViaPoints")
                        .HasForeignKey("OfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolAPI.Models.Location", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");
                });
#pragma warning restore 612, 618
        }
    }
}