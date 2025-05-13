using System.Diagnostics;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

// Test V
namespace Backend.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult LightsOn(int id) { }

        public IActionResult LightsOff(int id) { }

        public IActionResult InsideTemp() { }

        public IActionResult OutsideTemp() { }

        public IActionResult ElectricityConsumption() { }
    }
}
