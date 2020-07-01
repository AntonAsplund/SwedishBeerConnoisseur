using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public int SiteId { get; set; }
        public string Adress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Alias { get; set; }
        public bool IsStore { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LongitudePosition { get; set; }
        public string LatitudePosition { get; set; }
        public string OpeningHoursToday { get; set; }
    }
}
