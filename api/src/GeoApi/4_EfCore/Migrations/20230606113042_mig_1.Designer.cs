﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _4_EfCore.Repositories;

#nullable disable

namespace _4_EfCore.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20230606113042_mig_1")]
    partial class mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_4_EfCore.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Attribute")
                        .HasColumnType("text");

                    b.Property<string>("Block")
                        .HasColumnType("text");

                    b.Property<int>("FKey")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Buildings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attribute = "n1",
                            Block = "b1",
                            FKey = 1
                        },
                        new
                        {
                            Id = 2,
                            Attribute = "n2",
                            Block = "b2",
                            FKey = 2
                        });
                });

            modelBuilder.Entity("_4_EfCore.Models.Parcel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Attribute")
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .HasColumnType("text");

                    b.Property<int>("Island")
                        .HasColumnType("integer");

                    b.Property<string>("Layout")
                        .HasColumnType("text");

                    b.Property<string>("Neighbourhood")
                        .HasColumnType("text");

                    b.Property<int>("ParcelNo")
                        .HasColumnType("integer");

                    b.Property<string>("Province")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parcels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Attribute = "n1",
                            District = "ilce1",
                            Island = 1,
                            Layout = "p1",
                            Neighbourhood = "m1",
                            ParcelNo = 1,
                            Province = "il1"
                        },
                        new
                        {
                            Id = 2,
                            Attribute = "n2",
                            District = "ilce2",
                            Island = 2,
                            Layout = "p2",
                            Neighbourhood = "m2",
                            ParcelNo = 2,
                            Province = "il2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
