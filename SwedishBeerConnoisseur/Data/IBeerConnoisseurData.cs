﻿using SwedishBeerConnoisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Data
{
    public interface IBeerConnoisseurData
    {
        public Task<bool> AddBeverageToDatabase(Beverage beverage);
        public Task<List<Beverage>> RetrieveBeveragesList();
        public Task<List<Store>> FindStoresAndAgentsByCity(string city);
        public List<Beverage> RetrieveBeveragesInStores(List<Store> storeId);
        public Task<bool> AddStoresToDatabase();
        public Task<bool> MakeBeveragesRequest();
        public Task<bool> UpdateStoresAndStocks();
    }
}
