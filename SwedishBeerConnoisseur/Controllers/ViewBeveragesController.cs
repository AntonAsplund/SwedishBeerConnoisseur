using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwedishBeerConnoisseur.Data;
using SwedishBeerConnoisseur.Models;

namespace SwedishBeerConnoisseur.Controllers
{
    public class ViewBeveragesController : Controller
    {
        private readonly IBeerConnoisseurData beerData;

        public ViewBeveragesController(IBeerConnoisseurData beerData)
        {
            this.beerData = beerData;
        }


        public IActionResult Beverages()
        {
            return View();
        }
        /// <summary>
        /// Retrieves a list of beverages by the critera that a user has choosen
        /// </summary>
        /// <param name="storeCitySearchString"></param>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Beverages(string storeCitySearchString )
        {

            List<Store> stores = await beerData.FindStoresAndAgentsByCity(storeCitySearchString);
            List<Beverage> beverages = new List<Beverage>();

            if (stores == null)
            {
                //If no store is selected then it shows all beverages in the list
                beverages = await beerData.RetrieveBeveragesList();
            }
            else
            {
                //Goes through all the stores in specified town to retrieve the list
                beverages.AddRange(beerData.RetrieveBeveragesInStores(stores));
            }



            return View(new BeverageSearchViewModel { Beverages = beverages});

        }



        public IActionResult FindStores()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FindStores(string city)
        {
            List<Store> possibleStores = await beerData.FindStoresAndAgentsByCity(city);
            List<Store> stores = new List<Store>();

            if (possibleStores != null)
            {
                for (int i = 0; i < possibleStores.Count; i++)
                {
                    if (possibleStores[i].IsStore)
                    {
                        stores.Add(possibleStores[i]);
                    }
                }

                if (stores != null)
                {
                    return RedirectToAction("RetrieveFromLocation", stores);
                }
            }

            TempData["citySearch"] = "No city was found at that location";
            return View(city);
        }

        public IActionResult RetrieveFromLocation(List<Store> stores)
        {
            return View(stores);
        }

        public IActionResult RetrieveBeersFromLocation(Store store)
        {
            return View();
        }

    }
}