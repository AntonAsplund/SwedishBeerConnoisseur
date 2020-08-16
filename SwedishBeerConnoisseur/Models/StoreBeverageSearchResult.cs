using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    public class StoreBeverageSearchResult
    {
        public string SiteId { get; set; }
        public List<Beverage> Products { get; set; }
    }
}
