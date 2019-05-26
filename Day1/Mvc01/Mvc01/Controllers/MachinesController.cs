using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Mvc01.Data;
using Mvc01.Models;
using Mvc01.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc01.Controllers
{
    public class MachinesController : Controller
    {
        private readonly IEnumerable<ILog> logs;
        private readonly AppDb db;

        public MachinesController(IEnumerable<ILog> logs, AppDb db)
        {
            this.logs = logs;
            this.db = db;
        }

        // /machines/index/3
        public IActionResult Index(int? id)
        {
            if (id == null) id = 1;

            var machine = db.Machines.Find(id);

            if (machine == null) return NotFound();

            ViewBag.MachineList = new SelectList(db.Machines, nameof(machine.Id), nameof(machine.Id), id);

            return View(machine);
        }

        public async Task<IActionResult> InsertCoin(int id, decimal amount, string color)
        {
            var machine = db.Machines.Find(id);

            try
            {
                machine.AcceptsCoin(amount);
                db.SaveChanges();

                foreach (var log in logs)
                {
                    if (log is Log)
                    {
                        await log.SendAsync($"{amount} coin has accepted.");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult CancelBuying(int id)
        {
            var machine = db.Machines.Find(id);
            machine.CancelBuying();
            db.SaveChanges();
            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult TogglePower(int id)
        {
            var machine = db.Machines.Find(id);
            machine.TogglePower();
            db.SaveChanges();
            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult ToggleLid(int id)
        {
            var machine = db.Machines.Find(id);
            machine.ToggleLid();
            db.SaveChanges();
            return RedirectToAction(nameof(Index), new { id });
        }
    }
}