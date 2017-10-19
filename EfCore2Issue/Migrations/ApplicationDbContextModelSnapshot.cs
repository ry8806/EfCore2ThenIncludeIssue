﻿// <auto-generated />
using EfCore2Issue.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EfCore2Issue.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCore2Issue.Model.DateHolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("LayerId");

                    b.HasKey("Id");

                    b.HasIndex("LayerId");

                    b.ToTable("Holders");
                });

            modelBuilder.Entity("EfCore2Issue.Model.Layer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ScheduleId");

                    b.Property<int?>("WeeklyScheduleId");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("WeeklyScheduleId");

                    b.ToTable("Layer");
                });

            modelBuilder.Entity("EfCore2Issue.Model.SpecificDate", b =>
                {
                    b.Property<DateTimeOffset>("Date");

                    b.Property<int>("SpecificScheduleId");

                    b.HasKey("Date", "SpecificScheduleId");

                    b.HasIndex("SpecificScheduleId");

                    b.ToTable("SpecificDate");
                });

            modelBuilder.Entity("EfCore2Issue.Model.SpecificSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("From");

                    b.HasKey("Id");

                    b.ToTable("SpecificSchedule");
                });

            modelBuilder.Entity("EfCore2Issue.Model.WeeklySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Days");

                    b.Property<TimeSpan>("From");

                    b.HasKey("Id");

                    b.ToTable("WeeklySchedule");
                });

            modelBuilder.Entity("EfCore2Issue.Model.DateHolder", b =>
                {
                    b.HasOne("EfCore2Issue.Model.Layer", "Layer")
                        .WithMany()
                        .HasForeignKey("LayerId");
                });

            modelBuilder.Entity("EfCore2Issue.Model.Layer", b =>
                {
                    b.HasOne("EfCore2Issue.Model.SpecificSchedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleId");

                    b.HasOne("EfCore2Issue.Model.WeeklySchedule", "WeeklySchedule")
                        .WithMany()
                        .HasForeignKey("WeeklyScheduleId");
                });

            modelBuilder.Entity("EfCore2Issue.Model.SpecificDate", b =>
                {
                    b.HasOne("EfCore2Issue.Model.SpecificSchedule")
                        .WithMany("Dates")
                        .HasForeignKey("SpecificScheduleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
