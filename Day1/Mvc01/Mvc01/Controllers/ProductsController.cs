using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mvc01.Data;
using Mvc01.Models;

namespace Mvc01.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDb db;
        public ProductsController(AppDb db) => this.db = db;
        public IActionResult Index()
        {
            var items = db.Products.ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Create(string name, decimal price)
        //{
        //    Product product = new Product
        //    {
        //        Name = name,
        //        Price = price,
        //        CreateDate = DateTime.UtcNow.AddHours(7)
        //    };

        //    db.Add(product); // db.Products.Add(product); // in memory
        //    int rowAffected = db.SaveChanges(); // create SQL, execute at server-side.
        //    TempData["NewId"] = product.Id;

        //    return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        public IActionResult Create(Product product) // create object --> assign properties from request data --> validation in ModelState
        {
            if (db.Products.Any(x => x.Name == product.Name))
                ModelState.AddModelError(nameof(Product.Name), "Duplicate name.");

            if (ModelState.IsValid)
            {
                product.CreateDate = DateTime.UtcNow.AddHours(7);

                db.Add(product); // db.Products.Add(product); // in memory
                int rowAffected = db.SaveChanges(); // create SQL, execute at server-side.
                TempData["NewId"] = product.Id;

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
    }
}