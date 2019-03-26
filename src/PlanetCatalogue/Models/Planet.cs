using System.ComponentModel.DataAnnotations.Schema;

namespace PlanetCatalogue.Models
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public dynamic Extra { get; set; }
    }
}
