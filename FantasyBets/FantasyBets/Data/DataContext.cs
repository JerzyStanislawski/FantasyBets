using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FantasyBets.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public static readonly string FantasyDb = nameof(FantasyDb).ToLower();

        public DbSet<Season>? Seasons { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Season>().HasMany(s => s.Rounds).WithOne(r => r.Season);
            modelBuilder.Entity<Round>().HasMany(r => r.Games).WithOne(g => g.Round);
            modelBuilder.Entity<Game>().HasOne(r => r.Home).WithMany(t => t.Games);
            modelBuilder.Entity<Game>().HasOne(r => r.Away).WithMany(t => t.Games);
        }
    }
}
