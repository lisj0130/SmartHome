using ChatAppBackend.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class APIController : ControllerBase
    {
        private readonly IHubContext<SmartHomeHub> _hubContext;

        public APIController(IHubContext<SmartHomeHub> hubContext)
        {
            _hubContext = hubContext;
        }

        //Skicka till react att lampan ska tändas
        [HttpPost("LightsOn/{id}")]
        public async Task<IActionResult> LightsOn(int id)
        {
            await _hubContext.Clients.All.SendAsync("TurnOnLight", id, 1);

            return Ok(new { status = "Lampan är tänd", id = id });
        }

        //Skicka till react att lampan ska släckas
        [HttpPost("LightsOff/{id}")]
        public async Task<IActionResult> LightsOff(int id)
        {
            await _hubContext.Clients.All.SendAsync("TurnOffLight", id, 0);

            return Ok(new { status = "Lampan är släckt", id = id });
        }

        //Hämta temperaturen via web api och returnera den till vyn
        [HttpGet("OutsideTemp")]
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
    }
}
