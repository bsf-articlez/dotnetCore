using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
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
        //private static Machine machine = new Machine();
        private static List<Machine> machines = new List<Machine>
        {
            new Machine(1, new[] { 5m, 10m }),
            new Machine(2, new[] { 1m, 10m }),
            new Machine(3),
        };

        private readonly IEnumerable<ILog> logs;

        public MachinesController(IEnumerable<ILog> logs)
        {
            this.logs = logs;
        }

        // /machines/index/3
        public IActionResult Index(int? id)
        {
            if (id == null) id = 1;

            var machine = machines.SingleOrDefault(x => x.Id == id);

            if (machine == null) return NotFound();

            ViewBag.MachineList = new SelectList(machines, nameof(machine.Id), nameof(machine.Id), id);

            return View(machine);
        }

        public async Task<IActionResult> InsertCoin(int id, decimal amount, string color)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);

            try
            {
                machine.AcceptsCoin(amount);

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
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.CancelBuying();
            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult TogglePower(int id)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.TogglePower();
            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult ToggleLid(int id)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.ToggleLid();
            return RedirectToAction(nameof(Index), new { id });
        }
    }
}