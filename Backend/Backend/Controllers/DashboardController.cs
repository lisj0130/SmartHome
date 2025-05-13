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

        //Skicka anrop till react-projektet med indikation om vilken lampa som ska t�ndas. 1 f�r t�nda + id
        public IActionResult LightsOn(int id) { }

        //Skicka anrop till react-projektet med indikation om vilken lampa som ska sl�ckas. 0 f�r sl�cka + id
        public IActionResult LightsOff(int id) { }

        //G�r en algoritm f�r att generera inomhustemperatur och returnera den till vyn
        public IActionResult InsideTemp() { }

        //H�mta temperaturen via web api och returnera den till vyn
        public async Task<IActionResult> OutsideTemp() 
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
