﻿// <auto-generated />
using DoNotFret.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DoNotFret.Migrations
{
    [DbContext(typeof(DoNotFretDbContext))]
    [Migration("20210818021726_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DoNotFret.Models.Instruments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstrumentType")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instrument");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Ibanez",
                            Description = "Natural Wood Finish, 6 string electric guitar",
                            InstrumentType = 0,
                            Material = "Basswood",
                            Name = "Guitar"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Rickenbacker",
                            Description = "Cherry Red, 4 string electric bass",
                            InstrumentType = 0,
                            Material = "Eastern hardrock Maple",
                            Name = "Bass"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
