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

        //Gör en algoritm för att generera inomhustemperatur och returnera den till vyn
        public IActionResult InsideTemp()
        {
            Random random = new Random();
            double temperature = Math.Round(18 + random.NextDouble() * 5, 1);

            var log = new Log
            {
                InsideTemp = temperature,
                OutsideTemp = 0, // sätts till 0 tills vi hämtar det
                LightsOn = new List<string>(),
                TimeStamp = DateTime.UtcNow
            };

            _context.Logs.Add(log);
            _context.SaveChanges();

            return Json(new { temperature });
        }



        //Skapa en algoritm som beräknar elförbrukningen. Ta antal lampor, inomhustemp och utomhustemp i beaktning.
        public IActionResult ElectricityConsumption() 
        {
            // Vad du har förbrukat / String
            return View();
        }

        //Hämta in en lista och visa tidigare loggar
        public IActionResult ShowPreviousLogs()
        {
            var logs = _context.Logs
                .OrderByDescending(l => l.TimeStamp)
                .Take(20)
                .ToList();

            return Json(logs);
        }
    }
}
