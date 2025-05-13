using System.Diagnostics;
using Backend.Models;
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
        public IActionResult OutsideTemp() { }

        //Skapa en algoritm som beräknar elförbrukningen. Ta antal lampor, inomhustemp och utomhustemp i beaktning.
        public IActionResult ElectricityConsumption() 
        {
            // Du förburkar just nu såhär mycket (return string)
        }
    }
}
