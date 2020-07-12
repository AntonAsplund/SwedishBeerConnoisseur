using SwedishBeerConnoisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Data
{
    public interface IBeerConnoisseurData
    {
        public Task<bool> AddBeverageToDatabase(Beverage beverage);
        public List<Beverage> RetrieveBeveragesList();
    }
}
