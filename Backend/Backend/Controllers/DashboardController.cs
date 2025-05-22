using System.Diagnostics;
using Backend.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Backend.Controllers
{
    public class DashboardController : Controller
    {
        private readonly SmartHomeContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(SmartHomeContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        //Visa vyn
        public async Task<IActionResult> Dashboard()
        {
            string apiKey = "141d0705b70227498aac566b4b862bdb";
            string city = "Ume�";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={apiKey}&units=metric";

            double outsideTemp = 0;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url);
                    JObject weatherData = JObject.Parse(response);
                    outsideTemp = (double)weatherData["main"]["temp"];
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("Fel vid h�mtning av temperatur: " + e.Message);
                }
            }

            var newLog = new Log
            {
                InsideTemp = InsideTemperature(),
                OutsideTemp = outsideTemp,
                TimeStamp = DateTime.UtcNow
            };

            _context.Logs.Add(newLog);
            _context.SaveChanges();

            var logs = _context.Logs.OrderByDescending(l => l.TimeStamp).ToList();

            return View(logs); // Skickar listan av loggar till vyn
        }

        private double InsideTemperature()
        {
            Random random = new Random();
            double insideTemperature = Math.Round(18 + random.NextDouble() * 5, 1);

            return insideTemperature;
        }

        //Skapa en algoritm som ber�knar elf�rbrukningen
        private Dictionary<string, double> ElectricityConsumption()
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

                    totalConsumption[lamp] += duration * 0.04; // 40 watt = 0.04 kWh
                }
            }

            return totalConsumption;
        }

        //H�mta in en lista och visa tidigare loggar (5st)
        public IActionResult ShowPreviousLogs()
        {
            var logs = _context.Logs
                .OrderByDescending(l => l.TimeStamp)
                .Take(5)
                .ToList();

            return Json(logs);
        }

        /*
        public async Task<IActionResult> OutsideTemperature()
        {
            string apiKey = "141d0705b70227498aac566b4b862bdb";
            string city = "Ume�";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetStringAsync(url);

                    JObject weatherData = JObject.Parse(response);
                    double temperature = (double)weatherData["main"]["temp"];

                    return Json(new { temperature = temperature, city = city });
                }
                catch (HttpRequestException e)
                {
                    return StatusCode(500, $"Fel vid h�mtning av temperatur: {e.Message}");
                }
            }
        } */

    }
}
