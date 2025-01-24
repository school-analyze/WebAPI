﻿// <auto-generated />
using System;
using AnalyzeAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnalyzeAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("AnalyzeAPI.Models.GradeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Grade")
                        .HasPrecision(4, 2)
                        .HasColumnType("TEXT");

                    b.Property<int>("PercentageInfluence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SubjectId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SubjectModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserModelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SubjectModelId");

                    b.HasIndex("UserModelId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("AnalyzeAPI.Models.SubjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Math"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = 3,
                            Name = "History"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Physical Education"
                        },
                        new
                        {
                            Id = 5,
                            Name = "SIR"
                        },
                        new
                        {
                            Id = 6,
                            Name = "English"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Telecommunication"
                        },
                        new
                        {
                            Id = 8,
                            Name = "TPI"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Computer Science"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Religion"
                        });
                });

            modelBuilder.Entity("AnalyzeAPI.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnalyzeAPI.Models.GradeModel", b =>
                {
                    b.HasOne("AnalyzeAPI.Models.SubjectModel", null)
                        .WithMany("Grades")
                        .HasForeignKey("SubjectModelId");

                    b.HasOne("AnalyzeAPI.Models.UserModel", null)
                        .WithMany("Grades")
                        .HasForeignKey("UserModelId");
                });

            modelBuilder.Entity("AnalyzeAPI.Models.SubjectModel", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("AnalyzeAPI.Models.UserModel", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
