using SwedishBeerConnoisseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Data
{
    public interface IBeerConnoisseurData
    {
        public bool AddBeverageToDatabase(Beverage beverage);
    }
}
