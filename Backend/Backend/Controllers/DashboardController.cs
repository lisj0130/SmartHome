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

        //Skicka anrop till react-projektet med indikation om vilken lampa som ska t�ndas. 1 f�r t�nda + id
        public IActionResult LightsOn(int id) { }

        //Skicka anrop till react-projektet med indikation om vilken lampa som ska sl�ckas. 0 f�r sl�cka + id
        public IActionResult LightsOff(int id) { }

        //G�r en algoritm f�r att generera inomhustemperatur och returnera den till vyn
        public IActionResult InsideTemp() { }

        //H�mta temperaturen via web api och returnera den till vyn
        public IActionResult OutsideTemp() { }

        //Skapa en algoritm som ber�knar elf�rbrukningen. Ta antal lampor, inomhustemp och utomhustemp i beaktning.
        public IActionResult ElectricityConsumption() 
        {
            // Du f�rburkar just nu s�h�r mycket (return string)
        }
    }
}
