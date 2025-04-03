﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpainFootball.DAL;

#nullable disable

namespace SpainFootball.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250403165152_Ccc")]
    partial class Ccc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpainFootball.DAL.Enteties.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Team1Goals")
                        .HasColumnType("int");

                    b.Property<int?>("Team1Id")
                        .HasColumnType("int");

                    b.Property<int?>("Team2Goals")
                        .HasColumnType("int");

                    b.Property<int?>("Team2Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Team1Id");

                    b.HasIndex("Team2Id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlayerNum")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.ScoringPlayer", b =>
                {
                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("MatchId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("ScoringPlayers");
                });

            modelBuilder.Entity("SpainFootball.DAL.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DrawCount")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsLost")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("LoseCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WinCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.Match", b =>
                {
                    b.HasOne("SpainFootball.DAL.Team", "Team1")
                        .WithMany("HomeMatches")
                        .HasForeignKey("Team1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SpainFootball.DAL.Team", "Team2")
                        .WithMany("AwayMatches")
                        .HasForeignKey("Team2Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Team1");

                    b.Navigation("Team2");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.Player", b =>
                {
                    b.HasOne("SpainFootball.DAL.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.ScoringPlayer", b =>
                {
                    b.HasOne("SpainFootball.DAL.Enteties.Match", "Match")
                        .WithMany("ScoringPlayers")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpainFootball.DAL.Enteties.Player", "Player")
                        .WithMany("ScoringPlayers")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.Match", b =>
                {
                    b.Navigation("ScoringPlayers");
                });

            modelBuilder.Entity("SpainFootball.DAL.Enteties.Player", b =>
                {
                    b.Navigation("ScoringPlayers");
                });

            modelBuilder.Entity("SpainFootball.DAL.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("HomeMatches");

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
