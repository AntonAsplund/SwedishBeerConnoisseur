using Newtonsoft.Json;
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
        public List<Beverage> RetrieveBeveragesList()
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

        public async Task<bool> AddStoresToDatabase()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            var uri = "https://api-extern.systembolaget.se/site/v1/site?" + queryString;
            

            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<StoreSearchResultModel>(await response.Content.ReadAsStringAsync());

                foreach (var store in result.Hits)
                {
                    Store newStore = CopyFromRawStoreToStoreEntity(store);
                    Store storeInDatabase = dbContext.Stores.Where(S => S.SiteId == store.SiteId).FirstOrDefault<Store>();
                    if (storeInDatabase == null)
                    {
                        dbContext.Stores.Add(newStore);
                        await dbContext.SaveChangesAsync();
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

        
    }
}
