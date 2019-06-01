using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthwindMvc.Models;
using NorthwindMvc.Northwind.Models;

namespace NorthwindMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDb db;

        public HomeController(AppDb db) => this.db = db;
        public IActionResult Index()
        {
            IEnumerable<vw_CategorySalesFor1997> items = db.vw_CategorySaleFor1997.AsNoTracking().ToList();
            return View(items);
        }

        public IActionResult Sproc()
        {
            ViewBag.CategoryList = new SelectList(db.Categories, nameof(Categories.CategoryName), nameof(Categories.CategoryName));

            var year = new[] { 1996, 1997, 1998 };
            ViewBag.YearList = new SelectList(year);

            var items = db.sp_SalesByCategories("Seafood", 1997);
            return View(items);
        }

        public IActionResult SprocV1(string category, int year)
        {
            var items = db.sp_SalesByCategories(category, year);
            return Json(items);
        }

        public IActionResult SprocV2(string category, int year)
        {
            var items = db.sp_SalesByCategories(category, year);
            return PartialView(items);
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
