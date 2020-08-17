using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    public class BeveragesInStore
    {
        public int BeverageId { get; set; }
        public Beverage Beverage { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
