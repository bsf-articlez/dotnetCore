using Microsoft.AspNetCore.Mvc;
using NorthwindMvc.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindMvc.ViewComponents
{
    public class SalesByCategoryChartViewComponent : ViewComponent
    {
        private readonly AppDb db;

        public SalesByCategoryChartViewComponent(AppDb db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke(string category, int year)
        {
            var items = db.sp_SalesByCategories(category, year);

            var names = string.Join(",",
                        items.Select(x => "'" + x.ProductName.Replace("'", "") + "'")
                        .ToArray());
            ViewBag.ProductNameList = $"[{names}]";

            var totals = string.Join(",",
                        items.Select(x => x.Total).ToArray());
            ViewBag.TotalList = $"[{totals}]";

            return View(items);
        }
    }
}
