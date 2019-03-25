using System.Collections.Generic;

namespace Frontend.Models
{
    public class PlanetIndexViewModel
    {
        public IEnumerable<dynamic> Planets { get; set; }
    }

    public class TroopIndexViewModel
    {
        public IEnumerable<dynamic> Troops { get; set; }
    }
}
