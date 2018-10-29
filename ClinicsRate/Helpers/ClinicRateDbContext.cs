using ClinicsRate.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicsRate.Helpers
{
    public class ClinicRateDbContext: DbContext
    {
        public ClinicRateDbContext(DbContextOptions<ClinicRateDbContext> options) : base(options) { }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DictCity> DictCities { get; set; }
        public DbSet<DictProvince> DictProvinces { get; set; }
        public DbSet<Opinion> Opinions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
