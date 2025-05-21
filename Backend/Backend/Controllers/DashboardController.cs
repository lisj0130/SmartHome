using System.Diagnostics;
using Backend.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SmartHomeContext _context;

        public DashboardController(SmartHomeContext context)
        {
            _context = context;
        }

        //Visa vyn
        public IActionResult Dashboard()
        {
            return View();
        }

        //Skapa en algoritm som beräknar elförbrukningen
        public IActionResult ElectricityConsumption()
        {
            var logs = _context.Logs
                .OrderBy(l => l.TimeStamp)
                .ToList();

            var totalConsumption = new Dictionary<string, double>();

            for (int i = 0; i < logs.Count - 1; i++)
            {
                var currentLog = logs[i];
                var nextLog = logs[i + 1];

                var duration = (nextLog.TimeStamp - currentLog.TimeStamp).TotalHours;

                var lampsStillOn = currentLog.LightsOn.Intersect(nextLog.LightsOn);

                foreach (var lamp in lampsStillOn)
                {
                    if (!totalConsumption.ContainsKey(lamp))
                        totalConsumption[lamp] = 0;

                    totalConsumption[lamp] += duration * 0.04; // 40 watt = 0.04 kW
                }
            }

            return Json(totalConsumption);
        }

        //Hämta in en lista och visa tidigare loggar (5st)
        public IActionResult ShowPreviousLogs()
        {
            var logs = _context.Logs
                .OrderByDescending(l => l.TimeStamp)
                .Take(5)
                .ToList();

            return Json(logs);
        }
    }
}
