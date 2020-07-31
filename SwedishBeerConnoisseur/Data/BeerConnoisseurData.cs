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

        public List<Beverage> RetrieveBeveragesList()
        {
            return dbContext.Beverages.ToList<Beverage>();
        }

        public async Task<List<Store>> FindStoresByCity(string city)
        {

            var client = new HttpClient();
            var queryString = city;

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cba4b139e74b49cf9aae18c4d7761311");

            var uri = "https://api-extern.systembolaget.se/site/v1/site/search?" + queryString;

            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Store>>(await response.Content.ReadAsStringAsync());

                foreach (var beverage in result)
                {
                    
                }
            }
            catch
            {
                return null;
            }


            return 
        }
    }
}
