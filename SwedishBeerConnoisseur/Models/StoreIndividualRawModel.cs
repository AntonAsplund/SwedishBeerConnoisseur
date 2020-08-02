using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{

    /// <summary>
    /// Model to receive the result of a store entity from "systembolaget" API.
    /// </summary>
    public class StoreIndividualRawModel
    {
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
        public StoreCoordinatesModel Position { get; set; }
    }
}
