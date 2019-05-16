using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mvc01.Models;
using System.Collections.Generic;
using System.Linq;
using static Mvc01.Models.Constants;

namespace Mvc01.Controllers
{
    public class MachinesController : Controller
    {
        //private static Machine machine = new Machine();
        private static List<Machine> machines = new List<Machine>
        {
            new Machine(1){
                Coins = new List<Coin>
                {
                    Machine.SetCoin(Coins.TwentyFiveSatang, false),
                    Machine.SetCoin(Coins.FiftyFiveSatang, false),
                    Machine.SetCoin(Coins.One, false),
                    Machine.SetCoin(Coins.Two, true),
                    Machine.SetCoin(Coins.Five, true),
                    Machine.SetCoin(Coins.Ten, true),
                }
            },
            new Machine(2, new List<Coin>
                {
                    Machine.SetCoin(Coins.TwentyFiveSatang, false),
                    Machine.SetCoin(Coins.FiftyFiveSatang, false),
                    Machine.SetCoin(Coins.One, true),
                    Machine.SetCoin(Coins.Two, false),
                    Machine.SetCoin(Coins.Five, true),
                    Machine.SetCoin(Coins.Ten, true),
                }),
            new Machine(3,new List<Coin>
                {
                    Machine.SetCoin(Coins.TwentyFiveSatang, false),
                    Machine.SetCoin(Coins.FiftyFiveSatang, false),
                    Machine.SetCoin(Coins.One, true),
                    Machine.SetCoin(Coins.Two, true),
                    Machine.SetCoin(Coins.Five, false),
                    Machine.SetCoin(Coins.Ten, true),
                }),
        };

        // /machines/index/3
        public IActionResult Index(int? id)
        {
            if (id == null) id = 1; //return Content("NULL");

            var machine = machines.SingleOrDefault(x => x.Id == id);

            if (machine == null) return NotFound();

            ViewBag.MachineList = new SelectList(machines, nameof(machine.Id), nameof(machine.Id), id);
            ViewBag.Coins = machine.Coins;
            return View(machine);
        }

        public IActionResult InsertCoin(int id, decimal amount, string color)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.AcceptsCoin(amount);
            return RedirectToAction(nameof(Index), new
            {
                id
            });
        }

        public IActionResult CancelBuying(int id)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.CancelBuying();
            return RedirectToAction(nameof(Index), new { id });
        }

        public IActionResult TogglePower(int id, decimal[] coinIsAccepts)
        {
            var machine = machines.SingleOrDefault(x => x.Id == id);
            machine.SettingCoinsAccept(coinIsAccepts);
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