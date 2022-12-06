﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ontap.Data;

#nullable disable

namespace Ontap.Migrations
{
    [DbContext(typeof(OntapContext))]
    [Migration("20221206155648_bautaolai123")]
    partial class bautaolai123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ontap.Data.Match", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long>("First")
                        .HasColumnType("bigint");

                    b.Property<long>("IDStadium")
                        .HasColumnType("bigint");

                    b.Property<long>("Last")
                        .HasColumnType("bigint");

                    b.Property<int>("StadiumID")
                        .HasColumnType("int");

                    b.Property<long>("StadiumID1")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("StadiumID1");

                    b.ToTable("Matche");
                });

            modelBuilder.Entity("Ontap.Data.Player", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<long>("IDTeam")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<long>("TeamID")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeamID");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Ontap.Data.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Ontap.Data.Stadium", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("ID");

                    b.ToTable("Stadium");
                });

            modelBuilder.Entity("Ontap.Data.Team", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("ID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Ontap.Data.Match", b =>
                {
                    b.HasOne("Ontap.Data.Stadium", "Stadium")
                        .WithMany("Matches")
                        .HasForeignKey("StadiumID1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("Ontap.Data.Player", b =>
                {
                    b.HasOne("Ontap.Data.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Ontap.Data.Stadium", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("Ontap.Data.Team", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
