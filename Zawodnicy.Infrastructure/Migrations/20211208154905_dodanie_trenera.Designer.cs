﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zawodnicy.Infrastructure.Repositories;

namespace Zawodnicy.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211208154905_dodanie_trenera")]
    partial class dodanie_trenera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Zawodnicy.Core.Domain.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SkiJumpId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkiJumpId");

                    b.ToTable("Competition");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.Participation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("int");

                    b.Property<int?>("SkiJumperId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("SkiJumperId");

                    b.ToTable("Participation");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.SkiJump", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DesignPoint")
                        .HasColumnType("int");

                    b.Property<int>("JudgePoint")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("SkiJump");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Town");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Trainer");
                });

            modelBuilder.Entity("Zawodnicy.core.Domain.SkiJumper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ForeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("SkiJumper");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.Competition", b =>
                {
                    b.HasOne("Zawodnicy.Core.Domain.SkiJump", "SkiJump")
                        .WithMany()
                        .HasForeignKey("SkiJumpId");

                    b.Navigation("SkiJump");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.Participation", b =>
                {
                    b.HasOne("Zawodnicy.Core.Domain.Competition", "Competition")
                        .WithMany("Participations")
                        .HasForeignKey("CompetitionId");

                    b.HasOne("Zawodnicy.core.Domain.SkiJumper", "SkiJumper")
                        .WithMany("Participations")
                        .HasForeignKey("SkiJumperId");

                    b.Navigation("Competition");

                    b.Navigation("SkiJumper");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.SkiJump", b =>
                {
                    b.HasOne("Zawodnicy.Core.Domain.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId");

                    b.Navigation("Town");
                });

            modelBuilder.Entity("Zawodnicy.core.Domain.SkiJumper", b =>
                {
                    b.HasOne("Zawodnicy.Core.Domain.Trainer", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("Zawodnicy.Core.Domain.Competition", b =>
                {
                    b.Navigation("Participations");
                });

            modelBuilder.Entity("Zawodnicy.core.Domain.SkiJumper", b =>
                {
                    b.Navigation("Participations");
                });
#pragma warning restore 612, 618
        }
    }
}