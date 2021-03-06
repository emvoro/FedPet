﻿// <auto-generated />
using System;
using FedPet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FedPet.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FedPet.Models.Feeder", b =>
                {
                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.Property<bool>("AddFood")
                        .HasColumnType("bit");

                    b.Property<double>("CurrentWeight")
                        .HasColumnType("float");

                    b.HasKey("Pet_Id");

                    b.ToTable("Feeders");
                });

            modelBuilder.Entity("FedPet.Models.Feeding", b =>
                {
                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.Property<int>("Interval")
                        .HasColumnType("int");

                    b.Property<int>("Portion")
                        .HasColumnType("int");

                    b.HasKey("Pet_Id");

                    b.ToTable("Feedings");
                });

            modelBuilder.Entity("FedPet.Models.HealthIndicators", b =>
                {
                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HairLoss")
                        .HasColumnType("bit");

                    b.Property<bool>("Obesity")
                        .HasColumnType("bit");

                    b.Property<bool>("Pregnancy")
                        .HasColumnType("bit");

                    b.Property<bool>("SensitiveDigestion")
                        .HasColumnType("bit");

                    b.Property<bool>("UrolithiasisDisease")
                        .HasColumnType("bit");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Pet_Id");

                    b.ToTable("HealthIndicators");
                });

            modelBuilder.Entity("FedPet.Models.Owner", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Login");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("FedPet.Models.OwnerData", b =>
                {
                    b.Property<string>("Owner_Login")
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("OwnerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerPostCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerSignatureLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Owner_Login");

                    b.ToTable("OwnerDatas");
                });

            modelBuilder.Entity("FedPet.Models.PassportIssuingOrgan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AddressOfIssuing")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CityOfIssuing")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CountryOfIssuing")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("IssuingEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IssuingPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NameOfVeterinarian")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostCodeOfIssuing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PassportIssuingOrgans");
                });

            modelBuilder.Entity("FedPet.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Owner_Login")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhotoLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Owner_Login");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("FedPet.Models.Schedule", b =>
                {
                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.Property<string>("FirstFeeding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondFeeding")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdFeeding")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Pet_Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("FedPet.Models.Statistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<double>("AmountOfFood")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfFeeding")
                        .HasColumnType("datetime2");

                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Pet_Id");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("FedPet.Models.Vaccination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AuthorizedVeterinarian")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BatchNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfVaccination")
                        .HasColumnType("datetime2");

                    b.Property<string>("ManufacturerAndVaccineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Pet_Id");

                    b.ToTable("Vaccinations");
                });

            modelBuilder.Entity("FedPet.Models.VetPassport", b =>
                {
                    b.Property<int>("Pet_Id")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfIssuing")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfTattooApplication")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfTransponderApplication")
                        .HasColumnType("datetime2");

                    b.Property<int>("PassportIssuingOrgan_Id")
                        .HasColumnType("int");

                    b.Property<string>("PassportSerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TattooAlphanumericalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TattooLocation")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TransponderAlphanumericCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransponderLocation")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Pet_Id");

                    b.HasIndex("PassportIssuingOrgan_Id");

                    b.ToTable("VetPassports");
                });

            modelBuilder.Entity("FedPet.Models.Feeder", b =>
                {
                    b.HasOne("FedPet.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("FedPet.Models.Feeding", b =>
                {
                    b.HasOne("FedPet.Models.Feeder", "Feeder")
                        .WithMany()
                        .HasForeignKey("Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feeder");
                });

            modelBuilder.Entity("FedPet.Models.HealthIndicators", b =>
                {
                    b.HasOne("FedPet.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("FedPet.Models.OwnerData", b =>
                {
                    b.HasOne("FedPet.Models.Owner", "Owner")
                        .WithOne("OwnerData")
                        .HasForeignKey("FedPet.Models.OwnerData", "Owner_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FedPet.Models.Pet", b =>
                {
                    b.HasOne("FedPet.Models.Owner", "Owner")
                        .WithMany("Pets")
                        .HasForeignKey("Owner_Login")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("FedPet.Models.Schedule", b =>
                {
                    b.HasOne("FedPet.Models.Feeding", "Feeding")
                        .WithOne("Schedule")
                        .HasForeignKey("FedPet.Models.Schedule", "Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feeding");
                });

            modelBuilder.Entity("FedPet.Models.Statistics", b =>
                {
                    b.HasOne("FedPet.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("FedPet.Models.Vaccination", b =>
                {
                    b.HasOne("FedPet.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("FedPet.Models.VetPassport", b =>
                {
                    b.HasOne("FedPet.Models.PassportIssuingOrgan", "PassportIssuingOrgan")
                        .WithMany()
                        .HasForeignKey("PassportIssuingOrgan_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FedPet.Models.Pet", "Pet")
                        .WithMany()
                        .HasForeignKey("Pet_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PassportIssuingOrgan");

                    b.Navigation("Pet");
                });

            modelBuilder.Entity("FedPet.Models.Feeding", b =>
                {
                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("FedPet.Models.Owner", b =>
                {
                    b.Navigation("OwnerData");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
