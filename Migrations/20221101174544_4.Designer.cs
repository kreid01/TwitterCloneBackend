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
    [Migration("20221101174544_4")]
    partial class _4
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
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("CommentCount")
                        .HasColumnType("integer");

                    b.Property<int>("LikeCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostMedia")
                        .HasColumnType("text");

                    b.Property<string>("PostTextBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RetweetCount")
                        .HasColumnType("integer");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId1")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId2")
                        .HasColumnType("integer");

                    b.Property<string>("UserImg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.HasIndex("UserId2");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("TwitterCloneBackend.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CommentBody")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("CommentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CommentMedia")
                        .HasColumnType("text");

                    b.Property<int>("PostId")
                        .HasColumnType("integer");

                    b.Property<int?>("PosterId")
                        .HasColumnType("integer");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserImg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("TwitterCloneBackend.Models.Follows", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId1")
                        .HasColumnType("integer");

                    b.Property<string>("UserImg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("Follows");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserCoverImg")
                        .HasColumnType("text");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserImg")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.HasOne("User", null)
                        .WithMany("LikedPosts")
                        .HasForeignKey("UserId");

                    b.HasOne("User", null)
                        .WithMany("Posts")
                        .HasForeignKey("UserId1");

                    b.HasOne("User", null)
                        .WithMany("RetweetedPosts")
                        .HasForeignKey("UserId2");
                });

            modelBuilder.Entity("TwitterCloneBackend.Models.Comment", b =>
                {
                    b.HasOne("Post", null)
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TwitterCloneBackend.Models.Follows", b =>
                {
                    b.HasOne("User", null)
                        .WithMany("Followers")
                        .HasForeignKey("UserId");

                    b.HasOne("User", null)
                        .WithMany("Following")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Following");

                    b.Navigation("LikedPosts");

                    b.Navigation("Posts");

                    b.Navigation("RetweetedPosts");
                });
#pragma warning restore 612, 618
        }
    }
}