using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc01.Data;
using Mvc01.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            //var items = db.Products.Include(x => x.Pictures).ToList();

            var items = db.Products.ToList();
            foreach (var item in items)
            {
                await db.Entry(item).Collection(x => x.Pictures).LoadAsync();
            }
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

        // GET: /products/{productId}/pictures/{pictureId}
        // pictureId starts from 1, 2, 3, ... for each product.
        [HttpGet("products/{productId}/pictures/{pictureSeq}")]
        public IActionResult Pictures(int productId, int pictureSeq)
        {
            var p = db.Products.Include(x => x.Pictures)
                      .SingleOrDefault(x => x.Id == productId);

            ProductPicture pic = p.Pictures.Skip(pictureSeq - 1).Take(1).SingleOrDefault();
            if (pic == null) return NotFound();

            var filePath = Path.Combine(env.ContentRootPath, "Files", pic.Url);

            return PhysicalFile(filePath, "image/jpeg");
        }

        public IActionResult Edit(int id)
        {
            return View(db.Products.Include(x => x.Pictures).SingleOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Product item, IFormFile[] pics)
        {
            //if (db.Products.Any(x => x.Name == item.Name))
            //    ModelState.AddModelError(nameof(Product.Name), "Duplicate name.");

            if (ModelState.IsValid)
            {
                db.Update(item);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }

        public IActionResult Details(int id)
        {
            return View(db.Products.Include(x => x.Pictures).SingleOrDefault(x => x.Id == id));
        }
    }
}