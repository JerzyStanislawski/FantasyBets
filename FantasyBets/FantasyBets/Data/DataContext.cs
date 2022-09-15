using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public class DataContext : DbContext
    {
        public static readonly string FantasyDb = nameof(FantasyDb).ToLower();

        public DbSet<Season>? Seasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Database.EnsureCreated();
        }
    }
}
