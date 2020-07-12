using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SwedishBeerConnoisseur.Controllers
{
    public class ViewBeveragesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}