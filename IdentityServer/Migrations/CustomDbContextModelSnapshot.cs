﻿// <auto-generated />
using IdentityServer.AuthServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IdentityServer.AuthServer.Migrations
{
    [DbContext(typeof(CustomDbContext))]
    partial class CustomDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityServer.AuthServer.Models.CustomUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "istanbul",
                            Email = "fcakiroglu@outlook.com",
                            Password = "password",
                            UserName = "facakiroglu16"
                        },
                        new
                        {
                            Id = 2,
                            City = "Ankara",
                            Email = "ahmet@outlook.com",
                            Password = "password",
                            UserName = "ahmet16"
                        },
                        new
                        {
                            Id = 3,
                            City = "Konya",
                            Email = "mehmet@outlook.com",
                            Password = "password",
                            UserName = "mehmet16"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
