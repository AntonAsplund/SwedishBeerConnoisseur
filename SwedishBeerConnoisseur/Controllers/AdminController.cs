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
        public async Task<IActionResult> Index()
        {
            return View(await beerData.RetrieveBeveragesList());
        }

        public async Task<IActionResult> UpdateBeverages()
        {

            TempData["BeveragesRequestSuccess"] = await beerData.MakeBeveragesRequest();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateStores()
        {
            TempData["UpdateStoresSucess"] = await beerData.AddStoresToDatabase();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateStoresAndStocks()
        {
            TempData["UpdateStoresSucess"] = await beerData.UpdateStoresAndStocks();

            return RedirectToAction("Index");
        }

    }
}