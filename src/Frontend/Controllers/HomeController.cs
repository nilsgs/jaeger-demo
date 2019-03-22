using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Frontend.Services;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly PlanetService _planetService;

        public HomeController(PlanetService planetService)
        {
            _planetService = planetService;
        }

        public async Task<IActionResult> Index()
        {
            var planets = await _planetService.GetAllPlanets();

            return View(new HomeViewModel
            {
                Planets = planets
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
