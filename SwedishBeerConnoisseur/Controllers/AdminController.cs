using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwedishBeerConnoisseur.Data;
using SwedishBeerConnoisseur.Models;

namespace SwedishBeerConnoisseur.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBeerConnoisseurData beerData;

        public AdminController(IBeerConnoisseurData beerData)
        {
            this.beerData = beerData;
        }
        public IActionResult Index()
        {
            return View(beerData.RetrieveBeveragesList());
        }

        public async Task<IActionResult> UpdateBeverages()
        {

            TempData["BeveragesRequestSuccess"] = await MakeRequestBeverages();

            return RedirectToAction("Index");
        }

        #region MoveToBeerConnoisseurData

        /// <summary>
        /// Updates the database with the new data from "https://api-extern.systembolaget.se"
        /// </summary>
        public async Task<bool> MakeRequestBeverages()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "cba4b139e74b49cf9aae18c4d7761311");

            var uri = "https://api-extern.systembolaget.se/product/v1/product?" + queryString;

            try
            {
                var response = await client.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Beverage>>(await response.Content.ReadAsStringAsync());

                foreach (var beverage in result)
                {
                    if (beverage.Category == "Öl")
                    {
                        bool resultOfOperation = await beerData.AddBeverageToDatabase(beverage);
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        #endregion

        public async Task<IActionResult> UpdateStores()
        {
            await beerData.AddStoresToDatabase();

            return RedirectToAction("Index");
        }

    }
}