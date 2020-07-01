using Microsoft.EntityFrameworkCore;
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
    }
}
