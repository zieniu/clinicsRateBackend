﻿// <auto-generated />
using System;
using ClinicsRate.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClinicsRate.Migrations
{
    [DbContext(typeof(ClinicRateDbContext))]
    [Migration("20190102225216_DodanieDoOpinionDateCreated_2")]
    partial class DodanieDoOpinionDateCreated_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClinicsRate.Models.Clinic", b =>
                {
                    b.Property<int>("ClinicId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Accepted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int>("CityId");

                    b.Property<string>("ClinicName");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PostCode");

                    b.Property<int>("ProvinceId");

                    b.Property<string>("Street");

                    b.HasKey("ClinicId");

                    b.HasIndex("CityId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("ClinicsRate.Models.DictCity", b =>
                {
                    b.Property<int>("DictCityId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("DictCityId");

                    b.ToTable("DictCities");
                });

            modelBuilder.Entity("ClinicsRate.Models.DictProvince", b =>
                {
                    b.Property<int>("DictProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("DictProvinceId");

                    b.ToTable("DictProvinces");
                });

            modelBuilder.Entity("ClinicsRate.Models.Opinion", b =>
                {
                    b.Property<int>("OpinionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClinicId");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description");

                    b.Property<double>("Rate");

                    b.Property<int?>("UserId");

                    b.Property<string>("Username");

                    b.HasKey("OpinionId");

                    b.HasIndex("ClinicId");

                    b.HasIndex("UserId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("ClinicsRate.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessLevel")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Deleted");

                    b.Property<string>("Email");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ClinicsRate.Models.Clinic", b =>
                {
                    b.HasOne("ClinicsRate.Models.DictCity", "DictCity")
                        .WithMany("Clinics")
                        .HasForeignKey("CityId");

                    b.HasOne("ClinicsRate.Models.DictProvince", "DictProvince")
                        .WithMany("Clinics")
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("ClinicsRate.Models.Opinion", b =>
                {
                    b.HasOne("ClinicsRate.Models.Clinic", "Clinic")
                        .WithMany("Opinions")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ClinicsRate.Models.User", "User")
                        .WithMany("Opinions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
