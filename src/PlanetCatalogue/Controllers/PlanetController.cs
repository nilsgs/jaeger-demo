using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanetCatalogue.Models;
using PlanetCatalogue.Services;

namespace PlanetCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly PlanetContext _db;
        private readonly SwapiService _swapiService;

        public PlanetController(PlanetContext db, SwapiService swapiService)
        {
            _db = db;
            _swapiService = swapiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> Get()
        {
            var planets = await _db.Planets.ToListAsync();

            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<dynamic>> Get(int id)
        {
            Thread.Sleep(5000);

            var planet = await _db.Planets.FirstOrDefaultAsync(x => x.Id == id);

            if (planet == null)
                return NotFound();

            var extraInfo = await _swapiService.SearchPlanet(planet.Name);
            planet.Extra = extraInfo.FirstOrDefault();

            return Ok(planet);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
