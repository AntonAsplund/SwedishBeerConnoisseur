using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwedishBeerConnoisseur.Models
{
    /// <summary>
    /// Model to receive the result of a users serach for a stores by a given string query
    /// </summary>
    public class StoreSearchResultModel
    {
        public List<StoreIndividualRawModel> Hits { get; set; }
    }
}
