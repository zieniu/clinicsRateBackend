﻿using ClinicsRate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicsRate.Helpers
{
    public class ClinicRateDbContext : DbContext
    {
        public ClinicRateDbContext(DbContextOptions<ClinicRateDbContext> options) : base(options) { }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<DictCity> DictCities { get; set; }
        public DbSet<DictProvince> DictProvinces { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        //public DbSet<ClinicTMP> ClinicsTMP { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ################## CLINIC #####################
            modelBuilder.Entity<Clinic>()
                .HasKey(c => c.ClinicId);

            modelBuilder.Entity<Clinic>()
                .HasMany<Opinion>(o => o.Opinions)
                .WithOne(c => c.Clinic)
                .HasForeignKey(c => c.ClinicId)
                .OnDelete(DeleteBehavior.Cascade);

            // ################## OPINION #####################
            modelBuilder.Entity<Opinion>()
                .HasKey(o => o.OpinionId);

            // ################## USER #####################
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .HasMany<Opinion>(o => o.Opinions)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // ################## DICTPROVINCE #####################
            modelBuilder.Entity<DictProvince>()
                .HasKey(p => p.DictProvinceId);

            modelBuilder.Entity<DictProvince>()
                .HasMany<Clinic>(c => c.Clinics)
                .WithOne(p => p.DictProvince)
                .HasForeignKey(p => p.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // ################## DICTCITY #####################
            modelBuilder.Entity<DictCity>()
                .HasKey(c => c.DictCityId);

            modelBuilder.Entity<DictCity>()
                .HasMany<Clinic>(c => c.Clinics)
                .WithOne(c => c.DictCity)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
