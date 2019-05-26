using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc01.Data;
using Mvc01.Models;
using System;
using System.IO;
using System.Linq;

namespace Mvc01.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDb db;
        private readonly IHostingEnvironment env;

        public ProductsController(AppDb db, IHostingEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            var items = db.Products.ToList();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product item, IFormFile[] pics) // create object --> assign properties from request data --> validation in ModelState
        {
            if (db.Products.Any(x => x.Name == item.Name))
                ModelState.AddModelError(nameof(Product.Name), "Duplicate name.");

            if (ModelState.IsValid)
            {
                foreach (var pic in pics)
                {
                    string fileName = Path.GetRandomFileName() + Path.GetExtension(pic.FileName);
                    string filePath = Path.Combine(env.ContentRootPath, "Files", fileName);

                    using (FileStream fs = new FileStream(filePath, FileMode.CreateNew))
                    {
                        pic.CopyTo(fs);
                    }

                    ProductPicture productPicture = new ProductPicture
                    {
                        Description = "",
                        Url = fileName,
                    };

                    item.Pictures.Add(productPicture);
                }

                item.CreateDate = DateTime.UtcNow.AddHours(7);

                db.Add(item); // db.Products.Add(product); // in memory
                int rowAffected = db.SaveChanges(); // create SQL, execute at server-side.
                TempData["NewId"] = item.Id;

                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }
    }
}