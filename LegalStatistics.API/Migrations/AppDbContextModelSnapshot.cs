﻿// <auto-generated />
using System;
using LegalStatistics.API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LegalStatistics.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LegalStatistics.ReportRepository.Models.ArbitrationProceeding.ArbitrationProceeding_LawsuitContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ArbitrationProceeding.LawsuitsContent");
                });

            modelBuilder.Entity("LegalStatistics.ReportRepository.Models.ArbitrationProceeding.ArbitrationProceeding_LegalAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ArbitrationProceeding.LegalActions");
                });

            modelBuilder.Entity("LegalStatistics.ReportRepository.Models.ArbitrationProceeding.ArbitrationProceeding_Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<DateTime>("FillDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("LawsuitContentId")
                        .HasColumnType("integer");

                    b.Property<int>("LegalActionId")
                        .HasColumnType("integer");

                    b.Property<byte>("ReportingPeriod")
                        .HasColumnType("smallint");

                    b.Property<int>("Value")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LawsuitContentId");

                    b.HasIndex("LegalActionId");

                    b.ToTable("ArbitrationProceeding.Statistics");
                });

            modelBuilder.Entity("LegalStatistics.ReportRepository.Models.ArbitrationProceeding.ArbitrationProceeding_Statistics", b =>
                {
                    b.HasOne("LegalStatistics.ReportRepository.Models.ArbitrationProceeding.ArbitrationProceeding_LawsuitContent", "LawsuitContent")
                        .WithMany()
                        .HasForeignKey("LawsuitContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LegalStatistics.ReportRepository.Models.ArbitrationProceeding.ArbitrationProceeding_LegalAction", "LegalAction")
                        .WithMany()
                        .HasForeignKey("LegalActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LawsuitContent");

                    b.Navigation("LegalAction");
                });
#pragma warning restore 612, 618
        }
    }
}