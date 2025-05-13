using System.Diagnostics;
using Backend.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

// Test V
namespace Backend.Controllers
{
    public class DashboardController : Controller
    {

        //Visa vyn
        public IActionResult Dashboard()
        {
            return View();
        }

        //Skicka anrop till react-projektet med indikation om vilken lampa som ska tändas. 1 för tända + id
        public IActionResult LightsOn(int id) { }

        //Skicka anrop till react-projektet med indikation om vilken lampa som ska släckas. 0 för släcka + id
        public IActionResult LightsOff(int id) { }

        //Gör en algoritm för att generera inomhustemperatur och returnera den till vyn
        public IActionResult InsideTemp() { }

        //Hämta temperaturen via web api och returnera den till vyn
        public async Task<IActionResult> OutsideTemp() 
        {
            string apiKey = "141d0705b70227498aac566b4b862bdb";
            string city = "Umeå";
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
                    return StatusCode(500, $"Fel vid hämtning av temperatur: {e.Message}");
                }
            }

        }

        //Skapa en algoritm som beräknar elförbrukningen. Ta antal lampor, inomhustemp och utomhustemp i beaktning.
        public IActionResult ElectricityConsumption() 
        {
            // Vad du har förbrukat / String
        }

        //Hämta in en lista och visa tidigare loggar
        public IActionResult ShowPreviousLogs() { }
    }
}
