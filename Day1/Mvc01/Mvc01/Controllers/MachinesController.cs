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
            if (machine.IsPowerOn)
            {
                machine.AcceptsCoin(amount);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CancelCoin()
        {
            machine.ResetAmount();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PowerMachine(bool isPowerOn)
        {
            if (isPowerOn)
            {
                machine.PowerOff();
                machine.ResetAmount();
            }
            else
            {
                if (!machine.IsOpened)
                {
                    machine.PowerOn();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult TakeMoney(bool isOpened)
        {
            if (isOpened)
            {
                machine.Close();
            }
            else
            {
                if (!machine.IsPowerOn)
                {
                    machine.Open();
                }
            }
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
    }
}