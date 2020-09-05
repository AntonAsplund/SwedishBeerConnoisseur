using Newtonsoft.Json;
using SwedishBeerConnoisseur.Models;
using Microsoft.EntityFrameworkCore;
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
        /// Updates the database with the new data from "https://api-extern.systembolaget.se"
        /// </summary>
        /// <returns></returns>
        public async Task<bool> MakeBeveragesRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cba4b139e74b49cf9aae18c4d7761311");

            var uri = "https://api-extern.systembolaget.se/product/v1/product?" + queryString;

            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Beverage>>(await response.Content.ReadAsStringAsync());

                foreach (var beverage in result)
                {
                    if (beverage.Category == "Öl")
                    {
                        bool resultOfOperation = await AddBeverageToDatabase(beverage);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Adds a beverage to the database and checks if the new price is lower than the old price.
        /// </summary>
        /// <param name="beverage"></param>
        /// <returns></returns>
        public async Task<bool> AddBeverageToDatabase(Beverage beverage)
        {
            Beverage beverageInDatabase = await dbContext.Beverages.Where(bev => bev.ProductNumber == beverage.ProductNumber).FirstOrDefaultAsync();
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
            return await dbContext.Beverages.ToListAsync();
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
                List<Store> foundStores = await dbContext.Stores.Where(s => s.City.ToLower() == city.ToLower()).ToListAsync<Store>();
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
            var uri = "https://api-extern.systembolaget.se/site/v1/site" + queryString;
            
                
            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<StoreIndividualRawModel>>(await response.Content.ReadAsStringAsync());

                foreach (var store in result)
                {
                    if (store.IsStore)
                    {
                        Store newStore = CopyFromRawStoreToStoreEntity(store);
                        Store storeInDatabase = await dbContext.Stores.Where(S => S.SiteId == newStore.SiteId).FirstOrDefaultAsync();
                        if (storeInDatabase == null)
                        {
                            dbContext.Stores.Add(newStore);
                            await dbContext.SaveChangesAsync();
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

        public async Task<bool> UpdateStoresAndStocks()
        {

            var storesInDatabase = await dbContext.Stores.ToListAsync();


            foreach (var store in storesInDatabase)
            {
                //Removes all old connections between beverages and store. Renewing the stock of the store.
                var beveragesInStore = await dbContext.BeveragesInStore.Where(B => B.StoreId == store.StoreId).ToListAsync();
                dbContext.BeveragesInStore.RemoveRange(beveragesInStore);
                await dbContext.SaveChangesAsync();
                

                //Updates the stocks of the stores and adds it to the table "BeveragesInStore"
                List<string> allBeveragesInStore = await FindAllBeveragesInStore(store.SiteId);

                if (allBeveragesInStore != null)
                {
                    foreach (var beverage in allBeveragesInStore)
                    {
                        //Retrieves the beverage from the database and makes sure the connection between a store and beverage is made
                        Beverage newBeverage = await dbContext.Beverages.Where(b => b.ProductId == beverage).FirstOrDefaultAsync<Beverage>();

                        if (newBeverage != null)
                        {
                            dbContext.BeveragesInStore.Add(new BeveragesInStore { Beverage = newBeverage, Store = store });
                            await dbContext.SaveChangesAsync();
                        }
                    }

                }
            }

            return true;

        }

        //Finds all beverages in a given store by siteId  which are categorized as beers
        private async Task<List<string>> FindAllBeveragesInStore(string siteId)
        {
            var client = new HttpClient();
            bool beveragesNotFound = true;

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cba4b139e74b49cf9aae18c4d7761311");

            // Request headers
            var uri = "https://api-extern.systembolaget.se/product/v1/product/getproductswithstore?SiteId=" + siteId;

            List<string> beveragesInStore = new List<string>();

            while (beveragesNotFound)
            {
                try
                {
                    var response = await client.GetAsync(uri);

                    var result = JsonConvert.DeserializeObject<List<StoreBeverageSearchResult>>(await response.Content.ReadAsStringAsync());

                    StoreBeverageSearchResult storeBeverageSearchResult = result.Where(S => S.SiteId == siteId).FirstOrDefault();

                    //Handles the event of a store not being present in the JSON response from the server
                    if (storeBeverageSearchResult == null)
                    {
                        return null;
                    }

                    foreach (var beverage in storeBeverageSearchResult.Products)
                    {
                        beveragesInStore.Add(beverage.ProductId);
                    }

                    beveragesNotFound = false;
                }
                catch
                {
                    //Catches HTTP Exceptions
                }
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
