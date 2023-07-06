using Microsoft.EntityFrameworkCore;

namespace ElectronicVinylCollection.Entities
{
    public class VinylDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=inylDb;Trusted_Connection=True";
        public DbSet<User> Users { get; set; }
        public DbSet<Media> Medias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
