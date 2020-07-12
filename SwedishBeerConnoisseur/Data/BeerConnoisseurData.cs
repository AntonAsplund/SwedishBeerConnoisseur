using SwedishBeerConnoisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Data
{
    public class BeerConnoisseurData : IBeerConnoisseurData
    {
        private readonly BeerConnoisseurDbContext dbContext;
        public BeerConnoisseurData(BeerConnoisseurDbContext beerConnoisseurDbContext)
        {
            dbContext = beerConnoisseurDbContext;
        }
        public bool AddBeverageToDatabase(Beverage beverage)
        {
            Beverage beverageInDatabase = dbContext.Beverages.Where(bev => bev.BeverageId == beverage.BeverageId).FirstOrDefault<Beverage>();
            if (beverageInDatabase != null)
            {
                beverageInDatabase.Price = beverage.Price;
                if (beverageInDatabase.OldHighPrice < beverage.Price)
                {
                    beverageInDatabase.OldHighPrice = beverage.Price;
                }
            }
            else 
            {
                dbContext.Beverages.Add(beverage);

            }

            try
            {
                dbContext.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}
