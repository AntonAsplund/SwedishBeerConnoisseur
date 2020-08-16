using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    public class BeverageSearchViewModel
    {
        public List<Beverage> Beverages { get; set; }
        public Store Store { get; set; }
    }
}
