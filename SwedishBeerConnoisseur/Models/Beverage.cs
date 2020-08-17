using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    public class Beverage
    {
        public Beverage()
        {
            BeveragesInStore = new List<BeveragesInStore>();
        }
        //Internal Id reference
        public int BeverageId { get; set; }
        public string ProductId { get; set; }
        public string ProductNumber { get; set; }
        public string ProductNameBold { get; set; }
        public string ProductNameThin { get; set; }
        public string Category { get; set; }
        public string ProductNumberShort { get; set; }
        public string ProducerName { get; set; }
        public string SupplierName { get; set; }
        public bool IsKosher { get; set; }
        public string BottleTextShort { get; set; }
        public string Seal { get; set; }
        public int RestrictedParcelQuantity { get; set; }
        public bool IsOrganic { get; set; }
        public bool IsEthical { get; set; }
        public string EthicalLabel { get; set; }
        public bool IsWebLaunch { get; set; }
        public string SellStartDate { get; set; }
        public bool IsCompletelyOutOfStock { get; set; }
        public bool IsTemporaryOutOfStock { get; set; }
        public decimal AlcoholPercentage { get; set; }
        public decimal Volume { get; set; }
        public decimal Price { get; set; }
        // To record the highest price the product has had.
        public decimal OldHighPrice { get; set; } 
        public string Country { get; set; }
        public string OriginLevel1 { get; set; }
        public string OriginLevel2 { get; set; }
        public string SubCategory { get; set; }
        public string Type { get; set; }
        public string Style { get; set; }
        public string AssortmentText { get; set; }
        public string BeverageDescriptionShort { get; set; }
        public string Usage { get; set; }
        public string Taste { get; set; }
        public string Assortment { get; set; }
        public decimal RecycleFee { get; set; }
        public decimal Rating { get; set; }
        public int NumberOfRatings { get; set; }
        //Ratebeer rating
        public decimal RateBRating { get; set; }
        //UnTappd rating
        public decimal RateURating { get; set; }
        public int NumberOfRateBRatings { get; set; }
        public bool IsNews { get; set; }
        public virtual ICollection<BeveragesInStore> BeveragesInStore { get; set; }

    }
}
