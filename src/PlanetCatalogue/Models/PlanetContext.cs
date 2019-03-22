using Microsoft.EntityFrameworkCore;

namespace PlanetCatalogue.Models
{
    public class PlanetContext : DbContext
    {
        public PlanetContext(DbContextOptions<PlanetContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Planet>().HasData(
                new Planet
                {
                    Id = 1,
                    Name = "Alderaan", 
                    Description = "Forests, mountains; home planet of the House of Organa.",
                    Image = "alderaan.png"
                },
                new Planet
                {
                    Id = 2,
                    Name = "Bespin",
                    Description = "A gas planet with a thin layer of habitable atmosphere.",
                    Image = "bespin.jpg"
                },
                new Planet
                {
                    Id = 3,
                    Name = "Coruscant",
                    Description = "Cosmopolitan urban world consisting of one planet-wide city.",
                    Image = "coruscant.png"
                },
                new Planet
                {
                    Id = 4,
                    Name = "Hoth",
                    Description = "Desolate ice planet",
                    Image = "hoth.jpg"
                },
                new Planet
                {
                    Id = 5,
                    Name = "Kashyyyk ",
                    Description = "Forest planet and home of the Wookiees",
                    Image = "kashyyyk.png"
                },
                new Planet
                {
                    Id = 6,
                    Name = "Mandalore",
                    Description = "Home of Boba Fett",
                    Image = "mandalore.png"
                }
            );
        }

        public DbSet<Planet> Planets { get; set; }
    }
}