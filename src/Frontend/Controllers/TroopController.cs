using System.Threading.Tasks;
using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class TroopController : Controller
    {
        private readonly TroopService _service;

        public TroopController(TroopService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var troops = await _service.GetAllTroops();

            return View(new TroopIndexViewModel
            {
                Troops = troops
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            var trooper = await _service.GetTrooper(id);

            return View(trooper);
        }
    }
}