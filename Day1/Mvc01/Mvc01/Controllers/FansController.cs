using Microsoft.AspNetCore.Mvc;
using Mvc01.Models;

namespace Mvc01.Controllers
{
    public class FansController : Controller
    {
        private static Fan fan = new Fan();
        public IActionResult Index()
        {
            return View(fan);
        }

        public IActionResult PushNumber(int number)
        {
            fan.AcceptNumber(number);
            if (fan.Number > 0)
            {
                if (fan.IsPlugin)
                {
                    fan.PowerOn();
                }
            }
            else
            {
                fan.PowerOff();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ControlShook(bool isShook)
        {
            if (isShook)
            {
                fan.AcceptPush();
            }
            else
            {
                fan.AcceptPull();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ControlPlug(bool isPlugin)
        {
            if (isPlugin)
            {
                fan.Plugin();
                if (fan.Number > 0)
                {
                    fan.PowerOn();
                }
            }
            else
            {
                fan.UnPlug();
                fan.PowerOff();
            }
            return RedirectToAction("Index");
        }
    }
}