using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroopCatalogue.Models;

namespace TroopCatalogue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrooperController : ControllerBase
    {
        private readonly TrooperContext _db;

        public TrooperController(TrooperContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trooper>>> Get()
        {
            var troopers = await _db.Troopers.ToListAsync();

            return Ok(troopers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trooper>> Get(int id)
        {
            if(id == 2)
                throw new Exception("Admiral Ackbar was here!!");

            var trooper = await _db.Troopers.FirstOrDefaultAsync(x => x.Id == id);

            if (trooper == null)
                return NotFound();

            return Ok(trooper);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
