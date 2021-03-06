﻿using Microsoft.EntityFrameworkCore;
using SwedishBeerConnoisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Data
{
    public class BeerConnoisseurDbContext : DbContext
    {
        public DbSet<Beverage> Beverages { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users {get; set;}
        public DbSet<BeveragesInStore> BeveragesInStore { get; set; } 

        public BeerConnoisseurDbContext(DbContextOptions<BeerConnoisseurDbContext> options) : base(options)
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BeveragesInStore>()
                .HasKey(B => new { B.StoreId, B.BeverageId});

        }
    }
}
