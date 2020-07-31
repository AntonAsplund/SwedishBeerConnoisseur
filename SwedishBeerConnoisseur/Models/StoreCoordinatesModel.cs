using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    /// <summary>
    /// Holds the coordinates in longtitude and latitude for a store location
    /// </summary>
    public class StoreCoordinatesModel
    {
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
    }
}
