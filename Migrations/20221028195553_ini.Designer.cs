﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TwitterCloneBackend.Context;

#nullable disable

namespace TwitterCloneBackend.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221028195553_ini")]
    partial class ini
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Post", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostTextBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostTextMedia")
                        .HasColumnType("text");

                    b.Property<int>("RetweetCount")
                        .HasColumnType("integer");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
