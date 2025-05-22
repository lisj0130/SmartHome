using Backend.Models;
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
        private readonly SmartHomeContext _context;

        public APIController(IHubContext<SmartHomeHub> hubContext, SmartHomeContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }

        //Skicka till react att lampan ska t�ndas
        [HttpPost("LightsOn/{id}")]
        public async Task<IActionResult> LightsOn(int id)
        {
            string lightId = $"Light{id}";

            // H�mta senaste loggen eller skapa ny
            var latestLog = _context.Logs.OrderByDescending(l => l.TimeStamp).FirstOrDefault();

            if (latestLog == null || (DateTime.UtcNow - latestLog.TimeStamp).TotalMinutes > 1)
            {
                latestLog = new Log();
                _context.Logs.Add(latestLog);
            }

            if (!latestLog.LightsOn.Contains(lightId))
                latestLog.LightsOn.Add(lightId);

            latestLog.TimeStamp = DateTime.UtcNow;
            _context.SaveChanges();
            await _hubContext.Clients.All.SendAsync("TurnOnLight", id, 1);

            return Ok(new { status = "Lampan �r t�nd", id = id });
        }

        //Skicka till react att lampan ska sl�ckas
        [HttpPost("LightsOff/{id}")]
        public async Task<IActionResult> LightsOff(int id)
        {
            string lightId = $"Light{id}";

            // H�mta senaste logg eller skapa en ny om det g�tt f�r l�ng tid
            var latestLog = _context.Logs
                .OrderByDescending(l => l.TimeStamp)
                .FirstOrDefault();

            if (latestLog == null || (DateTime.UtcNow - latestLog.TimeStamp).TotalMinutes > 1)
            {
                latestLog = new Log();
                _context.Logs.Add(latestLog);
            }

            // Ta bort lampan om den �r t�nd
            if (latestLog.LightsOn.Contains(lightId))
                latestLog.LightsOn.Remove(lightId);

            latestLog.TimeStamp = DateTime.UtcNow;
            _context.SaveChanges();

            await _hubContext.Clients.All.SendAsync("TurnOffLight", id, 0);

            return Ok(new { status = "Lampan �r sl�ckt", id = id });
        }
    }
}
