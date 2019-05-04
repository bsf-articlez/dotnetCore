using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;

namespace Mvc01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.MyName = "Sumet";
            ViewData["Country"] = "Thailand"; //"<script>alert('Hi')</script>";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
