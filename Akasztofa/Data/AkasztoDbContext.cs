
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AkasztoDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public AkasztoDbContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FormAkasztofa;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
