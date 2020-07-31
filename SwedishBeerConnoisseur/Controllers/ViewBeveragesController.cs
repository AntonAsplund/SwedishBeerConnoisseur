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
        public IActionResult FindStores(string city)
        {
            List<Store> stores = beerData.FindStoresByCity(city);

            if (stores == null)
            {
                return View(city);
            }

            return RedirectToAction("RetrieveFromLocation", stores);
        }

        public IActionResult RetrieveFromLocation(Store store)
        {

            List<Beverage> beverages = beerData.RetrieveBeveragesList();

            return View();
        }
    }
}