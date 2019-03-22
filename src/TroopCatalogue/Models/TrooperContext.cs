using Microsoft.EntityFrameworkCore;

namespace TroopCatalogue.Models
{
    public class TrooperContext : DbContext
    {
        public TrooperContext(DbContextOptions<TrooperContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trooper>().HasData(
                new Trooper
                {
                    Id = 1,
                    Name = "Stormtrooper",
                    Image = "stromtrooper.png"
                },
                new Trooper
                {
                    Id = 2,
                    Name = "Death trooper",
                    Image = "deathtrooper.png"
                },
                new Trooper
                {
                    Id = 3,
                    Name = "Shadow trooper",
                    Image = "shadowtrooper.png"
                },
                new Trooper
                {
                    Id = 4,
                    Name = "Scout trooper",
                    Image = "scouttrooper.png"
                }
            );
        }

        public DbSet<Trooper> Troopers { get; set; }
    }
}
