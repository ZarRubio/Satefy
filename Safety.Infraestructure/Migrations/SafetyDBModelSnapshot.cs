﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Safety.Infraestructure.Context;

#nullable disable

namespace Safety.Infraestructure.Migrations
{
    [DbContext(typeof(SafetyDB))]
    partial class SafetyDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Safety.Infraestructure.Models.Guardian", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 29, 10, 20, 31, 324, DateTimeKind.Local).AddTicks(3259));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("id");

                    b.ToTable("Guardians", (string)null);
                });

            modelBuilder.Entity("Safety.Infraestructure.Models.Urgency", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 29, 10, 20, 31, 324, DateTimeKind.Local).AddTicks(4372));

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("GuardianId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<double>("latitude")
                        .HasColumnType("double");

                    b.Property<double>("longitude")
                        .HasColumnType("double");

                    b.Property<DateTime>("reportedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 11, 29, 10, 20, 31, 324, DateTimeKind.Local).AddTicks(4132));

                    b.Property<string>("summary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.HasIndex("GuardianId");

                    b.ToTable("Urgencies", (string)null);
                });

            modelBuilder.Entity("Safety.Infraestructure.Models.Urgency", b =>
                {
                    b.HasOne("Safety.Infraestructure.Models.Guardian", "Guardian")
                        .WithMany("Urgencies")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guardian");
                });

            modelBuilder.Entity("Safety.Infraestructure.Models.Guardian", b =>
                {
                    b.Navigation("Urgencies");
                });
#pragma warning restore 612, 618
        }
    }
}
