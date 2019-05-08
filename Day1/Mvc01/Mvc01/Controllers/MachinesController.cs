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
            return RedirectToAction("Index");
        }

        public IActionResult CancelCoin()
        {
            machine.ResetAmount();
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
    }
}