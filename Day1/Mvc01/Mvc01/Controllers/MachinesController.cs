﻿using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;
using System.Collections.Generic;
using System.Linq;

namespace Mvc01.Controllers
{
    public class MachinesController : Controller
    {
        //private static Machine machine = new Machine();
        private static List<Machine> machines = new List<Machine>()
        {
            new Machine(1),
            new Machine(2),
            new Machine(3),
            new Machine(0),
        };
        // /machines/index/3
        public IActionResult Index(int? id)
        {
            if (id == null) id = 1; //return Content("NULL");

            var machine = machines.SingleOrDefault(x => x.Id == id);

            if (machine == null) return NotFound();

            return View(machine);
        }

        public IActionResult InsertCoin(int id, decimal amount, string color)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.AcceptsCoin(amount);
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