using System.Threading.Tasks;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class PlanetController : Controller
    {
        private readonly PlanetService _service;

        public PlanetController(PlanetService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var planets = await _service.GetAllPlanets();

            return View(new PlanetIndexViewModel
            {
                Planets = planets
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var planet = await _service.GetPlanet(id);

            return View(planet);
        }
    }
}