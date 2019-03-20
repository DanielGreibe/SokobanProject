using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SokobanProject.Models;

namespace SokobanProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Game(){
            ViewData["Message"] = "Your application Game page.";

            return View();
        }

        public IActionResult LevelSelector(){
            ViewData["Message"] = "Your Level Selector page.";

            return View();
        }

        public IActionResult Settings(){
            ViewData["Message"] = "Your Settings page.";

            return View();
        }

        public IActionResult Privacy(){
            ViewData["Message"] = "Your Privacy page.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(){
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
