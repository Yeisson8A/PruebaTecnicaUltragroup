﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTecnicaUltragroup.Infrastructure.Data;

#nullable disable

namespace PruebaTecnicaUltragroup.Infrastructure.Migrations
{
    [DbContext(typeof(DbpruebaUltragroupContext))]
    [Migration("20250207163332_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.EmergencyContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EmergencyContact", (string)null);
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Hotel", (string)null);
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.HotelRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BaseCost")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("IdHotel")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdHotel");

                    b.ToTable("HotelRoom", (string)null);
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdEmergencyContact")
                        .HasColumnType("int");

                    b.Property<int>("IdRoom")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEmergencyContact");

                    b.HasIndex("IdRoom");

                    b.ToTable("Reservation", (string)null);
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.ReservationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("DocumentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("IdReservation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdReservation");

                    b.ToTable("ReservationDetail", (string)null);
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.HotelRoom", b =>
                {
                    b.HasOne("PruebaTecnicaUltragroup.Core.Entities.Hotel", "IdHotelNavigation")
                        .WithMany("HotelRooms")
                        .HasForeignKey("IdHotel")
                        .IsRequired()
                        .HasConstraintName("FK_HotelRoom_Hotel");

                    b.Navigation("IdHotelNavigation");
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.Reservation", b =>
                {
                    b.HasOne("PruebaTecnicaUltragroup.Core.Entities.EmergencyContact", "IdEmergencyContactNavigation")
                        .WithMany("Reservations")
                        .HasForeignKey("IdEmergencyContact")
                        .IsRequired()
                        .HasConstraintName("FK_Reservation_EmergencyContact");

                    b.HasOne("PruebaTecnicaUltragroup.Core.Entities.HotelRoom", "IdRoomNavigation")
                        .WithMany("Reservations")
                        .HasForeignKey("IdRoom")
                        .IsRequired()
                        .HasConstraintName("FK_Reservation_HotelRoom");

                    b.Navigation("IdEmergencyContactNavigation");

                    b.Navigation("IdRoomNavigation");
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.ReservationDetail", b =>
                {
                    b.HasOne("PruebaTecnicaUltragroup.Core.Entities.Reservation", "IdReservationNavigation")
                        .WithMany("ReservationDetails")
                        .HasForeignKey("IdReservation")
                        .IsRequired()
                        .HasConstraintName("FK_ReservationDetail_Reservation");

                    b.Navigation("IdReservationNavigation");
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.EmergencyContact", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.Hotel", b =>
                {
                    b.Navigation("HotelRooms");
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.HotelRoom", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("PruebaTecnicaUltragroup.Core.Entities.Reservation", b =>
                {
                    b.Navigation("ReservationDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
