using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    public class Beverage
    {
        public int BeverageId { get; set; }
        public int ProductNumber { get; set; }
        public string ProductNameBold { get; set; }
        public string ProductNameThin { get; set; }
        public string Category { get; set; }
        public int ProductNumberShort { get; set; }
        public bool IsKosher { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsEthical { get; set; }
        public int Volume { get; set; }
        public decimal Price { get; set; }
        public decimal OldHighPrice { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public string Style { get; set; }
        public string Usage { get; set; }
        public decimal RecycleFee { get; set; }
        public decimal Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public decimal RateBRating { get; set; }
        public int NumberOfRateBRatings { get; set; }

    }
}
