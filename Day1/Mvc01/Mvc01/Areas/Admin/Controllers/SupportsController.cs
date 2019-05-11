using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Mvc01.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}