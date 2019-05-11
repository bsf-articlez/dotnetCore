using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;

namespace Mvc01.Controllers
{
    public class MachinesController : Controller
    {
        private static Machine machine = new Machine();
        public IActionResult Index()
        {
            return View(machine);
        }

        public IActionResult InsertCoin(decimal amount)
        {
            machine.AcceptsCoin(amount);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CancelBuying()
        {
            machine.CancelBuying();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TogglePower()
        {
            machine.TogglePower();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ToggleLid()
        {
            machine.ToggleLid();
            return RedirectToAction(nameof(Index));
        }
    }
}