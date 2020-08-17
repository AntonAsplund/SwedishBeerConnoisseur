﻿using Newtonsoft.Json;
using SwedishBeerConnoisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SwedishBeerConnoisseur.Data
{
    public class BeerConnoisseurData : IBeerConnoisseurData
    {
        private readonly BeerConnoisseurDbContext dbContext;
        public BeerConnoisseurData(BeerConnoisseurDbContext beerConnoisseurDbContext)
        {
            dbContext = beerConnoisseurDbContext;
        }

        /// <summary>
        /// Adds a beverage to the database and checks if the new price is lower than the old price.
        /// </summary>
        /// <param name="beverage"></param>
        /// <returns></returns>
        public async Task<bool> AddBeverageToDatabase(Beverage beverage)
        {
            Beverage beverageInDatabase = dbContext.Beverages.Where(bev => bev.ProductNumber == beverage.ProductNumber).FirstOrDefault<Beverage>();
            if (beverageInDatabase == null)
            {
                dbContext.Beverages.Add(beverage);
            }
            else 
            {
                beverageInDatabase.Price = beverage.Price;
                if (beverageInDatabase.OldHighPrice < beverage.Price)
                {
                    beverageInDatabase.OldHighPrice = beverage.Price;
                }
            }

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;

        }


        /// <summary>
        /// Retrieves a list of all beverages in database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Beverage>> RetrieveBeveragesList()
        {
            return dbContext.Beverages.ToList<Beverage>();
        }

        /// <summary>
        /// Finds all stores and agents by given querystring in the database
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<List<Store>> FindStoresAndAgentsByCity(string city)
        {

            try
            {
                List<Store> foundStores = dbContext.Stores.Where(s => s.City.ToLower() == city.ToLower()).ToList<Store>();
                if (foundStores != null)
                {
                    return foundStores;
                }
            }
            catch
            { }

            return null;

        }

        /// <summary>
        /// Adds stores to the database and connects which beverages the store stocks
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddStoresToDatabase()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cba4b139e74b49cf9aae18c4d7761311");

            // Request headers
            var uri = "https://api-extern.systembolaget.se/site/v1/site/search" + queryString;
            
                
            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<StoreSearchResultModel>(await response.Content.ReadAsStringAsync());

                foreach (var store in result.Hits)
                {
                    if (store.IsStore)
                    {
                        Store newStore = CopyFromRawStoreToStoreEntity(store);
                        Store storeInDatabase = dbContext.Stores.Where(S => S.SiteId == newStore.SiteId).FirstOrDefault<Store>();
                        if (storeInDatabase == null)
                        {
                            dbContext.Stores.Add(newStore);
                            await dbContext.SaveChangesAsync();
                            storeInDatabase = dbContext.Stores.Where(S => S.SiteId == newStore.SiteId).FirstOrDefault<Store>();
                        }

                        //Removes all connections between beverages and store. Renewing the stock of the store.
                        var beveragesInStore = dbContext.BeveragesInStore.Where(B => B.StoreId == storeInDatabase.StoreId).ToList();
                        dbContext.BeveragesInStore.RemoveRange(beveragesInStore);
                        await dbContext.SaveChangesAsync();


                        //Updates the stocks of the stores and adds it to the table "BeveragesInStore"
                        List<string> allBeveragesInStore = await FindAllBeveragesInStore(storeInDatabase.SiteId);

                        if (allBeveragesInStore != null)
                        {
                            foreach (var beverage in allBeveragesInStore)
                            {
                                Beverage newBeverage = dbContext.Beverages.Where(b => b.ProductId == beverage).FirstOrDefault<Beverage>();

                                if (newBeverage != null)
                                {
                                    dbContext.BeveragesInStore.Add(new BeveragesInStore { Beverage = newBeverage, Store = storeInDatabase });
                                    await dbContext.SaveChangesAsync();
                                }
                            }

                        }
                    }
                }
            }
            catch
            {
                return false;
            }


            return true;
        }
        //Finds all beverages in a given store by siteId  which are categorized as beers
        private async Task<List<string>> FindAllBeveragesInStore(string siteId)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cba4b139e74b49cf9aae18c4d7761311");

            // Request headers
            var uri = "https://api-extern.systembolaget.se/product/v1/product/getproductswithstore?SiteId=" + siteId;

            List<string> beveragesInStore = new List<string>();

            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<StoreBeverageSearchResult>>(await response.Content.ReadAsStringAsync());

                StoreBeverageSearchResult storeBeverageSearchResult = new StoreBeverageSearchResult();

                foreach (var store in result)
                {
                    if (store.SiteId == siteId)
                    {
                        storeBeverageSearchResult = store;
                    }
                }

                foreach (var beverage in storeBeverageSearchResult.Products)
                {
                    beveragesInStore.Add(beverage.ProductId);
                }
            }

            catch
            {
                return null;
            }

            return beveragesInStore;
        }




        /// <summary>
        /// Deep copies a StoreIndividualRawModel to Store entity
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        private Store CopyFromRawStoreToStoreEntity(StoreIndividualRawModel store)
        {
            Store newStore = new Store();

            newStore.StoreId = store.StoreId;
            newStore.SiteId = store.SiteId;
            newStore.Alias = store.Alias;
            newStore.Address = store.Address;
            newStore.DisplayName = store.DisplayName;
            newStore.PostalCode = store.PostalCode;
            newStore.City = store.City;
            newStore.County = store.County;
            newStore.Country = store.Country;
            newStore.IsStore = store.IsStore;
            newStore.IsAgent = store.IsAgent;
            newStore.IsActiveForAgentOrder = store.IsActiveForAgentOrder;
            newStore.Phone = store.Phone;
            newStore.Email = store.Email;
            newStore.Depot = store.Depot;
            newStore.Name = store.Name;
            newStore.Lat = store.Position.Lat;
            newStore.Long = store.Position.Long;

            return newStore;
        }
        /// <summary>
        /// Takes a List of stores and returns a list of beverages which said stores stock
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public List<Beverage> RetrieveBeveragesInStores(List<Store> stores)
        {
            List<BeveragesInStore> beveragesInStore = new List<BeveragesInStore>();


            //Adds the stocked beverages in a list of stores to a list of beveragesInStore and skips any duplicates
            foreach (var store in stores)
            {

                List<BeveragesInStore> temporaryListOfBeveragesFromOneStore = dbContext.BeveragesInStore.Where(B => B.StoreId == store.StoreId).ToList();

                foreach (var beverage in temporaryListOfBeveragesFromOneStore)
                {
                    if (beveragesInStore.Contains(beverage) == false)
                    {
                        beveragesInStore.Add(beverage);
                    }
                }

            }

            //Converts list of BeveragesInStore entitys to a list of beverage entitys

            List<Beverage> beverages = new List<Beverage>();

            foreach (var beverage in beveragesInStore)
            {
                beverages.Add(dbContext.Beverages.Where(B => B.BeverageId == beverage.BeverageId).FirstOrDefault());
            }

            return beverages;
        }
    }
}
