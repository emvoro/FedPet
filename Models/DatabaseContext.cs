using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedPet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.Internal;

namespace FedPet.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<OwnerData> OwnerDatas { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<HealthIndicators> HealthIndicators { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<PassportIssuingOrgan> PassportIssuingOrgans { get; set; }
        public DbSet<VetPassport> VetPassports { get; set; }
        public DbSet<Feeder> Feeders { get; set; }
        public DbSet<Feeding> Feedings { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Statistics> Statistics { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
           Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
            .HasMany(x => x.Pets)
            .WithOne(x => x.Owner)
            .HasForeignKey(s => s.Owner_Login);

            //modelBuilder.Entity<Pet>()
            //    .HasMany(x => x.Vaccinations)
            //    .WithOne(x => x.Pet)
            //    .HasForeignKey(s => s.Pet_Id);
        }

    }
}
