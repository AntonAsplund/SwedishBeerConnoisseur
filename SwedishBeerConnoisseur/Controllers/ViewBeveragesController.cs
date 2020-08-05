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
            return View(beerData.RetrieveBeveragesList());
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