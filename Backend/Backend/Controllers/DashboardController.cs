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
        //Visa vyn
        public IActionResult Dashboard()
        {
            return View();
        }

        //G�r en algoritm f�r att generera inomhustemperatur och returnera den till vyn
        public IActionResult InsideTemp()
        {
            Random random = new Random();
            double temperature = Math.Round(18 + random.NextDouble() * 5, 1); 

            // Returnera temperaturen som JSON
            return Json(new { temperature });
        }


        //Skapa en algoritm som ber�knar elf�rbrukningen. Ta antal lampor, inomhustemp och utomhustemp i beaktning.
        public IActionResult ElectricityConsumption() 
        {
            // Vad du har f�rbrukat / String
        }

        //H�mta in en lista och visa tidigare loggar
        public IActionResult ShowPreviousLogs() { }
    }
}
