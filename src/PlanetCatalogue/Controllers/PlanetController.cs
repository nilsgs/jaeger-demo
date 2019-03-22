using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanetCatalogue.Models;

namespace PlanetCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly PlanetContext _db;

        public PlanetController(PlanetContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> Get()
        {
            var planets = await _db.Planets.ToListAsync();

            return Ok(planets);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> Get(int id)
        {
            var planet = await _db.Planets.FirstOrDefaultAsync(x => x.Id == id);

            if (planet == null)
                return NotFound();

            return Ok(planet);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
