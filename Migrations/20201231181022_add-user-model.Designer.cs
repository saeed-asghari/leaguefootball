﻿// <auto-generated />
using System;
using LeagueFootball.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace leaguefootball.Migrations
{
    [DbContext(typeof(LeaguesDataContext))]
    [Migration("20201231181022_add-user-model")]
    partial class addusermodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LeagueFootball.Entities.League", b =>
                {
                    b.Property<int>("LeagueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FoundingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("LeagueID");

                    b.ToTable("League");

                    b.HasData(
                        new
                        {
                            LeagueID = 1,
                            FoundingDate = new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "لیگ برتر"
                        },
                        new
                        {
                            LeagueID = 2,
                            FoundingDate = new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "لیگ آزادگان"
                        });
                });

            modelBuilder.Entity("LeagueFootball.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            DateOfBirth = new DateTime(1980, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "سیدجلال ",
                            LastName = "حسینی",
                            TeamId = 1
                        },
                        new
                        {
                            PlayerId = 2,
                            DateOfBirth = new DateTime(1980, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "وریا ",
                            LastName = "غفوری",
                            TeamId = 2
                        },
                        new
                        {
                            PlayerId = 3,
                            DateOfBirth = new DateTime(1980, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "علی ",
                            LastName = "محمدی",
                            TeamId = 3
                        });
                });

            modelBuilder.Entity("LeagueFootball.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("FoundingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LeagueID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TeamId");

                    b.HasIndex("LeagueID");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            FoundingDate = new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeagueID = 1,
                            Name = "پرسپولیس"
                        },
                        new
                        {
                            TeamId = 2,
                            FoundingDate = new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeagueID = 1,
                            Name = "استقلال"
                        },
                        new
                        {
                            TeamId = 3,
                            FoundingDate = new DateTime(2001, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LeagueID = 2,
                            Name = "تیم دسته دو"
                        });
                });

            modelBuilder.Entity("LeagueFootball.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Saeed",
                            LastName = "As",
                            Password = "test",
                            Username = "test"
                        });
                });

            modelBuilder.Entity("LeagueFootball.Entities.Player", b =>
                {
                    b.HasOne("LeagueFootball.Entities.Team", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueFootball.Entities.Team", b =>
                {
                    b.HasOne("LeagueFootball.Entities.League", null)
                        .WithMany("Teams")
                        .HasForeignKey("LeagueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeagueFootball.Entities.User", b =>
                {
                    b.OwnsMany("LeagueFootball.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("LeagueFootball.Entities.League", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("LeagueFootball.Entities.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
