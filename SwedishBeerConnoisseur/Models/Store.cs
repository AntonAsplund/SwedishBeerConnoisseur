using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    /// <summary>
    /// Holds the information about a location and is the model for the SQL server Store entity
    /// </summary>
    public class Store
    {
        public Store()
        {
            BeveragesInstore = new List<BeveragesInStore>();
        }
        //Internal Id reference
        public int StoreId { get; set; }
        public string SiteId { get; set; }
        public string Alias { get; set; }
        public string Address { get; set; }
        public string DisplayName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public bool IsStore { get; set; }
        public bool IsAgent { get; set; }
        public bool IsActiveForAgentOrder { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Depot { get; set; }
        public string Name { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public virtual ICollection<BeveragesInStore> BeveragesInstore { get; set; }
    }
}
